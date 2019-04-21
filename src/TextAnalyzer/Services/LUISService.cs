using System;
using System.Collections.Generic;
using System.Text;
using TextAnalyzer.Interfaces;
using Microsoft.Azure.CognitiveServices.Language.LUIS.Runtime.Models;
using Microsoft.Azure.CognitiveServices.Language.LUIS.Runtime;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace TextAnalyzer.Services
{
	public class LUISService : ILUISService
	{
		readonly ILogger _logger;

		public LUISService(ILogger logger)
		{
			_logger = logger;
		}

		public async Task<LuisResult> ExtractEntitiesFromLUIS(string textToAnalyze)
		{
			var method = "ExtractEntitiesFromLUIS";
			try
			{
				_logger.LogInformation(string.Format("{0} - {1}", method, "IN"));


				_logger.LogInformation(string.Format("{0} - {1}", method, "Getting credentials."));
				var credentials = new ApiKeyServiceClientCredentials(Environment.GetEnvironmentVariable("LUISAPISubscriptionKey"));
				_logger.LogDebug(string.Format("{0} - {1}", method, "Getting credentials."));


				_logger.LogInformation(string.Format("{0} - {1}", method, "Creating client."));
				var luisService = new LUISRuntimeClient(credentials);


				_logger.LogInformation(string.Format("{0} - {1}", method, "Predicting."));
				return await luisService.Prediction.ResolveAsync(Environment.GetEnvironmentVariable("LUISAPPID"), textToAnalyze,
					null, null, false, true, Environment.GetEnvironmentVariable("BingAPISubscriptionKey"));
			}
			catch (ArgumentNullException arg)
			{
				_logger.LogError(string.Format("{0} - {1}", method, "Received a null argument."));
				_logger.LogError(string.Format("{0} - {1}", method, "Argument:"));
				_logger.LogError(string.Format("{0} - {1}", method, arg.ParamName));
				return null;
			}
			catch (Exception ex)
			{
				_logger.LogError(string.Format("{0} - {1}", method, "Generic Exception."));
				_logger.LogError(string.Format("{0} - {1}", method, "Message:"));
				_logger.LogError(string.Format("{0} - {1}", method, ex.Message));
				return null;
			}
		}
	}
}
