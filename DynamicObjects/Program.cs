using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using DynamicObjects.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DynamicObjects
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            dynamic book = new JObject();
            book.title = "The Greatest Book Ever";
            book.publishDate = DateTime.Parse("01/15/2015");
            book.authors = new JArray("Margaret Jones", "Eli Mather", "Ted Smith");

            var dynamo = new DynamicJSONObject(JsonConvert.SerializeObject(book));
            //var props = dynamo.Properties();
            Console.WriteLine(dynamo.GetType());
            Console.WriteLine(dynamo.Dynamo.title);

            if (Debugger.IsAttached)
            {
                Console.Read();
            }
        }
    }
}