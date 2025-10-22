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
        
        static void Main(string[] args)
        {
            add();
            rndm_add();
         
        }

    }
}
