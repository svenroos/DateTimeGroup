using System;
using DateTimeGroupExtension;



namespace DTGExample
{
    internal class DTGExample
    {
        public static void Main()
        {      
            DateTime dt = DateTime.Now;
            Console.WriteLine("DateTimeGroup Example");
            Console.WriteLine();
            Console.WriteLine("Current local computer time:                 " + dt.ToLocalTime().ToString());
            Console.WriteLine();
            Console.WriteLine("Current time as DTG for Z:                   " + dt.ToDTGString());
            Console.WriteLine("Current time as DTG for R:                   " + dt.ToDTGString("R"));
            Console.WriteLine("Current time as DTG for A:                   " + dt.ToDTGString("A"));
            Console.WriteLine("Current time as DTG for D*:                  " + dt.ToDTGString("D*"));
            Console.WriteLine("Current time as DTG for local (J):           " + dt.ToDTGString("J"));
            Console.WriteLine();

            while (true)
            {
                Console.WriteLine();
                Console.Write("Please input a time as DTG:                  ");
                string? inputdtg = Console.ReadLine();

                if (string.IsNullOrEmpty(inputdtg))
                {
                    inputdtg = "";
                }

                if (inputdtg.ToLower() == "exit")
                {
                    break;
                }

                if (!DateTimeGroup.IsValidDTG(inputdtg))
                {
                    Console.Write("\"" + inputdtg + "\" is not a valid DTG");
                    Console.WriteLine();
                }
                else
                { 
                    Console.Write("Please input a DTG TimeZone (default: Z):    ");
                    string? inputtz = Console.ReadLine();

                    if (string.IsNullOrEmpty(inputtz))
                    {
                        inputtz = "Z";
                    }

                    if (!DateTimeGroup.IsValidTimeZone(inputtz))
                    {
                        Console.Write("\"" + inputtz + "\" is not a valid timezone");
                        Console.WriteLine();
                    }
                    else
                    {
                        dt = DateTimeGroupExtension.DateTimeExtension.FromDTGString(inputdtg);
                        Console.WriteLine("Date and time as DTG for Z                   " + dt.ToDTGString());
                        Console.WriteLine("Date and time as DTG for " + inputtz + "                   " + dt.ToDTGString(inputtz));
                        Console.WriteLine("Date and Time in Operating System Local Time " + dt.ToLocalTime().ToString());
                        Console.WriteLine("Date and time as UTC                         " + dt.ToString());
                        Console.WriteLine();
                    }
                   
                }
            }
        }
    }
}