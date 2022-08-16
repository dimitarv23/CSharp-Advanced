using System;
using System.Collections.Generic;
using System.Linq;

namespace P08.SoftUniParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> invited = new HashSet<string>();
            bool hasPartyStarted = false;

            string reservationNumber = Console.ReadLine();
            while (reservationNumber != "END")
            {
                if (reservationNumber == "PARTY")
                {
                    hasPartyStarted = true;
                    reservationNumber = Console.ReadLine();
                    continue;
                }

                if (hasPartyStarted)
                {
                    if (invited.Contains(reservationNumber))
                    {
                        invited.Remove(reservationNumber);
                    }
                }
                else
                {
                    if (!invited.Contains(reservationNumber))
                    {
                        invited.Add(reservationNumber);
                    }
                }

                reservationNumber = Console.ReadLine();
            }
            
            string[] vipGuests = invited.Where(x => char.IsDigit(x[0])).ToArray();
            string[] otherGuests = invited.Where(x => !char.IsDigit(x[0])).ToArray();

            Console.WriteLine(invited.Count);

            foreach (var guest in vipGuests)
            {
                Console.WriteLine(guest);
            }

            foreach (var guest in otherGuests)
            {
                Console.WriteLine(guest);
            }
        }
    }
}
