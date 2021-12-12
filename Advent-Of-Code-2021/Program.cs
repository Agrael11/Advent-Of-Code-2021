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
                Console.Write("Select the challange [1-12] or all challanges [A], write [Q] to quit: ");
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

        static void DoChallange(int challange, bool nice = true)
        {
            if (nice)
            {
                DrawATree();
            }
            string inputData = File.ReadAllText($"inputData{challange}.txt");
            string result1;
            string result2;
            switch (challange)
            {
                case 1:
                    result1 = new Day01.Challange1().DoChallange(inputData).ToString();
                    result2 = new Day01.Challange2().DoChallange(inputData).ToString();
                    break;
                case 2:
                    result1 = new Day02.Challange1().DoChallange(inputData).ToString();
                    result2 = new Day02.Challange2().DoChallange(inputData).ToString();
                    break;
                case 3:
                    result1 = new Day03.Challange1().DoChallange(inputData).ToString();
                    result2 = new Day03.Challange2().DoChallange(inputData).ToString();
                    break;
                case 4:
                    result1 = new Day04.Challange1().DoChallange(inputData).ToString();
                    result2 = new Day04.Challange2().DoChallange(inputData).ToString();
                    break;
                case 5:
                    result1 = new Day05.Challange1().DoChallange(inputData).ToString();
                    result2 = new Day05.Challange2().DoChallange(inputData).ToString();
                    break;
                case 6:
                    result1 = new Day06.Challange1().DoChallange(inputData).ToString();
                    result2 = new Day06.Challange2().DoChallange(inputData).ToString();
                    break;
                case 7:
                    result1 = new Day07.Challange1().DoChallange(inputData).ToString();
                    result2 = new Day07.Challange2().DoChallange(inputData).ToString();
                    break;
                case 8:
                    result1 = new Day08.Challange1().DoChallange(inputData).ToString();
                    result2 = new Day08.Challange2().DoChallange(inputData).ToString();
                    break;
                case 9:
                    result1 = new Day09.Challange1().DoChallange(inputData).ToString();
                    result2 = new Day09.Challange2().DoChallange(inputData).ToString();
                    break;
                case 10:
                    result1 = new Day10.Challange1().DoChallange(inputData).ToString();
                    result2 = new Day10.Challange2().DoChallange(inputData).ToString();
                    break;
                case 11:
                    result1 = new Day11.Challange1().DoChallange(inputData).ToString();
                    result2 = new Day11.Challange2().DoChallange(inputData).ToString();
                    break;
                case 12:
                    result1 = new Day12.Challange1().DoChallange(inputData).ToString();
                    result2 = new Day12.Challange2().DoChallange(inputData).ToString();
                    break;
                default:
                    result1 = "ERROR";
                    result2 = "ERROR";
                    break;
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Results of Day {challange} are: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(result1);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" and ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(result2);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("!");
        }
        
        static void DoAllChallanges()
        {
            DrawATree();
            for (int i = 1; i <= 12; i++)
            {
                DoChallange(i, false);
            }
        }

        static void DrawATree()
        {
            Console.Clear();
            for (int i = 0; i < 40; i++)
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