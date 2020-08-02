using System;
using Bouvet_CodeSmells;
using Xunit;

namespace CodeSmellsTests
{
    public class PubPricesTest
    {
        [Fact]
        public void Test1()
        {

        }

        private Pub pub;

        public PubPricesTest()
        {
            pub = new Pub();
        }

        [Fact]
        public void oneBeerTest()
        {
            int actualPrice = pub.ComputeCost(Pub.ONE_BEER, false, 1);
            Assert.Equal(74, actualPrice);
        }

        [Fact]
        public void testStudentsGetADiscountForBeer()
        {
            int actualPrice = pub.ComputeCost(Pub.ONE_BEER, true, 1);
            Assert.Equal(67, actualPrice);
        }

        [Fact]
        public void testCidersAreCostly()
        {
            int actualPrice = pub.ComputeCost(Pub.ONE_CIDER, false, 1);
            Assert.Equal(103, actualPrice);
        }

        [Fact]
        public void testProperCidersAreEvenMoreExpensive()
        {
            int actualPrice = pub.ComputeCost(Pub.A_PROPER_CIDER, false, 1);
            Assert.Equal(110, actualPrice);
        }

        [Fact]
        public void testACocktail()
        {
            int actualPrice = pub.ComputeCost(Pub.GT, false, 1);
            Assert.Equal(115, actualPrice);
        }

        [Fact]
        public void testThatADrinkNotInTheSortimentGivesError()
        {
            Assert.Throws<ArgumentException>(() => pub.ComputeCost("sanfranciscosling", false, 1));
        }

        [Fact]
        public void testStudentsDoNotGetDiscountsForCocktails()
        {
            int actualPrice = pub.ComputeCost(Pub.GT, true, 1);
            Assert.Equal(115, actualPrice);
        }

        [Fact]
        public void testBacardiSpecial()
        {
            int actualPrice = pub.ComputeCost(Pub.BACARDI_SPECIAL, false, 1);
            Assert.Equal(127, actualPrice);
        }

        [Fact]
        public void testCanBuyAtMostTwoDrinksInOneGo()
        {
            Assert.Throws<ArgumentException>(() => pub.ComputeCost(Pub.BACARDI_SPECIAL, false, 3));
        }

        [Fact]
        public void testStudentsGetDiscountsWhenOrderingMoreThanOneBeer()
        {
            int actualPrice = pub.ComputeCost(Pub.ONE_BEER, true, 2);
            Assert.Equal(67 * 2, actualPrice);
        }

        [Fact]
        public void testCanOrderMoreThanTwoBeers()
        {
            pub.ComputeCost(Pub.ONE_BEER, false, 5);
        }
    }
}
