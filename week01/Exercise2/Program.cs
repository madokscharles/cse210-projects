using System;

/*
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise2 Project.");
    }
}
*/

class Program
{
    static void Main(string[] args)
    {
        // Prompt the user for their grade percentage
        Console.Write("Enter your grade percentage? ");
        int percentage = int.Parse(Console.ReadLine());

        string letter = "";
        string sign = ""; // Stretch Challenge

        // Determining the letter grade
        if (percentage >= 90)
        {
            letter = "A";
        }
        else if (percentage >= 80)
        {
            letter = "B";
        }
        else if (percentage >= 70)
        {
            letter = "C";
        }
        else if (percentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Determining the "+" or "-" sign if the grade is not F
        if (letter != "F")
        {
            int lastDigit = percentage % 10;

            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
        }

        // Handling special cases for "A" and "F"
        if (letter == "A")
        {
            if (percentage == 100)
            {
                sign = ""; // No "-" for a perfect score
            }
            else if (sign == "+")
            {
                sign = ""; // No "A+"
            }
        }

        if (letter == "F")
        {
            sign = ""; // No "+" or "-" for "F"
        }

        // Display the letter grade with the sign
        Console.WriteLine($"Your grade is: {letter}{sign}");

        // Check if user passed or failed
        if (percentage >= 70)
        {
            Console.WriteLine("Congratulations, you passed!");
        }
        else
        {
            Console.WriteLine("Sorry, better luck next time!");
        }
    }
}