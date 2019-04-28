using Microsoft.Azure.CognitiveServices.Language.TextAnalytics;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Models;
using System;
using System.Threading;
using System.Threading.Tasks;
using TextAnalyzer.Interfaces.Helpers;

namespace TextAnalyzer.Services.Helpers
{
	public partial class TextAnalyticsService
	{
		public class TextAnalyticsClientHelper : ITextAnalyticsClientHelper
		{
			public Task<LanguageBatchResult> DetectLanguageAsync(ITextAnalyticsClient operations, bool? showStats = null, LanguageBatchInput languageBatchInput = null, CancellationToken cancellationToken = default) =>
				operations.DetectLanguageAsync(showStats, languageBatchInput, cancellationToken);
			public Task<EntitiesBatchResult> EntitiesAsync(ITextAnalyticsClient operations, bool? showStats = null, MultiLanguageBatchInput multiLanguageBatchInput = null, CancellationToken cancellationToken = default) =>
				operations.EntitiesAsync(showStats, multiLanguageBatchInput, cancellationToken);
			public Task<KeyPhraseBatchResult> KeyPhrasesAsync(ITextAnalyticsClient operations, bool? showStats = null, MultiLanguageBatchInput multiLanguageBatchInput = null, CancellationToken cancellationToken = default) =>
				operations.KeyPhrasesAsync(showStats, multiLanguageBatchInput, cancellationToken);
			public Task<SentimentBatchResult> SentimentAsync(ITextAnalyticsClient operations, bool? showStats = null, MultiLanguageBatchInput multiLanguageBatchInput = null, CancellationToken cancellationToken = default) =>
				operations.SentimentAsync(showStats, multiLanguageBatchInput, cancellationToken);
		}
	}
}
