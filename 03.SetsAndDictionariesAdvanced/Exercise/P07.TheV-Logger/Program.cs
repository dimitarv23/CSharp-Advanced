using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace P07.TheV_Logger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> vloggers = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> vloggersAndFollowing = new Dictionary<string, List<string>>();

            string command = Console.ReadLine();
            while (command != "Statistics")
            {
                string[] cmdArgs = command.Split();
                string vloggerName = cmdArgs[0];
                string action = cmdArgs[1];

                if (action == "joined")
                {
                    if (!vloggers.ContainsKey(vloggerName))
                    {
                        vloggers.Add(vloggerName, new List<string>());
                        vloggersAndFollowing.Add(vloggerName, new List<string>());
                    }
                }
                else if (action == "followed")
                {
                    string followedVloggerName = cmdArgs[2];

                    if (IsAbleToFollow(vloggers, vloggerName, followedVloggerName))
                    {
                        vloggers[followedVloggerName].Add(vloggerName);
                        vloggersAndFollowing[vloggerName].Add(followedVloggerName);
                    }
                }

                command = Console.ReadLine();
            }
            
            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");
            int counter = 1;

            foreach (var vlogger in vloggers
                         .OrderByDescending(x => x.Value.Count)
                         .ThenBy(x => vloggersAndFollowing[x.Key].Count))
            {
                int currVloggerFollowing = vloggersAndFollowing[vlogger.Key].Count;

                Console.WriteLine($"{counter}. {vlogger.Key} : {vlogger.Value.Count} followers, {currVloggerFollowing} following");

                if (counter == 1)
                {
                    foreach (var follower in vlogger.Value.OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }

                counter++;
            }
        }

        static bool IsAbleToFollow(Dictionary<string, List<string>> vloggers, string vloggerName,
            string followedVlogger)
        {
            if (!vloggers.ContainsKey(vloggerName) || !vloggers.ContainsKey(followedVlogger))
            {
                return false;
            }

            if (vloggerName == followedVlogger)
            {
                return false;
            }

            if (vloggers[followedVlogger].Contains(vloggerName))
            {
                return false;
            }

            return true;
        }
    }
}
