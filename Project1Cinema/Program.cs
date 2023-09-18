using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;



class Program
{
    static void Main()
    {
        List<CinemaHall> cinemaHalls = new List<CinemaHall>();

        Console.Write("Enter the number of cinema halls: ");
        int numberOfHalls = Parser.ParseInt(Console.ReadLine());

        for (int i = 1; i <= numberOfHalls; i++) 
        {
            Console.Write($"Enter the name for hall {i}:");
            string hallname = Console.ReadLine();
            Console.Write($"Enter the capacity of the hall {i}:");
            int hallCapacity = Parser.ParseInt( Console.ReadLine());

            cinemaHalls.Add(new CinemaHall(hallname, hallCapacity));
        }

        foreach(var hall in cinemaHalls)
        {
            Console.WriteLine($"Enter the number of movies for {hall.HallName}:");
            int numberofMovies = Parser.ParseInt( Console.ReadLine());

            for (int i = 1; i <= numberofMovies; i++)
            {
                Console.WriteLine($"Enter the name of the movie {i}:");
                    string movieName = Console.ReadLine();
                hall.MoviesPlaying.Add(movieName);
            }
        }

        foreach(var hall in cinemaHalls)
        {
            hall.DisplayMovieSchedule();
            hall.DisplayMovieInfo();

        }

        Console.WriteLine("Enter a boolean: ");
        string boolInput = Console.ReadLine();
        bool parsedBool;
        if(bool.TryParse(boolInput, out parsedBool))
        {
            Console.WriteLine($"parsed bool : {parsedBool}");
        }
        else
        {
            Console.WriteLine("Invalid Boolean");
        }
        Console.WriteLine("enter a movie title:");
        string movieTitle = Console.ReadLine();
        Console.WriteLine("Enter the duration of movie:");
        int movieDuration = Parser.ParseInt( Console.ReadLine());


        var movieInfo = new Movie(movieTitle, movieDuration);
        Console.WriteLine($"Movie Info: Title={movieInfo.Title}, Duration={movieInfo.Duration} minutes");

        Console.WriteLine("Enter to check if this movie is available: ");
        string thisTitle= Console.ReadLine();
        string selectedTitle = cinemaHalls.Any(hall => hall.MoviesPlaying.Any(movie => string.Equals(movie, thisTitle, StringComparison.OrdinalIgnoreCase))) ? "Movie available" : "Not available";
        //string selectedTitle = cinemaHalls.Any(hall=>hall.MoviesPlaying.Contains(thisTitle)? "Movie available" : "not available";
        Console.WriteLine($"selected Title: { selectedTitle}");




        // LINQ example
      
        var hallsWithMovies = cinemaHalls.Where(hall => hall.MoviesPlaying.Any()).ToList();
        Console.WriteLine("Halls with Movies:");
        foreach (var hall in hallsWithMovies)
        {
            Console.WriteLine($"- {hall.HallName}");
        }
    }


}