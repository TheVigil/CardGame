using System;

namespace Data.Objects
{
    public class Artist
    {
        private string _name;
        private string _nickname;
        private DateTime _dateOfBirth;
        private DateTime _dateOfDeath;
        private string _birthplace;
        private string _deathplace;

        public Artist(string name, string nickname, string dateOfBirth, string dateOfDeath, string birthplace, string deathplace)
        {
            _name = name;
            _nickname = nickname;
            _dateOfBirth = DateTime.Parse(dateOfBirth);
            _dateOfDeath = DateTime.Parse(dateOfDeath);
            _birthplace = birthplace;
            _deathplace = deathplace;
        }

        public string Name
        {
            get { return _name; }
        }

        public string Nickname
        {
            get { return _nickname; }
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