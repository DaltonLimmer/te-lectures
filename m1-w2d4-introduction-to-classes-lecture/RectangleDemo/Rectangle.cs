using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RectangleDemo
{
    public class Rectangle
    {
        // Member Variables
        private int _length;
        private string _word;

        // Properties
        public int Length
        {
            get
            {
                return _length;
            }

            set
            {
                if (value < 0)
                {
                    _length = value * -1;
                }
                else
                {
                    _length = value;
                }
            }
        }

        public int Width { get; set; }

        public int Area
        {
            get
            {
                return CalculateArea();
            }
        }

        public string Word
        {
            get
            {
                return _word;
            }
            set
            {
                if (value == "Name")
                {
                    _word = "names";
                }
            }
        }

        // Default Constructor
        public Rectangle()
        {
            Length = 0;
            Width = 0;
        }

        // Overloaded Constructor
        public Rectangle(int length, int width)
        {
            Length = length;
            Width = width;
        }

        // Methods
        private int CalculateArea()
        {
            int result = _length * Width;
            return result;
        }

        public static int CalculateArea(int height, int width)
        {
            int result = height * width;
            return result;
        }

    }
}
