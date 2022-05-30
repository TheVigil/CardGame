using System.Drawing;
using System.Collections.Generic;
using Data.Json.Colors_Patterns.Objects;
using Utils;

namespace Data.Objects
{
    public class ItemCard : Card
    {
        private string _guid;
        private Image _cardImg;
        private string _artAllocation;
        private Artist _artist;
        private string _title;
        private List<int> _estimatedCreationTime;
        private List<string> _materials;
        private List<string> _techniques;
        private string[] _keywords;

        public ItemCard(OutputParameter jParam, string imgPath, Artist artist, string[] keywords)
        {
            _guid = jParam._guid;
            _cardImg = FileToImage(imgPath);
            _artAllocation = jParam._domain;
            _artist = artist;
            _title = jParam._title;
            _estimatedCreationTime = AssignCreationTimeRange(jParam._creationTime);
            _materials = ListFiller.FillList<Material>(jParam._materials);
            _techniques = ListFiller.FillList<Technique>(jParam._techs);
            _keywords = keywords;
        }

        private Image FileToImage(string imgPath)
        {
            return Image.FromFile(imgPath);
        }

        public string Guid
        {
            get { return _guid; }
        }

        public Image Image
        {
            get { return _cardImg; }
        }

        public string Allocation
        {
            get { return _artAllocation; }
        }

        public Artist Artist
        {
            get { return _artist; }
        }

        public string Title
        {
            get { return _title; }
        }

        public List<int> CreationTime
        {
            get { return _estimatedCreationTime; }
        }

        private List<int> AssignCreationTimeRange(string estimatedTime)
        {
            List<int> estimatedTimeRange = new List<int>();
            string[] timeRange = new string[1];
            string cleanedTime = CleanupJSONTimes(estimatedTime);

            if (cleanedTime.Contains('/'))
                timeRange = cleanedTime.Split('/');
            else if (cleanedTime.Contains('-'))
                timeRange = cleanedTime.Split('-');
            else
                timeRange[0] = cleanedTime;

            for (int i = 0; i < timeRange.Length; i++)
                estimatedTimeRange.Add(Int32.Parse(timeRange[i]));

            return estimatedTimeRange;
        }

        private string CleanupJSONTimes(string estimatedTime)
        {
            if (estimatedTime.Contains("um"))
            {
                estimatedTime = estimatedTime.Replace("um ", "");

                if (!(estimatedTime.Contains('/') || estimatedTime.Contains('-')))
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
            else if (estimatedTime.Contains("Jh."))
            {
                if (estimatedTime.Contains("Hälfte"))
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

        public List<string> Materials
        {
            get { return _materials; }
        }

        public List<string> Techniques
        {
            get { return _techniques; }
        }

        public string[] Keywords
        {
            get { return _keywords; }
        }
    }
}