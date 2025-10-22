using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp1
{
    
    internal class Program
    {
        public static Random random = new Random();
        public static int balance;
        public static List<string> name = new List<string>();
        public static List<pare> pares = Core.Context.pare.ToList();
        public static void add()
        {
            name.Add("кардан");
            name.Add("двигатель");
            name.Add("КПП");
            name.Add("привод");
            name.Add("печка");
        }
        public static void rndm_add()
        {
            
            int i = 0;
            balance = random.Next(10000, 20000);
            foreach (string s in name)
            {

                pare newpare = new pare
                {
                    Name = s,
                    count = random.Next(0, 5),
                    Price = random.Next(0, 10000)
                };
                Core.Context.pare.Add(newpare);

            }
            Core.Context.SaveChanges();
        }
        public static void game()
        {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("Сейчас на складе есть:");
            foreach (pare sp in pares)
            {
                Console.WriteLine($"{sp.Name},себестоимость-{sp.Price},колличество-{sp.count}");
            }
            Console.WriteLine($"{balance}-баланс");
            int temp_break = random.Next(0, 5);
            Console.WriteLine($"К вам приехал клиент,и у него сломано {name[temp_break]}\nвыберете какую деталь вы ему поставите");
            int temp_choice = Convert.ToInt32(Console.ReadLine());
            int coun;
            foreach(pare pr in pares)
            {
                if (pr.Name == name[temp_choice])
                {
                    coun = pr.count;
                }
            }
            if (temp_choice == temp_break)
            {
                
                Console.WriteLine("Ты правильно выбрал деталь и починил машину!");
                balance = balance + ((pares.First(u => u.Name == name[temp_choice]).Price / 100) * 20);

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
                foreach (var pare in Core.Context.pare.ToList())
                {
                    Core.Context.pare.Remove(pare);
                }
                Core.Context.SaveChanges();

            }
            Console.WriteLine("если ты хочешь купить какую то деталь напиши y/n");
            string temp_choice_buy=Console.ReadLine();
            if (temp_choice_buy == "y")
            {
                buy();
            }




            Console.WriteLine("----------------------------------------------------------");

        }
        public static void buy()
        {
            Console.WriteLine("какую запчасть вы хотите купить?\n" +
                "0-кардан\n" +
                "1-двигатель\n" +
                "2-КПП\n" +
                "3-привод\n" +
                "4-печка");
            int temp_buy = Convert.ToInt32(Console.ReadLine());
            pare editpare = Core.Context.pare.ToList().Last(u => u.Name == pares[temp_buy].Name); // находим пользователя для изменений
            editpare.count += 1; // вносим изменения
            balance=balance-(pares.First(u => u.Name == name[temp_buy]).Price);
            Core.Context.SaveChanges();

        }
        public static void game_while()
        {
            while (true)
            {
                Console.WriteLine("ВЫберете следущий ход 1 или очистить базу 2");
                int temp_game = Convert.ToInt32(Console.ReadLine());
                switch (temp_game)
                {
                    case 1:
                        game();
                        break;
                    case 2:
                        foreach (var pare in Core.Context.pare.ToList())
                        {
                            Core.Context.pare.Remove(pare);
                        }
                        Core.Context.SaveChanges();
                        break;


                }
            }
        }
        static void Main(string[] args)
        {
            add();
            rndm_add();
            game_while();
        }

    }
}
