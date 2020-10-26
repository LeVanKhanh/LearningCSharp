using Common.Regrex;
using Xunit;

namespace Common.Tests.RegrexTests
{
    public class ExcludingSpecificCharactersTests
    {
        [Theory]
        [InlineData(@"$")]
        [InlineData(@"@")]
        [InlineData(@"~")]
        [InlineData(@";")]
        [InlineData(@"'")]
        [InlineData(@"+")]
        [InlineData(@"=")]
        [InlineData(@",")]
        [InlineData(@">")]
        [InlineData(@"<")]
        [InlineData(@"|")]
        [InlineData(@"/")]
        [InlineData(@"\")]
        [InlineData(@"?")]
        [InlineData(@":")]
        [InlineData(@"&")]
        [InlineData(@"*")]
        [InlineData(@"""")]
        [InlineData(@"#")]
        [InlineData(@"[")]
        [InlineData(@"]")]
        ///@ ~ ;  ' + = , < > | / \ ? : & $ * " # [ ]
        public void Excluding_ExcludeRegrexCharacters_InvalidText(string specialChar)
        {
            var excludingSpecificCharacters = new Excluding();
            var isValidWithSpecialChartAtTheEnd = excludingSpecificCharacters.ExcludeRegrexCharacters($"Start{specialChar}");
            var isValidWithSpecicalChartAtTheStart = excludingSpecificCharacters.ExcludeRegrexCharacters($"{specialChar}End");
            var isValidWithSpecicalChartInTheMidle = excludingSpecificCharacters.ExcludeRegrexCharacters($"Start{specialChar}End");
            Assert.False(isValidWithSpecialChartAtTheEnd);
            Assert.False(isValidWithSpecicalChartAtTheStart);
            Assert.False(isValidWithSpecicalChartInTheMidle);
        }

        [Theory]
        [InlineData(")")]
        [InlineData("(")]
        [InlineData("}")]
        [InlineData("{")]
        [InlineData("%")]
        [InlineData("-")]
        [InlineData(".")]
        [InlineData("`")]
        public void Excluding_ExcludeRegrexCharacters_Invalid(string text)
        {
            var excludingSpecificCharacters = new Excluding();
            string normalText = "abcdefghijklmnopqrstuvwxyz";
            var isValidWithSpecialChartAtTheEnd = excludingSpecificCharacters.ExcludeRegrexCharacters($"{normalText} {text}");
            var isValidWithSpecicalChartAtTheStart = excludingSpecificCharacters.ExcludeRegrexCharacters($"{text} {normalText}");
            var isValidWithSpecicalChartInTheMidle = excludingSpecificCharacters.ExcludeRegrexCharacters($"{normalText} {text} {normalText}");
            Assert.True(isValidWithSpecialChartAtTheEnd);
            Assert.True(isValidWithSpecicalChartAtTheStart);
            Assert.True(isValidWithSpecicalChartInTheMidle);
        }
    }
}
