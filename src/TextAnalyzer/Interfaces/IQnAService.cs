using System;
using System.Collections.Generic;
using System.Text;
using TextAnalyzer.Services;

namespace TextAnalyzer.Interfaces
{
	public interface IQnAService
	{
		object CheckQnAMakerForResponse(string textToAnalyze);
	}
}
