using System;
using System.Collections.Generic;




public class CinemaHall:IHallInfo,IMovieInfo
{
    public string HallName { get; set; }
    public int Capacity { get; set; }
    public string HallType { get; set; }
    public List<string> MoviesPlaying { get; set; }




    public CinemaHall(string hallName, int capacity)
    {
        HallName = hallName;
        Capacity = capacity;
        HallType = HallType;
        MoviesPlaying = new List<string>();
    }




    public void DisplayMovieSchedule()
    {
        Console.WriteLine($"Movie Schedule for {HallName} Hall:");
        foreach (string movie in MoviesPlaying)
        {
            Console.WriteLine($"- {movie}");
        }
    }
    public void DisplayMovieInfo()
    {
        Console.WriteLine($"Movie Info for {HallName} hall. ");
        foreach(var movie in MoviesPlaying)
        {
            Console.WriteLine($"The title of Movie Playing is {movie}");
        }
    }
    
}