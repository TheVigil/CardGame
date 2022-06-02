using Data.Objects;
using System.Globalization;
using System;

namespace Utils
{
    public class NullFixer
    {
        public static T GenVal<T>(string jValue)
        {
            if (jValue is null)
            {
                switch (typeof(T))
                {
                    case var type when type == typeof(DateTime):
                        DateTime date = new DateTime();

                        return (T)Convert.ChangeType(date, typeof(T));

                    default:
                        throw new ArgumentException();
                }
            }
            else
            {
                switch (typeof(T))
                {
                    case var type when type == typeof(DateTime):
                        DateTime time;
                        jValue = CleanHelper<DateTime>(jValue);

                        if (jValue.Length == 4)
                            time = DateTime.ParseExact(jValue, "yyyy", CultureInfo.InvariantCulture);
                        else
                            time = DateTime.Parse(jValue);

                        return (T)Convert.ChangeType(time, typeof(T));

                    default:
                        throw new ArgumentException();

                }
            }
        }

        private static string CleanHelper<T>(string jValue)
        {
            switch (typeof(T))
            {
                case var type when type == typeof(DateTime):
                    if (jValue.Contains("(vor)"))
                        jValue = jValue.Replace("(vor) ", "");
                    else if (jValue.Contains("(nach)"))
                        jValue = jValue.Replace("(nach) ", "");

                    return jValue;

                default:
                    throw new ArgumentException();
            }
        }
    }
}