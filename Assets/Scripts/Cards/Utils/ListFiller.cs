using System;
using System.Collections.Generic;
using Data.Json.Colors_Patterns.Objects;

namespace Utils
{
    public class ListFiller
    {
        public static List<string> FillList<T>(List<T> source)
        {
            List<string> destination = new List<string>();
            switch (typeof(T))
            {
                case var type when type == typeof(JMaterial):
                    List<JMaterial> matList = (List<JMaterial>)Convert.ChangeType(source, typeof(List<T>));
                    foreach (JMaterial mat in matList)
                        destination.Add(mat._term);

                    return destination;

                case var type when type == typeof(Technique):
                    List<Technique> techList = (List<Technique>)Convert.ChangeType(source, typeof(List<T>));
                    foreach (Technique tech in techList)
                        destination.Add(tech._term);

                    return destination;

                default:
                    throw new ArgumentException();
            }
        }
    }
}