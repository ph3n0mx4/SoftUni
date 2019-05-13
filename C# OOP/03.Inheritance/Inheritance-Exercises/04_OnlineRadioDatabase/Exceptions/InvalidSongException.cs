namespace _04_OnlineRadioDatabase
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class InvalidSongException : FormatException
    {
        public InvalidSongException(string message= "Invalid song.") 
            : base(message)
        {
        }
    }
}
