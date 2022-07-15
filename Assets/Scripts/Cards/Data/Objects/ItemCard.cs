using System;
using System.Collections.Generic;
using Data.Json.Colors_Patterns.Objects;
using Data.Json.Deserializer;
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
        private string _histClass;
        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            InstantiateItemCard();
            InstantiateSpriteRenderer();
        }

        private void InstantiateItemCard()
        {
            OutputParameter jParam = JParamHolder._currOutParam; // Currently setted parameter by GameManager for each Card

            _guid = jParam._guid;
            _imgDataName = jParam._dataName;
            _artAllocation = jParam._domain;
            _artist = new Artist();
            _artist.SetJParam = jParam;
            _artist.Awake();
            _title = jParam._title;
            _estimatedCreationTime = AssignCreationTimeRange(jParam._creationTime);
            _materials = ListFiller.FillList<JMaterial>(jParam._materials);
            _techniques = ListFiller.FillList<Technique>(jParam._techs);
            _keywords = jParam._keywords;
            _histClass = jParam._histClass;
        }

        private void InstantiateSpriteRenderer()
        {
            ConfigParameter confParam = JConfigDeserializer.JConfig._out[0]; // Static index is correct for current dataset
            _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            _spriteRenderer.drawMode = SpriteDrawMode.Sliced;
            _spriteRenderer.sprite = Resources.Load<Sprite>(confParam._savePath + _guid);
            _spriteRenderer.size = new Vector2(1f, 1f);
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

        public string HistClass
        {
            get { return _histClass; }
        }
    }
}