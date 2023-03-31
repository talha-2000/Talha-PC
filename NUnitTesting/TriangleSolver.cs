using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleSolver
{
    public class Triangle
    {
        public string AnalyzeTriangle(int firstSide, int secondSide, int thirdSide)
        {
            string output;
            if ((firstSide == 0) || (secondSide == 0) || (thirdSide == 0))
            {
                output = "At least one side of your triangle has a zero length and is thus invalid";
                return output;
            }

            if (((firstSide + secondSide) > thirdSide) && ((firstSide + thirdSide) > secondSide) && ((secondSide + thirdSide) > firstSide))
            {
                if ((firstSide == secondSide) && (firstSide == thirdSide) && (secondSide == thirdSide))
                {
                    output = "Based on all sides being equal, the type of triangle is an EQUILATERAL";
                }
                else if ((firstSide == secondSide) || (secondSide == thirdSide) || (thirdSide == firstSide))
                {
                    output = "Based on two sides being equal, the type of triangle is an ISOSCELES";

                }
                else
                {
                    output = "Based on all three sides being different, the type of triangle is a SCALENE";

                }


            }
            else
            {
                output = "Based on the values entered, the triangle is INVALID";
            }


            return output;
        }
    }
}


