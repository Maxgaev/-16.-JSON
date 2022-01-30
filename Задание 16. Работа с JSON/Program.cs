using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Text.Json.Serialization;
using System.IO;

namespace Задание_16.Работа_с_JSON
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int n = 5;
            Product[] products = new Product[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("\nВведите код товара");
                int codeid = Int32.Parse(Console.ReadLine());
                Console.WriteLine("\nВведите название товара");
                string name = Console.ReadLine();
                Console.WriteLine("\nВведите цену товара");
                double price = double.Parse(Console.ReadLine());

                products[i] = new Product() { Codeid = codeid, Name = name, Price = price };
            }

            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true,
            };
            string jsonString = JsonSerializer.Serialize(products, options);
            Console.WriteLine(jsonString);
            Console.ReadKey();

            using (StreamWriter sw = new StreamWriter("../../../Products.json"))
            {
                sw.WriteLine(jsonString);
            }
            
        }



    }

    
}
