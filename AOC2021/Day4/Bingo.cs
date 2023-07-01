using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Bingo
{
    public int BoardNumber { get; set; }
    public int Column { get; set; }
    public int Row { get; set; }
    public int Value { get; set; }
    public bool Marked { get; set; }
    public bool isBingo { get; set; } = false;
    
    public Bingo() { }

    public Bingo(int boardNumber, int column, int row, int value, bool marked, bool bingo)
    {
        BoardNumber = boardNumber;
        Column = column;
        Row = row;
        Value = value;
        Marked = marked;
        isBingo = bingo;
    }
}

