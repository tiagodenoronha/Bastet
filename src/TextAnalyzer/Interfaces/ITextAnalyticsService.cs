using System;
using System.Collections.Generic;
using System.Text;

namespace TextAnalyzer.Interfaces
{
	public interface ITextAnalyticsService
	{
		object ExtractKeywordsAndSentimentFromTextAnalytics(string textToAnalyze);
	}
}
