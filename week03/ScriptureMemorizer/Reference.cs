using System;

public class Reference
{
    public string Text { get; set; }

    // Constructor for single verse or verse range
    public Reference(string reference)
    {
        Text = reference;
    }

    public override string ToString()
    {
        return Text;
    }
}