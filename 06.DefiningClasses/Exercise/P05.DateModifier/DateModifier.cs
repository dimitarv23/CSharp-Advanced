using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class DateModifier
    {
        private string firstDate;
        private string secondDate;
        private int differenceBetweenDates;

        public DateModifier(string firstDate, string secondDate)
        {
            this.FirstDate = firstDate;
            this.SecondDate = secondDate;
            this.DifferenceBetweenDates = DaysDifference(FirstDate, SecondDate);
        }

        public string FirstDate
        {
            get { return firstDate; }
            set { firstDate = value; }
        }
        public string SecondDate
        {
            get { return secondDate; }
            set { secondDate = value; }
        }
        public int DifferenceBetweenDates
        {
            get { return differenceBetweenDates; }
            private set { differenceBetweenDates = value; }
        }

        public int DaysDifference(string date1, string date2)
        {
            string[] date1Info = date1.Split();
            int date1Year = int.Parse(date1Info[0]);
            int date1Month = int.Parse(date1Info[1]);
            int date1Day = int.Parse(date1Info[2]);

            string[] date2Info = date2.Split();
            int date2Year = int.Parse(date2Info[0]);
            int date2Month = int.Parse(date2Info[1]);
            int date2Day = int.Parse(date2Info[2]);

            DateTime firstDate = new DateTime(date1Year, date1Month, date1Day);
            DateTime secondDate = new DateTime(date2Year, date2Month, date2Day);

            return (int)Math.Abs((firstDate - secondDate).TotalDays);
        }
    }
}
