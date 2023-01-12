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
     * Complete the 'timeConversion' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING s as parameter.
     */

    public static string timeConversion(string s)
    {
        int hour = int.Parse(s.Substring(0, 2));

        string AMPM = s.Substring(s.Length - 2, 2);

        string newHour = string.Empty;

        if (AMPM == "AM")
        {
            if (hour == 12)
            {
                newHour = $"00{s.Substring(2, 6)}";
            }
            else
            {
                newHour =  s.Substring(0, 8);
            }
        }

        if (AMPM == "PM")
        {
            if (hour < 12)
            {
                newHour = $"{hour + 12}{s.Substring(2, 6)}";
            }
        
            if (hour == 12)
            {
                newHour = $"12{s.Substring(2, 6)}";
            }
        }

        return newHour;

    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        string result = Result.timeConversion(s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}