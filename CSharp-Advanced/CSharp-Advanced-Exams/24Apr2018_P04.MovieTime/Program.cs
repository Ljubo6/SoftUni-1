using System;
using System.Collections.Generic;
using System.Linq;

namespace _24Apr2018_P04.MovieTime
{
    public class Program
    {
        public static void Main()
        {
            string favGenre = Console.ReadLine();
            string favLength = Console.ReadLine();

            var allMovies = new List<Movie>();

            while (true)
            {
                string[] movie = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries);

                if (movie[0] == "POPCORN!")
                {
                    break;
                }

                string name = movie[0];
                string genre = movie[1];
               
                int[] durationArray = movie[2].Split(':', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                TimeSpan duration = new TimeSpan(durationArray[0], durationArray[1], durationArray[2]);
                var currentMovie = new Movie(name, genre, duration);
                allMovies.Add(currentMovie);
            }

            if (favLength.ToLower() == "short")
            {
                allMovies = allMovies
                    .OrderBy(x => x.Duration)
                    .ThenBy(x => x.Name)
                    .ToList();
            }

            if (favLength.ToLower() == "long")
            {
                allMovies = allMovies
                    .OrderByDescending(x => x.Duration)
                    .ThenBy(x => x.Name)
                    .ToList();
            }

            long totalTicks = allMovies.Sum(x => x.Duration.Ticks);
            var totalDuration = new TimeSpan(totalTicks);

            foreach (var movie in allMovies)
            {
                if (movie.Genre == favGenre)
                {
                    Console.WriteLine(movie.Name);
                    var wifeResponse = Console.ReadLine();
                    if (wifeResponse == "Yes")
                    {
                        Console.WriteLine($"We're watching {movie.Name} - {movie.Duration}");
                        Console.WriteLine($"Total Playlist Duration: {totalDuration}");
                        return;
                    }
                }
            }
        }
    }

    public class Movie
    {
        public string Name { get; set; }
        public string Genre { get; set; }
        public TimeSpan Duration { get; set; }

        public Movie(string name, string genre, TimeSpan duration)
        {
            this.Name = name;
            this.Genre = genre;
            this.Duration = duration;
        }
    }
}
