using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Family family = new Family();

            for (int i = 0; i < n; i++)
            {
                string[] currPersonInfo = Console.ReadLine().Split();
                string personName = currPersonInfo[0];
                int personAge = int.Parse(currPersonInfo[1]);

                family.AddMembers(new Person(personName, personAge));
            }

            Person oldestMember = family.GetOldest();
            Console.WriteLine($"{oldestMember.Name} {oldestMember.Age}");
        }
    }
}
