using System;
using System.Collections.Generic;
using System.Linq;

namespace P10.ThePartyReservationFilterModule
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine()
                .Split()
                .ToList();

            List<string> filters = new List<string>();

            string command = Console.ReadLine();
            while (command != "Print")
            {
                string[] cmdArgs = command
                    .Split(';');
                string action = cmdArgs[0];
                string property = cmdArgs[1];

                string filter = $"{property};{cmdArgs[2]}";

                if (action == "Add filter")
                {
                    if (!filters.Contains(filter))
                    {
                        filters.Add(filter);
                    }
                }
                else if (action == "Remove filter")
                {
                    if (filters.Contains(filter))
                    {
                        filters.Remove(filter);
                    }
                }

                command = Console.ReadLine();
            }

            Action<List<string>, List<string>, int> filterGuests = ApplyFilterss;
            filterGuests(guests, filters, 0);

            Console.WriteLine(string.Join(" ", guests));
        }

        static void ApplyFilterss(List<string> guests, List<string> filters, int filterIndex)
        {
            string filter = filters[filterIndex];
            filterIndex++;

            string[] filterArgs = filter.Split(';');

            string property = filterArgs[0];
            Predicate<string> predicate = x => true;

            if (property == "Starts with")
            {
                predicate = x => x.StartsWith(filterArgs[1]);
            }
            else if (property == "Ends with")
            {
                predicate = x => x.EndsWith(filterArgs[1]);
            }
            else if (property == "Length")
            {
                int length = int.Parse(filterArgs[1]);
                predicate = x => x.Length == length;
            }
            else if (property == "Contains")
            {
                predicate = x => x.Contains(filterArgs[1]);
            }

            guests.RemoveAll(predicate);

            if (filterIndex < filters.Count)
            {
                ApplyFilterss(guests, filters, filterIndex);
            }
        }
    }
}
