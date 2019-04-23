using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.CognitiveServices.Language.LUIS.Runtime;
using Microsoft.Azure.CognitiveServices.Language.LUIS.Runtime.Models;

namespace TextAnalyzer.Interfaces
{
    public interface IPredictionHelperService
    {
        Task<LuisResult> ResolveAsync(IPrediction prediction, string appId, string query, double? timezoneOffset = null, bool? verbose = null, bool? staging = null, bool? spellCheck = null, string bingSpellCheckSubscriptionKey = null, bool? log = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}