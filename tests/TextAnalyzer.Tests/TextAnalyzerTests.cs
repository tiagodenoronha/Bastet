using Microsoft.Azure.CognitiveServices.Language.LUIS.Runtime.Models;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
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
			await Assert.ThrowsAsync<ArgumentException>(() => TextAnalyzerFunction.Run(message, _logger.Object,
				_luisService.Object, _qnaService.Object, _textAnalyticsService.Object, _queueService.Object));
		}

		[Fact]
		public void SimpleQuestionReturnsQnA()
		{
			//Arrange
			var message = GeneralUtterances.Qna;
			//It is not possible to do Mock.Of<LuisResult>
			var mock = It.Is<LuisResult>(x => x.TopScoringIntent.Intent == "FAQ");

			_luisService.Setup(service => service.ExtractEntitiesFromLUIS(message)).ReturnsAsync(mock);

			//Act
			TextAnalyzerFunction.Run(message, _logger.Object, _luisService.Object, _qnaService.Object, _textAnalyticsService.Object, _queueService.Object);

			//Assert
			//Assert.
		}

		[Fact]
		public void ComplicatedQuestionReturnsOther()
		{
			//Arrange
			var message = GeneralUtterances.Qna;
			var mock = It.Is<LuisResult>(x => x.TopScoringIntent.Intent == "OTHER");

			_luisService.Setup(service => service.ExtractEntitiesFromLUIS(message)).ReturnsAsync(mock);

			//Act
			TextAnalyzerFunction.Run(message, _logger.Object, _luisService.Object, _qnaService.Object, _textAnalyticsService.Object, _queueService.Object);

			//Assert
			//Assert.f
		}
	}
}
