namespace CMP1903M_A02_2223.Game; 

/**
 * <summary>
 * A Utility class which holds on to all Game instances.
 * </summary>
 */
public class GameRegistry {

    public static readonly AbstractGame EASY_GAME = new EasyGame();
    public static readonly AbstractGame ADVANCED_GAME = new AdvancedGame();

}