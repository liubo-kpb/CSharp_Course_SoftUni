namespace DateModifier
{
    public static class DateModifier
    {
        public static double GetDifferenceInDates(string date1, string date2)
        {
            string[] dateInfo = date1.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int year = int.Parse(dateInfo[0]);
            int month = int.Parse(dateInfo[1]);
            int day = int.Parse(dateInfo[2]);
            DateTime dateTime1 = new DateTime(year, month, day);

            dateInfo = date2.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            year = int.Parse(dateInfo[0]);
            month = int.Parse(dateInfo[1]);
            day = int.Parse(dateInfo[2]);
            DateTime dateTime2 = new DateTime(year, month, day);

            TimeSpan timeSpan = dateTime1 > dateTime2 ? (dateTime1 - dateTime2) : (dateTime2 - dateTime1);
            double days = timeSpan.TotalDays;

            return days;
        }
    }
}
