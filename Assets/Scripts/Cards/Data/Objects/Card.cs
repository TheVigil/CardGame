using System;
using System.Collections;
using System.Drawing;

namespace Data.Objects
{
    public abstract class Card
    {
        protected string _guid;
        protected Image _cardImg;
        protected double _pixHeight;
        protected double _pixWidth;

        public string Guid
        {
            get { return _guid; }
        }

        public Image CardImg
        {
            get { return _cardImg; }
        }

        protected Image FileToImage(string imgPath)
        {
            return Image.FromFile(imgPath);
        }

        public double PixHeight
        {
            get { return _pixHeight; }
        }

        public double PixWidth
        {
            get { return _pixWidth; }
        }
    }
}