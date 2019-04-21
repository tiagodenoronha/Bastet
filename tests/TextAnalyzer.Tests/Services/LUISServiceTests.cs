using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TextAnalyzer.Interfaces;
using Xunit;

namespace TextAnalyzer.Tests.Services
{
	public class LUISServiceTests
	{
		readonly Mock<ILUISService> _luisService;

		public LUISServiceTests()
		{
			_luisService = new Mock<ILUISService>();
		}

		[Fact]
		public async Task MessageReturnsLUISResultOK()
		{
			//Arrange
			var message = string.Empty;

			//Act 

			//Assert
		}

		[Fact]
		public async Task MessageThrowsArgumentNullExceptionSubscriptionKey()
		{
			//Arrange
			var message = string.Empty;

			//Act 

			//Assert
		}

		[Fact]
		public async Task MessageThrowsArgumentNullExceptionAppID()
		{
			//Arrange
			var message = string.Empty;

			//Act 

			//Assert
		}
	}
}
