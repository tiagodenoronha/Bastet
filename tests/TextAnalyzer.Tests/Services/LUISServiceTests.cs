using Microsoft.Azure.CognitiveServices.Language.LUIS.Runtime;
using Microsoft.Azure.CognitiveServices.Language.LUIS.Runtime.Models;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.Protected;
using RichardSzalay.MockHttp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TextAnalyzer.Interfaces;
using TextAnalyzer.Services;
using Xunit;

namespace TextAnalyzer.Tests.Services
{
	public class LUISServiceTests
	{
		const string APPID = "AppID";
		const string SUBSCRIPTIONKEY = "SubscriptionKey";

		readonly Mock<ILogger> _logger;
		LUISService _luisService;
		Mock<ILUISRuntimeClient> _luisRuntimeClient;
		Mock<IPrediction> _prediction;
        Mock<IPredictionHelperService> _predictionHelperService;

		public LUISServiceTests()
		{
			_logger = new Mock<ILogger>();
			_prediction = new Mock<IPrediction>();
            _predictionHelperService = new Mock<IPredictionHelperService>();

            _predictionHelperService.Setup(x => x.ResolveAsync(
                It.IsAny<IPrediction>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<double?>(),
                It.IsAny<bool?>(),
                It.IsAny<bool?>(),
                It.IsAny<bool?>(),
                It.IsAny<string>(),
                It.IsAny<bool?>(),
                It.IsAny<CancellationToken>())).Returns(Task.FromResult(new LuisResult()));

			_luisRuntimeClient = new Mock<ILUISRuntimeClient>();
			_luisRuntimeClient.SetupGet(x => x.Prediction).Returns(_prediction.Object);

		}

		[Fact]
		public async Task MessageReturnsLUISResultOK()
		{
			//Arrange
			var message = string.Empty;
			Environment.SetEnvironmentVariable("LUISAPISubscriptionKey", SUBSCRIPTIONKEY);
			Environment.SetEnvironmentVariable("LUISAPPID", APPID);
			_luisService = new LUISService(_logger.Object, _luisRuntimeClient.Object, _predictionHelperService.Object);

			//Act
			var result = await _luisService.ExtractEntitiesFromLUIS(message);

			//Assert
			Assert.NotNull(result);
		}

		[Fact]
		public async Task MessageThrowsArgumentNullExceptionSubscriptionKey()
		{
			//Arrange
			var message = string.Empty;

			Environment.SetEnvironmentVariable("LUISAPPID", APPID);
			_luisService = new LUISService(_logger.Object, _luisRuntimeClient.Object, _predictionHelperService.Object);

			//Act
			var result = await _luisService.ExtractEntitiesFromLUIS(message);

			//Assert
			Assert.Null(result);
		}

		[Fact]
		public async Task MessageThrowsArgumentNullExceptionAppID()
		{
			var message = string.Empty;

			Environment.SetEnvironmentVariable("LUISAPISubscriptionKey", SUBSCRIPTIONKEY);
			_luisService = new LUISService(_logger.Object, _luisRuntimeClient.Object, _predictionHelperService.Object);

			//Act
			var result = await _luisService.ExtractEntitiesFromLUIS(message);

			//Assert
			Assert.Null(result);
		}
	}
}
