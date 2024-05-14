namespace Game2048
{
    public class ConsoleGame
    {
        private Game game { get; set; }

        public ConsoleGame()
        {
            game = new Game();
        }
        public void ShowBoard()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    int cellValue = game.board.Data[i, j].Value;
                    ConsoleColor cellColor = GetCellColor(cellValue);
                    Console.ForegroundColor = cellColor;
                    Console.Write($"{cellValue,-5}");
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }

        public void StartGame()
        {
            ShowBoard();
            DisplayGameStatus();
            Direction direction;
            while (true)
            {
                Console.WriteLine("Use arrow keys to move");
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        direction = Direction.Up; break;
                    case ConsoleKey.DownArrow:
                        direction = Direction.Down; break;
                    case ConsoleKey.LeftArrow:
                        direction = Direction.Left; break;
                    case ConsoleKey.RightArrow:
                        direction = Direction.Right; break;
                    default:
                        Console.WriteLine("\nInvalid input. Please Enter any key to continue");
                        Console.ReadKey(true);
                        continue;
                }
                game.Move(direction);
                ShowBoard();
                DisplayGameStatus();
                if (game.status == GameStatus.Win)
                {
                    Console.WriteLine("\nYou won! Good job!!");
                    break;
                }
                if (game.status == GameStatus.Lose)
                {
                    Console.WriteLine("\nLOSERRRRRR!!");
                    break;
                }
            }
        }
        private void DisplayGameStatus()
        {
            Console.WriteLine($"Points: {game.points}");
            Console.WriteLine($"Status: {game.status}");
        }
        private ConsoleColor GetCellColor(int cellValue)
        {
            switch (cellValue)
            {
                case 2:
                    return ConsoleColor.Green;
                case 4:
                    return ConsoleColor.Yellow;
                case 8:
                    return ConsoleColor.Magenta;
                case 16:
                    return ConsoleColor.Cyan;
                case 32:
                    return ConsoleColor.DarkCyan;
                case 64:
                    return ConsoleColor.DarkRed;
                case 128:
                    return ConsoleColor.Gray;
                case 256:
                    return ConsoleColor.Blue;
                case 512:
                    return ConsoleColor.DarkBlue;
                case 1024:
                    return ConsoleColor.Yellow;
                case 2048:
                    return ConsoleColor.Red;
                default:
                    return ConsoleColor.White;
            }
        }


    }
}
