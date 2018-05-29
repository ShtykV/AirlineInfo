using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlTypes;
using AirlineInfo;

namespace AirlineInfo
{
    class PassengerInfo
    {
        
        public static void InitPassenger()
        {
            using (var airctx = new AirlineModel())
            {
                Passenger passenger = new Passenger();
                Console.WriteLine("-------Entering new passenger---------");
                char sw = 'y';
                while (sw == 'y')
                {
                    Console.WriteLine("Select flight: ");
                    Console.WriteLine("Select airport departure: " + '\n' +
                        "1)Kyiv" + '\n' +
                        "2)Lviv" + '\n' +
                        "3)Odessa" + '\n' +
                        "4)Kharkiv");
                    string departure = "";
                    switch (Convert.ToInt32(Console.ReadLine()))
                    {
                        case 1:
                            departure = "Kyiv";
                            break;
                        case 2:
                            departure = "Kharkiv";
                            break;
                        case 3:
                            departure = "Lviv";
                            break;
                        case 4:
                            departure = "Odessa";
                            break;
                    }
                    Console.WriteLine("Select airport arrival: " + '\n' +
                                        "1)Kyiv" + '\n' +
                                        "2)Lviv" + '\n' +
                                        "3)Odessa" + '\n' +
                                        "4)Kharkiv");
                    string arrival = "";
                    switch (Convert.ToInt32(Console.ReadLine()))
                    {
                        case 1:
                            arrival = "Kyiv";
                            break;
                        case 2:
                            arrival = "Kharkiv";
                            break;
                        case 3:
                            arrival = "Lviv";
                            break;
                        case 4:
                            arrival = "Odessa";
                            break;
                    }

                    var flight = from element in airctx.Flight
                                 where element.airport_arrival == arrival
                                 where element.airport_departure == departure
                                 select element;
                    if (flight.FirstOrDefault()!=null)
                    {
                        Console.WriteLine("ID---airport departure---time to departure-----airport arrival------time to arrival---------terminal------fligh status-----gate status-----type-----fare-------");
                        foreach (Flight a in flight)
                        {
                            string gs = "unknown";
                            FlightInfo.StatusCheck(a, gs);
                            Console.WriteLine("{0, 0} {1, 7}  {2, 33} {3, 8} {4, 33} {5, 18} {6, 9} {7, 12} {8, 12} {9, 13}", a.Id, a.airport_departure, a.departure_time, a.airport_arrival, a.arrival_time, a.terminal, a.flight_status, gs, a.type, a.fare);
                        }
                        passenger.Flight_Id = Convert.ToInt32(Console.ReadLine());
                    }
                    else
                    {
                        Console.WriteLine("Flight don't finded!"+'\n'+"Try again?(y/n)");
                        sw = Convert.ToChar(Console.ReadLine());
                    }
                }
                if (sw == 'y')
                {
                    Console.WriteLine("Enter full name: ");
                    passenger.full_name = Console.ReadLine();

                    Console.WriteLine("Enter nationality: ");
                    passenger.nationality = Console.ReadLine();

                    Console.WriteLine("Enter passport: ");
                    passenger.passport = Console.ReadLine();

                    Console.WriteLine("Enter date of birth: ");
                    passenger.date_of_birth = Convert.ToDateTime(Console.ReadLine());

                    Console.WriteLine("Enter sex: ");
                    passenger.sex = Console.ReadLine();

                    Console.WriteLine("Select class: " + '\n' +
                                        "1)business" + '\n' +
                                        "2)economy " + '\n');
                    switch (Convert.ToInt32(Console.ReadLine()))
                    {
                        case 1:
                            passenger._class = "business";
                            break;
                        case 2:
                            passenger._class = "economy ";
                            break;
                    }

                    Console.WriteLine("Enter seat: ");
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 1; j < 10; j++)
                        {
                            Console.Write(i + "" + j + " ");
                        }
                        Console.Write(i + 1 + "0");
                        if (i == 1) { Console.Write('\n'); }
                        Console.Write('\n');
                    }
                    passenger.seat = Convert.ToInt32(Console.ReadLine());
                    airctx.Passenger.Add(passenger);
                    airctx.SaveChanges();
                }
               
                Console.Clear();  
            }
            
        }
        public static void PassengerGet()
        {
            using (var airctx = new AirlineModel())
            {
                Console.WriteLine("ID--------Full name------nationality------passport------date of birth-------------sex-----class-----seat----flight");
                foreach (Passenger a in airctx.Passenger)
                {
                    Console.WriteLine("{0, 0} {1, 19}  {2, 4} {3, 21} {4, 24} {5, 9} {6, 11} {7, 5} {8, 5}", a.Id, a.full_name, a.nationality, a.passport, a.date_of_birth, a.sex, a._class, a.seat, a.Flight_Id);
                }
            }    
        }
    }
}
