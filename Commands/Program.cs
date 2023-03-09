using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commands
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            string command = Console.ReadLine();

            while (command != "print")
            {
                string[] tokens = command.Split();
                string action = tokens[0];

                if (action == "push")
                {
                    int number = int.Parse(tokens[1]);
                    numbers.Add(number);
                }
                else if (action == "pop")
                {
                    if (numbers.Count > 0)
                    {
                        int number = numbers[numbers.Count - 1];
                        numbers.RemoveAt(numbers.Count - 1);
                        Console.WriteLine(number);
                    }
                }
                else if (action == "shift")
                {
                    if (numbers.Count > 0)
                    {
                        int number = numbers[numbers.Count - 1];
                        numbers.RemoveAt(numbers.Count - 1);
                        numbers.Insert(0, number);
                    }
                }
                else if (action == "addMany")
                {
                    int index = int.Parse(tokens[1]);

                    if (index >= 0 && index < numbers.Count)
                    {
                        List<int> numbersToAdd = new List<int>();

                        for (int i = 2; i < tokens.Length; i++)
                        {
                            int numberToAdd = int.Parse(tokens[i]);
                            numbersToAdd.Add(numberToAdd);
                        }

                        numbers.InsertRange(index, numbersToAdd);
                    }
                }
                else if (action == "remove")
                {
                    int index = int.Parse(tokens[1]);

                    if (index >= 0 && index < numbers.Count)
                    {
                        numbers.RemoveAt(index);
                    }
                }

                command = Console.ReadLine();
            }

            numbers.Reverse();
            Console.WriteLine(string.Join(", ", numbers));

        }
    }
}
