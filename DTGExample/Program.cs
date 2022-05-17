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
            Console.WriteLine("Current time as DTG for Z: " + dt.ToDTGString());

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Please input a time as DTG: ");
                string? input = Console.ReadLine();

                if (DTG.IsValidDTG(input))
                {
                    dt = DTG.FromString(input);
                    Console.WriteLine("Input date and time as UTC " + dt.ToString());
                }
                else
                {
                    Console.WriteLine("Not a valid DTG");
                }
            }


        }
    }
}