using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using TextAnalyzer.Interfaces;
using Willezone.Azure.WebJobs.Extensions.DependencyInjection;

namespace TextAnalyzer
{
	public static class TextAnalyzerFunction
	{
		[FunctionName("TextAnalyzerFunction")]
		public static async Task Run([ServiceBusTrigger("myqueue", Connection = "ServiceBusConnectionString")]string htmlText, ILogger log,
			[Inject]ILUISService ILUISService,
			[Inject]IQnAService IQnAService,
			[Inject]ITextAnalyticsService ITextAnalyticsService,
			[Inject]IQueueService IQueueService)
		{
			var method = "Main";
			log.LogInformation(string.Format("{0} - {1}", method, "IN"));

			if (string.IsNullOrWhiteSpace(htmlText))
				throw new ArgumentNullException("You need to provide a text to test!");
			var sanitizedText = HelperMethods.HtmlToPlainText(htmlText);

			log.LogInformation(string.Format("{0} - {1}", method, "Extracting information from LUIS."));
			var result = await ILUISService.ExtractEntitiesFromLUIS(sanitizedText);

			if (result == null)
			{
				log.LogError(string.Format("{0} - {1}", method, "LUIS Result returned null. Exiting."));
				return;
			}

			if (result.TopScoringIntent.Intent.Equals("FAQ"))
			{
				log.LogInformation(string.Format("{0} - {1}", method, "Getting FAQs Answer."));
				var response = IQnAService.CheckQnAMakerForResponse(sanitizedText);
				IQueueService.InsertAnswerIntoCRM(response);
			}
			else
			{
				log.LogInformation(string.Format("{0} - {1}", method, "Getting Keywords and Sentiment."));
				var response = ITextAnalyticsService.GetMetadataFromTextAnalytics(sanitizedText);
				IQueueService.InsertKeywordAndSentimentoIntoCRM(response);
			}
		}
	}
}
