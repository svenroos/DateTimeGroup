using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DateTimeGroup;



namespace DTGExample
{
    internal class DTGExample
    {
        public static void Main()
        {
            Console.WriteLine("Example for DTG");
            Console.WriteLine();
            Console.WriteLine();
            
            DateTime dt = new DateTime();
            dt = DateTime.Now;
            Console.WriteLine("Current local computer time:         " + dt.ToString());
            Console.WriteLine();
            Console.WriteLine("Current time as DTG for R:           " + dt.ToDTGString(DTG.DTGTimeZone.R));
            Console.WriteLine("Current time as DTG for Z:           " + dt.ToDTGString());
            Console.WriteLine("Current time as DTG for A:           " + dt.ToDTGString("A"));
            Console.WriteLine("Current time as DTG for D*:          " + dt.ToDTGString(DTG.DTGTimeZone.DSTAR));
            Console.WriteLine();
            Console.WriteLine("Current time as DTG for local (J):   " + dt.ToDTGString(DTG.DTGTimeZone.J));
            Console.WriteLine();

            while (true)
            {
                Console.WriteLine();
                Console.Write("Please input a time as DTG:          ");
                string? input = Console.ReadLine();

                if (DTG.IsValidDTG(input))
                {
                    dt = DateTimeExtension.FromDTGString(input);
                    Console.WriteLine("Date and time as UTC                 " + dt.ToString());
                    Console.Write("Date and time as DTG for Z           " + dt.ToDTGString());
                }
                else if (input.ToLower() == "exit")
                {
                    break;
                }
                else
                {
                    Console.Write("Not a valid DTG");
                }
            }


        }
    }
}