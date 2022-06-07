using System;
using System.Collections.Generic;
using Data.Json.Colors_Patterns.Objects;
using Utils;
using Unity;
using UnityEngine;

namespace Data.Objects
{
    public class ItemCard : Card
    {
        private string _guid;
        private string _imgDataName;
        private string _artAllocation;
        private Artist _artist;
        private string _title;
        private List<int> _estimatedCreationTime;
        private List<string> _materials;
        private List<string> _techniques;
        private List<string> _keywords;
        private SpriteRenderer _renderer;

        public ItemCard(OutputParameter jParam, string imgPath)
        {
            _guid = jParam._guid;
            _imgDataName = imgPath + "/" + _guid + ".png";
            _artAllocation = jParam._domain;
            _artist = new Artist(jParam);
            _title = jParam._title;
            _estimatedCreationTime = AssignCreationTimeRange(jParam._creationTime);
            _materials = ListFiller.FillList<JMaterial>(jParam._materials);
            _techniques = ListFiller.FillList<Technique>(jParam._techs);
            _keywords = jParam._keywords;
        }

        private void Awake()
        {
            _renderer = this.gameObject.GetComponent<SpriteRenderer>();
            _renderer.drawMode = SpriteDrawMode.Sliced;
            _renderer.sprite = Resources.Load<Sprite>(_imgDataName);
        }

        public string Guid
        {
            get { return _guid; }
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

        public string ImgDataName
        {
            get { return _imgDataName; }
        }

        private List<int> AssignCreationTimeRange(string estimatedTime)
        {
            List<int> estimatedTimeRange = new List<int>();
            string[] timeRange = new string[1];
            string cleanedTime = "";

            if (estimatedTime != null)
                cleanedTime = TimeFixer.CleanupCreationTimes(estimatedTime);

            if (cleanedTime.Contains('/'))
                timeRange = cleanedTime.Split('/');
            else if (cleanedTime.Contains('-'))
                timeRange = cleanedTime.Split('-');
            else
                timeRange[0] = cleanedTime;

            for (int i = 0; i < timeRange.Length; i++)
            {
                try
                {
                    estimatedTimeRange.Add(Int32.Parse(timeRange[i]));
                }
                catch (FormatException fe)
                {
                    estimatedTimeRange.Add(0000);
                }

            }

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

        public List<string> Keywords
        {
            get { return _keywords; }
        }
    }
}