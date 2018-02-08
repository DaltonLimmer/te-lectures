using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RectangleDemo;

namespace RectangleDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            Rectangle shape = new Rectangle()
            {
                Length = 1,
                Width = 1
            };
            shape.Word = "chris";
            shape.Word = "Name";

            


            //var temp = shape.Length;
            //shape.Width = 10;
            //shape.Length = -10;

            ////shape._length = 10;



            //int area = shape.Area;
            int area2 = Rectangle.CalculateArea(2, 10);
        }
    }
}
