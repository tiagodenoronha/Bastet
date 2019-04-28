using System;
using System.Collections.Generic;
using System.Text;
using TextAnalyzer.Interfaces;
using TextAnalyzer.Interfaces.Helpers;
using Microsoft.Azure.CognitiveServices.Language.LUIS.Runtime.Models;
using Microsoft.Azure.CognitiveServices.Language.LUIS.Runtime;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace TextAnalyzer.Services
{
	public class LUISService : ILUISService
	{
		readonly ILogger _logger;
		ILUISClientHelper _luisClientHelper;

		public LUISService(ILogger logger, ILUISClientHelper predictionHelperService)
		{
			_logger = logger;
			_luisClientHelper = predictionHelperService;
		}

		public async Task<LuisResult> GetIntentFromLUIS(string textToAnalyze)
		{
			var method = "GetIntentFromLUIS";
			try
			{
				_logger.LogInformation(string.Format("{0} - {1}", method, "IN"));

				_logger.LogInformation(string.Format("{0} - {1}", method, "Getting credentials."));
				var subscriptionKey = Environment.GetEnvironmentVariable("LUISAPISubscriptionKey");
				if (subscriptionKey == null)
					throw new System.ArgumentNullException("subscriptionKey");

				var credentials = new ApiKeyServiceClientCredentials(Environment.GetEnvironmentVariable("LUISAPISubscriptionKey"));

				_logger.LogInformation(string.Format("{0} - {1}", method, "Creating client."));
				var client = new LUISRuntimeClient(credentials);

				_logger.LogInformation(string.Format("{0} - {1}", method, "Setting Endpoint"));
				client.Endpoint = "https://westeurope.api.cognitive.microsoft.com/";

				_logger.LogInformation(string.Format("{0} - {1}", method, "Getting app ID."));
				var appID = Environment.GetEnvironmentVariable("LUISAPPID");
				if (appID == null)
					throw new System.ArgumentNullException("appID");

				_logger.LogInformation(string.Format("{0} - {1}", method, "Getting Bing Subscription Key."));

				var bingSubcriptionKey = Environment.GetEnvironmentVariable("BingAPISubscriptionKey");
				if (bingSubcriptionKey == null)
					throw new System.ArgumentNullException("bingSubcriptionKey");

				_logger.LogInformation(string.Format("{0} - {1}", method, "Predicting."));
				return await _luisClientHelper.ResolveAsync(client.Prediction, appID, textToAnalyze,
					null, null, false, true, bingSubcriptionKey);
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
			finally
			{
				_logger.LogInformation(string.Format("{0} - {1}", method, "OUT"));
			}
		}
	}
}
