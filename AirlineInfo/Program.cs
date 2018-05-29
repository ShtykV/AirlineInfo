using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            int s = 0;
            bool menu = true;
            while (menu)
            {
                Console.WriteLine("Menu of Airport 'Kyiv'" + '\n' +
                "1)Add flight" + '\n' +
                "2)Add passenger" + '\n' +
                "3)Show flight" + '\n' +
                "4)Show passenger" + '\n' +
                "5)Exit");
                s = Convert.ToInt32(Console.ReadLine());
                switch (s)
                {
                    case 1:
                        FlightInfo.InitFlight();
                        break;
                    case 2:
                        PassengerInfo.InitPassenger();
                        break;
                    case 3:
                        FlightInfo.FlightGet();
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 4:
                        PassengerInfo.PassengerGet();
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 5:
                        menu = false;
                        break;
                }
            }
        }
    }
}
