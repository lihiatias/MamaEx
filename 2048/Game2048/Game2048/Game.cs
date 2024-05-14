namespace Game2048
{
    public class Game
    {
        public Board board { get; set; }
        public GameStatus status { get; set; }
        public int points { get; protected set; }
        public Game()
        {
            board = new Board();
            status = GameStatus.Idle;
            points = 0;
        }
        public void StartNewGame()
        {
            board.Restart();
            status = GameStatus.Idle;
            points = 0;
        }

        public void Move(Direction direction)
        {
            if (status == GameStatus.Idle)
            {
                int pointsEarned = board.Move(direction);
                points += pointsEarned;
                UpdateGameStatus();
            }
        }

        private bool isOn()
        {
            return status == GameStatus.Idle;
        }

        private void UpdateGameStatus()
        {
            if (CheckLose())
            {
                status = GameStatus.Lose;
                return;
            }
            if (CheckWin())
            {
                status = GameStatus.Win;
                return;
            }
            status = GameStatus.Idle;
        }

        private bool CheckWin()
        {
            foreach (Cell cell in board.Data)
            {
                if (cell.Value == 2048)
                {
                    return true;
                }
            }
            return false;
        }

        private bool CheckLose()
        {
            for (int row = 0; row < Board.Size; row++)
            {
                for (int col = 0; col < Board.Size; col++)
                {
                    if (board.IsEmpty(board.Data[row, col]))
                        return false;
                    if (row > 0 && board.CheckMerge(board.Data[row, col], board.Data[row - 1, col]))
                        return false;
                    if (col > 0 && board.CheckMerge(board.Data[row, col], board.Data[row, col - 1]))
                        return false;
                }
            }
            return true;

        }




    }
}
