namespace CMP1903M_A02_2223.Game; 

/**
 * <summary>
 * IGame Interface
 * Represents a game which can be started. See <see cref="AbstractGame"/>
 * </summary>
 */
public interface IGame {

    /**
     * <summary>
     * Runs a new operator scene using the new score of the user, defined in <see cref="HandleRoundOver"/>.
     * This is implemented individually based on the game, as you can have either two or three card games.
     * </summary>
     */
    void RunGame() => RunGame(0);

    /**
     * <summary>
     * Prints the error associated with not picking a valid option in the round over screen.
     * </summary>
     */
    void RunGame(int score);

}