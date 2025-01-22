using System;
using System.Linq;
using System.IO;

class Program
{
    static bool IsReportSafeSol1(string report)
    {

        int[] levels = report.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                             .Where(s => int.TryParse(s.Trim(), out _))
                             .Select(int.Parse)
                             .ToArray();

        if (levels.Length == 0) return false;

        bool increasing = true, decreasing = true;

        for (int i = 1; i < levels.Length; i++)
        {
            int diff = Math.Abs(levels[i] - levels[i - 1]);
            if (diff < 1 || diff > 3)
                return false;
            if (levels[i] < levels[i - 1])
                increasing = false;
            if (levels[i] > levels[i - 1])
                decreasing = false;
        }
        return increasing || decreasing;
    }
    public static void sol1()
    {
        if (!File.Exists("input.txt"))
        {
            Console.WriteLine("Il file input.txt non è stato trovato.");
            return;
        }

        string content = File.ReadAllText("input.txt");
        string[] reports = content.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
        int safeCount = reports.Count(IsReportSafeSol1);
        Console.WriteLine($"Numero di report sicuri: {safeCount}");

    }
    static void Main()
    {
        Program.sol1();
    }

   
}
