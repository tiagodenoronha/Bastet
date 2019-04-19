using System;
using System.Collections.Generic;
using System.Text;

namespace TextAnalyzer.Models
{
    public class LUISRecognizedText
    {
        internal LuisIntent Intent { get; set; }
        internal IEnumerable<string> ExtractedEntities { get; set; }
    }
}
