namespace _04_Telephony
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class SmartPhone : ICalling, IBrowsing
    {
        public string Browse(string website)
        {
            if(website.Any(x=>char.IsDigit(x)))
            {
                throw new ArgumentException("Invalid URL!");
            }
            return$"Browsing: {website}!";
        }

        public string Call(string number)
        {
            if(!number.Any(x=>char.IsDigit(x)))
            {
                throw new ArgumentException("Invalid number!");
            }
            return $"Calling... {number}";
        }
    }
}
