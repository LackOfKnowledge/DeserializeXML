using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Deserialize_KSkuratowicz2NS
{
    public class Program
    {
        static void Main(string[] args)
        {
            SerializeObjectToXmlString();
            SerializeToXmlFile();
            SerializeListToXmlFile();
            DeserializeXmlToList();
            DeserializeXmlToObject();
            OperationCmpleted();
        }

        private static void OperationCmpleted()
        {
            Console.WriteLine("Operacja zakończona");
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Krzysztof Skuratowicz INF II NS");
            Console.ReadKey();
            Console.ResetColor();
        }

        public static void SerializeObjectToXmlString()
        {
            var czlonek = new Pracownik
            {
                Name = "Bernie",
                SecondName = "Barbarossa",
                Age = 25,
                JoiningDate = DateTime.Now,
                IsEngineer = true,
            };
            var xmlSerializer = new XmlSerializer(typeof(Pracownik));
            using var writer = new StringWriter();
            xmlSerializer.Serialize(writer, czlonek);
            var xmlContent = writer.ToString();
            Console.WriteLine(xmlContent);
            DeserializeXmlToString(xmlContent);
        }

        public static void SerializeToXmlFile()
        {
            var pracownik = new Pracownik
            {
                Name = "Bernie",
                SecondName = "Barbarossa",
                Age = 25,
                JoiningDate = DateTime.Now,
                IsEngineer = true,
            };
            var xmlSerializer = new XmlSerializer(typeof(Pracownik));
            using var writer = new StreamWriter(@"c:\users\janke\source\repos\deserialize_kskuratowicz2ns\deserialize_kskuratowicz2ns\xml-files\sample01.xml");
            xmlSerializer.Serialize(writer, pracownik);
        }
        public static void SerializeListToXmlFile()
        {
            var pracownikList = new List<Pracownik>
            {
                new Pracownik
                {
                    Name = "Bernie",
                    SecondName = "Barbarossa",
                    Age = 25,
                    JoiningDate = DateTime.Now,
                    IsEngineer = true,
                },
                new Pracownik
                {
                    Name = "Katarzyna",
                    SecondName = "Katarzyńska",
                    Age = 29,
                    JoiningDate = DateTime.Now,
                    IsEngineer = false,
                },
                new Pracownik
                {
                    Name = "Zbigniew",
                    SecondName = "Wodecki",
                    Age = 70,
                    JoiningDate = DateTime.Now,
                    IsEngineer = true, // jak najbardziej, jeszcze jak :)
                },
            };
            var xmlSerializer = new XmlSerializer(typeof(List<Pracownik>));
            using var writer = new StreamWriter(@"c:\users\janke\source\repos\deserialize_kskuratowicz2ns\deserialize_kskuratowicz2ns\xml-files\sample02.xml");
            xmlSerializer.Serialize(writer, pracownikList);
        }

        public static void DeserializeXmlToList()
        {
            var xmlSerializer = new XmlSerializer(typeof(List<Pracownik>));
            using var reader = new StreamReader(@"c:\users\janke\source\repos\deserialize_kskuratowicz2ns\deserialize_kskuratowicz2ns\xml-files\sample02.xml");
            var pracownik = (List<Pracownik>)xmlSerializer.Deserialize(reader);
        }
        public static void DeserializeXmlToObject()
        {
            var xmlSerializer = new XmlSerializer(typeof(Pracownik));
            using var reader = new StreamReader(@"c:\users\janke\source\repos\deserialize_kskuratowicz2ns\deserialize_kskuratowicz2ns\xml-files\sample01.xml");
            var pracownik = (Pracownik)xmlSerializer.Deserialize(reader);
        }
        public static void DeserializeXmlToString(string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(Pracownik));
            using var reader = new StringReader(xmlString);
            var member = (Pracownik)xmlSerializer.Deserialize(reader);
        }
    }
}
