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

            var childTokens = book.ChildrenTokens;

            var dynamo = new DynamicJSONObject(JsonConvert.SerializeObject(book));
            //var props = dynamo.Properties();
            //Console.WriteLine(dynamo.GetType());
            //Console.WriteLine(dynamo.Dynamo.title);

            /*------------------------------------------------------*/
            var objectFileDir = Directory.GetCurrentDirectory();
            var objectFile = Path.Combine(objectFileDir, "Book.json");

            var obj = objectReader.LoadDynamic(objectFile);

            Console.WriteLine("//////////////////////////////////////////////");
            foreach (var token in obj)
            {
                Console.WriteLine(token.Name + " " + token.Value);
            }
            Console.WriteLine((JObject)obj.Count);
            Console.WriteLine(obj);

            Console.Write("Title = " + obj.Title);

            //TO DO
            /*
             * Create an object with methods and serialize it
             * Deserialze the object to see if methods come back
             */
            if (Debugger.IsAttached)
            {
                Console.Read();
            }
        }
    }
}