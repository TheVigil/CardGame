using System;
using Unity;
using UnityEngine;

namespace Data.Objects
{
    public class Card : MonoBehaviour
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