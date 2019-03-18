using System;
using System.Linq;
using System.Text;

namespace P02
{
    class SongEncyrption
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] currentSong = input.Split(':').ToArray();
                string artistName = currentSong[0];
                string songName = currentSong[1];

                bool artistValid = ValidateArtist(artistName);
                bool songValid = ValidateSong(songName);

                if (artistValid == false || songValid == false)
                {
                    Console.WriteLine("Invalid input!");
                    input = Console.ReadLine();
                }
                else
                {
                    int encrCode = artistName.Length;
                    string encryptedArtist = EncryptArtistName(artistName, encrCode);
                    string encryptedSong = EncryptSongName(songName, encrCode);
                    Console.WriteLine($"Successful encryption: {encryptedArtist}@{encryptedSong}");

                    input = Console.ReadLine();
                }
            }
        }

        public static string EncryptSongName(string songName, int encrCode)
        {
            StringBuilder song = new StringBuilder();

            for (int i = 0; i < songName.Length; i++)
            {
                if (songName[i] != ' ' && songName[i] != '\'')
                {
                    if (songName[i] + encrCode > 90)
                    {
                        song.Append((char)((songName[i] + encrCode) - 26));
                    }
                    else
                    {
                        song.Append((char)(songName[i] + encrCode));
                    }
                }
                else
                {
                    song.Append(songName[i]);
                }
            }

            return song.ToString();
        }

        public static string EncryptArtistName(string artistName, int encrCode)
        {
            StringBuilder artist = new StringBuilder();
            for (int i = 0; i < artistName.Length; i++)
            {
                if (artistName[i] != ' ' && artistName[i] != '\'')
                {
                    if (char.IsUpper(artistName[i]) && artistName[i] + encrCode > 90)
                    {
                        artist.Append((char)((artistName[i] + encrCode) - 26));
                    }
                    else if (char.IsLower(artistName[i]) && artistName[i] + encrCode > 122)
                    {
                        artist.Append((char)((artistName[i] + encrCode) - 26));
                    }
                    else
                    {
                        artist.Append((char)(artistName[i] + encrCode));
                    }
                }
                else
                {
                    artist.Append(artistName[i]);
                }
            }

            return artist.ToString();
        }

        public static bool ValidateSong(string songName)
        {
            for (int i = 0; i < songName.Length; i++)
            {
                if (char.IsUpper(songName[i]) || songName[i] == ' ')
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        public static bool ValidateArtist(string artistName)
        {
            if (char.IsLower(artistName[0]))
            {
                return false;
            }
            else
            {
                for (int i = 1; i < artistName.Length; i++)
                {
                    if (char.IsLower(artistName[i]) || artistName[i] == ' ' || artistName[i] == '\'')
                    {
                        continue;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
