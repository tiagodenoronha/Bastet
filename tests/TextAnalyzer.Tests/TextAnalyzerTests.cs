using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using TextAnalyzer.Interfaces;
using TextAnalyzer.Models;
using Xunit;

namespace TextAnalyzer.Tests
{
	public class TextAnalyzerTests
	{
		readonly ILogger _logger;
		readonly Mock<ILUISService> _luisService;
		readonly Mock<IQnAService> _qnaService;
		readonly Mock<ITextAnalyticsService> _textAnalyticsService;
		readonly Mock<IQueueService> _queueService;

		public TextAnalyzerTests()
		{
			_logger = Mock.Of<ILogger>();
			_luisService = new Mock<ILUISService>();
			_qnaService = new Mock<IQnAService>();
			_textAnalyticsService = new Mock<ITextAnalyticsService>();
			_queueService = new Mock<IQueueService>();
		}

		[Fact]
		public void EmptyInputThrowsException()
		{
			//Arrange
			var message = string.Empty;

			//Act and Assert
			Assert.Throws<ArgumentException>(() => TextAnalyzerFunction.Run(message, _logger,
				_luisService.Object, _qnaService.Object, _textAnalyticsService.Object, _queueService.Object));
		}

		[Fact]
		public void SimpleQuestionReturnsQnA()
		{
			//Arrange
			var message = GeneralUtterances.Qna;
			_luisService.Setup(service => service.ExtractEntitiesFromLUIS(message)).Returns(Mock.Of<LUISRecognizedText>(x => x.Intent == LuisIntent.FAQ));

			//Act
			TextAnalyzerFunction.Run(message, _logger, _luisService.Object, _qnaService.Object, _textAnalyticsService.Object, _queueService.Object);

			//Assert
			//Assert.
		}

		[Fact]
		public void ComplicatedQuestionReturnsOther()
		{
			//Arrange
			var message = GeneralUtterances.Qna;
			_luisService.Setup(service => service.ExtractEntitiesFromLUIS(message)).Returns(Mock.Of<LUISRecognizedText>(x => x.Intent == LuisIntent.OTHER));

			//Act
			TextAnalyzerFunction.Run(message, _logger, _luisService.Object, _qnaService.Object, _textAnalyticsService.Object, _queueService.Object);

			//Assert
			//Assert.f
		}
	}
}
