using System;
using System.IO;
using System.Collections.Generic;

namespace AoC_Day2_Part1
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = File.ReadAllText(@"E:\Projects\AoC\AoC_Day2_Part1\input.txt");
            Console.WriteLine(Utils.InputParser(input));
            Console.ReadLine();
        }
    }

    static class Utils
    {
        public static string InputParser(string input)
        {
            string[] inputStringArray = input.Split(",");

            Dictionary<int, string[]> commandList = new Dictionary<int, string[]>();
            int kvpIndex = 0;
            for (int i = 0; i < inputStringArray.Length - 4; i += 4)
            {
                string[] command = new string[4];
                Array.ConstrainedCopy(inputStringArray, i, command, 0, 4);
                commandList.Add(kvpIndex, command);
                kvpIndex++;
            }

            for (int i = 0; i < commandList.Count; i++)
            {
                int x = Int32.Parse(commandList[i][1]);
                int y = Int32.Parse(commandList[i][2]);
                int pos = Int32.Parse(commandList[i][3]);

                switch(commandList[i][0])
                {
                    case "1":
                        AddAndReplace(x, y, pos, inputStringArray);
                        break;
                    case "2":
                        MultiplyAndReplace(x, y, pos, inputStringArray);
                        break;
                    case "99":
                        return inputStringArray[0];
                    default:
                        Console.WriteLine("This should not be: " + commandList[i][0]);
                        break;
                }

                commandList = GenerateCommandDict(inputStringArray);
            }

            return inputStringArray[0];
        }

        private static Dictionary<int, string[]> GenerateCommandDict(string[] inputStringArray)
        {
            Dictionary<int, string[]> commandList = new Dictionary<int, string[]>();
            int kvpIndex = 0;
            for (int i = 0; i < inputStringArray.Length - 4; i += 4)
            {
                string[] command = new string[4];
                Array.ConstrainedCopy(inputStringArray, i, command, 0, 4);
                commandList.Add(kvpIndex, command);
                kvpIndex++;
            }

            return commandList;
        }

        private static void AddAndReplace(int x, int y, int stringPosition, string[] stringArray)
        {
            stringArray[stringPosition] = (x + y).ToString();
        }

        private static void MultiplyAndReplace(int x, int y, int stringPosition, string[] stringArray)
        {
            stringArray[stringPosition] = (x * y).ToString();
        }
    }
}
