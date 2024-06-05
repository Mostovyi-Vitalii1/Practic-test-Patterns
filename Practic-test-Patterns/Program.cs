using System;
using System.Xml;
using Newtonsoft.Json;

class XmlToJsonAdapter
{
    private readonly XmlDocument _xmlDocument;

    public XmlToJsonAdapter(string xmlData)
    {
        _xmlDocument = new XmlDocument();
        _xmlDocument.LoadXml(xmlData);
    }

    public string ConvertToJson()
    {
        //Для того щоб це працювало коректно потрібно було встановити пакет NewtonsoftJson (13.0.3)
        return JsonConvert.SerializeXmlNode(_xmlDocument);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter XML data:");
        //Приклад того, що треба вводити - "<root><name>John</name><age>30</age></root>"
        string xmlData = Console.ReadLine();

        XmlToJsonAdapter adapter = new XmlToJsonAdapter(xmlData);
        string jsonData = adapter.ConvertToJson();

        Console.WriteLine("\nConverted JSON data:");
        Console.WriteLine(jsonData);
    }
}
