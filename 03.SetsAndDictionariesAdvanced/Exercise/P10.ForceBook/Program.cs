using System;
using System.Collections.Generic;
using System.Linq;

namespace P10.ForceBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> sides = new Dictionary<string, List<string>>();

            string command = Console.ReadLine();
            while (command != "Lumpawaroo")
            {
                string[] cmdArgs = new string[2];
                string forceUser = string.Empty;
                string forceSide = string.Empty;

                if (command.Contains(" -> "))
                {
                    cmdArgs = command.Split(" -> ");
                    forceUser = cmdArgs[0];
                    forceSide = cmdArgs[1];

                    RemoveUserFromOtherSides(sides, forceUser);

                    if (sides.ContainsKey(forceSide))
                    {
                        sides[forceSide].Add(forceUser);
                    }
                    else
                    {
                        sides.Add(forceSide, new List<string>() { forceUser });
                    }

                    Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                }
                else
                {
                    cmdArgs = command.Split(" | ");
                    forceSide = cmdArgs[0];
                    forceUser = cmdArgs[1];

                    bool doesUserExist = DoesUserExist(sides, forceUser);

                    if (sides.ContainsKey(forceSide))
                    {
                        if (!doesUserExist)
                        {
                            sides[forceSide].Add(forceUser);
                        }
                    }
                    else
                    {
                        sides.Add(forceSide, new List<string>());

                        if (!doesUserExist)
                        {
                            sides[forceSide].Add(forceUser);
                        }
                    }
                }

                command = Console.ReadLine();
            }

            foreach (var side in sides
                .Where(s => s.Value.Count > 0)
                .OrderByDescending(s => s.Value.Count)
                .ThenBy(s => s.Key))
            {
                Console.WriteLine($"Side: {side.Key}, Members: {side.Value.Count}");

                foreach (var user in side.Value.OrderBy(u => u))
                {
                    Console.WriteLine($"! {user}");
                }
            }
        }

        static void RemoveUserFromOtherSides(Dictionary<string, List<string>> sides, string username)
        {
            foreach (var side in sides)
            {
                if (side.Value.Contains(username))
                {
                    side.Value.Remove(username);
                }
            }
        }

        static bool DoesUserExist(Dictionary<string, List<string>> sides, string username)
        {
            foreach (var side in sides)
            {
                if (side.Value.Contains(username))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
