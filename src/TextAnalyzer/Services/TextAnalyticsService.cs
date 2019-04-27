using Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

		public Task<IEnumerable<DetectedLanguage>> GetLanguageFromText(string text)
		{
			throw new NotImplementedException();
		}

		public Task<double> GetScoreFromText(DetectedLanguage language, string text)
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
