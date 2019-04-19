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
			var htmlText = "<table width=\"100 %\" bgcolor=\"#ffffff\" border=\"0\" cellpadding=\"10\" cellspacing=\"0\"><tr> <td> <table bgcolor=\"#ffffff\" class=\"content\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr><td valign=\"top\" mc:edit=\"headerBrand\" id=\"templateContainerHeader\"><p style=\"text-align:center;margin:0;padding:0;\"><img src=\"http://c0185784a2b233b0db9b-d0e5e4adc266f8aacd2ff78abb166d77.r51.cf2.rackcdn.com/templates/cog-01.jpg\" style=\"max-width:600px;display:inline-block;\"/></p></td></tr><tr><td align=\"center\" valign=\"top\"><table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" id=\"templateContainer\"><tr><td valign=\"top\" class=\"bodyContent\" mc:edit=\"body_content\"><p>Hi --First Name=there--,</p><p>I noticed you were interested in learning more about growing --Company=your business--. I would like to <a href=\"http://www.autopilothq.com/\">invite you</a> to our free 30 day business growth course. Or, you can <a href=\"http://www.autopilothq.com/\">signup</a> for a free complimentary 45 minute session for being such a valuable contributor to our Facebook community. <br/><br/> Just to confirm, is this your first time starting a business, or have you done it before? </p></td></tr><tr align=\"top\"><td valign=\"top\" class=\"bodyContentImage\"><table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" valign=\"top\"><tr><td align=\"left\" width=\"50\" valign=\"top\" mc:edit=\"footer_sigimage\" style=\"margin:0;padding:0;\"><p style=\"margin-bottom:10px; padding:0;display:block;\"><img src=\"http://c0185784a2b233b0db9b-d0e5e4adc266f8aacd2ff78abb166d77.r51.cf2.rackcdn.com/templates/img_profile.jpg\" style=\"max-width:600px;display:block;\"/></p></td><td width=\"15\" align=\"left\" valign=\"top\" style=\"width:15px;margin:0;padding:0;\">&nbsp;</td><td align=\"left\" valign=\"top\" mc:edit=\"footer_sig\" valign=\"top\" style=\"margin:0;padding-top:10px;line-height:1;\"><h4><strong>Jenny Smith</strong></h4><h5>Business Development at COG</h5></td></tr></table></td></tr></table></td></tr><tr><td align=\"center\" valign=\"top\" id=\"bodyCellFooter\" class=\"unSubContent\"><table width=\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" id=\"templateContainerFooter\"><tr><td valign=\"top\" width=\"100%\" mc:edit=\"footer_unsubscribe\"><p style=\"text-align:center;\"><img src=\"http://c0185784a2b233b0db9b-d0e5e4adc266f8aacd2ff78abb166d77.r51.cf2.rackcdn.com/templates/cog-03.jpg\" style=\"max-width:600px;margin:0 auto 0 auto;display:inline-block;\"/></p><h6 style=\"text-align:center;margin-top: 9px;\">COG Inc</h6><h6 style=\"text-align:center;\">589&#8203; Howard&#8203; Street&#8203;</h6><h6 style=\"text-align:center;\">San Francisco,&#8203; CA&#8203; 94105&#8203;</h6><h6 style=\"text-align:center;margin-top: 7px;\"><a href=\"--unsubscribe--\">unsubscribe</a></h6></td></tr></table></td></tr></table> </td></tr></table>";

			//Act
			var text = HelperMethods.HtmlToPlainText(htmlText);

			//Assert
			Assert.DoesNotContain(HelperMethods.stripFormatting, text);
			Assert.DoesNotContain(HelperMethods.lineBreak, text);
			Assert.DoesNotContain(HelperMethods.tagWhiteSpace, text);
		}
	}
}
