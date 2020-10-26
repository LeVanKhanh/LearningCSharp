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

        [Fact]
        public void Excluding_ExcludeRegrexCharacters_ValidText()
        {
            var excludingSpecificCharacters = new Excluding();
            string normalText = "abcdefghijklmnopqrstuvwxyz(){}%-_.`";
            var isValidWithLowerCase = excludingSpecificCharacters.ExcludeRegrexCharacters(normalText);
            var isValidWithUpperCase = excludingSpecificCharacters.ExcludeRegrexCharacters(normalText.ToUpper());
            Assert.True(isValidWithLowerCase);
            Assert.True(isValidWithUpperCase);
        }
    }
}
