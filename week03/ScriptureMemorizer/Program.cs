using System;

class Program
{
    static void Main()
    {
        // Create a scripture instance
        string reference = "John 3:16";
        string text = "For God so loved the world that he gave his only begotten Son";
        Scripture scripture = new Scripture(reference, text);

        // Loop for user interaction
        while (!scripture.AllWordsHidden())
        {
            Console.Clear();
            scripture.DisplayScripture();
            Console.WriteLine("Press Enter to hide a word, or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }
            else
            {
                scripture.HideRandomWord();
            }
        }

        // Final display of hidden scripture
        Console.Clear();
        scripture.DisplayScripture();
        Console.WriteLine("All words are now hidden!");
    }
}