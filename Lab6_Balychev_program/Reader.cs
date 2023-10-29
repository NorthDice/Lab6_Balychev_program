using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6_Balychev_program
{
    
        public class Reader
        {
            public static int GetValue()
            {
                return int.Parse(Console.ReadLine());
            }

            public static int GetValue(int minRange,int value, int maxRange)
            {
                int number = value;

                if (minRange > number || number > maxRange)
                    throw new OverflowException("Please, input number from the specified range!");

                return number;
            }
        }
    
}
