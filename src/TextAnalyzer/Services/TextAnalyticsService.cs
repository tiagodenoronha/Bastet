using Microsoft.Azure.CognitiveServices.Language.LUIS.Runtime;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TextAnalyzer.CognitiveModels;
using TextAnalyzer.Interfaces;
using TextAnalyzer.Interfaces.Helpers;

namespace TextAnalyzer.Services
{
	public partial class TextAnalyticsService : ITextAnalyticsService
	{
		readonly ILogger _logger;
		readonly ITextAnalyticsClientHelper _helper;

		public TextAnalyticsService(ILogger logger, ITextAnalyticsClientHelper helper)
		{
			_logger = logger;
			_helper = helper;
		}

		public async Task<DetectedLanguage> GetLanguageFromText(string text)
		{
			var method = "GetLanguageFromText";
			try
			{
				_logger.LogInformation(string.Format("{0} - {1}", method, "IN"));

				_logger.LogInformation(string.Format("{0} - {1}", method, "Getting Credentials."));
				var credentials = new ApiKeyServiceClientCredentials(Environment.GetEnvironmentVariable("TextAnalyticsSubscriptionKey"));

				_logger.LogInformation(string.Format("{0} - {1}", method, "Creating Client."));
				var client = new TextAnalyticsClient(credentials);

				_logger.LogInformation(string.Format("{0} - {1}", method, "Setting Endpoint."));
				client.Endpoint = "https://westeurope.api.cognitive.microsoft.com";

				_logger.LogInformation(string.Format("{0} - {1}", method, "Getting Language."));
				var result = await _helper.DetectLanguageAsync(client, false, new LanguageBatchInput(
					new List<LanguageInput> {
						new LanguageInput(null, "1", text)
					}));

				if (result == null)
				{
					_logger.LogError(string.Format("{0} - {1}", method, "Result returned null."));
					return null;
				}
				return result.Documents[0].DetectedLanguages[0];
			}
			catch (ArgumentNullException arg)
			{
				_logger.LogError(string.Format("{0} - {1}", method, "Received a null argument."));
				_logger.LogError(string.Format("{0} - {1}", method, "Argument:"));
				_logger.LogError(string.Format("{0} - {1}", method, arg.ParamName));
				return null;
			}
			finally
			{
				_logger.LogInformation(string.Format("{0} - {1}", method, "OUT"));
			}
		}

		public Task<double> GetSentimentFromText(DetectedLanguage language, string text)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<string>> GetKeyPhrasesFromText(DetectedLanguage language, string text)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<EntityRecord>> GetEntitiesFromText(DetectedLanguage language, string text)
		{
			throw new NotImplementedException();
		}
	}
}
