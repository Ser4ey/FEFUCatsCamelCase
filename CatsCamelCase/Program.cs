using System;
using System.IO;
using System.Text;

class VariableNameConverter
{
    static void Main()
    {
        string inputFileName = "input.txt";
        string outputFileName = "output.txt";

        string inputVariableName = File.ReadAllText(inputFileName).Trim();
        string outputVariableName = ConvertVariableName(inputVariableName);
        File.WriteAllText(outputFileName, outputVariableName);
    }

    static string ConvertVariableName(string variableName)
    {
        StringBuilder result = new StringBuilder();
        bool isSnakeCase = true;
        
        foreach (char c in variableName)
        {
            if (Char.IsUpper(c))
            {
                isSnakeCase = false;
            }
        }
        
        if (isSnakeCase)
        {
            bool nextCharToUpper = false;
            bool firstChar = true;
            foreach (char c in variableName)
            {
                if (c == '_')
                {
                    nextCharToUpper = true;
                }
                else if (firstChar)
                {
                    result.Append(Char.ToUpper(c));
                }
                else if (nextCharToUpper)
                {
                    result.Append(Char.ToUpper(c));
                    nextCharToUpper = false;
                }
                else
                {
                    result.Append(c);
                }

                firstChar = false;
            }
        }
        else
        {
            foreach (char c in variableName)
            {
                if (Char.IsUpper(c) && result.Length > 0)
                {
                    result.Append("_");
                    result.Append(Char.ToLower(c));
                }
                else
                {
                    result.Append(Char.ToLower(c));
                }
            }
        }

        return result.ToString();
    }
}