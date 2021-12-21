using System.Diagnostics;

namespace AdventOfCode
{
    /// <summary>
    /// Main Advent of Code 2021 Class
    /// </summary>
    class Program
    {
        static void Main()
        {
            DrawATree();
            Console.ForegroundColor = ConsoleColor.White;
            string result = ""; 
            while (result != "Q")
            {
                Console.WriteLine("Advent of Code 2021!");
                Console.Write("Select the challange [1-21] or all challanges [A], write [Q] to quit: ");
#if DEBUG
                if (result != "21")
                    result = "21";
                else
                    result = "Q";
                Console.WriteLine(result);
#else
                result = Console.ReadLine() ?? "";
#endif

                if (int.TryParse(result, out int parsed) && parsed >= 1 && parsed <= 21)
                {
                    DoChallange(parsed);
                }
                else if (result.ToUpper() == "A")
                {
                    DoAllChallanges();
                }
                else if (result.ToUpper() != "Q")
                {
                    DrawATree();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Wrong command.");
                }
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        static private string FormatTime(ulong milliseconds)
        {
            uint milli = (uint)(milliseconds % 1000);
            uint seconds = (uint)(milliseconds / 1000);
            uint minutes = seconds / 60;
            seconds %= 60;
            uint hours = minutes / 60;
            minutes %= 60;
            string time = "";
            if (hours > 0) time = hours.ToString().PadLeft(2, '0') + ":";
            if (minutes > 0 || hours > 0) time += minutes.ToString().PadLeft(2, '0') + ":";
            if (seconds > 0 && (minutes > 0 || hours > 0)) time += seconds.ToString().PadLeft(2, '0') + "." + milli.ToString().PadLeft(3, '0');
            else if (seconds > 0) time += seconds.ToString().PadLeft(2, '0') + "." + milli.ToString().PadLeft(3, '0') + "s";
            else time += milli.ToString().PadLeft(3, '0') + "ms";
            return time;
        }

        static ulong DoChallange(int challange, bool nice = true)
        {
            if (File.Exists($"inputData{challange}.txt"))
            {
                if (nice)
                {
                    DrawATree();
                }
                string inputData = File.ReadAllText($"inputData{challange}.txt");
                Stopwatch watch1;
                Stopwatch watch2;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"Results of Day {challange} are: ");
                watch1 = Stopwatch.StartNew();
                string result1 = challange switch
                {
                    1 => Day01.Challange1.DoChallange(inputData).ToString(),
                    2 => Day02.Challange1.DoChallange(inputData).ToString(),
                    3 => Day03.Challange1.DoChallange(inputData).ToString(),
                    4 => Day04.Challange1.DoChallange(inputData).ToString(),
                    5 => Day05.Challange1.DoChallange(inputData).ToString(),
                    6 => Day06.Challange1.DoChallange(inputData).ToString(),
                    7 => Day07.Challange1.DoChallange(inputData).ToString(),
                    8 => Day08.Challange1.DoChallange(inputData).ToString(),
                    9 => Day09.Challange1.DoChallange(inputData).ToString(),
                    10 => Day10.Challange1.DoChallange(inputData).ToString(),
                    11 => Day11.Challange1.DoChallange(inputData).ToString(),
                    12 => Day12.Challange1.DoChallange(inputData).ToString(),
                    13 => Day13.Challange1.DoChallange(inputData).ToString(),
                    14 => Day14.Challange1.DoChallange(inputData).ToString(),
                    15 => Day15.Challange1.DoChallange(inputData).ToString(),
                    16 => Day16.Challange1.DoChallange(inputData).ToString(),
                    17 => Day17.Challange1.DoChallange(inputData).ToString(),
                    18 => Day18.Challange1.DoChallange(inputData).ToString(),
                    19 => Day19.Challange1.DoChallange(inputData).ToString(),
                    20 => Day20.Challange1.DoChallange(inputData).ToString(),
                    21 => Day21.Challange1.DoChallange(inputData).ToString(),
                    _ => "ERROR",
                };
                watch1.Stop();
                Console.ForegroundColor = ConsoleColor.Cyan;
                if (result1.Contains('\n') || result1.Length > 20)
                {
                    Console.WriteLine();
                    Console.WriteLine(result1);
                }
                else
                {
                    Console.Write(result1);
                }
                Console.ForegroundColor = ConsoleColor.White;
                watch2 = Stopwatch.StartNew();
                string result2 = challange switch
                {
                    1 => Day01.Challange2.DoChallange(inputData).ToString(),
                    2 => Day02.Challange2.DoChallange(inputData).ToString(),
                    3 => Day03.Challange2.DoChallange(inputData).ToString(),
                    4 => Day04.Challange2.DoChallange(inputData).ToString(),
                    5 => Day05.Challange2.DoChallange(inputData).ToString(),
                    6 => Day06.Challange2.DoChallange(inputData).ToString(),
                    7 => Day07.Challange2.DoChallange(inputData).ToString(),
                    8 => Day08.Challange2.DoChallange(inputData).ToString(),
                    9 => Day09.Challange2.DoChallange(inputData).ToString(),
                    10 => Day10.Challange2.DoChallange(inputData).ToString(),
                    11 => Day11.Challange2.DoChallange(inputData).ToString(),
                    12 => Day12.Challange2.DoChallange(inputData).ToString(),
                    13 => Day13.Challange2.DoChallange(inputData).ToString(),
                    14 => Day14.Challange2.DoChallange(inputData).ToString(),
                    15 => Day15.Challange2.DoChallange(inputData).ToString(),
                    16 => Day16.Challange2.DoChallange(inputData).ToString(),
                    17 => Day17.Challange2.DoChallange(inputData).ToString(),
                    18 => Day18.Challange2.DoChallange(inputData).ToString(),
                    19 => Day19.Challange2.DoChallange(inputData).ToString(),
                    20 => Day20.Challange2.DoChallange(inputData).ToString(),
                    21 => Day21.Challange2.DoChallange(inputData).ToString(),
                    _ => "ERROR",
                };
                watch2.Stop();
                Console.Write(" and ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                if (result2.Contains('\n') || result2.Length > 20)
                {
                    Console.WriteLine();
                    Console.WriteLine(result2);
                }
                else
                {
                    Console.Write(result2);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("! ");
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("It took ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(FormatTime((ulong)watch1.Elapsed.TotalMilliseconds));
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" and ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(FormatTime((ulong)watch2.Elapsed.TotalMilliseconds));
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(".");
                return (ulong)(watch1.ElapsedMilliseconds + watch2.ElapsedMilliseconds);
            }
            else
            {
                return 0;
            }
        }
        
        static void DoAllChallanges()
        {
            DrawATree();
            ulong totalTime = 0;
            for (int i = 1; i <= 25; i++)
            {
                totalTime += DoChallange(i, false);
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Total time is: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(FormatTime(totalTime));
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(".");
            Console.WriteLine();
        }

        static void DrawATree()
        {
            Console.Clear();
            for (int i = 0; i < Console.WindowWidth/40*Console.WindowHeight; i++)
            {
                Console.ForegroundColor = (ConsoleColor)new Random().Next(1, 16);
                int x = new Random().Next(0, Console.WindowWidth);
                int y = new Random().Next(0, Console.WindowHeight);
                Console.CursorLeft = x;
                Console.CursorTop = y;
                Console.Write('*');

            }
            Console.CursorLeft = 0;
            Console.CursorTop = 0;
            DrawLine(@"()", 11);
            DrawLine(@"/\",11);
            DrawLine(@"/i\\",10);
            DrawLine(@"o/\\",10);
            DrawLine(@"///\i\",9);
            DrawLine(@"/*/o\\",9);
            DrawLine(@"/i//\*\",8);
            DrawLine(@"/ o/*\\i\",8);
            DrawLine(@"//i//o\\\\",7);
            DrawLine(@"/*////\\\\i\",6);
            DrawLine(@"//o//i\\*\\\",6);
            DrawLine(@"/i///*/\\\\\o\",5);
            DrawLine(@"||",11);
        }

        static void DrawLine(string line, int left = 0)
        {
            Console.CursorLeft += left;
            foreach (char c in line)
            {
                if (c == '\\' || c == '/')
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else if (c == '(' || c == ')')
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else
                {
                    Console.ForegroundColor = (ConsoleColor)new Random().Next(1, 16);
                }
                Console.Write(c);
            }
            Console.WriteLine();
        }
    }
}