using System;

namespace Utils
{
    public class TimeFixer
    {
        public static string CleanupCreationTimes(string estimatedTime)
        {
            estimatedTime = estimatedTime.ToLower();
            if (estimatedTime.Contains("um"))
            {
                estimatedTime = estimatedTime.Replace("um ", "");

                if (!(estimatedTime.Contains('/') || estimatedTime.Contains('-') || estimatedTime.Contains('(')))
                {
                    int upperDeviation = Int32.Parse(estimatedTime) + 10;
                    int lowerDeviation = Int32.Parse(estimatedTime) - 10;

                    estimatedTime = lowerDeviation + "-" + upperDeviation;
                }
            }
            else if (estimatedTime.Contains("nach"))
            {
                estimatedTime = estimatedTime.Replace("nach ", "");
                int upperDeviation = Int32.Parse(estimatedTime) + 10;

                estimatedTime = estimatedTime + "-" + upperDeviation;
            }
            else if (estimatedTime.Contains("vor"))
            {
                estimatedTime = estimatedTime.Replace("vor ", "");
                int lowerDeviation = Int32.Parse(estimatedTime) - 10;
                estimatedTime = lowerDeviation + "-" + estimatedTime;
            }
            else if (estimatedTime.Contains("jh."))
            {
                if (estimatedTime.Contains("hälfte"))
                {
                    char[] halfCenturyTime = estimatedTime.ToCharArray();
                    int upperDeviation = 50;
                    int composedCentury = Int32.Parse(halfCenturyTime[10] + "" + halfCenturyTime[11]);

                    estimatedTime = (composedCentury - 1) + "00-" + (composedCentury - 1) + upperDeviation;
                }
                else
                {
                    char[] fullCenturyTime = estimatedTime.ToCharArray();
                    int upperDeviation = 99;
                    int composedCentury = Int32.Parse(fullCenturyTime[0] + "" + fullCenturyTime[1]);

                    estimatedTime = (composedCentury - 1) + "00-" + (composedCentury - 1) + upperDeviation;
                }
            }
            if (estimatedTime.Contains('/'))
            {
                string[] timeSplit = estimatedTime.Split('/');

                if (timeSplit[1].Length < 4)
                {
                    char[] longTimeInfo = timeSplit[0].ToCharArray();
                    estimatedTime = timeSplit[0] + "/" + longTimeInfo[0] + longTimeInfo[1] + timeSplit[1];
                }
            }
            if (estimatedTime.Contains('(') && estimatedTime.Contains(')'))
            {
                estimatedTime = estimatedTime.Replace(" (", "/");
                estimatedTime = estimatedTime.Replace(")", "");
            }

            return estimatedTime;
        }

        public static string CleanupDates(string sDate)
        {
            if (sDate.Contains("(vor)"))
                sDate = sDate.Replace("(vor) ", "");
            else if (sDate.Contains("(nach)"))
                sDate = sDate.Replace("(nach) ", "");
            else if (sDate.Contains("(um)"))
                sDate = sDate.Replace("(um) ", "");
            if (sDate.Length == 4)
                sDate = "01.01." + sDate;

            return sDate;
        }
    }
}