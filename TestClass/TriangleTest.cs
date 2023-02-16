using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnitDemonstration;
using NUnit.Framework;

namespace TriangleTest
{
    public class TriangleTest
    {
        [TestFixture]

        public class TriangleTest1
        {

            [Test]

            public void TriangleEquilateral()
            {
                //ARRANGE
                int firstSide = 60;
                int secondSide = 60;
                int thirdSide = 60;

                string expected = "All sides are Equal, Hence Triangle is ISOSCELES";

                //ACT
                string actual = Triangle.AnalyzeTriangle(firstSide, secondSide, thirdSide);

                //ASSERT
                Assert.AreEqual(expected, actual);
            }
            [Test]
            public void TriangleIsosceles()
            {
                //ARRANGE
                int firstSide = 60;
                int secondSide = 20;
                int thirdSide = 60;

                string expected = "Two sides are Equal, Hence Triangle is ISOSCELES";

                //ACT
                string actual = Triangle.AnalyzeTriangle(firstSide, secondSide, thirdSide);

                //ASSERT
                Assert.AreEqual(expected, actual);
            }
            [Test]
            public void TriangleScalene()
            {
                //ARRANGE
                int firstSide = 10;
                int secondSide = 12;
                int thirdSide = 13;

                string expected = " All sides are different, Hence Triangle is SCALENE";

                //ACT
                string actual = Triangle.AnalyzeTriangle(firstSide, secondSide, thirdSide);

                //ASSERT
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void CheckIfEnteredValueIsInteger()
            {
                //ARRANGE
                int firstSide = 10;
                int secondSide = 12;
                int thirdSide =  10;
                

                string expected = "Please Enter a valid integer value!";

                //ACT
                string actual = Triangle.AnalyzeTriangle(firstSide, secondSide, thirdSide);

                //ASSERT
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void CheckIfAnyEnteredIntegerIsZero()
            {
                //ARRANGE
                int firstSide = 10;
                int secondSide = 12;
                int thirdSide = 50;

                string expected = "At least one side of your triangle has a zero length and is thus invalid";

                //ACT
                string actual = Triangle.AnalyzeTriangle(firstSide, secondSide, thirdSide);

                //ASSERT
                Assert.AreEqual(expected, actual);
            }
            [Test]
            public void CheckIfAnyEnteredIntegerIsNegative()
            {
                //ARRANGE
                int firstSide = 10;
                int secondSide = 12;
                int thirdSide = 10;

                string expected = " At least one side of your triangle has a negative length and is thus invalid";

                //ACT
                string actual = Triangle.AnalyzeTriangle(firstSide, secondSide, thirdSide);

                //ASSERT
                Assert.AreEqual(expected, actual);
            }


        }
    }
}
