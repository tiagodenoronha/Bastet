using Microsoft.Extensions.Logging;
using Moq;
using TextAnalyzer.Services;
using Xunit;

namespace TextAnalyzer.Tests.Services
{
	public class TextAnalyticsServiceTests
	{
		readonly Mock<ILogger> _logger;
		TextAnalyticsService _textAnalyticsService;

		public TextAnalyticsServiceTests()
		{
			_logger = new Mock<ILogger>();
		}

		[Fact]
		public void GetLanguageWithEmptyTextThrowsArgumentNull()
		{
			//Assert
			var message = string.Empty;
			_textAnalyticsService = new TextAnalyticsService(_logger.Object);

			//Act

			//Arrange
		}
	}
}
