namespace TimeTrackingApp.Helpers
{
    public static class TimeConverter
    {
        private class TimeUnit
        {
            public string Name { get; set; }
            public int SecondsPerUnit { get; set; }

            public TimeUnit(string name, int secondsPerUnit)
            {
                Name = name;
                SecondsPerUnit = secondsPerUnit;
            }
        }

        //===============================
        // TIME CONVERSION
        //===============================

        private static readonly TimeUnit[] TimeUnits =
        [
            new TimeUnit("year", 31557600),
            new TimeUnit("month", 2629800),
            new TimeUnit("week", 604800),
            new TimeUnit("day", 86400),
            new TimeUnit("hour", 3600),
            new TimeUnit("minute", 60),
            new TimeUnit("second", 1)
        ];

        public static int SecondsToMinutes(int seconds) => seconds / 60;
        public static int SecondsToHours(int seconds) => seconds / 3600;
        public static int SecondsToDays(int seconds) => seconds / 86400;
        public static int SecondsToWeeks(int seconds) => seconds / 604800;
        public static int SecondsToMonths(int seconds) => seconds / 2629800;
        public static int SecondsToYears(int seconds) => seconds / 31557600;


        //===============================
        // TIME FORMATTING UI
        //===============================

        //returns a string representation of the time in the largest unit possible,
        //with the remainder in the next largest unit
        //for UI purposes, e.g. "1 hour and 30 minutes", "2 days and 3 hours", "5 minutes and 10 seconds"
        public static string FormatTime(int seconds)
        {
            // Find the largest unit where the value is >= 1
            for (int i = 0; i < TimeUnits.Length - 1; i++)
            {
                TimeUnit timeUnit = TimeUnits[i];
                int value = seconds / timeUnit.SecondsPerUnit;

                // 1 second or larger
                if (value >= 1)
                {
                    //calc reminder and get the next smaller unit
                    TimeUnit nextTimeUnit = TimeUnits[i + 1];
                    int remainder = (seconds % timeUnit.SecondsPerUnit) / nextTimeUnit.SecondsPerUnit;

                    //plural or singular
                    string mainUnit = value == 1 ? timeUnit.Name : $"{timeUnit.Name}s"; 
                    string nextUnit = remainder == 1 ? nextTimeUnit.Name : $"{nextTimeUnit.Name}s";

                    if (remainder == 0)
                    {
                        return $"{value} {mainUnit}";
                    }

                    return $"{value} {mainUnit} and {remainder} {nextUnit}";
                }
            }

            // < 1 second or fallback
            return $"{seconds} seconds";
        }
    }
}
