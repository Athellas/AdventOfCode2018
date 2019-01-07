using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AdventOfCode2018
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Mic check check check");
            Console.WriteLine("");
            //Console.WriteLine("IO test");
            //List<string> input = ConvertPuzzleInputToListString(@"C:\_aoc2018\day2puzzle1.txt");
            //foreach(string s in input)
            //{
            //    Console.WriteLine(s);
            //}
            //Console.ReadLine();
            Console.WriteLine("Day 2 Puzzle 1:");
            Console.WriteLine(Day2Puzzle1(@"C:\_aoc2018\day2puzzle1.txt"));
            Console.WriteLine();
            Console.ReadLine();

            Console.WriteLine("Day 2 Puzzle 2:");
            Console.WriteLine(Day2Puzzle2(@"C:\_aoc2018\day2puzzle1.txt"));
            Console.WriteLine();
            Console.ReadLine();
        }

        static string Day2Puzzle1(string path)
        {
            List<string> puzzleInput = new List<string> { };
            puzzleInput = ConvertPuzzleInputToListString(path);
            int numberOfTwos=0;
            int numberOfThrees=0;
            //char[] lineChars = new char[] { }; 
            foreach (string line in puzzleInput)
            {
                char[] lineChars= line.ToCharArray(0, line.Length);
                Dictionary<char, int> hashmap = new Dictionary<char, int>();
                
                for(int i = 0; i<line.Length; i++)
                {
                    if (hashmap.ContainsKey(lineChars[i]))
                    {
                        int get = hashmap[lineChars[i]];
                        hashmap[lineChars[i]] = get + 1;
                    }
                    else
                    {
                        hashmap[lineChars[i]] = 1;
                    }
                }

                if (hashmap.ContainsValue(2))
                    { numberOfTwos++; }
                if (hashmap.ContainsValue(3))
                    { numberOfThrees++; }
            }

            return (numberOfTwos*numberOfThrees).ToString();
        }

        static string Day2Puzzle2(string path)
        {
            List<string> puzzleInput = new List<string> { };
            puzzleInput = ConvertPuzzleInputToListString(path);
            puzzleInput.Sort();
            Console.WriteLine("Testing sort");
            string candidate = "";
            List<int> candidateIndex = new List<int> ();
            foreach (string line in puzzleInput)
            {
                for (int i = 0; i < puzzleInput.Count; i++)
                {
                    int mistakeCount = 0;
                    for (int j = 0; j<line.Length; j++)
                    {
                        if (line[j] !=puzzleInput[i][j])
                        { mistakeCount++; }
                    }
                    if (mistakeCount == 1)
                    {
                        candidate = puzzleInput[i];
                        candidateIndex.Add(i);
                        Console.WriteLine("Candidate found: " + candidate);
                    }
                }
            }
            Console.WriteLine();
            List<char> finalWord = new List<char>();
            for(int i=0; i<puzzleInput[candidateIndex[0]].Length; i++)
            {
                if (puzzleInput[candidateIndex[0]][i] == puzzleInput[candidateIndex[1]][i])
                    finalWord.Add(puzzleInput[candidateIndex[0]][i]);
            }            
            return string.Concat(finalWord);
        }

        static List<string> ConvertPuzzleInputToListString(string path)
        {
            var lines = File.ReadAllLines(path);
            List<string> puzzleInputListString = new List<string> { };
            foreach (var line in lines)
            {
                puzzleInputListString.Add(line);
            }
            return puzzleInputListString;
        }
    }
}
