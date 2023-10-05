using System.Security.Cryptography.X509Certificates;
using Archivos;
using Xunit;


public class VocalCounterTests
{
    [Fact]
    public void CountVocals_EmptyString_ReturnsEmptyString()
    {
        // Arrange
        string content = "";

        // Act
        VocalCounter.CountVocals(ref content);

        // Assert
        Assert.Equal("", content);
    }

    [Fact]
    public void CountVocals_NoVocals_ReturnsOriginalString()
    {
        // Arrange
        string content = "Brrr! Crypts Gym";

        // Act
        VocalCounter.CountVocals(ref content);

        // Assert
        Assert.Equal("Brrr! Crypts Gym", content);
    }

    [Fact]
    public void CountVocals_SingleVocal_ReturnsStringWithCount()
    {
        // Arrange
        string content = "hi gym";

        // Act
        VocalCounter.CountVocals(ref content);

        // Assert
        Assert.Equal("h1 gym", content);
    }

    [Fact]
    public void CountVocals_ReplacesVocalsWithCount()
    {
        // Arrange
        string content = "This is a test string with some vocals";
        string expected = "This is a test string w4th som2 v2c2ls";

        // Act
        VocalCounter.CountVocals(ref content);

        // Assert
        Assert.Equal(expected, content);
    }

    [Fact]

    public void CountVocals_ReplacesVocalWithSingleString()
    {
        // Arrange
        string content = "a";
        string expected = "1";

        // Act
        VocalCounter.CountVocals(ref content);

        // Assert
        Assert.Equal(expected, content);
    }

}
