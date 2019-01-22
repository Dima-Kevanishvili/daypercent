using System;

namespace dayPercent
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime now = DateTime.Now;
            float minutes = convertToMinutes(now);
            float dayP = timePercent(minutes);
            float weekP = weekPercent(now);
            float monthP = monthPercent(now);
            float yearP = yearPercent(now);
            Console.WriteLine("This Application Shows You What Percentage of Time in Day, Week, Month, Year Has Passed");
            Console.WriteLine("Rounded:");
            Console.WriteLine("Day Percent: " + Math.Round(dayP).ToString() + "%");
            Console.WriteLine("Week Percent: " + Math.Round(weekP).ToString() + "%");
            Console.WriteLine("Month Percent: " + Math.Round(monthP).ToString() + "%");
            Console.WriteLine("Year Percent: " + Math.Round(yearP).ToString() + "%");
            Console.WriteLine("Decimal:");
            Console.WriteLine("Day Percent: " + dayP.ToString() + "%");
            Console.WriteLine("Week Percent: " + weekP.ToString() + "%");
            Console.WriteLine("Month Percent: " + monthP.ToString() + "%");
            Console.WriteLine("Year Percent: " + yearP.ToString() + "%");

        }
        static float convertToMinutes(DateTime now)
        {
            float hMinutes = now.TimeOfDay.Hours * 60;
            float mMinutes = now.TimeOfDay.Minutes;
            float sMinutes = now.TimeOfDay.Seconds / 60;
            return hMinutes + mMinutes + sMinutes;
        }
        static float timePercent(float minutes)
        {
            return (minutes / 1440) * 100;
        }
        static float weekPercent(DateTime now)
        {
            int today = ((int)(now.DayOfWeek + 6) % 7 + 1); w
            float weekTime;
            if (today == 1)
            {
                weekTime = convertToMinutes(now);
            }
            else
            {
                weekTime = 1440 * (today - 1) + convertToMinutes(now);
            }
            return (weekTime / 10080) * 100;
        }
        static float monthPercent(DateTime now)
        {
            int today = now.Day;
            int maxDay = DateTime.DaysInMonth(now.Year, now.Month);
            float monthTime;
            if(today == 1)
            {
                monthTime = convertToMinutes(now);
            }
            else
            {
                monthTime = 1440 * (today - 1) + convertToMinutes(now);
            }
            return (monthTime / (1440 * maxDay)) * 100;
        }
        static float yearPercent(DateTime now)
        {
            int today = now.DayOfYear;
            int maxDay;
            float yearTime;
            if (DateTime.IsLeapYear(now.Year)){
                maxDay = 366;
            }
            else
            {
                maxDay = 365;
            }
            if(today == 1)
            {
                yearTime = convertToMinutes(now);
            }
            else
            {
                yearTime = 1440 * (today - 1) + convertToMinutes(now);
            }
            return (yearTime / (1440 * maxDay)) * 100;
        }
    }
}
