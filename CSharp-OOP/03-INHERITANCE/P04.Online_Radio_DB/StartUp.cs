using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        List<Song> songs = new List<Song>();
        int allSongsTotalMins = 0;
        int allSongsTotalSec = 0;

        int songsCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < songsCount; i++)
        {
            try
            {
                string[] currentSong = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
                if (currentSong.Length != 3)
                {
                    throw new InvalidSongException();
                }

                string artist = currentSong[0];
                string title = currentSong[1];

                string[] length = currentSong[2].Split(':', StringSplitOptions.RemoveEmptyEntries).ToArray();

                int minutes = 0;
                int seconds = 0;

                if (length.Length != 2)
                {
                    throw new InvalidSongLengthException();
                }
                else
                {
                    bool isMinutes = int.TryParse(length[0], out minutes);
                    bool isSeconds = int.TryParse(length[1], out seconds);

                    if (!isMinutes || !isSeconds)
                    {
                        throw new InvalidSongLengthException();
                    }
                }

                Song song = new Song(artist, title, minutes, seconds);
                Console.WriteLine("Song added.");
                songs.Add(song);
                allSongsTotalMins += minutes;
                allSongsTotalSec += seconds;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                continue;
            }
        }

        allSongsTotalMins += allSongsTotalSec / 60;
        int allSongsTotalHours = allSongsTotalMins / 60;
        allSongsTotalMins %= 60;
        allSongsTotalSec %= 60;

        Console.WriteLine($"Songs added: {songs.Count}");
        Console.WriteLine($"Playlist length: {allSongsTotalHours}h {allSongsTotalMins}m {allSongsTotalSec}s");
    }
}
