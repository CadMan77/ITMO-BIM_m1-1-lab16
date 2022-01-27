using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

//2.Необходимо разработать программу для получения информации о товаре из json - файла.
//  Десериализовать файл «Products.json» из задачи 1.Определить название самого дорогого товара.

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/Lab16-OUT/Products.json";
            StreamReader SR = new StreamReader(path);
            string json_string = SR.ReadToEnd();
            Product[] ImportedProducts = JsonSerializer.Deserialize<Product[]>(json_string);
            decimal priceMax = 0;
            string maxPricePrName = String.Empty;
            foreach (Product oPr in ImportedProducts)
            {
                if (oPr.Price>priceMax)
                {
                    maxPricePrName = oPr.Name;
                    priceMax = oPr.Price;
                }
            }
            Console.WriteLine($"Самый дорогой товар в списке - {maxPricePrName}.");
            Console.ReadKey();
        }
    }
} 
