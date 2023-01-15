using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines("HelloWorld.ti");
        int lineNum = 0;

        foreach (string line in lines)
        {
            lineNum++;

            string[] tokens = line.Split(' ');
            string firstToken = tokens[0].TrimStart(':');
            if (firstToken == "Disp")
            {
                string stringToPrint = string.Join(" ", tokens, 1, tokens.Length - 1);
                if (!Regex.IsMatch(stringToPrint, "^\"(.*?)\"$"))
                {
                    Console.WriteLine("Error: The string is not surrounded by double quotes.");
                    continue;
                }
                stringToPrint = stringToPrint.Trim('"');

                // use regular expression to extract values from the string
                MatchCollection matches = Regex.Matches(stringToPrint, @"(\d+)");
                List<int> values = new List<int>();
                foreach (Match match in matches)
                {
                    values.Add(int.Parse(match.Value));
                }

                // use the values to format the string
                stringToPrint = string.Format(stringToPrint, values.ToArray());
                Console.WriteLine(stringToPrint);
            }
        }

        Console.ReadLine();
    }
}
