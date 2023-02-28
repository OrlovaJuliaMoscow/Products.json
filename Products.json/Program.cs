using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using Products.json;

namespace Products.json
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int n = 5;
            Product[] products = new Product[n];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Enter code");
                int code = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter name");
                string name = Console.ReadLine();

                Console.WriteLine("Enter summa");
              double summa = Convert.ToInt32(Console.ReadLine());
                products[i] = new Product() { Code = code, Name = name, Summa = summa };
            }
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            string jsonString=JsonSerializer.Serialize(products, options);
            using (StreamWriter sw = new StreamWriter("../../../Products.json"))
                { 
                    sw.WriteLine(jsonString);
                }
        }
    }
}