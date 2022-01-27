using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.IO;

//1.Необходимо разработать программу для записи информации о товаре в текстовый файл в формате json.

//Разработать класс для моделирования объекта «Товар». Предусмотреть члены класса «Код товара» (целое число), «Название товара» (строка), «Цена товара» (вещественное число).
//Создать массив из 5-ти товаров, значения должны вводиться пользователем с клавиатуры.
//Сериализовать массив в json-строку, сохранить ее программно в файл «Products.json».

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            const int qty = 5;
            Product[] Products = new Product[qty];
            byte ind = 0;

            do
            {
                try
                {
                    Products[ind] = new Product();
                    Console.WriteLine($"Введите данные продукта №{ind + 1}:");
                    Console.Write("\tКод:\t\t");
                    Products[ind].Code = Convert.ToInt32(Console.ReadLine());
                    Console.Write("\tНазвание:\t");
                    Products[ind].Name = Console.ReadLine();
                    Console.Write("\tЦена:\t\t");
                    Products[ind].Price = Convert.ToDecimal(Console.ReadLine());
                    ind += 1;
                }
                catch (Exception)
                {
                    Console.WriteLine("\nОШИБКА!!! (недопустимый ввод).");
                }
                finally { Console.WriteLine(); }
            }
            while (ind < qty);

            string json_string="";
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/Lab16-OUT/";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            path+= "/Products.json";

            JsonSerializerOptions jso = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            json_string = JsonSerializer.Serialize(Products, jso); // о возможности в одно касание ЗАГНАТЬ в JSON массив стало понятно ТОЛЬКО после просмотра вебинара№3 (в котором на 27:45 нам пеняют за неспособность осознать самостоятельно возможность СЧИТАТЬ из Json массив ... ожидания от способностей слушателей явно завышены :D)!!

            StreamWriter SW = new StreamWriter(path);
            SW.Write(json_string);
            SW.Close();
        }
    }
}
