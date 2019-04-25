using Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using TextAnalyzer.CognitiveModels;
using TextAnalyzer.Interfaces;

namespace TextAnalyzer.Services
{
	public class TextAnalyticsService : ITextAnalyticsService
	{
		readonly ILogger _logger;

		public TextAnalyticsService(ILogger logger)
		{
			_logger = logger;
		}

		public TextAnalyticsModels GetMetadataFromTextAnalytics(string text)
		{
			var method = "GetMetadataFromTextAnalytics";
			try
			{
				throw new NotImplementedException();
			}
			catch (ArgumentNullException arg)
			{
				_logger.LogError(string.Format("{0} - {1}", method, "Received a null argument."));
				_logger.LogError(string.Format("{0} - {1}", method, "Argument:"));
				_logger.LogError(string.Format("{0} - {1}", method, arg.ParamName));
				return null;
			}
			catch (Exception ex)
			{
				_logger.LogError(string.Format("{0} - {1}", method, "Generic Exception."));
				_logger.LogError(string.Format("{0} - {1}", method, "Message:"));
				_logger.LogError(string.Format("{0} - {1}", method, ex.Message));
				return null;
			}
		}

		IEnumerable<DetectedLanguage> GetLanguageFromText(string text)
		{
			throw new NotImplementedException();
		}

		double GetScoreFromText(DetectedLanguage language, string text)
		{
			throw new NotImplementedException();
		}

		IEnumerable<string> GetKeyPhrasesFromText(string text)
		{
			throw new NotImplementedException();
		}

		IEnumerable<EntityRecord> GetEntitiesFromText(string text)
		{
			throw new NotImplementedException();
		}
	}
}
