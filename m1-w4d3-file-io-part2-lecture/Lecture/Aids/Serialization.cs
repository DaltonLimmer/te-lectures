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

namespace Lecture.Aids
{
    public static class Serialization
    {
        public static void SerializingXMLData()
        {
            LocalSettings settings = CreateLocalSettings();

            string dirPath = @"C:\VSTemp";

            // Serializing Classes to XML and saving in a file
            string filePath = Path.Combine(dirPath, "Settings.xml");

            XmlSerializer xmlSerializer = new XmlSerializer(settings.GetType());
            using (StringWriter strWriter = new StringWriter())
            {
                using (XmlWriter xmlWriter = XmlWriter.Create(strWriter))
                {
                    xmlSerializer.Serialize(xmlWriter, settings);
                    string outXml = strWriter.ToString();

                    if (!Directory.Exists(dirPath))
                    {
                        Directory.CreateDirectory(@"C:\VSTemp");
                    }

                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }

                    File.WriteAllText(filePath, outXml);
                }
            }

            using (StreamReader strReader = new StreamReader(filePath))
            {
                LocalSettings result = (LocalSettings)xmlSerializer.Deserialize(strReader);
            }
        }

        public static void SerializingBinaryData()
        {
            LocalSettings settings = CreateLocalSettings();

            string dirPath = @"C:\VSTemp";

            // Serialize and Deserialize object to a binary file
            string filePath = Path.Combine(dirPath, "Settings.dat");

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            FileStream fs = new FileStream(filePath, FileMode.Create);

            // Serialize object to binary file
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, settings);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
            }
            finally
            {
                fs.Close();
            }

            // Deserialize data from binary file to object
            fs = new FileStream(filePath, FileMode.Open);
            try
            {
                LocalSettings result = (LocalSettings)formatter.Deserialize(fs);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
            }
            finally
            {
                fs.Close();
            }
        }

        private static LocalSettings CreateLocalSettings()
        {
            LocalSettings settings = new LocalSettings();
            settings.Name = "Chris Rupp";
            settings.Description = "My local settings";
            settings.LastSaveDate = DateTime.Now;
            Preference preference = new Preference();
            preference.Name = "Enable Autosave";
            preference.Options = new List<string>();
            preference.Options.Add("Keep last 5 saves");
            preference.Options.Add("Save every 5 minutes");
            settings.Preferences.Add(preference);

            return settings;
        }
    }
}
