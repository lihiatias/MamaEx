using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2048
{
    public class Cell
    {
        public int Value {  get; set; }
        public bool Status { get; set; }
        public Cell() 
        {
            Value = 0;
            Status = true;
        }

        public void ChangeStatus(bool status)
        {
            Status = status;
        }
        public void ChangeValue(int value)
        {
            Value = value;
        }

    }
}
