using CMP1903M_A02_2223.Util;

namespace CMP1903M_A02_2223.AO1 {

    /**
     * A simple class for a Randmo Instance and a shorthand Print function.
     **/
    public class Util {
        public static readonly Random RANDOM = new Random();
        public static void EnsurePackCount(Pack pack) {
            if (pack.Count != 52) {
                LogHandler.Print("The Pack must have 52 Cards in order to shuffle!");
                throw new Exception("The Pack must have 52 cards in order to shuffle!");
            }
        }
        
    }
}