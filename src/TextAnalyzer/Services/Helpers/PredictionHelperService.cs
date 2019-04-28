using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.CognitiveServices.Language.LUIS.Runtime;
using Microsoft.Azure.CognitiveServices.Language.LUIS.Runtime.Models;
using TextAnalyzer.Interfaces.Helpers;

namespace TextAnalyzer.Services.Helpers
{
	public class LUISClientHelper : ILUISClientHelper
	{
		public Task<LuisResult> ResolveAsync(IPrediction prediction, string appId, string query, double? timezoneOffset = null,
			bool? verbose = null, bool? staging = null, bool? spellCheck = null, string bingSpellCheckSubscriptionKey = null,
			bool? log = null, CancellationToken cancellationToken = default)
			=> prediction.ResolveAsync(appId, query, timezoneOffset, verbose, staging, spellCheck, 
				bingSpellCheckSubscriptionKey, log, cancellationToken);
	}
}
