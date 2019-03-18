public class Song
{
    private string artist;
    private string title;
    private int minutes;
    private int seconds;

    public Song(string artist, string title, int mins, int sec)
    {
        this.Artist = artist;
        this.Title = title;
        this.Minutes = mins;
        this.Seconds = sec;
    }

    public string Artist
    {
        get => this.artist;
        private set
        {
            if (value.Length < 3 || value.Length > 20)
            {
                throw new InvalidArtistNameException();
            }

            this.artist = value;
        }
    }

    public string Title
    {
        get => this.title;
        private set
        {
            if (value.Length < 3 || value.Length > 30)
            {
                throw new InvalidSongNameException();
            }

            this.title = value;
        }
    }

    public int Minutes
    {
        get => this.minutes;
        set
        {
            if ( value < 0 || value > 14)
            {
                throw new InvalidSongMinutesException();
            }

            this.minutes = value;
        }
    }

    public int Seconds
    {
        get => this.seconds;
        set
        {
            if (value < 0 || value > 59)
            {
                throw new InvalidSongSecondsException();
            }

            this.seconds = value;
        }
    }
}

