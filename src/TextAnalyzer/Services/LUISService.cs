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
		ILUISRuntimeClient _client;
		IPredictionHelperService _predictionHelperService;

		public LUISService(ILogger logger, ILUISRuntimeClient client, IPredictionHelperService predictionHelperService)
		{
			_logger = logger;
			_client = client;
			_predictionHelperService = predictionHelperService;

		}

		public async Task<LuisResult> ExtractEntitiesFromLUIS(string textToAnalyze)
		{
			var method = "ExtractEntitiesFromLUIS";
			try
			{
				_logger.LogInformation(string.Format("{0} - {1}", method, "IN"));

				_logger.LogInformation(string.Format("{0} - {1}", method, "Getting credentials."));
				var credentials = new ApiKeyServiceClientCredentials(Environment.GetEnvironmentVariable("LUISAPISubscriptionKey"));
				_logger.LogDebug(string.Format("{0} - {1}", method, Environment.GetEnvironmentVariable("LUISAPISubscriptionKey")));

				_logger.LogInformation(string.Format("{0} - {1}", method, "Creating client."));
				
				//TODO we might not actually need this...
				if (_client == null)
				{
					_client = new LUISRuntimeClient(credentials);
				}

				_logger.LogInformation(string.Format("{0} - {1}", method, "Setting Endpoint"));
				_client.Endpoint = "https://westeurope.api.cognitive.microsoft.com/";

				_logger.LogInformation(string.Format("{0} - {1}", method, "Getting app ID."));
				var appID = Environment.GetEnvironmentVariable("LUISAPPID");

				_logger.LogInformation(string.Format("{0} - {1}", method, "Getting Bing Subscription Key."));
				var bingSubcriptionKey = Environment.GetEnvironmentVariable("BingAPISubscriptionKey");

				_logger.LogInformation(string.Format("{0} - {1}", method, "Predicting."));
				return await _predictionHelperService.ResolveAsync(_client.Prediction, appID, textToAnalyze,
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
		}
	}
}
