using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    public static void sol1()
    {
        if (!File.Exists("input.txt"))
        {
            Console.WriteLine("Il file input.txt non è stato trovato.");
            return;
        }

        List<int> leftList = new List<int>();
        List<int> rightList = new List<int>();


        string[] lines = File.ReadAllLines("input.txt");


        foreach (var line in lines)
        {

            var item = line.Split(' ');

            if (item.Length == 2)
            {
                leftList.Add(int.Parse(item[0]));
                rightList.Add(int.Parse(item[1]));
            }
            else if (item.Length == 5)
            {
                leftList.Add(int.Parse(item[3]));
                rightList.Add(int.Parse(item[4]));
            }
        }


        leftList.Sort();
        rightList.Sort();


        int distance = 0;
        for (int i = 0; i < leftList.Count; i++)
        {
            distance += Math.Abs(leftList[i] - rightList[i]);
        }


        Console.WriteLine($"\nla distanza è {distance}");
    }
    //------Seconda parte dell'esercizio------
    public static void sol2()
    {
       
        List<int> leftList = new List<int>();
        List<int> rightList = new List<int>();

        string[] lines = File.ReadAllLines("input.txt");

        foreach (var line in lines)
        {
            var item = line.Split(' ');

            if (item.Length == 2)
            {
                leftList.Add(int.Parse(item[0]));
                rightList.Add(int.Parse(item[1]));
            }
            else if (item.Length == 5)
            {
                leftList.Add(int.Parse(item[3]));
                rightList.Add(int.Parse(item[4]));
            }
        }
        
        Dictionary<int, int> rightFrequency = new Dictionary<int, int>();

        foreach (int num in rightList)
        {
            if (rightFrequency.ContainsKey(num))
            {
                rightFrequency[num]++;
            }
            else
            {
                rightFrequency[num] = 1;
            }
        }

        // Calcola il punteggio di similarità
        int similarityScore = 0;

        foreach (int leftNum in leftList)
        {
            if (rightFrequency.ContainsKey(leftNum))
            {
                similarityScore += leftNum * rightFrequency[leftNum];
            }
        }

        // Stampa il punteggio di similarità
        Console.WriteLine($"\npunteggio di similarità è: {similarityScore}");
    }
    static void Main()
    {
        Program.sol1();
        Program.sol2();
    }
}
