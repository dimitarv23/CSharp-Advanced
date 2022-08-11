using System;
using System.Collections.Generic;
using System.Linq;

namespace P11.KeyRevolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int priceOfBullet = int.Parse(Console.ReadLine());
            int sizeOfGunBarrel = int.Parse(Console.ReadLine());
            int[] bullets = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] locks = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int valueOfIntelligence = int.Parse(Console.ReadLine());

            Queue<int> locksLeft = new Queue<int>(locks);
            Stack<int> bulletsLeft = new Stack<int>(bullets);
            int bulletsUntilReload = sizeOfGunBarrel;

            while (locksLeft.Count > 0)
            {
                int currBulletShot = bulletsLeft.Pop();
                int currLock = locksLeft.Peek();
                bulletsUntilReload--;

                if (currBulletShot <= currLock)
                {
                    Console.WriteLine("Bang!");
                    locksLeft.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                if (bulletsLeft.Count == 0)
                {
                    if (locksLeft.Count == 0)
                    {
                        break;
                    }

                    Console.WriteLine($"Couldn't get through. Locks left: {locksLeft.Count}");
                    return;
                }

                if (bulletsUntilReload == 0)
                {
                    Console.WriteLine("Reloading!");
                    bulletsUntilReload = sizeOfGunBarrel;
                }
            }

            int bulletsShot = bullets.Length - bulletsLeft.Count;
            int totalEarned = valueOfIntelligence - bulletsShot * priceOfBullet;
            Console.WriteLine($"{bulletsLeft.Count} bullets left. Earned ${totalEarned}");
        }
    }
}
