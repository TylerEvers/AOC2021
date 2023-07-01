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
                    var boardValue = new Bingo(boardNumber, col, row, int.Parse(arrRow.Substring((col-1)*3,2)), false, false); 
                    boards.Add(boardValue);
                }
            }
            boardNumber++;
        }
        return Tuple.Create(inputs, boards);
    }

    public static void PlayBingo(List<int> inputs, List<Bingo> boards)
    {
        int? firstWinner = null;
        int? lastWinner = null;

        //Loop through inputs
        for (int i = 0; i < inputs.Count; i++)
        {
            int value = inputs[i];

            //Mark Boards
            boards.Where(x => x.Value == value && !x.isBingo)
                .ToList()
                .ForEach(y => y.Marked = true);

            if (i >=4)
            {
                var winningBoards = new List<int>();

                winningBoards.AddRange(boards.Where(x => x.Marked && !x.isBingo)
                    .GroupBy(g => new { g.BoardNumber, g.Row })
                    .Where(x => x.Count() == 5)
                    .SelectMany(group => group.Select(x => x.BoardNumber))
                    .Distinct()
                    .ToList());

                winningBoards.AddRange(boards.Where(x => x.Marked && !x.isBingo)
                    .GroupBy(g => new { g.BoardNumber, g.Column })
                    .Where(x => x.Count() == 5)
                    .SelectMany(group => group.Select(x => x.BoardNumber))
                    .Distinct()
                    .ToList());

                foreach (var boardNumber in winningBoards)
                {
                    //Bingo!
                    boards.Where(x => x.BoardNumber == boardNumber && !x.isBingo)
                        .ToList()
                        .ForEach(y => y.isBingo = true);

                    if (firstWinner == null)
                    {
                        firstWinner = SumBoard(boards, boardNumber) * value;
                    } else
                    {
                        lastWinner = SumBoard(boards, boardNumber) * value;
                    }
                }
            }
        }
        Console.Write($"First Winner: {firstWinner}, Last Winner: {lastWinner}");
    }

    public static int SumBoard(List<Bingo> boards, int boardNumber)
    {
        return boards.Where(x => x.BoardNumber == boardNumber && x.Marked == false).Sum(x => x.Value);
    }
}

