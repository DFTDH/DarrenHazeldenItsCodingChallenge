namespace DarrenHazeldenItsCodingChallengeTests;

using DarrenHazeldenItsCodingChallenge.Classes;

[TestFixture]
public class GameBoardTests
{
    [Test]
    public void TestMovePlayer_ValidMove()
    {
        // Arrange
        var gameBoard = new GameBoard(8, 0, 0);
        var player = new Player(0, 0);

        // Act
        bool moveResult = gameBoard.MovePlayer(player, 'U');

        // Assert
        Assert.IsTrue(moveResult);
        Assert.That(player.Row, Is.EqualTo(1));
    }

    [Test]
    public void TestMovePlayer_OutOfBounds()
    {
        // Arrange
        var gameBoard = new GameBoard(8, 0, 0);
        var player = new Player(7, 7);

        // Act
        var moveResult = gameBoard.MovePlayer(player, 'R');

        // Assert
        Assert.IsFalse(moveResult);
        Assert.That(player.Column, Is.EqualTo(7)); // Player position should not change
    }

    [Test]
    public void TestIsGameWon_GameNotWon()
    {
        // Arrange
        var gameBoard = new GameBoard(8, 0, 0);
        var player = new Player(0, 0);

        // Act
        var gameWon = gameBoard.IsGameWon(player.Row);

        // Assert
        Assert.IsFalse(gameWon);
    }

    [Test]
    public void TestIsGameWon_GameWon()
    {
        // Arrange
        var gameBoard = new GameBoard(8, 0, 0);
        var player = new Player(7, 0);

        // Act
        var gameWon = gameBoard.IsGameWon(player.Row);

        // Assert
        Assert.IsTrue(gameWon);
    }
    
    [Test]
    public void TestSetupLandmines()
    {
        // Arrange
        var boardSize = 8;
        var minLandmines = 5;
        var maxLandmines = 15;
        var gameBoard = new GameBoard(boardSize, minLandmines, maxLandmines);

        // Act
        var totalLandmines = 0;
        for (var row = 0; row < boardSize; row++)
        {
            for (var col = 0; col < boardSize; col++)
            {
                totalLandmines += gameBoard.GetSquareValue(row, col);
            }
        }

        // Assert
        Assert.GreaterOrEqual(totalLandmines, minLandmines);
        Assert.LessOrEqual(totalLandmines, maxLandmines);
    }
    
    [Test]
    public void TestMovePlayer_HitOneLandmine()
    {
        // Arrange
        var gameBoard = new GameBoard(8, 0, 0);
        Player player = new Player(0, 0);

        // Force a landmine hit
        gameBoard.SetSquareValue(0, 1, 1);

        // Act
        bool moveResult = gameBoard.MovePlayer(player, 'R');

        // Assert
        Assert.IsTrue(moveResult); 
        Assert.That(gameBoard.GetLandminesHitCount(), Is.EqualTo(1));
        Assert.IsFalse(gameBoard.IsGameOver());
    }
    
    [Test]
    public void TestMovePlayer_HitThreeLandmines()
    {
        // Arrange
        var gameBoard = new GameBoard(8, 0, 0);
        Player player = new Player(0, 0);

        // Force a landmine hit
        gameBoard.SetSquareValue(0, 1, 1);
        gameBoard.SetSquareValue(0, 2, 1);
        gameBoard.SetSquareValue(0, 3, 1);

        // Act
        bool moveResult1 = gameBoard.MovePlayer(player, 'R');
        bool moveResult2 = gameBoard.MovePlayer(player, 'R');
        bool moveResult3 = gameBoard.MovePlayer(player, 'R');

        // Assert
        Assert.IsTrue(moveResult1); 
        Assert.IsTrue(moveResult2); 
        Assert.IsTrue(moveResult3); 
        Assert.That(gameBoard.GetLandminesHitCount(), Is.EqualTo(3));
        Assert.IsTrue(gameBoard.IsGameOver());
    }

}