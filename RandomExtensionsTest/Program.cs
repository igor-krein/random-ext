using System;
using RandomExtensions;
using System.Collections.Generic;
using System.Linq;

namespace RandomExtensionsTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestLong();
            //TestDate();
            TestList();
        }

        static void TestLong()
        {
            long from, to, randomValue;
            Random random = new Random();

            from = long.MinValue;
            to = long.MaxValue;

            from = 10;
            to = 500;

            Dictionary<long, int> distribution = new Dictionary<long, int>();
            for (int i = 0; i < 200; i++)
            {
                randomValue = random.NextLong(from, to);
                //                randomValue = random.Next((int)from, (int)to);
                Console.WriteLine($"Value between {from} and {to} => {randomValue}");
                if (distribution.ContainsKey(randomValue)) distribution[randomValue]++;
                else distribution[randomValue] = 1;
            }

            Console.WriteLine("Random value distribution:");
            foreach (KeyValuePair<long, int> pair in distribution.OrderBy(item => item.Key))
            {
                Console.WriteLine($"{pair.Key} => {pair.Value}");
            }
        }

        static void TestDateTime()
        {
            DateTime from, to, randomValue;
            Random random = new Random();

            from = new DateTime(1950, 1, 1);
            to = new DateTime(1950, 12, 31);

            Dictionary<DateTime, int> distribution = new Dictionary<DateTime, int>();
            for (int i = 0; i < 200; i++)
            {
                randomValue = random.NextDateTime(from, to);
                Console.WriteLine($"Value between {from} and {to} => {randomValue}");
                if (distribution.ContainsKey(randomValue)) distribution[randomValue]++;
                else distribution[randomValue] = 1;
            }

            Console.WriteLine("Random value distribution:");
            foreach (KeyValuePair<DateTime, int> pair in distribution.OrderBy(item => item.Key))
            {
                Console.WriteLine($"{pair.Key} => {pair.Value}");
            }
        }

        static void TestDate()
        {
            DateTime from, to, randomValue;
            Random random = new Random();

            from = new DateTime(1950, 1, 1);
            to = new DateTime(1950, 12, 31);

            Dictionary<DateTime, int> distribution = new Dictionary<DateTime, int>();
            for (int i = 0; i < 200; i++)
            {
                randomValue = random.NextDate(from, to);
                Console.WriteLine($"Value between {from} and {to} => {randomValue}");
                if (distribution.ContainsKey(randomValue)) distribution[randomValue]++;
                else distribution[randomValue] = 1;
            }

            Console.WriteLine("Random value distribution:");
            foreach (KeyValuePair<DateTime, int> pair in distribution.OrderBy(item => item.Key))
            {
                Console.WriteLine($"{pair.Key} => {pair.Value}");
            }
        }

        static void TestList()
        {
            Random random = new Random();

            int diceSideCount = 20, minHit = 5;

            Dictionary<string, int> distribution = new Dictionary<string, int>();
            //List<string> words = new List<string> { "one", "two", "three", "four", "five", "million" };
            string[] words = { "one", "two", "three", "four", "five", "million" };
            for (int i = 0; i < 1000; i++)
            {
                var randomValue = random.NextItemOrDefault(words, diceSideCount, minHit, "[null]");
                Console.WriteLine($"{randomValue}");
                if (distribution.ContainsKey(randomValue)) distribution[randomValue]++;
                else distribution[randomValue] = 1;
            }

            Console.WriteLine("Random value distribution:");
            foreach (KeyValuePair<string, int> pair in distribution.OrderBy(item => item.Key))
            {
                Console.WriteLine($"{pair.Key} => {pair.Value}");
            }
        }
    }
}
