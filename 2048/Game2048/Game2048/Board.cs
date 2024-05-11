using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2048
{
    public class Board
    {
        public Cell [,] Data { get; protected set; }
        public static Random rnd = new Random();
        public Board() 
        {
            Data  = new Cell[4, 4];

        }
        public void Restart()
        {
            for (int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    Cell cell = new Cell();
                    Data[i, j] = cell;
                }
            }
            
        }
        private void Rnd_Location()
        {
            int rnd_i = rnd.Next(0, 4);
            int rnd_j = rnd.Next(0, 4);
            int[] options = new[] { 2, 4 };
            int value = options[rnd.Next(options.Length)];
            Data[rnd_i, rnd_j].Value = value;
            Data[rnd_i, rnd_j].Status = true;
        }
        
        public void Move(Direction direction) 
        { 

        }

        private void MoveRight()
        {
            for(int i = 0; i < 4;i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (IsEmpty())
                }
            }

        }
        public bool IsEmpty(Cell cell)
        {
            return cell.Status;
        }
        public void CheckMarge(Cell cell1 , Cell cell2)
        {
            if (cell1.Value == cell2.Value)
            {
                cell1.Value = cell2.Value * 2;
                cell2.Status = true;
            }
        }

        


    }
}
