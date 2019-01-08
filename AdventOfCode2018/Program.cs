using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

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
            //Console.WriteLine("Day 2 Puzzle 1:");
            //Console.WriteLine(Day2Puzzle1(@"C:\_aoc2018\day2puzzle1.txt"));
            //Console.WriteLine();
            //Console.ReadLine();

            //Console.WriteLine("Day 2 Puzzle 2:");
            //Console.WriteLine(Day2Puzzle2(@"C:\_aoc2018\day2puzzle1.txt"));
            //Console.WriteLine();
            //Console.ReadLine();

            Console.WriteLine("Day 3 Puzzle 1: ");
            Console.WriteLine(Day3Puzzle1(@"C:\_aoc2018\day3puzzle1.txt"));
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

        static string Day3Puzzle1(string path)
        {
            List<string> puzzleInput = new List<string> { };
            puzzleInput = ConvertPuzzleInputToListString(path);

            int[,] fabric = new int[1000, 1000];

            // #1 @ 286,440: 19x24

            List<int> positionX = new List<int>(new int[puzzleInput.Count]);
            string patternPositionX = @"(\d\d\d\,)| (\d\d\,)| (\d\,)";
            for (int i = 0; i < puzzleInput.Count; i++)
            {
                positionX[i] = Int32.Parse((Regex.Match(puzzleInput[i], patternPositionX).Value).TrimEnd(','));
                Console.WriteLine(positionX[i].ToString());                
            }

            List<int> positionY = new List<int>(new int[puzzleInput.Count]);
            string patternPositionY = @"(\,\d\d\d)|(\,\d\d)|(\,\d)";
            for (int i = 0; i < puzzleInput.Count; i++)
            {
                positionY[i] = Int32.Parse((Regex.Match(puzzleInput[i], patternPositionY).Value).TrimStart(','));
                Console.WriteLine(positionY[i].ToString());
            }

            List<int> sizeX = new List<int>(new int[puzzleInput.Count]);
            string patternSizeX = @"(\d\dx)|(\dx)";
            for (int i = 0; i < puzzleInput.Count; i++)
            {
                sizeX[i] = Int32.Parse((Regex.Match(puzzleInput[i], patternSizeX).Value).TrimEnd('x'));
                Console.WriteLine(sizeX[i].ToString());
            }

            List<int> sizeY = new List<int>(new int[puzzleInput.Count]);
            string patternSizeY = @"(x\d\d)|(x\d)";
            for (int i = 0; i < puzzleInput.Count; i++)
            {
                sizeY[i] = Int32.Parse((Regex.Match(puzzleInput[i], patternSizeY).Value).TrimStart('x'));
                Console.WriteLine(sizeY[i].ToString());
            }

            for (int i=0; i < puzzleInput.Count; i++)
            {
                for (int x = 0; x < sizeX[i]; x++ )
                {
                    for (int y = 0; y < sizeY[i]; y++)
                    {
                        fabric[positionX[i] + x, positionY[i] + y]++;
                    }
                }
            }

            int result=0;
            foreach (int z in fabric)
            {
                if (z > 1)
                {
                    result++;
                }
            }
            
            return result.ToString();
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
