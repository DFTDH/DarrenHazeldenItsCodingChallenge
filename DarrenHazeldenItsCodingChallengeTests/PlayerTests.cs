namespace DarrenHazeldenItsCodingChallengeTests;

using DarrenHazeldenItsCodingChallenge.Classes;

[TestFixture]
public class PlayerTests
{
    [Test]
    public void TestUpdatePosition()
    {
        // Arrange
        var player = new Player(2, 3);

        // Act
        player.UpdatePosition(4, 5);

        // Assert
        Assert.That(player.Row, Is.EqualTo(4));
        Assert.That(player.Column, Is.EqualTo(5));
    }
}