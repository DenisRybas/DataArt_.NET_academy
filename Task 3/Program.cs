using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            CardService card = new CardService();
            Console.WriteLine("Part 1:");
            card.Part1();
            Console.WriteLine("-----------------------");
            Console.WriteLine("Part 2:");
            card.Part2();
            Console.WriteLine("-----------------------");
            Console.WriteLine("Part 3:");
            card.Part3();
            Console.WriteLine("-----------------------");
            Console.WriteLine("Part 4:");
            card.Part4();
            Console.WriteLine("-----------------------");
            Console.WriteLine("Part 6:");
            card.Part6();
            Console.WriteLine("-----------------------");
        }
    }
}