using Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TextAnalyzer.CognitiveModels;

namespace TextAnalyzer.Interfaces
{
	public interface ITextAnalyticsService
	{
		Task<DetectedLanguage> GetLanguageFromText(string text);

		Task<double> GetSentimentFromText(DetectedLanguage language, string text);

		Task<IEnumerable<string>> GetKeyPhrasesFromText(DetectedLanguage language, string text);

		Task<IEnumerable<EntityRecord>> GetEntitiesFromText(DetectedLanguage language, string text);
	}
}
