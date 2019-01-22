import time
import calendar


def main():

    now = time.localtime(time.time())
    minutes = convert_to_minutes(now)
    day_p = time_percent(minutes)
    week_p = week_percent(now)
    month_p = month_percent(now)
    year_p = year_percent(now)
    print("This Application Shows You What Percentage of Time in Day, Week, Month, Year Has Passed")
    print("Rounded:")
    print("Day Percent:", str(round(day_p)) + '%')
    print("Week Percent:", str(round(week_p)) + '%')
    print("Month Percent:", str(round(month_p)) + '%')
    print("Year Percent:", str(round(year_p)) + '%')
    print("Decimal:")
    print("Day Percent:", str(day_p) + '%')
    print("Week Percent:", str(week_p) + '%')
    print("Month Percent:", str(month_p) + '%')
    print("Year Percent:", str(year_p) + '%')


def convert_to_minutes(now):
    hMinutes = now.tm_hour * 60
    mMinutes = now.tm_min
    sMinutes = now.tm_sec / 60
    return hMinutes + mMinutes + sMinutes


def time_percent(minutes):
    return(minutes / 1440) * 100


def week_percent(now):
    today = now.tm_wday + 1  # In Python Indexed With 0-6
    week_time = 0
    if(today == 1):
        week_time = convert_to_minutes(now)
    else:
        week_time = 1440 * (today - 1) + convert_to_minutes(now)
    return (week_time / 10080) * 100


def month_percent(now):
    today = now.tm_mday
    max_day = calendar.monthrange(now.tm_year, now.tm_mon)[1]
    month_time = 0
    if(today == 1):
        month_time = convert_to_minutes(now)
    else:
        month_time = 1440 * (today-1) + convert_to_minutes(now)
    return (month_time / (1440 * max_day)) * 100


def year_percent(now):
    today = now.tm_yday
    max_day = 0
    year_time = 0
    if(calendar.isleap(now.tm_year)):
        max_day = 366
    else:
        max_day = 365
    if(today == 1):
        year_time = convert_to_minutes(now)
    else:
        year_time = 1440 * (today - 1) + convert_to_minutes(now)
    return (year_time / (1440 * max_day)) * 100


if __name__ == "__main__":
    main()
