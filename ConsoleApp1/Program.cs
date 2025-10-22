using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int balance;


            
            List<string> name= new List<string>();
            name.Add("кардан");
            name.Add("двигатель");
            name.Add("КПП");
            name.Add("привод");
            name.Add("печка");

            void rndm_add()
            {
                int i = 0;
                balance=random.Next(10000,20000);
                foreach (string s in name)
                {
                    
                    pare newpare = new pare
                    {
                        Name = s,
                        count = random.Next(0, 5),
                        Price=random.Next(0,10000)
                    };
                    
                }
                Core.Context.SaveChanges();
            }
            List<pare> pares = new List<pare>();
            rndm_add();
            void game()
            {
                Console.WriteLine("----------------------------------------------------------");
                Console.WriteLine("Сейчас на складе есть:");
                foreach (pare sp in pares)
                {
                    Console.WriteLine($"{sp.Name},себестоимость-{sp.Price},колличество-{sp.count}");
                }
                Console.WriteLine($"{balance}-баланс");
                int temp_break = random.Next(1, 6);
                Console.WriteLine($"К вам приехал клиент,и у него сломано {name[temp_break]}\nвыберете какую деталь вы ему поставите");
                int temp_choice=Convert.ToInt32(Console.ReadLine());
                if (temp_choice == temp_break)
                {
                    Console.WriteLine("Ты правильно выбрал деталь и починил машину!");
                    balance = balance + ((pares.First(u => u.Name == name[temp_choice]).Price/100)*20);

                    pare editpare = Core.Context.pare.ToList().Last(u => u.Name == pares[temp_choice].Name); // находим пользователя для изменений
                    editpare.count -= 1; // вносим изменения

                    Core.Context.SaveChanges();

                }
                if (temp_choice != temp_break)
                {
                    Console.WriteLine("Ты непраивльно выбрал деталь для замены...");
                    balance = balance - ((pares.First(u => u.Name == name[temp_choice]).Price / 100) * 20);
                    pare editpare = Core.Context.pare.ToList().Last(u => u.Name == pares[temp_choice].Name); // находим пользователя для изменений
                    editpare.count -= 1; // вносим изменения

                    Core.Context.SaveChanges();
                }
                if (balance <= 0)
                {
                    Console.WriteLine("Увы ты проиграл...");
                }




                Console.WriteLine("----------------------------------------------------------");

            }
            
            while (true)
            {
                game();
            }
        }
    }
}
