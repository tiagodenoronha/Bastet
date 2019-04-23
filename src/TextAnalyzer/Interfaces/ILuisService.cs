using Microsoft.Azure.CognitiveServices.Language.LUIS.Runtime.Models;
using System.Threading.Tasks;

namespace TextAnalyzer.Interfaces
{
	public interface ILUISService
	{
		Task<LuisResult> ExtractEntitiesFromLUIS(string textToAnalyze);
	}
}
