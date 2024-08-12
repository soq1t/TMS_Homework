using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using MyHomeworkToolkit;
using Newtonsoft.Json;

namespace Homework13_1.Squad
{
    internal static class SquadManager
    {
        public static Squad? DeserializeSquad(FileInfo jsonFile)
        {
            try
            {
                Squad? squad = JsonConvert.DeserializeObject<Squad>(GetJsonFromFile(jsonFile));
                return squad;
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }

        private static string GetJsonFromFile(FileInfo jsonFile)
        {
            using (StreamReader reader = new StreamReader(jsonFile.FullName))
            {
                string json = reader.ReadToEnd();
                return json;
            }
        }

        public static void SerializeSqauadToXml(Squad squad)
        {
            if (squad == null)
            {
                ConsoleUtility.PrintError("Невозможно сериализовать пустое значение!");
            }
            else
            {
                string serializeDirPath = Directory.GetCurrentDirectory() + @"\output";

                if (!Directory.Exists(serializeDirPath))
                    Directory.CreateDirectory(serializeDirPath);

                string serializeFileName = squad.SquadName + ".xml";

                using (
                    StreamWriter writer = new StreamWriter(
                        serializeDirPath + "\\" + serializeFileName
                    )
                )
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Squad));
                    serializer.Serialize(writer, squad);

                    try
                    {
                        Process.Start("explorer.exe", serializeDirPath);
                    }
                    catch (Exception ex) { }
                }
            }
        }
    }
}
