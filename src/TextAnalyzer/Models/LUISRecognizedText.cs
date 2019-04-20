using System;
using System.Collections.Generic;
using System.Text;

namespace TextAnalyzer.Models
{
	public class LUISRecognizedText
	{
		public LuisIntent Intent { get; set; }
		public IEnumerable<string> ExtractedEntities { get; set; }
	}
}
