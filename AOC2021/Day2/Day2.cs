using System;
using System.Collections.Generic;
using System.Linq;

public class AOCDay2
{
    public static void Day2()
    {
        var lstCommands = ReadFile();
        CalculatePosition(lstCommands);
        CalculatePositionWithAim(lstCommands);

    }

    private static void CalculatePosition(List<string> lstCommands)
    {
        var intY = 0;
        var intX = 0;
        foreach (string command in lstCommands)
        {
            int intValue = Convert.ToInt32(command.Substring(command.IndexOf(" ")));
            switch (command.Substring(0,command.IndexOf(" ")))
            {
                case "up":
                    intY -= intValue;
                    break;
                case "forward":
                    intX += intValue;
                    break;
                case "down":
                    intY += intValue;
                    break;
                default:
                    Console.WriteLine($"Unexpected command in the input: {command.Trim()}");
                    break;
            }
        }
        Console.WriteLine($"Answer: {intY * intX}");
    }

    private static void CalculatePositionWithAim(List<string> lstCommands)
    {
        var intY = 0;
        var intX = 0;
        var intAim = 0;

        foreach (string command in lstCommands)
        {
            int intValue = Convert.ToInt32(command.Substring(command.IndexOf(" ")));
            switch (command.Substring(0, command.IndexOf(" ")))
            {
                case "forward":
                    intX += intValue;
                    intY += intValue * intAim;
                    break;
                case "up":
                    intAim -= intValue;
                    break;
                case "down":
                    intAim += intValue;
                    break;
                default:
                    Console.WriteLine($"Unexpected command in the input: {command.Trim()}");
                    break;
            }
        }
        Console.WriteLine($"Answer: {intY * intX}");
    }

    public static List<string> ReadFile()
    {
        List<string> lstCommands = new List<string>();

        lstCommands = System.IO.File.ReadAllLines(@"..\Day2.txt").ToList();

        return lstCommands;
    }
}