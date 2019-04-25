using Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace TextAnalyzer.CognitiveModels
{
	public class TextAnalyticsModels
	{
		public IEnumerable<DetectedLanguage> Languages { get; set; }

		public double Score { get; set; }

		public IEnumerable<string> KeyPhrases { get; set; }

		public IEnumerable<EntityRecord> Entities { get; set; }
	}
}
