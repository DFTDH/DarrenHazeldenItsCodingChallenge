using DarrenHazeldenItsCodingChallenge.Classes;
using DarrenHazeldenItsCodingChallenge.Interfaces;

const int boardSize = 8;
const int minLandmines = 5;
const int maxLandmines = 15;

IGameBoard gameBoard = new GameBoard(boardSize, minLandmines, maxLandmines);
IPlayer player = new Player(0, 0);

while (!gameBoard.IsGameOver())
{
    Console.WriteLine($"Current Position: Row {player.Row}, Col {player.Column}");
    
    Console.WriteLine("Enter move (U/D/L/R): ");
    var move = Console.ReadKey().KeyChar;

    if (gameBoard.MovePlayer(player, move))
    {
        player.UpdatePosition(player.Row, player.Column);

        if (gameBoard.IsGameWon(player.Row))
        {
            Console.WriteLine($"Congratulations! You have reached the final row and only hit {gameBoard.GetLandminesHitCount()} mines. You win!");
            break;
        }
        
        Console.WriteLine(gameBoard.GetLandminesHitCount() > 2 ? "Game Over! You hit too many landmines!" : $"\nLandmines hit: {gameBoard.GetLandminesHitCount()}");
    }
    else
    {
        Console.WriteLine("Invalid move. Please try again.");
    }

    Console.WriteLine("Press Enter to Continue.");
    Console.ReadLine();
}