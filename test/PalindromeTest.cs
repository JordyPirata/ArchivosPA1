using Archivos;
using Xunit;


public class PalindromeTests
{
    [Fact]
    public void IsPalindrome_ReturnsTrue_ForPalindrome()
    {
        // Arrange
        var word = "racecar";

        // Act
        var result = Palindrome.IsPalindrome(word);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsPalindrome_ReturnsFalse_ForNonPalindrome()
    {
        // Arrange
        var word = "hello";

        // Act
        var result = Palindrome.IsPalindrome(word);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void MaximumPalindrome_ReturnsCorrectResult_ForMultiplePalindromes()
    {
        // Arrange
        var content = "level radar civic kayak";

        // Act
        var result = Palindrome.MaximumPalindrome(ref content);

        // Assert
        Assert.Equal(5, result.Item1);
        Assert.Equal("level", result.Item2);
    }

    [Fact]
    public void MaximumPalindrome_ReturnsCorrectResult_ForSinglePalindrome()
    {
        // Arrange
        var content = "hello world racecar";

        // Act
        var result = Palindrome.MaximumPalindrome(ref content);

        // Assert
        Assert.Equal(7, result.Item1);
        Assert.Equal("racecar", result.Item2);
    }

    [Fact]
    public void MaximumPalindrome_ReturnsCorrectResult_ForNoPalindromes()
    {
        // Arrange
        var content = "hello world";

        // Act
        var result = Palindrome.MaximumPalindrome(ref content);

        // Assert
        Assert.Equal(0, result.Item1);
        Assert.Equal("", result.Item2);
    }
}
