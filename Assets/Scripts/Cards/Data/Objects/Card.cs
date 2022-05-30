using System;
using System.Collections;
using System.Drawing;

namespace Data.Objects
{
    public abstract class Card
    {
        protected readonly double _pixHeight = 50.0;
        protected readonly double _pixWidth = 30.0;

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