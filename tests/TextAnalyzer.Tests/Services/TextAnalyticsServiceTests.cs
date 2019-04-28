using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading.Tasks;
using TextAnalyzer.Services;
using TextAnalyzer.Interfaces.Helpers;
using Xunit;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Models;
using System.Threading;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics;
using System.Collections;
using System.Collections.Generic;

namespace TextAnalyzer.Tests.Services
{
	public class TextAnalyticsServiceTests : IDisposable
	{
		readonly Mock<ILogger> _logger;
		readonly Mock<ITextAnalyticsClientHelper> _textAnalyticsClientHelper;
		TextAnalyticsService _textAnalyticsService;

		const string SUBSCRIPTIONKEY = "SubscriptionKey";

		public TextAnalyticsServiceTests()
		{
			_logger = new Mock<ILogger>();
			_textAnalyticsClientHelper = new Mock<ITextAnalyticsClientHelper>();
		}

		public void Dispose() => Environment.SetEnvironmentVariable("TextAnalyticsSubscriptionKey", string.Empty);

		[Fact]
		public async Task GetLanguageWithoutSubscriptionKeyReturnsNull()
		{
			//Assert
			_textAnalyticsService = new TextAnalyticsService(_logger.Object, _textAnalyticsClientHelper.Object);

			//Act
			var result = await _textAnalyticsService.GetLanguageFromText(string.Empty);

			//Arrange
			Assert.Null(result);
		}

		[Fact]
		public async Task GetLanguageReturnsOK()
		{
			//Assert
			var resultDocument = new LanguageBatchResult(
				 new List<LanguageBatchResultItem>()
				 {
					  new LanguageBatchResultItem(
						  It.IsAny<string>(),
						  new List<DetectedLanguage>{
							  new DetectedLanguage(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<double>())
						  }
					  )
				 }
			);
			Environment.SetEnvironmentVariable("TextAnalyticsSubscriptionKey", SUBSCRIPTIONKEY);

			_textAnalyticsClientHelper.Setup(x => x.DetectLanguageAsync(
				It.IsAny<ITextAnalyticsClient>(), It.IsAny<bool>(), It.IsAny<LanguageBatchInput>(), It.IsAny<CancellationToken>()))
				.ReturnsAsync(resultDocument);

			_textAnalyticsService = new TextAnalyticsService(_logger.Object, _textAnalyticsClientHelper.Object);

			//Act
			var result = await _textAnalyticsService.GetLanguageFromText(string.Empty);

			//Arrange
			Assert.NotNull(result);
		}
	}
}
