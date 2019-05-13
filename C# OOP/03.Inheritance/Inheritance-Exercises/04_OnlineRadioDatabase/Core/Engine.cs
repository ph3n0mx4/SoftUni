namespace _04_OnlineRadioDatabase.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using _04_OnlineRadioDatabase.Exceptions.SongException;

    public class Engine
    {
        private List<Song> songs;

        public Engine()
        {
            this.songs = new List<Song>();
        }

        public void Run()
        {
            int n =int.Parse(Console.ReadLine());

            var playList = new List<Song>();

            for (int i = 0; i < n; i++)
            {
                try
                {
                    var inputArgs = Console.ReadLine().Split(";").ToArray();

                    if (inputArgs.Length != 3)
                    {
                        throw new InvalidSongException();
                    }
                    //<artist name>;<song name>;<minutes:seconds>
                    string artistName = inputArgs[0];
                    string songName = inputArgs[1];
                    var length = inputArgs[2].Split(":").ToArray();

                    bool isMinutes = int.TryParse(length[0], out int minutes);
                    bool isSecond = int.TryParse(length[1], out int seconds);

                    if (!isMinutes || !isSecond)
                    {
                        throw new InvalidSongLengthException();
                    }

                    var song = new Song(artistName, songName, minutes, seconds);
                    songs.Add(song);
                    Console.WriteLine("Song added.");
                }
                catch (FormatException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            //TimeSpan sec =  new TimeSpan.FromSecond(totalSeconds);
            //int a = sec.Seconds;
            Print();
        }

        private void Print()
        {
            Console.WriteLine($"Songs added: {this.songs.Count}");
            int totalSeconds = this.songs.Sum(s => s.Seconds+s.Minutes*60);
            //int totalMinutes = this.songs.Sum(s => s.Minutes);
            //var time = new TimeSpan(0, totalMinutes, totalSeconds);
            var time = TimeSpan.FromSeconds(totalSeconds);
            Console.WriteLine($"Playlist length: {time.Hours}h {time.Minutes}m {time.Seconds}s");
        }

        //2
        //Playlist length: 0h 7m 47s

    }
}
