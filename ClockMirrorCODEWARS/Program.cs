using System;
using System.Text;

namespace ClockMirrorCODEWARS
{
    class MainClass
    {
        public static string timeExample = "01:00";
		public static int hours = Int32.Parse(timeExample.Substring(0, 2));
		public static int minutes = Int32.Parse(timeExample.Substring(3, 2));

		public static int hoursDifference = 0;
		public static int minutesDifference = 0;

		public static bool beforeSix = false;
		public static bool beforeThirty = false;
		public static bool isSix = false;
		public static bool isThirty = false;
		public static bool isTwelve = false;
		public static bool isSixtyMins = false;

		public static void Main(string[] args)
        {
          
            StringBuilder newTime = new StringBuilder();

            int newHr = GetNewHours(hours);
            int newMin = GetNewMins(minutes);

            //appending the hours to the newTime string
            if (beforeSix || isSix || newHr < 9)
            {
                newTime.Append("0" + newHr.ToString());
            }
            else if (newHr > 9)
            {
                {
                    newTime.Append(newHr.ToString());
                }
            }

            //appends the : between the hours and minutes
            newTime.Append(":");


            Console.WriteLine(newTime);
            //appending the minutes to the newTime string

            if(isSixtyMins)
            {
                newTime.Append("00");
            }
            else if (newMin >= 10)
            {
				newTime.Append(newMin);
			}
            else if (newMin < 10)
            {
                newTime.Append("0" + newMin);
            }

            Console.WriteLine(newTime);


        }

		public static int GetNewHours(int hr)
		{
			//hours 
			if (hr > 6 && !(hr == 12))
			{
				hoursDifference = hr - 6; // gathers the amount of hours
											 // beyond 6

				beforeSix = true; // hour is now before six
				return 6 - hoursDifference; 
			}
			else if (hr < 6)
			{
				hoursDifference = 6 - hr; // gathers the amount of hours
                                          // before 6

                beforeSix = false; // hour is now after six
				return 6 + hoursDifference; // sets hours to its "mirror image"

			}
			else if (hr == 12)
			{
				beforeSix = false;
				isSix = false;
				isTwelve = true; // hour is exactly twelve
                return 12;
			}
			else if (hr == 6)
			{
				beforeSix = false;
				isSix = true; // hour is exactly 6
				isTwelve = false;
                return 6;
			}
            else {
                return 0;
            }

		}

		public static int GetNewMins(int min)
		{
			if (min == 0)
			{
				isSixtyMins = true;
                return 0;
			}
            if (min > 30)
            {
                minutesDifference = min - 30;

                isThirty = false;
                beforeThirty = true; // minutes are now less than 30
                return 30 - minutesDifference;
            }
            else if (min < 30)
            {
                minutesDifference = 30 - min;

                isThirty = false;
                beforeThirty = false;
                return minutesDifference + 30;

            }
            else if (min == 30)
            {
                beforeThirty = false;
                isThirty = true;
                return 30;
            }
            else
            {
                return 0;
            }
		}
    }
}
