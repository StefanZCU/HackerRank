using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'migratoryBirds' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    public static int migratoryBirds(List<int> arr)
    {
        SortedDictionary<int, int> results = new SortedDictionary<int, int>();

        int maxCount = 0;
        int bestBird = int.MaxValue;

        for (int i = 0; i < arr.Count; i++)
        {
            if (!results.ContainsKey(arr[i]))
            {
                results.Add(arr[i], 0);
            }

            results[arr[i]]++;
        }

        foreach (var bird in results)
        {
            if (bird.Value > maxCount)
            {
                maxCount = bird.Value;
                bestBird = bird.Key;
            }
            else if (bird.Value == maxCount && bird.Key < bestBird)
            {
                bestBird = bird.Key;
            }
        }
        return bestBird;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int arrCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        int result = Result.migratoryBirds(arr);

        textWriter.WriteLine(result);
        
        textWriter.Flush();
        textWriter.Close();
    }
}