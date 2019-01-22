const moment = require("moment");

const main = () => {
  const now = moment();
  const minutes = convertToMinutes(now);
  const dayP = timePercent(minutes);
  const weekP = weekPercent(now);
  const monthP = monthPercent(now);
  const yearP = yearPercent(now);
  console.log(
    "This Application Shows You What Percentage of Time in Day, Week, Month, Year Has Passed"
  );
  console.log("Rounded:");
  console.log("Day Percent:", Math.round(dayP) + "%");
  console.log("Week Percent:", Math.round(weekP) + "%");
  console.log("Month Percent:", Math.round(monthP) + "%");
  console.log("Year Percent:", Math.round(yearP) + "%");
  console.log("Decimal:");
  console.log("Day Percent:", dayP + "%");
  console.log("Week Percent:", weekP + "%");
  console.log("Month Percent:", monthP + "%");
  console.log("Year Percent:", yearP + "%");
};

const convertToMinutes = now => {
  const hMinutes = now.hours() * 60;
  const mMinutes = now.minutes();
  const sMinutes = now.seconds() / 60;
  return hMinutes + mMinutes + sMinutes;
};

const timePercent = minutes => {
  return (minutes / 1440) * 100;
};

const weekPercent = now => {
  const today = now.day();
  let weekTime;
  if (today == 1) {
    weekTime = convertToMinutes(now);
  } else {
    weekTime = 1440 * (today - 1) + convertToMinutes(now);
  }
  return (weekTime / 10080) * 100;
};

const monthPercent = now => {
  const today = now.date();
  let monthTime;
  if (today == 1) {
    monthTime = convertToMinutes(now);
  } else {
    monthTime = 1440 * (today - 1) + convertToMinutes(now);
  }

  return (monthTime / (1440 * now.daysInMonth())) * 100;
};

const yearPercent = now => {
  const today = now.dayOfYear();
  let max_day;
  if (now.isLeapYear()) {
    max_day = 366;
  } else {
    max_day = 365;
  }
  let yearTime;
  if (today == 1) {
    yearTime = convertToMinutes(now);
  } else {
    yearTime = 1440 * (today - 1) + convertToMinutes(now);
  }

  return (yearTime / (1440 * max_day)) * 100;
};
main();
