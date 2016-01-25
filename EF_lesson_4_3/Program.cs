using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_lesson_4_3
{
    class Program
    {
        static void Main(string[] args)
        {
            using (PhoneContext db = new PhoneContext())
            {
                int number1 = db.Phones.Count();
                // найдем кол-во моделей, которые в названии содержат Samsung
                int number2 = db.Phones.Count(p => p.Name.Contains("Samsung"));

                Console.WriteLine(number1);
                Console.WriteLine(number2);

                int minPrice = db.Phones.Min(p => p.Price);
                // максимальная цена
                int maxPrice = db.Phones.Max(p => p.Price);
                // средняя цена на телефоны фирмы Samsung
                double avgPrice = db.Phones.Where(p => p.Company.Name == "Samsung")
                                    .Average(p => p.Price);

                Console.WriteLine(minPrice);
                Console.WriteLine(maxPrice);
                Console.WriteLine(avgPrice);

                // суммарная цена всех моделей
                int sum1 = db.Phones.Sum(p => p.Price);
                // суммарная цена всех моделей фирмы Samsung
                int sum2 = db.Phones.Where(p => p.Name.Contains("Samsung"))
                                    .Sum(p => p.Price);
                Console.WriteLine(sum1);
                Console.WriteLine(sum2);
            }
            Console.ReadLine();
        }
    }
}
