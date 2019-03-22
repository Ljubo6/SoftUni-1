using System;

[Author("Ventsi")]
public class Attributes
{
    [Author("Gosho")]
    static void Main(string[] args)
    {
        var tracker = new Tracker();
        tracker.PrintMethodsByAuthor();
    }
}
