namespace Game2048
{
    public class Board
    {
        public Cell[,] Data { get; protected set; }
        public static Random rnd = new Random();
        public const int Size = 4;
        public Board()
        {
            Data = new Cell[Size, Size];
            Restart();

        }
        public void Restart()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Cell cell = new Cell();
                    Data[i, j] = cell;
                }
            }
            Rnd_Location();
            Rnd_Location();
        }
        private void Rnd_Location()
        {
            int[] options = new[] { 2, 4 };

            int value = options[rnd.Next(options.Length)];
            int row, col;
            do
            {
                row = rnd.Next(0, Size);
                col = rnd.Next(0, Size);
            } while (!IsEmpty(Data[row, col]));
            Data[row, col].Value = value;
        }

        public int Move(Direction direction)
        {
            int points = 0;
            switch (direction)
            {
                case Direction.Up:
                    points = MoveUp(); break;
                case Direction.Down:
                    points = MoveDown(); break;
                case Direction.Left:
                    points = MoveLeft(); break;
                case Direction.Right:
                    points = MoveRight(); break;
            }
            Rnd_Location();
            return points;
        }

        private int MoveRight()
        {
            int points = 0;
            for (int row = 0; row < Size; row++)
            {
                bool[] merged = new bool[Size] { false, false, false, false };
                for (int col = Size - 2; col >= 0; col--)
                {
                    if (!IsEmpty(Data[row, col]))
                    {
                        int currentCol = col;
                        while (currentCol < Size - 1 && IsEmpty(Data[row, currentCol + 1]))
                        {
                            MoveToNext(Data[row, currentCol], Data[row, currentCol + 1]);
                            currentCol++;
                        }
                        if (currentCol < Size - 1 && !IsEmpty(Data[row, currentCol + 1]))
                        {
                            if (CheckMerge(Data[row, currentCol], Data[row, currentCol + 1]) && !merged[currentCol + 1])
                            {
                                Merge(Data[row, currentCol], Data[row, currentCol + 1]);
                                points += Data[row, currentCol + 1].Value;
                                merged[currentCol + 1] = true;
                            }
                            currentCol++;
                        }
                    }
                }
            }
            return points;
        }
        private int MoveLeft()
        {
            int points = 0;
            for (int row = 0; row < Size; row++)
            {
                bool[] merged = new bool[Size] { false, false, false, false };
                for (int col = 1; col < Size; col++)
                {
                    if (!IsEmpty(Data[row, col]))
                    {
                        int currentCol = col;
                        while (currentCol > 0 && IsEmpty(Data[row, currentCol - 1]))
                        {
                            MoveToNext(Data[row, currentCol], Data[row, currentCol - 1]);
                            currentCol--;
                        }
                        if (currentCol > 0 && !IsEmpty(Data[row, currentCol - 1]))
                        {
                            if (CheckMerge(Data[row, currentCol], Data[row, currentCol - 1]) && !merged[currentCol - 1])
                            {
                                Merge(Data[row, currentCol], Data[row, currentCol - 1]);
                                points += Data[row, currentCol - 1].Value;
                                merged[currentCol - 1] = true;
                            }
                            currentCol--;
                        }
                    }
                }
            }
            return points;
        }
        private int MoveUp()
        {
            int points = 0;
            for (int col = 0; col < Size; col++)
            {
                bool[] merged = new bool[Size] { false, false, false, false };
                for (int row = 1; row < Size; row++)
                {
                    if (!IsEmpty(Data[row, col]))
                    {
                        int currentRow = row;
                        while (currentRow > 0 && IsEmpty(Data[currentRow - 1, col]))
                        {
                            MoveToNext(Data[currentRow, col], Data[currentRow - 1, col]);
                            currentRow--;
                        }
                        if (currentRow > 0 && !IsEmpty(Data[currentRow - 1, col]))
                        {
                            if (CheckMerge(Data[currentRow, col], Data[currentRow - 1, col]) && !merged[currentRow - 1])
                            {
                                Merge(Data[currentRow, col], Data[currentRow - 1, col]);
                                points += Data[currentRow - 1, col].Value;
                                merged[currentRow - 1] = true;
                            }
                            currentRow--;
                        }
                    }
                }
            }
            return points;
        }
        private int MoveDown()
        {
            int points = 0;
            for (int col = 0; col < Size; col++)
            {
                bool[] merged = new bool[Size] { false, false, false, false };
                for (int row = Size - 1; row >= 0; row--)
                {
                    if (!IsEmpty(Data[row, col]))
                    {
                        int currentRow = row;
                        while (currentRow < Size - 1 && IsEmpty(Data[currentRow + 1, col]))
                        {
                            MoveToNext(Data[currentRow, col], Data[currentRow + 1, col]);
                            currentRow++;
                        }
                        if (currentRow < Size - 1 && !IsEmpty(Data[currentRow + 1, col]))
                        {
                            if (CheckMerge(Data[currentRow, col], Data[currentRow + 1, col]) && !merged[currentRow + 1])
                            {
                                Merge(Data[currentRow, col], Data[currentRow + 1, col]);
                                points += Data[currentRow + 1, col].Value;
                                merged[currentRow + 1] = true;
                            }
                            currentRow++;
                        }
                    }
                }
            }
            return points;
        }
        private void MoveToNext(Cell moving_cell, Cell empty_cell)
        {
            empty_cell.Value = moving_cell.Value;
            moving_cell.Value = 0;
        }

        public bool IsEmpty(Cell cell)
        {
            return cell.Value == 0;
        }
        private void Merge(Cell moving_cell, Cell current_cell)
        {
            current_cell.Value = moving_cell.Value * 2;
            moving_cell.Value = 0;
        }
        public bool CheckMerge(Cell moving_cell, Cell current_cell)
        {
            return moving_cell.Value == current_cell.Value;
        }







    }
}
