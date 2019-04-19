using System;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using TextAnalyzer.Models;
using TextAnalyzer.Services;

namespace TextAnalyzer
{
	public static class TextAnalyzerFunction
	{
		[FunctionName("TextAnalyzerFunction")]
		public static void Run([ServiceBusTrigger("myqueue", Connection = "ServiceBusConnectionString")]string htmlText, ILogger log)
		{
			var method = "Main";
			log.LogInformation(string.Format("{0} - {1}", method, "IN"));

			if (string.IsNullOrWhiteSpace(htmlText))
				throw new ArgumentException("You need to provide a text to test!");
			var sanitizedText = HelperMethods.HtmlToPlainText(htmlText);

			log.LogInformation(string.Format("{0} - {1}", method, "Extracting information from LUIS."));
			var luisService = new LUISService();
			var result = luisService.ExtractEntitiesFromLUIS(sanitizedText);

			var queueService = new QueueService();
			if (result.Intent == LuisIntent.FAQ)
			{
				log.LogInformation(string.Format("{0} - {1}", method, "Getting FAQs Answer."));
				var qnaService = new QnAService();
				var response = qnaService.CheckQnAMakerForResponse(sanitizedText);
				queueService.InsertAnswerIntoCRM(response);
			}
			else
			{
				log.LogInformation(string.Format("{0} - {1}", method, "Getting Keywords and Sentiment"));
				var textAnalyticsService = new TextAnalyticsService();
				var response = textAnalyticsService.ExtractKeywordsAndSentimentFromTextAnalytics(sanitizedText);
				queueService.InsertKeywordAndSentimentoIntoCRM(response);
			}
		}
	}
}
