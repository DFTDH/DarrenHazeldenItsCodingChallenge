namespace DarrenHazeldenItsCodingChallenge.Classes;

using DarrenHazeldenItsCodingChallenge.Interfaces;

/// <summary>
/// Controls the Player object
/// </summary>
public class Player : IPlayer
{
    /// <summary>
    /// The current player Row position
    /// </summary>
    public int Row { get; private set; }
    
    /// <summary>
    /// The current player Column position
    /// </summary>
    public int Column { get; private set; }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="row"></param>
    /// <param name="column"></param>
    public Player(int row, int column)
    {
        Row = row;
        Column = column;
    }
    
    /// <summary>
    /// Updates player position with new input
    /// </summary>
    /// <param name="newRow"></param>
    /// <param name="newColumn"></param>
    public void UpdatePosition(int newRow, int newColumn)
    {
        Row = newRow;
        Column = newColumn;
    }
}