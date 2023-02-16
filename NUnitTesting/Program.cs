using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitDemonstration
{
    public class Program
    {
        public static void Main()
        {
           
            string customTriangle;

            int firstSide;
            int secondSide;
            int thirdSide;
            Console.Write("\n\n");
            Console.Write("Triangle Solver\n");
            Console.Write("--------------------------------------------------------\n");
            Console.Write("Enter three integers to check the Triangle");
            Console.Write("\n\n");

            Console.WriteLine("Please Enter the first Integer: ");
            while (!int.TryParse(Console.ReadLine(), out firstSide))
            {
                Console.WriteLine("Please Enter a valid integer value!");

            }

            Console.WriteLine("Please Enter the second Integer: ");
            while (!int.TryParse(Console.ReadLine(), out secondSide))
            {
                Console.WriteLine("Please Enter a valid integer value!");

            }

            Console.WriteLine("Please Enter the third Integer: ");
            while (!int.TryParse(Console.ReadLine(), out thirdSide))
            {
                Console.WriteLine("Please Enter a valid integer value!");

            }


            customTriangle = Triangle.AnalyzeTriangle(firstSide, secondSide, thirdSide);

            Console.WriteLine(customTriangle);
            Console.WriteLine();
            Console.ReadLine();
           

        }
    }
}