// See https://aka.ms/new-console-template for more information

using System;
public class Transform
{
    public static String TransformSeconds(int seconds)
    {
        if (seconds < 0)
        {
            return "Error, you must insert non negative value";
        }
        else if (seconds == 0)
        {
            return "Now";
        }

        int hours = seconds / 3600;
        int minutes = (seconds % 3600) / 60;
        int totalSeconds = (seconds % 60);

        return $"{hours} hours: {minutes} minutes: {totalSeconds} seconds";
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Submit the number to transform ");
        string input = Console.ReadLine();

        if (int.TryParse(input, out int seconds))
        {
            string result = TransformSeconds(seconds);
            Console.WriteLine(result);
        }
        else
        {
            Console.WriteLine("Error: Type of input invalid");
        }
    }
}

