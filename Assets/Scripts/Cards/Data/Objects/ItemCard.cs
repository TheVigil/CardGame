using System.Drawing;
using System.Collections.Generic;

namespace Data.Objects
{
    public class ItemCard : Card
    {
        private string _artAllocation;
        private Artist _artist;
        private string _title;
        private List<int> _estimatedCreationTime;
        private List<string> _materials;
        private List<string> _techniques;

        public ItemCard(string guid, string imgPath, string artAllocation, Artist artist, string title, string creationTime, List<string> mats, List<string> techs, double pixHeight, double pixWidth)
        {
            _guid = guid;
            _cardImg = base.FileToImage(imgPath);
            _artAllocation = artAllocation;
            _artist = artist;
            _title = title;
            _estimatedCreationTime = AssignCreationTimeRange(creationTime);
            _materials = mats;
            _techniques = techs;
            _pixHeight = pixHeight;
            _pixWidth = pixWidth;
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

            if (estimatedTime.Contains('/'))
                timeRange = estimatedTime.Split('/');
            else if (estimatedTime.Contains('-'))
                timeRange = estimatedTime.Split('-');
            else
                timeRange[0] = estimatedTime;

            for (int i = 0; i < timeRange.Length; i++)
                estimatedTimeRange.Add(Int32.Parse(timeRange[i]));

            return estimatedTimeRange;
        }

        public List<string> Materials
        {
            get { return _materials; }
        }

        public List<string> Techniques
        {
            get { return _techniques; }
        }
    }
}