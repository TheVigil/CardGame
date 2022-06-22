using System;
using Data.Json.Colors_Patterns.Objects;
using Utils;
using Unity;
using UnityEngine;

namespace Data.Objects
{
    public class Artist
    {
        private OutputParameter _jParam;
        private string _name;
        private DateTime _dateOfBirth;
        private DateTime _dateOfDeath;
        private string _birthplace;
        private string _deathplace;

        internal void Awake() // Assembly-Access (almost equals protected)
        {
            _name = CleanArtName(_jParam._artist[0]._fullname);
            _dateOfBirth = string.IsNullOrEmpty(_jParam._artist[0]._birthdate)
                                    ? (DateTime)new DateTime()
                                    : DateTime.Parse(TimeFixer.CleanupDates(_jParam._artist[0]._birthdate));
            _dateOfDeath = string.IsNullOrEmpty(_jParam._artist[0]._deathdate)
                                    ? (DateTime)new DateTime()
                                    : DateTime.Parse(TimeFixer.CleanupDates(_jParam._artist[0]._deathdate));
            _birthplace = _jParam._artist[0]._birthplace;
            _deathplace = _jParam._artist[0]._deathplace;
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

        public OutputParameter SetJParam
        {
            set { _jParam = value; }
        }

        public string Name
        {
            get { return _name; }
        }

        public int BirthDay
        {
            get { return _dateOfBirth.Day; }
        }

        public int BirthMonth
        {
            get { return _dateOfBirth.Month; }
        }

        public int BirthYear
        {
            get { return _dateOfBirth.Year; }
        }

        public int DeathDay
        {
            get { return _dateOfDeath.Day; }
        }

        public int DeathMonth
        {
            get { return _dateOfDeath.Month; }
        }

        public int DeathYear
        {
            get { return _dateOfDeath.Year; }
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