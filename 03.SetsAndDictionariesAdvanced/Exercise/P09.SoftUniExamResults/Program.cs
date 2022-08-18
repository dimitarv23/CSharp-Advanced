using System;
using System.Collections.Generic;
using System.Linq;

namespace P09.SoftUniExamResults
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> contestants = new Dictionary<string, int>();
            Dictionary<string, int> submissions = new Dictionary<string, int>();

            string command = Console.ReadLine();
            while (command != "exam finished")
            {
                string[] cmdArgs = command.Split("-");
                string username = cmdArgs[0];

                if (cmdArgs[1] == "banned")
                {
                    if (contestants.ContainsKey(username))
                    {
                        contestants.Remove(username);
                    }
                }
                else
                {
                    string language = cmdArgs[1];
                    int points = int.Parse(cmdArgs[2]);

                    if (!contestants.ContainsKey(username))
                    {
                        contestants.Add(username, points);
                    }
                    else
                    {
                        contestants[username] = Math.Max(contestants[username], points);
                    }

                    if (!submissions.ContainsKey(language))
                    {
                        submissions.Add(language, 0);
                    }

                    submissions[language]++;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine("Results:");

            foreach (var contestant in contestants
                .OrderByDescending(c => c.Value)
                .ThenBy(c => c.Key))
            {
                Console.WriteLine($"{contestant.Key} | {contestant.Value}");
            }

            Console.WriteLine("Submissions:");
            foreach (var submission in submissions
                .OrderByDescending(s => s.Value)
                .ThenBy(s => s.Key))
            {
                Console.WriteLine($"{submission.Key} - {submission.Value}");
            }
        }
    }
}
