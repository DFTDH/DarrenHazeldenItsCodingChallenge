namespace DarrenHazeldenItsCodingChallenge.Interfaces;

/// <summary>
/// Game board - controls the gameboard and the overall game itself
/// </summary>
public interface IGameBoard
{
    /// <summary>
    /// Returns True if Game Is Over
    /// </summary>
    bool IsGameOver();
    
    /// <summary>
    /// Returns True if player has won the game
    /// </summary>
    /// <param name="playerRow"></param>
    bool IsGameWon(int playerRow);
    
    /// <summary>
    /// Moves the provided player object with the provided move
    /// Returns False if the move couldn't be made for any reason
    /// </summary>
    /// <param name="player"></param>
    /// <param name="move"></param>
    bool MovePlayer(IPlayer player, char move);
    
    /// <summary>
    /// Returns how many landmines the player has hit
    /// </summary>
    int GetLandminesHitCount();
}