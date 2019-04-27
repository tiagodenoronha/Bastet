using Microsoft.Azure.CognitiveServices.Language.LUIS.Runtime.Models;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading.Tasks;
using TextAnalyzer.Interfaces;
using Xunit;

namespace TextAnalyzer.Tests
{
	public class TextAnalyzerTests
	{
		readonly Mock<ILogger> _logger;
		readonly Mock<ILUISService> _luisService;
		readonly Mock<IQnAService> _qnaService;
		readonly Mock<ITextAnalyticsService> _textAnalyticsService;
		readonly Mock<IQueueService> _queueService;

		public TextAnalyzerTests()
		{
			_logger = new Mock<ILogger>();
			_luisService = new Mock<ILUISService>();
			_qnaService = new Mock<IQnAService>();
			_textAnalyticsService = new Mock<ITextAnalyticsService>();
			_queueService = new Mock<IQueueService>();
		}

		[Fact]
		public async Task EmptyInputThrowsException()
		{
			//Arrange
			var message = string.Empty;

			//Act and Assert
			await Assert.ThrowsAsync<ArgumentNullException>(() => TextAnalyzerFunction.Run(message, _logger.Object,
				_luisService.Object, _qnaService.Object, _textAnalyticsService.Object, _queueService.Object));
		}

		[Fact]
		public void SimpleQuestionReturnsQnA()
		{
			//Arrange
			var message = "message";
			var mock = new LuisResult
			{
				TopScoringIntent = new IntentModel { Intent = "FAQ" }
			};
			_luisService.Setup(service => service.GetIntentFromLUIS(It.IsAny<string>())).ReturnsAsync(mock);

			//Act
			TextAnalyzerFunction.Run(message, _logger.Object, _luisService.Object,
				_qnaService.Object, _textAnalyticsService.Object, _queueService.Object);

			//Assert
			//TODO
		}

		[Fact]
		public void ComplicatedQuestionReturnsOther()
		{
			//Arrange
			var message = "message";
			var mock = new LuisResult
			{
				TopScoringIntent = new IntentModel { Intent = "OTHER" }
			};
			_luisService.Setup(service => service.GetIntentFromLUIS(It.IsAny<string>())).ReturnsAsync(mock);

			//Act
			TextAnalyzerFunction.Run(message, _logger.Object, _luisService.Object,
				_qnaService.Object, _textAnalyticsService.Object, _queueService.Object);

			//Assert
			//TODO
		}
	}
}
