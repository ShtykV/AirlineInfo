using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlTypes;

namespace AirlineInfo
{
    class FlightInfo
    {
        string gate_status = "close";
        string flight_status = "check-in";

        public static void InitFlight()
        {
            using (var airctx = new AirlineModel())
            {
                Flight flight = new Flight();
                flight.type = "N";
                Console.WriteLine("-------Entering new passenger---------");

                Console.WriteLine("Select airport departure: " + '\n' +
                    "1)Kyiv" + '\n' +
                    "2)Lviv" + '\n' +
                    "3)Odessa" + '\n' +
                    "4)Kharkiv");
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        flight.airport_departure = "Kyiv";
                        flight.type = "D";
                        break;
                    case 2:
                        flight.airport_departure = "Lviv";
                        break;
                    case 3:
                        flight.airport_departure = "Odessa";
                        break;
                    case 4:
                        flight.airport_departure = "Kharkiv";
                        break;
                }

                Console.WriteLine("Enter date and time to departure:" + '\n' + "(dd.mm.yyyy hh:mm:ss) ");
                flight.departure_time = Convert.ToDateTime(Console.ReadLine());

                Console.WriteLine("Select airport arrival: " + '\n' +
                "1)Kyiv" + '\n' +
                "2)Lviv" + '\n' +
                "3)Odessa" + '\n' +
                "4)Kharkiv");

                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        flight.airport_arrival = "Kyiv";
                        flight.type = "A";
                        break;
                    case 2:
                        flight.airport_arrival = "Kharkiv";
                        break;
                    case 3:
                        flight.airport_arrival = "Lviv";
                        break;
                    case 4:
                        flight.airport_arrival = "Odessa";
                        break;
                }

                Console.WriteLine("Enter date and time to arrival:" + '\n' + "(dd.mm.yyyy hh:mm:ss) ");
                flight.arrival_time = Convert.ToDateTime(Console.ReadLine());

                Console.WriteLine("Select terminal: " + '\n' +
                   "1)A" + '\n' +
                   "2)B" + '\n');
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        flight.terminal = "A";
                        break;
                    case 2:
                        flight.terminal = "B";
                        break;
                }

                Console.WriteLine("Enter fare: ");
                flight.fare = Convert.ToDecimal(Console.ReadLine());

                airctx.Flight.Add(flight);

                airctx.SaveChanges();
            }

            Console.Clear();
        }
        public static void FlightGet()
        {
            using (var airctx = new AirlineModel())
            {
                Console.WriteLine("ID---airport departure---time to departure-----airport arrival------time to arrival---------terminal------fligh status-----gate status-----type-----fare-------");
                foreach (Flight a in airctx.Flight)
                {
                    string gs="unknown";
                    StatusCheck(a, gs);
                    Console.WriteLine("{0, 0} {1, 7}  {2, 33} {3, 8} {4, 33} {5, 18} {6, 9} {7, 12} {8, 12} {9, 13}", a.Id, a.airport_departure, a.departure_time, a.airport_arrival, a.arrival_time, a.terminal, a.flight_status, gs, a.type, a.fare);
                }
            }

        }
        public static void StatusCheck(Flight a,  string gs)
        {
            DateTime d = new DateTime();
            if (d< a.departure_time)
            {
                a.flight_status = "check-in";
            }
            else if(d>a.departure_time && d < a.arrival_time)
            {
                a.flight_status = "in flight";
                gs = "close";
            }
            if (d.Day==a.departure_time.Day && d.Hour==a.departure_time.Hour-1)
            {
                gs = "open";
            }
            // Console.WriteLine("Gate status is " + gate_status);
        }
    }
}
