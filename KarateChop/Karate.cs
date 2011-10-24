using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KarateChop
{
    public static class Karate
    {
        public static int Chop(int searchValue, int[] intArray)
        {
            for (int i = 0; i < intArray.Length; i++)
            {
                if (intArray[i].Equals(searchValue))
                    return i;
            }

            return -1;
        }
        public static int ChopRecursive(int value, int[] intArray)
        {
            var interval = GetInterval(value, intArray, 0, intArray.Length);

            while (true)
            {
                if (intArray[interval.Item1] == value)
                    return interval.Item1;

                if (intArray[interval.Item2] == value)
                    return interval.Item2;

                if (interval.Item1 == interval.Item2)
                {
                    if (intArray[interval.Item1] == value)
                        return interval.Item1;
                    
                    return -1;
                }

                interval = GetInterval(value, intArray, interval.Item1, interval.Item2);
            }
        }

        private static Tuple<int, int> GetInterval(int value, int[] intArray, int startindex, int slutindex)
        {
            var iMitten = startindex + ((slutindex - startindex) / 2);

            if (iMitten <= startindex)
                return new Tuple<int, int>(startindex, slutindex-1);

            if (iMitten >= slutindex)
                return new Tuple<int, int>(startindex+1, slutindex);

            if (intArray[iMitten] > value)
                return new Tuple<int, int>(startindex, iMitten);

            return new Tuple<int, int>(iMitten, slutindex);
        }



    }
}
