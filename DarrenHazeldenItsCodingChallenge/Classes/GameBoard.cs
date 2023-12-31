namespace DarrenHazeldenItsCodingChallenge.Classes;

using DarrenHazeldenItsCodingChallenge.Interfaces;

/// <summary>
/// Game board - controls the gameboard and the overall game itself
/// </summary>
public class GameBoard : IGameBoard
{
    /// <summary>
    /// The game board, a 2d array.
    /// An entry populated with 1 is a space with a landmine
    /// </summary>
    private int[,] Board;
    
    /// <summary>
    /// Size of the game board
    /// Square board so total size of the array is Size x Size
    /// </summary>
    private int Size { get; }
    
    /// <summary>
    /// How many landmines are on the game board total
    /// </summary>
    private int Landmines { get; }
    
    /// <summary>
    /// How many landmines have been hit in the active game
    /// </summary>
    private int LandminesHit { get; set; }
    
    /// <summary>
    /// True if Game is Over, False otherwise
    /// </summary>
    private bool GameOver { get; set; }

    /// <summary>
    /// GameBoard Constructor
    /// </summary>
    /// <param name="size"></param>
    /// <param name="minLandmines"></param>
    /// <param name="maxLandmines"></param>
    public GameBoard(int size, int minLandmines, int maxLandmines)
    {
        Size = size;
        Landmines = new System.Random().Next(minLandmines, maxLandmines + 1); // Generate a random number of landmines within the range provided
        LandminesHit = 0;
        GameOver = false;
        Board = new int[size, size]; 
        SetupLandmines(Landmines);
    }

    /// <summary>
    /// Randomly populates the array with the given number of landmines
    /// </summary>
    /// <param name="landmines"></param>
    private void SetupLandmines(int landmines)
    {
        var random = new System.Random();
        for (var i = 0; i < landmines; i++)
        {
            var row = random.Next(Size);
            var column = random.Next(Size);
            Board[row, column] = 1; // 1 indicates a landmine in the square
        }
    }

    /// <summary>
    /// Returns True if Game Is Over
    /// </summary>
    public bool IsGameOver()
    {
        return GameOver;
    }

    /// <summary>
    /// Returns True if player has won the game
    /// </summary>
    /// <param name="playerRow"></param>
    public bool IsGameWon(int playerRow)
    {
        return playerRow == (Size - 1); //Player row count starts at 0
    }

    /// <summary>
    /// Returns how many landmines the player has hit
    /// </summary>
    public int GetLandminesHitCount()
    {
        return LandminesHit;
    }
    
    /// <summary>
    /// Gets the value of a provided square on the board
    /// If 1, it is a landmine
    /// </summary>
    /// <param name="row"></param>
    /// <param name="column"></param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public int GetSquareValue(int row, int column)
    {
        if (row < 0 || row >= Size || column < 0 || column >= Size)
        {
            throw new ArgumentOutOfRangeException();
        }

        return Board[row, column];
    }
    
    /// <summary>
    /// Sets the value of a provided square on the board
    /// If 1, it is a landmine
    /// </summary>
    /// <param name="row"></param>
    /// <param name="column"></param>
    /// <param name="value"></param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public void SetSquareValue(int row, int column, int value)
    {
        if (row < 0 || row >= Size || column < 0 || column >= Size)
        {
            throw new ArgumentOutOfRangeException();
        }

        Board[row, column] = value;
    }


    /// <summary>
    /// Moves the provided player object with the provided move
    /// Returns False if the move couldn't be made for any reason
    /// </summary>
    /// <param name="player"></param>
    /// <param name="move"></param>
    public bool MovePlayer(IPlayer player, char move)
    {
        // Player cannot move further if game is over
        if (GameOver)
        {
            return false;
        }
        
        var newRow = player.Row;
        var newColumn = player.Column;

        switch (move)
        {
            case 'U':
                newRow++;
                break;
            case 'D':
                newRow--;
                break;
            case 'L':
                newColumn--;
                break;
            case 'R':
                newColumn++;
                break;
            default:
                return false; //Player entered invalid move
        }
        
        if (newRow < 0 || newRow >= Size || newColumn < 0 || newColumn >= Size)
        {
            return false; // Player out of bounds
        }
        
        if (Board[newRow, newColumn] == 1) // Check for a landmine
        {
            LandminesHit++;
            if (LandminesHit > 2)
            {
                GameOver = true; // Game lost if more than 2 landmines are hit
            }
        }
        
        player.UpdatePosition(newRow, newColumn);

        return true;
    }
}