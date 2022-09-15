using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //With the empty constructor
            Person person1 = new Person();
            person1.Name = "Peter";
            person1.Age = 20;

            //With the inline initialization constructor
            Person person2 = new Person("George", 18);

            Person person3 = new Person()
            {
                Name = "Jose",
                Age = 43
            };
        }
    }
}
