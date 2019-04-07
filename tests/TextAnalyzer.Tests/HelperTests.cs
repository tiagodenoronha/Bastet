using Moq;
using System;
using Xunit;

namespace TextAnalyzer.Tests
{
    public class HelperTests
    {
        [Fact]
        public void HTMLStringIsParsedCorrectly()
        {
            //Arrange
            var htmlText = @"<!DOCTYPE html>< html >< body >< h1 > My First Heading</ h1 >< p > My first paragraph.</ p ><br></ body ></ html >";

            //Act
            var text = HelperMethods.HtmlToPlainText(htmlText);

            //Assert
            Assert.DoesNotContain(HelperMethods.stripFormatting, text);
        }
    }
}
