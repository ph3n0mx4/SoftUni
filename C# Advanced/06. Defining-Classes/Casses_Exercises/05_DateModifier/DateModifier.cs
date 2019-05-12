namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class DateModifier
    {
        private DateTime firstDate;

        private DateTime secondDate;

        public DateTime FirstDate
        {
            get { return firstDate; }
            set { firstDate = value; }
        }

        public DateTime SecondDate
        {
            get { return secondDate; }
            set { secondDate = value; }
        }

        public DateModifier(DateTime firstDate, DateTime secondDate)
        {
            this.firstDate = firstDate;
            this.secondDate = secondDate;
        }

        public int DifferentDays()
        {
            return Math.Abs((firstDate - secondDate).Days);
        }



    }
}
