using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Xunit.Sdk;

namespace KarateChop.Tests
{
    public class KarateChopForLoopTests
    {
        private int[] intArray;

        private static void Chop(int search, int[] intArray, int index)
        {
            Assert.Equal(index, Karate.Chop(search, intArray));
        }

        [Fact]
        public void EmtyArray_Returns_minus1()
        {
            Assert.Equal(-1, Karate.Chop(1, new int[] { }));
        }

        [Fact]
        public void NoHit_Returns_minus1()
        {
            Assert.Equal(-1, Karate.Chop(1, new int[] { 3 }));

        }

        [Fact]
        public void Hit_Returns_Index()
        {
            intArray = new int[] { 1 };
            Chop(1, intArray, 0);
        }

        [Fact]
        public void Hit_Returns_Index_Three_Field_Array()
        {
            intArray = new int[] { 1, 3, 5 };
            Chop(3, intArray, 1);
        }

    }
    public class KarateChopTheRealChopTests
    {
        private int[] intArray;
        /// <summary>
        /// Initializes a new instance of the KarateChopTheRealChopTests class.
        /// </summary>
        
        public KarateChopTheRealChopTests()
        {
            intArray = CreateArray(5000);
        }

        private int[] CreateArray(int positioner)
        {
            var numberlist = new List<int>();

            for (int i = 0; i < positioner; i++)
            {
                if (i % 2 == 0)
                    numberlist.Add(i);
            }

            numberlist.Sort();
            return numberlist.ToArray();
        }

        [Fact]
        public void Zero_returns_minus1()
        {
            Assert.Equal(-1, Karate.ChopRecursive(0, intArray));
        }

        [Fact]
        public void Ten_returns_Index_four()
        {
            Assert.Equal(4, Karate.ChopRecursive(10, intArray));
        }
    }
}
