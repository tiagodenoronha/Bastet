using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.CognitiveServices.Language.LUIS.Runtime;
using Microsoft.Azure.CognitiveServices.Language.LUIS.Runtime.Models;
using TextAnalyzer.Interfaces;

namespace TextAnalyzer.Services
{
	public class PredictionHelperService : IPredictionHelperService
	{
		public Task<LuisResult> ResolveAsync(IPrediction prediction, string appId, string query, double? timezoneOffset = null,
			bool? verbose = null, bool? staging = null, bool? spellCheck = null, string bingSpellCheckSubscriptionKey = null,
			bool? log = null, CancellationToken cancellationToken = default)
			=> prediction.ResolveAsync(appId, query, timezoneOffset, verbose, staging, spellCheck, 
				bingSpellCheckSubscriptionKey, log, cancellationToken);
	}
}
