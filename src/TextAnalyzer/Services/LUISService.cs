using System;
using System.Collections.Generic;
using System.Text;
using TextAnalyzer.Interfaces;
using TextAnalyzer.Models;

namespace TextAnalyzer.Services
{
	public class LUISService : ILuisService
	{
		public LUISRecognizedText ExtractEntitiesFromLUIS(string textToAnalyze) => throw new NotImplementedException();
	}
}
