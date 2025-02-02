using System;
using System.Collections.Generic;

public class Scripture
{
    public Reference Reference { get; set; }
    public List<Word> Words { get; set; }

    // Constructor for single verse
    public Scripture(string reference, string text)
    {
        Reference = new Reference(reference);
        Words = new List<Word>();
        foreach (var word in text.Split(' '))
        {
            Words.Add(new Word(word));
        }
    }

    // Constructor for verse range
    public Scripture(string reference, string[] verses)
    {
        Reference = new Reference(reference);
        Words = new List<Word>();
        foreach (var verse in verses)
        {
            foreach (var word in verse.Split(' '))
            {
                Words.Add(new Word(word));
            }
        }
    }

    // Display of full scripture with hidden words
    public void DisplayScripture()
    {
        Console.WriteLine(Reference.ToString());
        foreach (var word in Words)
        {
            Console.Write(word.IsHidden ? new string('_', word.Text.Length) + " " : word.Text + " ");
        }
        Console.WriteLine();
    }

    // Hiding a random word
    public void HideRandomWord()
    {
        var random = new Random();
        var nonHiddenWords = Words.FindAll(w => !w.IsHidden);
        if (nonHiddenWords.Count > 0)
        {
            var wordToHide = nonHiddenWords[random.Next(nonHiddenWords.Count)];
            wordToHide.IsHidden = true;
        }
    }

    // Check if all words are hidden
    public bool AllWordsHidden()
    {
        return Words.All(w => w.IsHidden);
    }
}