using System;
using System.Collections.Generic;
using System.Text;
using TextAnalyzer.CognitiveModels;

namespace TextAnalyzer.Interfaces
{
	public interface ITextAnalyticsService
	{
		TextAnalyticsModels GetMetadataFromTextAnalytics(string textToAnalyze);
	}
}
