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
                Console.Write("Select the challange [1-14] or all challanges [A], write [Q] to quit: ");
                result = Console.ReadLine()??"";

                switch (result.ToUpper())
                {
                    case "1":
                    case "2":
                    case "3":
                    case "4":
                    case "5":
                    case "6":
                    case "7":
                    case "8":
                    case "9":
                    case "10":
                    case "11":
                    case "12":
                    case "13":
                    case "14":
                        DoChallange(int.Parse(result));
                        break;
                    case "A":
                        DoAllChallanges();
                        break;
                    case "Q":
                        break;
                    default:
                        DrawATree();
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Wrong command.");
                        break;
                }
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        static ulong DoChallange(int challange, bool nice = true)
        {
            if (nice)
            {
                DrawATree();
            }
            string inputData = File.ReadAllText($"inputData{challange}.txt");
            Stopwatch watch1;
            Stopwatch watch2;
            string result1;
            string result2;
            switch (challange)
            {
                case 1:
                    watch1 = Stopwatch.StartNew();
                    result1 = new Day01.Challange1().DoChallange(inputData).ToString();
                    watch1.Stop();
                    watch2 = Stopwatch.StartNew();
                    result2 = new Day01.Challange2().DoChallange(inputData).ToString();
                    watch2.Stop();
                    break;
                case 2:
                    watch1 = Stopwatch.StartNew();
                    result1 = new Day02.Challange1().DoChallange(inputData).ToString();
                    watch1.Stop();
                    watch2 = Stopwatch.StartNew();
                    result2 = new Day02.Challange2().DoChallange(inputData).ToString();
                    watch2.Stop();
                    break;
                case 3:
                    watch1 = Stopwatch.StartNew();
                    result1 = new Day03.Challange1().DoChallange(inputData).ToString();
                    watch1.Stop();
                    watch2 = Stopwatch.StartNew();
                    result2 = new Day03.Challange2().DoChallange(inputData).ToString();
                    watch2.Stop();
                    break;
                case 4:
                    watch1 = Stopwatch.StartNew();
                    result1 = new Day04.Challange1().DoChallange(inputData).ToString();
                    watch1.Stop();
                    watch2 = Stopwatch.StartNew();
                    result2 = new Day04.Challange2().DoChallange(inputData).ToString();
                    watch2.Stop();
                    break;
                case 5:
                    watch1 = Stopwatch.StartNew();
                    result1 = new Day05.Challange1().DoChallange(inputData).ToString();
                    watch1.Stop();
                    watch2 = Stopwatch.StartNew();
                    result2 = new Day05.Challange2().DoChallange(inputData).ToString();
                    watch2.Stop();
                    break;
                case 6:
                    watch1 = Stopwatch.StartNew();
                    result1 = new Day06.Challange1().DoChallange(inputData).ToString();
                    watch1.Stop();
                    watch2 = Stopwatch.StartNew();
                    result2 = new Day06.Challange2().DoChallange(inputData).ToString();
                    watch2.Stop();
                    break;
                case 7:
                    watch1 = Stopwatch.StartNew();
                    result1 = new Day07.Challange1().DoChallange(inputData).ToString();
                    watch1.Stop();
                    watch2 = Stopwatch.StartNew();
                    result2 = new Day07.Challange2().DoChallange(inputData).ToString();
                    watch2.Stop();
                    break;
                case 8:
                    watch1 = Stopwatch.StartNew();
                    result1 = new Day08.Challange1().DoChallange(inputData).ToString();
                    watch1.Stop();
                    watch2 = Stopwatch.StartNew();
                    result2 = new Day08.Challange2().DoChallange(inputData).ToString();
                    watch2.Stop();
                    break;
                case 9:
                    watch1 = Stopwatch.StartNew();
                    result1 = new Day09.Challange1().DoChallange(inputData).ToString();
                    watch1.Stop();
                    watch2 = Stopwatch.StartNew();
                    result2 = new Day09.Challange2().DoChallange(inputData).ToString();
                    watch2.Stop();
                    break;
                case 10:
                    watch1 = Stopwatch.StartNew();
                    result1 = new Day10.Challange1().DoChallange(inputData).ToString();
                    watch1.Stop();
                    watch2 = Stopwatch.StartNew();
                    result2 = new Day10.Challange2().DoChallange(inputData).ToString();
                    watch2.Stop();
                    break;
                case 11:
                    watch1 = Stopwatch.StartNew();
                    result1 = new Day11.Challange1().DoChallange(inputData).ToString();
                    watch1.Stop();
                    watch2 = Stopwatch.StartNew();
                    result2 = new Day11.Challange2().DoChallange(inputData).ToString();
                    watch2.Stop();
                    break;
                case 12:
                    watch1 = Stopwatch.StartNew();
                    result1 = new Day12.Challange1().DoChallange(inputData).ToString();
                    watch1.Stop();
                    watch2 = Stopwatch.StartNew();
                    result2 = new Day12.Challange2().DoChallange(inputData).ToString();
                    watch2.Stop();
                    break;
                case 13:
                    watch1 = Stopwatch.StartNew();
                    result1 = new Day13.Challange1().DoChallange(inputData).ToString();
                    watch1.Stop();
                    watch2 = Stopwatch.StartNew();
                    result2 = new Day13.Challange2().DoChallange(inputData).ToString();
                    watch2.Stop();
                    break;
                case 14:
                    watch1 = Stopwatch.StartNew();
                    result1 = new Day14.Challange1().DoChallange(inputData).ToString();
                    watch1.Stop();
                    watch2 = Stopwatch.StartNew();
                    result2 = new Day14.Challange2().DoChallange(inputData).ToString();
                    watch2.Stop();
                    break;
                default:
                    watch1 = Stopwatch.StartNew();
                    result1 = "ERROR";
                    watch1.Stop();
                    watch2 = Stopwatch.StartNew();
                    result2 = "ERROR";
                    watch2.Stop();
                    break;
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"Results of Day {challange} are: ");
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
            uint milli = (uint)(watch1.ElapsedMilliseconds%1000);
            uint seconds = (uint)(watch1.ElapsedMilliseconds / 1000);
            uint minutes = seconds / 60;
            seconds %= 60;
            uint hours = minutes / 60;
            minutes %= 60;
            string time = "";
            if (hours > 0) time = hours.ToString().PadLeft(2, '0') + ":";
            if (minutes > 0 || hours > 0) time += minutes.ToString().PadLeft(2, '0') + ":";
            if (seconds > 0 || minutes > 0 || hours > 0) time += seconds.ToString().PadLeft(2, '0') + ".";
            time += milli.ToString().PadLeft(3, '0') + " ms";
            Console.Write(time);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" and ");
            Console.ForegroundColor = ConsoleColor.Green;
            milli = (uint)(watch2.Elapsed.TotalMilliseconds % 1000);
            seconds = (uint)(watch2.ElapsedMilliseconds / 1000);
            minutes = seconds / 60;
            seconds %= 60;
            hours = minutes / 60;
            minutes %= 60;
            time = "";
            if (hours > 0) time = hours.ToString().PadLeft(2, '0') + ":";
            if (minutes > 0 || hours > 0) time += minutes.ToString().PadLeft(2, '0') + ":";
            if (seconds > 0 || minutes > 0 || hours > 0) time += seconds.ToString().PadLeft(2, '0') + ".";
            time += milli.ToString().PadLeft(3, '0') + " ms";
            Console.Write(time);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(".");
            return (ulong)(watch1.ElapsedMilliseconds + watch2.ElapsedMilliseconds);
        }
        
        static void DoAllChallanges()
        {
            DrawATree();
            ulong totalTime = 0;
            for (int i = 1; i <= 14; i++)
            {
                totalTime += DoChallange(i, false);
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Total time is: ");
            Console.ForegroundColor = ConsoleColor.Green;
            uint milli = (uint)(totalTime % 1000);
            uint seconds = (uint)(totalTime / 1000);
            uint minutes = seconds / 60;
            seconds %= 60;
            uint hours = minutes / 60;
            minutes %= 60;
            string time = "";
            if (hours > 0) time = hours.ToString().PadLeft(2, '0') + ":";
            if (minutes > 0 || hours > 0) time += minutes.ToString().PadLeft(2, '0') + ":";
            if (seconds > 0 || minutes > 0 || hours > 0) time += seconds.ToString().PadLeft(2, '0') + ".";
            time += milli.ToString().PadLeft(3, '0') + " ms";
            Console.Write(time);
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