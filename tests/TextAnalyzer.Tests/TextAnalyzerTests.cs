using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TextAnalyzer.Tests
{
    public class TextAnalyzerTests
    {
        readonly ILogger _logger;

        public TextAnalyzerTests()
        {
            _logger = Mock.Of<ILogger>();
        }

        [Fact]
        public void EmptyInputReturnsError()
        {
            //Arrange
            var message = string.Empty;

            //Act and Assert
            Assert.Throws<ArgumentException>(() => TextAnalyzerFunction.Run(message, _logger));
        }
    }
}
