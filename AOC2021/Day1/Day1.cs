using System;
using System.Collections.Generic;
using System.Linq;

public class AOCDay1
{
    public static void Day1()
    {
        var lstDepths = ReadFile();
        CalculateIncreases(lstDepths);
    }

    private static void CalculateIncreases(List<int> lstDepths)
    {
        var intIncreasesCount = 0;
        var intPrev = lstDepths[0];

        foreach (int depth in lstDepths.Skip(1))
        {
            if (depth > intPrev)
            {
                intIncreasesCount++;
            }

            intPrev = depth;
        }

        Console.WriteLine($"Answer: {intIncreasesCount}");
    }

    public static List<int> ReadFile()
    {
        List<int> lstDepths = new List<int>();

        lstDepths = System.IO.File.ReadAllLines(@"..\Day1.txt").Select(int.Parse).ToList();

        return lstDepths;
    }
}

