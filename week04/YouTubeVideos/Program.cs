class Program
{
    static void Main(string[] args)
    {
        // Create videos
        var video1 = new Video("How to Learn Programming for Beginners", "Madokuboba Dokubo", 300);
        video1.Comments.Add(new Comment("Kelly", "It is easy to follow, thanks! great tutorial!"));
        video1.Comments.Add(new Comment("Cutie", "I always wanted to learn programming, this helps! Thanks!"));
        video1.Comments.Add(new Comment("Mike", "Great for beginners!"));

        var video2 = new Video("Learn C# Simplified", "Madokuboba Dokubo", 600);
        video2.Comments.Add(new Comment("Shakiru", "Quick but effective."));
        video2.Comments.Add(new Comment("Philip", "I love your videos!"));
        video2.Comments.Add(new Comment("Hope", "Nice, but I wish there were more details, please do another video for beginners."));

        // List to hold videos
        List<Video> videos = new List<Video> { video1, video2 };

        // Iterate through videos and display information
        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");
            
            foreach (var comment in video.Comments)
            {
                Console.WriteLine($"- {comment.CommenterName}: {comment.Text}");
            }
            Console.WriteLine();
        }
    }
}