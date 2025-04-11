using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Xml;

namespace FinalHW
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Введите расположение JSON файла: ");
                string jsonFilePath = Console.ReadLine();

                Console.Write("Введите расположение нового XML файла: ");
                string xmlFilePath = Console.ReadLine();

                ConvertJsonToXml(jsonFilePath, xmlFilePath);

                Console.WriteLine($"Преобразование успешно завершено. Путь к новому XML файлу: {xmlFilePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine("Нажмите любую клавишу для выхода.");
            Console.ReadKey();
        }

        static void ConvertJsonToXml(string jsonFilePath, string xmlFilePath)
        {
            if (!File.Exists(jsonFilePath))
            {
                throw new FileNotFoundException("JSON файл не найден в ", jsonFilePath);
            }

            string jsonContent = File.ReadAllText(jsonFilePath);

            using JsonDocument jsonDoc = JsonDocument.Parse(jsonContent);

            var xmlWriterSettings = new XmlWriterSettings
            {
                Indent = true,
                IndentChars = "  ",
                Encoding = Encoding.UTF8
            };

            using (var xmlWriter = XmlWriter.Create(xmlFilePath, xmlWriterSettings))
            {
                xmlWriter.WriteStartDocument();
                WriteJsonToXml(jsonDoc.RootElement, xmlWriter, "root");
                xmlWriter.WriteEndDocument();
            }
        }

        static void WriteJsonToXml(JsonElement jsonElement, XmlWriter xmlWriter, string elementName)
        {
            switch (jsonElement.ValueKind)
            {
                case JsonValueKind.Object:
                    xmlWriter.WriteStartElement(elementName);
                    foreach (var property in jsonElement.EnumerateObject())
                    {
                        WriteJsonToXml(property.Value, xmlWriter, property.Name);
                    }
                    xmlWriter.WriteEndElement();
                    break;

                case JsonValueKind.Array:
                    xmlWriter.WriteStartElement(elementName);
                    int index = 0;
                    foreach (var item in jsonElement.EnumerateArray())
                    {
                        WriteJsonToXml(item, xmlWriter, $"{elementName}_{index}");
                        index++;
                    }
                    xmlWriter.WriteEndElement();
                    break;

                case JsonValueKind.String:
                    xmlWriter.WriteElementString(elementName, jsonElement.GetString());
                    break;

                case JsonValueKind.Number:
                    xmlWriter.WriteElementString(elementName, jsonElement.GetRawText());
                    break;

                case JsonValueKind.True:
                case JsonValueKind.False:
                    xmlWriter.WriteElementString(elementName, jsonElement.GetBoolean().ToString().ToLower());
                    break;

                case JsonValueKind.Null:
                    xmlWriter.WriteStartElement(elementName);
                    xmlWriter.WriteAttributeString("nil", "true");
                    xmlWriter.WriteEndElement();
                    break;

                default:
                    xmlWriter.WriteElementString(elementName, jsonElement.GetRawText());
                    break;
            }
        }
    }
}
