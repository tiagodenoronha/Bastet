using Microsoft.Azure.CognitiveServices.Language.TextAnalytics;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Models;
using System.Threading;
using System.Threading.Tasks;

namespace TextAnalyzer.Interfaces.Helpers
{
	public interface ITextAnalyticsClientHelper
	{
		Task<LanguageBatchResult> DetectLanguageAsync(ITextAnalyticsClient operations, bool? showStats = null, LanguageBatchInput languageBatchInput = null, CancellationToken cancellationToken = default);
		Task<EntitiesBatchResult> EntitiesAsync(ITextAnalyticsClient operations, bool? showStats = null, MultiLanguageBatchInput multiLanguageBatchInput = null, CancellationToken cancellationToken = default);
		Task<KeyPhraseBatchResult> KeyPhrasesAsync(ITextAnalyticsClient operations, bool? showStats = null, MultiLanguageBatchInput multiLanguageBatchInput = null, CancellationToken cancellationToken = default);
		Task<SentimentBatchResult> SentimentAsync(ITextAnalyticsClient operations, bool? showStats = null, MultiLanguageBatchInput multiLanguageBatchInput = null, CancellationToken cancellationToken = default);
	}
}