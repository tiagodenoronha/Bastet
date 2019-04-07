using System;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using TextAnalyzer.Models;

namespace TextAnalyzer
{
    public static class TextAnalyzerFunction
    {
        [FunctionName("TextAnalyzerFunction")]
        public static void Run([ServiceBusTrigger("myqueue", Connection = "ServiceBusConnectionString")]string htmlText, ILogger log)
        {
            var method = "Main";
            log.LogInformation(string.Format("{0} - {1}", method, "IN"));

            var sanitizedText = HelperMethods.HtmlToPlainText(htmlText);

            log.LogInformation(string.Format("{0} - {1}", method, "Extracting information from LUIS."));
            var result = ExtractEntitiesFromLUIS(sanitizedText);

            if (result.Intent == LuisIntent.FAQ)
            {
                log.LogInformation(string.Format("{0} - {1}", method, "Getting FAQs Answer."));
                var response = CheckQnAMakerForResponse(sanitizedText);
                InsertAnswerIntoCRM(response);
            }
            else
            {
                log.LogInformation(string.Format("{0} - {1}", method, "Getting Keywords and Sentiment"));
                var response = ExtractKeywordsAndSentimentFromTextAnalytics(sanitizedText);
                InsertKeywordAndSentimentoIntoCRM(response);
            }

        }

        static void InsertKeywordAndSentimentoIntoCRM(object response) => throw new NotImplementedException();
        static void InsertAnswerIntoCRM(object response) => throw new NotImplementedException();
        static object CheckQnAMakerForResponse(string textToAnalyze) => throw new NotImplementedException();
        static object ExtractKeywordsAndSentimentFromTextAnalytics(string textToAnalyze) => throw new NotImplementedException();
        static LUISRecognizedText ExtractEntitiesFromLUIS(string textToAnalyze) => throw new NotImplementedException();
    }
}
