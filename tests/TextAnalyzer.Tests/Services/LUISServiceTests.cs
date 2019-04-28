using Microsoft.Azure.CognitiveServices.Language.LUIS.Runtime;
using Microsoft.Azure.CognitiveServices.Language.LUIS.Runtime.Models;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using TextAnalyzer.Interfaces.Helpers;
using TextAnalyzer.Services;
using Xunit;

namespace TextAnalyzer.Tests.Services
{
	public class LUISServiceTests : IDisposable
	{
		const string APPID = "AppID";
		const string SUBSCRIPTIONKEY = "SubscriptionKey";
		const string BINGAPISUBSCRIPTIONKEY = "BingAPISubscriptionKey";

		readonly Mock<ILogger> _logger;
		readonly Mock<ILUISClientHelper> _predictionHelperService;
		LUISService _luisService;

		public LUISServiceTests()
		{
			_logger = new Mock<ILogger>();
			_predictionHelperService = new Mock<ILUISClientHelper>();
		}

		public void Dispose()
		{
			Environment.SetEnvironmentVariable("LUISAPISubscriptionKey", string.Empty);
			Environment.SetEnvironmentVariable("LUISAPPID", string.Empty);
			Environment.SetEnvironmentVariable("BingAPISubscriptionKey", string.Empty);
		}

		[Fact]
		public async Task MessageThrowsArgumentNullExceptionSubscriptionKey()
		{
			//Arrange
			_luisService = new LUISService(_logger.Object, _predictionHelperService.Object);

			//Act
			var result = await _luisService.GetIntentFromLUIS(It.IsAny<string>());

			//Assert
			Assert.Null(result);
		}

		[Fact]
		public async Task MessageThrowsArgumentNullExceptionAppID()
		{
			//Arrange
			Environment.SetEnvironmentVariable("LUISAPISubscriptionKey", SUBSCRIPTIONKEY);
			_luisService = new LUISService(_logger.Object, _predictionHelperService.Object);

			//Act
			var result = await _luisService.GetIntentFromLUIS(It.IsAny<string>());

			//Assert
			Assert.Null(result);
		}

		[Fact]
		public async Task MessageThrowsArgumentNullExceptionBingSubscriptionKey()
		{
			//Arrange
			Environment.SetEnvironmentVariable("LUISAPISubscriptionKey", SUBSCRIPTIONKEY);
			Environment.SetEnvironmentVariable("LUISAPPID", APPID);
			_luisService = new LUISService(_logger.Object, _predictionHelperService.Object);

			//Act
			var result = await _luisService.GetIntentFromLUIS(It.IsAny<string>());

			//Assert
			Assert.Null(result);
		}

		[Fact]
		public async Task MessageReturnsLUISResultOK()
		{
			//Arrange
			Environment.SetEnvironmentVariable("LUISAPISubscriptionKey", SUBSCRIPTIONKEY);
			Environment.SetEnvironmentVariable("LUISAPPID", APPID);
			Environment.SetEnvironmentVariable("BingAPISubscriptionKey", BINGAPISUBSCRIPTIONKEY);

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
				It.IsAny<CancellationToken>()))
				.Returns(Task.FromResult(new LuisResult()));

			_luisService = new LUISService(_logger.Object, _predictionHelperService.Object);

			//Act
			var result = await _luisService.GetIntentFromLUIS(It.IsAny<string>());

			//Assert
			Assert.NotNull(result);
		}
	}
}
