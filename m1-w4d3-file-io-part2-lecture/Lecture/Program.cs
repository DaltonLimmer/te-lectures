using Lecture.Aids;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Lecture
{
    class Program
    {
        static void Main(string[] args)
        {
            // Here are a few examples of reading in a file and writing out values
            // to demonstrate their value.
            //ReadingInFiles.ReadACharacterFile();
            //ReadingInFiles.ReadInACSVFile();  

            //BinaryFileWriter.WritePrimitiveValues();
            //BinaryFileWriter.ReadPrimitiveValues();
            //BinaryImageManipulator.ReadFileIn();
            //PerformanceDemo.SlowPerformance();
            //PerformanceDemo.FastPerformance();

            //Serialization.SerializingXMLData();
            Serialization.SerializingBinaryData();

            // Students find value in building something useful. 
            // As a group you could build something that prompts the user for data and saves it to a file.
            // OR reads a file in and "processes" the data (geocoding?)


            //Console.ReadKey();




        }
    }
}
