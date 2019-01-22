import org.joda.time.LocalDate;
import org.joda.time.LocalTime;

import java.time.Year;

public class Main {


    public static void main(String[] args) {
        LocalDate currentDate = LocalDate.now();
        float minutes = convertToMinutes();
        float dayPercent = timePercent(minutes);
        float weekPercent = weekPercent(currentDate);
        float monthPercent = monthPercent(currentDate);
        float yearPercent = yearPercent(currentDate);
        System.out.println("This Application Shows You What Percentage of Time in Day, Week, Month, Year Has Passed");
        System.out.println("Rounded:");
        System.out.println("Day Percent: " + Math.round(dayPercent) + "%");
        System.out.println("Week Percent: " + Math.round(weekPercent) + "%");
        System.out.println("Month Percent: " + Math.round(monthPercent) + "%");
        System.out.println("Year Percent: " + Math.round(yearPercent) + "%");
        System.out.println("Decimal:");
        System.out.println("Day Percent: " + (dayPercent) + "%");
        System.out.println("Week Percent: " + (weekPercent) + "%");
        System.out.println("Month Percent: " + (monthPercent) + "%");
        System.out.println("Year Percent: " + (yearPercent) + "%");
    }

    private static float convertToMinutes() {
        LocalTime time = LocalTime.now();
        float hMinutes = time.getHourOfDay() * 60;
        float mMinutes = time.getMinuteOfHour();
        float sMinutes = time.getSecondOfMinute() / 60.0f;
        return hMinutes + mMinutes + sMinutes;
    }

    private static float weekPercent(LocalDate date) {
        int today = date.getDayOfWeek();
        float week_time;
        if (today == 1) {
            week_time = convertToMinutes();
        } else {
            week_time = (1440 * (today - 1)) + convertToMinutes();
        }
        return (week_time / 10080) * 100;
    }

    private static float monthPercent(LocalDate date) {
        int max_day = date.dayOfMonth().withMaximumValue().getDayOfMonth();
        int today = date.getDayOfMonth();
        float monthTime;
        if (today == 1) {
            monthTime = convertToMinutes();
        } else {
            monthTime = (1440 * (today - 1)) + convertToMinutes();
        }

        return (monthTime / (1440 * max_day)) * 100;
    }

    private static float yearPercent(LocalDate date) {
        Year year = Year.now();
        int max_day;
        int today = date.getDayOfYear();
        float yearTime;
        if (year.isLeap()) {
            max_day = 366;
        } else {
            max_day = 365;
        }

        if (today == 1) {
            yearTime = convertToMinutes();
        } else {
            yearTime = (1440 * (today - 1)) + convertToMinutes();
        }
        return (yearTime / (1440 * max_day)) * 100;
    }

    private static float timePercent(float minutes) {
        return (minutes / 1440) * 100;
    }

}
