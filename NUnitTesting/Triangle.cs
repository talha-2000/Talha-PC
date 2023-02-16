using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitDemonstration
{
    public static class Triangle
    {

       public static string AnalyzeTriangle(int firstSide, int secondSide, int thirdSide)
        {
            string output;
            string input = " ";



            if ((firstSide <= 0) || (secondSide <= 0) || (thirdSide <= 0))
            {
                return output = "At least one side of your triangle has a negative length and is thus invalid";
               
            }
            
         


            if ((firstSide == 0) || (secondSide == 0) || (thirdSide == 0))
            {
               return  output = "At least one side of your triangle has a zero length and is thus invalid";
               
            }

                if (((firstSide + secondSide) > thirdSide) && ((firstSide + thirdSide) > secondSide) && ((secondSide + thirdSide) > firstSide))
                {
                    if ((firstSide == secondSide) && (firstSide == thirdSide) && (secondSide == thirdSide))
                    {
                       return output = "All sides are Equal, Hence Triangle is ISOSCELES";
                        
                         
                        
                    }
                    else if ((firstSide == secondSide) || (secondSide == thirdSide) || (thirdSide == firstSide))
                    {
                       return output = "Two sides are Equal, Hence Triangle is ISOSCELES";


                }
                    else
                    {
                        return output = " All sides are different, Hence Triangle is SCALENE";
                   

                    }


                }
                else
                {
                   return output = "Based on the values entered, the triangle is INVALID";
               
                }

            Console.ReadLine();

            


            

           


        }

    }
}
