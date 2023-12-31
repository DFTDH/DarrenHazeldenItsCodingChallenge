namespace DarrenHazeldenItsCodingChallenge.Interfaces;

/// <summary>
/// Controls the Player object
/// </summary>
public interface IPlayer
{
    /// <summary>
    /// The current player Row position
    /// </summary>
    int Row { get; }
    
    /// <summary>
    /// The current player Column position
    /// </summary>
    int Column { get; }
    
    /// <summary>
    /// Updates player position with new input
    /// </summary>
    /// <param name="newRow"></param>
    /// <param name="newColumn"></param>
    void UpdatePosition(int newRow, int newColumn);
}