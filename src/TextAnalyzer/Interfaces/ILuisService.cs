using System;
using System.Collections.Generic;
using System.Text;
using TextAnalyzer.Models;

namespace TextAnalyzer.Interfaces
{
	public interface ILuisService
	{
		LUISRecognizedText ExtractEntitiesFromLUIS(string textToAnalyze);
	}
}
