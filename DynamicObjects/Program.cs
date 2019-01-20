using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.IO;
using DynamicObjects.Model;
using DynamicObjects.Util;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DynamicObjects
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            JsonObjectReader objectReader = new JsonObjectReader();
            dynamic book = new JObject();
            book.title = "The Greatest Book Ever";
            book.publishDate = DateTime.Parse("01/15/2015");
            book.authors = new JArray("Margaret Jones", "Eli Mather", "Ted Smith");

            /*------------------------------------------------------*/
            var objectFileDir = Directory.GetCurrentDirectory();
            var objectFile = Path.Combine(objectFileDir, "Book.json");

            var obj = objectReader.LoadJsonObject(objectFile);

            Console.WriteLine("//////////////////////////////////////////////");
            foreach (var token in obj.Properties())
            {
                Console.WriteLine(token.Name + " - " + token.Value);
                Console.WriteLine("Token indexed: " + obj[token.Name]);
            }

            //var foo = obj.Where(p => p.Name == "Title");//.Select(p => p.Value);

            //TO DO
            /*
             * register methods on objects - store in JSON file with object properties
             * get data on the property, search the object properties?
             */
            if (Debugger.IsAttached)
            {
                Console.Read();
            }
        }
    }
}