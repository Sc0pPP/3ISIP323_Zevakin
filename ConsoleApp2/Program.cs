using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        public static List<tovary> tovars = Core.Context.tovary.ToList();

        public static void registration()
        {
            Console.WriteLine("Для регистрации напишите ваш логин");
            string login=Console.ReadLine();
            Console.WriteLine("Напишите пароль");
            string pasword=Console.ReadLine();
            Console.WriteLine("Подтвердите ввш пароль и напишите его еще один раз");
            string examination=Console.ReadLine();
            if (pasword == examination)
            {
                users user = new users
                {
                    Login = login,
                    passwrod = pasword
                };
                Core.Context.users.Add(user); 
                Core.Context.SaveChanges();
            }
        }
        public static void list_tovar_and_add_to_cart()
        {
            List<users> Lusers = Core.Context.users.ToList();
            Console.WriteLine("Войдите в аакаунт,введите ваш логин");
            string temp_login = Console.ReadLine();
            Console.WriteLine("Войдите в аакаунт,введите ваш пароль");
            string temp_pasword = Console.ReadLine();
            int id_user = Lusers.First(x => x.Login == temp_login).ID;
            foreach (users user in Lusers)
            {
                if (user.Login == temp_login)
                {
                    if (user.passwrod == temp_pasword)
                    {
                        Console.WriteLine("Вы успешно вошли в свою учетную запись");
                        Console.WriteLine("Сегодня в наличии такие товары:");
                        foreach (var tovar in tovars)
                        {
                            Console.WriteLine($"id:{tovar.ID},{tovar.Name},цена:{tovar.Price},{tovar.Description}");

                        }
                        Console.WriteLine("Хотите ли вы что то купить?y/n");
                        string temp = Console.ReadLine();
                        if (temp == "y")
                        {
                            Console.WriteLine("Введите ID товара");
                            int temp_tovarid=Convert.ToInt32(Console.ReadLine());
                            cart cart = new cart
                            {
                                UsersID=user.ID,
                                TovarID=temp_tovarid,
                            };
                            
                            Core.Context.cart.Add(cart);
                            Core.Context.SaveChanges();

                        }

                    }
                }
                {
                    Console.WriteLine("eror");
                    break;
                }
            }
        }
        public static void viewing_tovar()
        {

        }

        public static void placing_an_order()
        {

        }
        public static void history_of_orders()
        {

        }
        static void Main(string[] args)
        {
            Console.WriteLine("Выберете действие");
            while (true)
            {
                int temp_choice = Convert.ToInt32(Console.ReadLine());
                switch (temp_choice) {
                    case 1://просмотр товара
                        viewing_tovar();
                        break;
                    case 2://регистрация
                        registration();
                        break;

                    case 3://вход в аккаунт
                        List<users> Lusers = Core.Context.users.ToList();
                        Console.WriteLine("Войдите в аакаунт,введите ваш логин");
                        string temp_login = Console.ReadLine();
                        Console.WriteLine("Войдите в аакаунт,введите ваш пароль");
                        string temp_pasword = Console.ReadLine();
                        int id_user = Lusers.First(x => x.Login == temp_login).ID;
                        foreach (users user in Lusers)
                        {
                            if (user.Login == temp_login)
                            {
                                if (user.passwrod == temp_pasword)
                                {
                                    Console.WriteLine("Вы успешно вошли в свою учетную запись");

                                }
                            }
                        }

                                    break;
                    case 4://корзина и оформление заказа
                        placing_an_order();

                        break;
                    case 5://просмотр истории заказов с датой
                        history_of_orders();
                        break;

                }
            }

        }
    }
}
