using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class AOCDay3
{
    public static void Day3()
    {
        var arrBinary = ReadFile();
        CalculatePowerConsumption(arrBinary);
        CalculateLifeSupport(arrBinary);
    }

    public static string[] ReadFile()
    {
        string[] arrBinary;

        arrBinary = System.IO.File.ReadAllLines(@"..\Day3.txt").ToArray();

        return arrBinary;
    }

    private static void CalculatePowerConsumption(string[] arrBinary)
    {
        var strGamma = "";
        var strEpsilon = "";
        var i = 0;

        while (i < arrBinary[0].Length)
        {
            if (arrBinary.Count(x => x.Substring(i, 1).Contains("1")) > 500)
            {
                strGamma += "1";
                strEpsilon += "0";
            } else
            {
                strGamma += "0";
                strEpsilon += "1";
            }

            i++;
        }

        Console.WriteLine($"Answer: {Convert.ToInt32(strGamma, 2) * Convert.ToInt32(strEpsilon, 2)}");
    }

    private static void CalculateLifeSupport(string[] arrBinary)
    {
        var arrO2 = arrBinary;
        var arrCO2 = arrBinary;
        var i = 0;

        while (i < arrBinary[0].Length)
        {
            //O2
            if (arrO2.Count() > 1)
            {
                if ((arrO2.Count(x => x.Substring(i, 1).Contains("1")) >= arrO2.Count() / 2.0))
                {
                    arrO2 = arrO2.Where(x => x.Substring(i, 1).Contains("1")).ToArray();
                }
                else
                {
                    arrO2 = arrO2.Where(x => x.Substring(i, 1).Contains("0")).ToArray();
                }
            }

            //CO2
            if (arrCO2.Count() > 1)
            {
                if ((arrCO2.Count(x => x.Substring(i, 1).Contains("1")) >= arrCO2.Count() / 2.0))
                {
                    arrCO2 = arrCO2.Where(x => x.Substring(i, 1).Contains("0")).ToArray();
                }
                else
                {
                    arrCO2 = arrCO2.Where(x => x.Substring(i, 1).Contains("1")).ToArray();
                }
            }


            i++;
        }

        Console.WriteLine($"Answer: {Convert.ToInt32(arrO2[0], 2) * Convert.ToInt32(arrCO2[0], 2)}");
    }
}
