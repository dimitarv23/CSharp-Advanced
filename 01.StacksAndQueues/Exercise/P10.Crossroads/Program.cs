using System;
using System.Collections.Generic;

namespace P10.Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> trafficLightQueue = new Queue<string>();
            int durationOfGreenLight = int.Parse(Console.ReadLine());
            int durationOfFreeWindow = int.Parse(Console.ReadLine());

            int countOfCarsPassed = 0;

            string command = Console.ReadLine();
            while (command != "END")
            {
                if (command == "green")
                {
                    string currCarPassing = string.Empty;
                    int greenLightSecondsLeft = durationOfGreenLight;
                    bool isCarInFreeWindow = false;
                    int timeLeftToPass = 0;

                    while (greenLightSecondsLeft > 0)
                    {
                        if (trafficLightQueue.Count == 0)
                        {
                            break;
                        }

                        string carPassing = trafficLightQueue.Dequeue();
                        int neededSeconds = carPassing.Length;

                        if (greenLightSecondsLeft >= neededSeconds)
                        {
                            greenLightSecondsLeft -= neededSeconds;
                            countOfCarsPassed++;
                            continue;
                        }

                        neededSeconds -= greenLightSecondsLeft;
                        greenLightSecondsLeft = 0;

                        isCarInFreeWindow = true;
                        timeLeftToPass = neededSeconds;
                        currCarPassing = carPassing;
                    }

                    if (isCarInFreeWindow)
                    {
                        if (durationOfFreeWindow >= timeLeftToPass)
                        {
                            timeLeftToPass = 0;
                            countOfCarsPassed++;
                        }
                        if (durationOfFreeWindow < timeLeftToPass)
                        {
                            timeLeftToPass -= durationOfFreeWindow;

                            Console.WriteLine("A crash happened!");
                            Console.WriteLine($"{currCarPassing} was hit at {currCarPassing[currCarPassing.Length - timeLeftToPass]}.");
                            return;
                        }
                    }
                }
                else
                {
                    trafficLightQueue.Enqueue(command);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{countOfCarsPassed} total cars passed the crossroads.");
        }
    }
}
