//=====================================
#region Datetime
//=====================================

using System.Globalization;

//creating an empty date
DateTime date = new DateTime(2026, 6, 1);
Console.WriteLine(date);

//custom date

DateTime customDate = new DateTime(1999, 08, 27, 12, 0, 12);
Console.WriteLine(customDate);

//converting from string to date
string stringDate1 = "12.15.2015";
string stringDate2 = "12/15/2015";
string stringDate3 = "dec.15.2015";
string stringDate4 = "12-15-12";
string stringDate5 = "15.12.2015"; //current culture settings of the system

DateTime stringDate = DateTime.Parse(stringDate5); //TryParse exits too
//works depending on the culture settings of the system, so be careful with it ^
//we can add a culture info to the parse method to be sure about the format of the date
//DateTime.Parse( new CultureInfo("en-US") ,stringDate5); 
//^ this will make sure that the date is parsed in the format of month/day/year,
//so if we have a date in the format of day/month/year it will not be parsed correctly and will throw an exception
Console.WriteLine(stringDate);


DateTime today = DateTime.Now;
Console.WriteLine(today);

Console.WriteLine(today.AddDays(2)); //adding 2 days to the current date
Console.WriteLine(today.AddDays(-2));

Console.WriteLine(today.Day);
Console.WriteLine(today.Date);
Console.WriteLine(today.DayOfWeek);

//formating
string dateFormat1 = today.ToString("dd/MM/yyyy");
string dateFormat2 = today.ToString("MM/dd/yyyy");
string dateFormat3 = today.ToString("yyyy-MM-dd");
string dateFormat4 = today.ToString("dddd, dd MMMM yyyy", CultureInfo.GetCultureInfo("en-Us")); //another way !ADD line 5 [using System.Globalization;]
//MM - month, mm - minutes

Console.WriteLine(dateFormat4);

//fromating
string stringFormat = string.Format("Today is {0:dd/MM/yyyy}, {0:dddd}", today);
//0 is the index of the variable that we want to format, in this case 'today', and after the colon we specify the format of the date
Console.WriteLine(stringFormat);

#endregion
//=====================================