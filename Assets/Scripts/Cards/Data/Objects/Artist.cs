using System;
using Data.Json.Colors_Patterns.Objects;
using Utils;

namespace Data.Objects
{
    public class Artist
    {
        private string _name;
        private DateTime? _dateOfBirth;
        private DateTime? _dateOfDeath;
        private string _birthplace;
        private string _deathplace;

        public Artist(OutputParameter jParam)
        {
            _name = CleanArtName(jParam._artist[0]._fullname);
            _dateOfBirth = string.IsNullOrEmpty(jParam._artist[0]._birthdate)
                                    ? (DateTime?)null
                                    : DateTime.Parse(TimeFixer.CleanupDates(jParam._artist[0]._birthdate));
            _dateOfDeath = string.IsNullOrEmpty(jParam._artist[0]._deathdate)
                                    ? (DateTime?)null
                                    : DateTime.Parse(TimeFixer.CleanupDates(jParam._artist[0]._deathdate));
            _birthplace = jParam._artist[0]._birthplace;
            _deathplace = jParam._artist[0]._deathplace;
        }

        private string CleanArtName(string name)
        {
            if (name.Contains("Anonym,"))
            {
                string[] nameArr = name.Split(',');
                name = nameArr[0];
            }
            if (name.Contains('(') && name.Contains(')'))
            {
                int start = name.IndexOf(" (");
                int end = name.IndexOf(")");
                name = name.Remove(start, end + 1 - start);
            }

            return name;
        }

        public string Name
        {
            get { return _name; }
        }

        public int BirthDay
        {
            get { return _dateOfBirth.Value.Day; }
        }

        public int BirthMonth
        {
            get { return _dateOfBirth.Value.Month; }
        }

        public int BirthYear
        {
            get { return _dateOfBirth.Value.Year; }
        }

        public int DeathDay
        {
            get { return _dateOfDeath.Value.Day; }
        }

        public int DeathMonth
        {
            get { return _dateOfDeath.Value.Month; }
        }

        public int DeathYear
        {
            get { return _dateOfDeath.Value.Year; }
        }

        public string Birthplace
        {
            get { return _birthplace; }
        }

        public string Deathplace
        {
            get { return _deathplace; }
        }
    }
}