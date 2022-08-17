using System;
using System.Collections.Generic;
using System.Linq;

namespace P08.Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string, int>> contestants = new Dictionary<string, Dictionary<string, int>>();

            string command1 = Console.ReadLine();
            while (command1 != "end of contests")
            {
                string[] cmdArgs = command1.Split(":");
                string contest = cmdArgs[0];
                string password = cmdArgs[1];

                if (!contests.ContainsKey(contest))
                {
                    contests.Add(contest, password);
                }

                command1 = Console.ReadLine();
            }

            string command2 = Console.ReadLine();
            while (command2 != "end of submissions")
            {
                string[] cmdArgs = command2.Split("=>");
                string contest = cmdArgs[0];
                string password = cmdArgs[1];
                string username = cmdArgs[2];
                int points = int.Parse(cmdArgs[3]);

                if (CheckContest(contests, contest, password))
                {
                    if (!contestants.ContainsKey(username))
                    {
                        contestants.Add(username, new Dictionary<string, int>());
                    }

                    if (contestants[username].ContainsKey(contest))
                    {
                        contestants[username][contest] = Math.Max(contestants[username][contest], points);
                    }
                    else
                    {
                        contestants[username].Add(contest, points);
                    }
                }

                command2 = Console.ReadLine();
            }

            foreach (var bestContestant in contestants
                         .OrderByDescending(x => x.Value.Values.Sum())
                         .Take(1))
            {
                Console.WriteLine($"Best candidate is {bestContestant.Key} with total {bestContestant.Value.Values.Sum()} points.");
            }
            
            Console.WriteLine("Ranking:");

            foreach (var contestant in contestants
                         .OrderBy(x => x.Key))
            {
                Console.WriteLine(contestant.Key);

                foreach (var competition in contestant.Value
                             .OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {competition.Key} -> {competition.Value}");
                }
            }
        }

        static bool CheckContest(Dictionary<string, string> contests, string contest, string password)
        {
            if (!contests.ContainsKey(contest))
            {
                return false;
            }

            if (contests[contest] != password)
            {
                return false;
            }

            return true;
        }
    }
}
