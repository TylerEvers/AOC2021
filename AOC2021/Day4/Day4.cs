using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class AOCDay4
{
    public static void Day4()
    {
        var fileResponse = ReadFile();
        PlayBingo(fileResponse.Item1, fileResponse.Item2);
    }

    public static Tuple<List<int>, List<Bingo>> ReadFile()
    {
        List<int> inputs = new List<int>();
        List<Bingo> boards = new List<Bingo>();

        var arr = System.IO.File.ReadLines(@"..\Day4.txt").ToArray();

        inputs = arr[0].Split(',').Select(int.Parse).ToList();

        //Loop through file lines - skipping inputs
        int boardNumber = 0;
        for (int i = 1; i < arr.Length; i = i + 6)
        {
            //Row
            for (int row = 1; row <= 5; row++)
            {
                var arrRow = arr[i + row];
                //Column
                for (int col = 1; col <= 5; col++)
                {
                    var boardValue = new Bingo(boardNumber, col, row, int.Parse(arrRow.Substring((col-1)*3,2)), false); 
                    boards.Add(boardValue);
                }
            }
            boardNumber++;
        }
        return Tuple.Create(inputs, boards);
    }

    public static void PlayBingo(List<int> inputs, List<Bingo> boards)
    {
        for (int i = 0; i < inputs.Count; i++)
        {
            int value = inputs[i];
            boards.Where(x => x.Value == value).ToList().ForEach(y => y.Marked = true);

            //Get first winning board
            if (i >=4)
            {
                var rowWinner = boards.Where(x => x.Marked == true)
                    .GroupBy(g => new { g.BoardNumber, g.Row})
                    .Where(x => x.Count() == 5)
                    .ToList();

                var colWinner = boards.Where(x => x.Marked == true)
                    .GroupBy(g => new { g.BoardNumber, g.Column })
                    .Where(x => x.Count() == 5)
                    .ToList();

                if (rowWinner.Count() > 0 || colWinner.Count() > 0)
                {
                    int winningBoard = rowWinner.Count() > 0 ? rowWinner[0].First().BoardNumber : colWinner[0].First().BoardNumber;
                    int sum = boards.Where(x => x.BoardNumber == winningBoard && x.Marked == false).Sum(x => x.Value);

                    //Print Output
                    Console.WriteLine($"Answer: {sum * value}");
                }   
            }

            //TODO: Get last winning board
        }
    }
}

