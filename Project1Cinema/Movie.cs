public class Movie
{
    public string Title { get; set; }
    public int Duration { get; set; }


    public Movie(string title, int duration)
    {
        Title = title;
        Duration = duration;
    }
}