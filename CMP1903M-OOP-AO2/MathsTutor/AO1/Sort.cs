﻿namespace CMP1903M_A02_2223.AO1 {

    /**
     * <summary>
     * Basic structure for a Sort and the neccesary methods required.
     * In this case, it is just a <see cref="Sort(Pack)"/> method
     * used by our Pack class.
     * </summary>
     **/
    public interface Sort {
        bool Sort(Pack pack);
        string Name();
    }

     /**
     * <summary>
     * A No Shuffle Sort is the easiest in this file:
     * It does nothing.
     * <summary>
     */
     public class NoShuffleSort : Sort {
        public bool Sort(Pack pack) {
            // In this case, the bool represents if the pack has ACTUALLY been sorted,
            // So in this case it has not been sorted as it remains the same.
            Util.EnsurePackCount(pack);
            return false;
        }

        public string Name() {
            return "NoShuffle";
        }
    }


    /**
     * <summary>
     * A Fisher-Yates Shuffle is simple:
     * forEach card in the collection:
     *   - Pick a random Index
     *   - Flip the index1 card with the random index card
     * <summary>
     */
    public class FisherYatesShuffleSort : Sort {
        public bool Sort(Pack pack) {
            Util.EnsurePackCount(pack);
            foreach (var card in pack.ToList()) {
                var index = pack.IndexOf(card);
                var randomIndex = Util.RANDOM.Next(index, pack.Count);
                (pack[index], pack[randomIndex]) = (pack[randomIndex], pack[index]);
            }

            return true;
        }
        
        public string Name() {
            return "FisherYates";
        }
    }

    /**
     * <summary>
     * Riffle shuffle is the traditional card shuffle where you split the deck in two and put each card in one
     * after another, taking it in turns from each side of the split deck (usually LR, LR, LR....)
     * So this sort we need to split the deck and rejoin it by taking one from each side of the deck
     * </summary>
     */
    public class RiffleShuffleSort : Sort {
        public bool Sort(Pack pack) {
            Util.EnsurePackCount(pack);
            var halfDeckSize = pack.Count / 2;


            var left = pack.GetRange(0, halfDeckSize - 1);
            var right = pack.GetRange(halfDeckSize - 1, halfDeckSize - 1);

            var newDeck = new List<Card>();
            for (var i = 0; i < halfDeckSize -1; i++) {
                newDeck.Add(left[i]);
                newDeck.Add(right[i]);
            }

            pack.Clear();
            pack.AddRange(newDeck);

            return true;
        }
        
        public string Name() {
            return "Riffle";
        }
    }

    /**
     * <summary>
     * Sorts Class
     * This is a class designed for constants to be defined - In this case, our sorts.
     * It is also a place where the now deprecated Magic Values can be mapped to
     * NO_SHUFFLE, FISHER_YATES_SHUFFLE and RIFFLE_SHUFFLE easily by our codebase.
     * </summary>
     **/
    public class Sorts {
        public static readonly Sort NO_SHUFFLE = new NoShuffleSort();
        public static readonly Sort FISHER_YATES_SHUFFLE = new FisherYatesShuffleSort();
        public static readonly Sort RIFFLE_SHUFFLE = new RiffleShuffleSort();

        /**
         * <summary>
         * Gets the Sort instance associated to the supplied ID.
         * </summary>
         * <returns>
         * Returns the Sort from the ID, or if not present, NO_SHUFFLE
         * </returns>
         **/
        public static Sort GetSort(int sortId) {
            return GetSortOrDefault(sortId, NO_SHUFFLE);
        }

         /**
         * <summary>
         * Gets the Sort instance associated to the supplied ID. If there is no
         * sort mapped to the magic value, it will fallback to the defaultSort
         * parameter.
         * </summary>
         * <returns>
         * Returns the Sort from the ID or the fallback Sort.
         * </returns>
         **/
        public static Sort GetSortOrDefault(int sortId, Sort defaultSort) {
            switch (sortId) {
                case 1:
                    return FISHER_YATES_SHUFFLE;
                case 2:
                    return RIFFLE_SHUFFLE;
                case 3:
                    return NO_SHUFFLE;
                default:
                    return defaultSort;
            }
        }

         /**
         * <summary>
         * Gets the Sort ID associated with a Sort object. If the sort has no ID, it
         * will return the ID for no sort.
         * </summary>
         * <returns>
         * Returns the ID for the sort, or if it has no ID, the NO_SHUFFLE id.
         * </returns>
         **/
        public static int GetSortId(Sort sort) {
            if (sort is FisherYatesShuffleSort) {
                return 1;
            }
            else if (sort is RiffleShuffleSort) {
                return 2;
            }
            else {
                return 3; // No Shuffle
            }
        }
    }
}