using Moq;
using NUnit.Framework;
using PlayersManagerLib;

namespace PlayerManager.Tests;

[TestFixture]
public class PlayerTests
{
    private Mock<IPlayerMapper> _mockPlayerMapper;

    [OneTimeSetUp]
    public void Setup()
    {
        _mockPlayerMapper = new Mock<IPlayerMapper>();
    }

    [TestCase]
    public void RegisterNewPlayer_ShouldCreatePlayer()
    {
        // Arrange
        _mockPlayerMapper
            .Setup(x => x.IsPlayerNameExistsInDb(It.IsAny<string>()))
            .Returns(false);

        _mockPlayerMapper
            .Setup(x => x.AddNewPlayerIntoDb(It.IsAny<string>()));

        // Act
        Player player =
            Player.RegisterNewPlayer(
                "Virat",
                _mockPlayerMapper.Object);

        // Assert
        Assert.That(player, Is.Not.Null);
        Assert.That(player.Name, Is.EqualTo("Virat"));
        Assert.That(player.Age, Is.EqualTo(23));
        Assert.That(player.Country, Is.EqualTo("India"));
        Assert.That(player.NoOfMatches, Is.EqualTo(30));
    }

    [TestCase]
    public void RegisterNewPlayer_ShouldThrowException_WhenPlayerExists()
    {
        // Arrange
        _mockPlayerMapper
            .Setup(x => x.IsPlayerNameExistsInDb(It.IsAny<string>()))
            .Returns(true);

        // Act & Assert
        Assert.Throws<ArgumentException>(() =>
            Player.RegisterNewPlayer(
                "Virat",
                _mockPlayerMapper.Object));
    }
}