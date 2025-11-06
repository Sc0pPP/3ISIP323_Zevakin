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
        public static string temp_login;
        public static List<users> Lusers = Core.Context.users.ToList();
        public static List<cart> Carts = Core.Context.cart.ToList();
        public static List<pvz> Pvz = Core.Context.pvz.ToList();
        public static List<order> Orders = Core.Context.order.ToList();

        public static void registration()
        {
            Console.WriteLine("Для регистрации напишите ваш логин");
            string login = Console.ReadLine();
            Console.WriteLine("Напишите пароль");
            string pasword = Console.ReadLine();
            Console.WriteLine("Подтвердите ввш пароль и напишите его еще один раз");
            string examination = Console.ReadLine();
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

            Console.WriteLine("Сегодня в наличии такие товары:");
            foreach (var tovar in tovars)
            {
                Console.WriteLine($"id:{tovar.ID},{tovar.Name},цена:{tovar.Price},{tovar.Description}");

            }
            Console.WriteLine("Хотите ли вы что то купить?y/n");
            string temp = Console.ReadLine();
            int id = Lusers.First(u => u.Login == temp_login).ID;
            if (temp == "y")
            {
                Console.WriteLine("Введите ID товара");
                int temp_tovarid = Convert.ToInt32(Console.ReadLine());
                cart cart = new cart
                {
                    UsersID = id,
                    TovarID = temp_tovarid,
                };

                Core.Context.cart.Add(cart);
                Core.Context.SaveChanges();

            }

        }

    
                   
                
            
        
        public static void viewing_tovar()
        {
            Console.WriteLine("Сегодня в наличии такие товары:");
            foreach (var tovar in tovars)
            {
                Console.WriteLine($"id:{tovar.ID},{tovar.Name},цена:{tovar.Price},{tovar.Description}");

            }

        }

        public static void placing_an_order()
        {
            int id = Lusers.First(u=>u.Login==temp_login).ID;
            List<cart> temp_order = Carts.Where(u => u.UsersID == id).ToList();
            foreach (var cart in temp_order)
            {
                foreach(var tovar in tovars)
                {
                    if (tovar.ID == cart.TovarID)
                    {
                        Console.WriteLine($"id:{tovar.ID},{tovar.Name},цена:{tovar.Price},{tovar.Description}");
                    }
                }
            }
            Console.WriteLine(" хотите ли вы заказать все эти товары?y/n");
            string temp_choice=Console.ReadLine();
            if (temp_choice == "y")
            {
                Console.WriteLine("Выберете пвз");
                foreach(pvz punkt in Pvz)
                {
                    Console.WriteLine($"{punkt.ID},{punkt.Addres}");
                }
                Console.WriteLine("Введите ID пвз");
                int id_pvz=Convert.ToInt32(Console.ReadLine());
                foreach(cart cart in temp_order)
                {
                    if (id == cart.UsersID)
                    {
                        order order = new order()
                        {
                            UsersID = id,
                            TovarID = cart.TovarID,
                            PvzID=id_pvz,
                            Date= DateTime.Now,
                        };
                        Core.Context.order.Add(order);
                        Core.Context.cart.Remove(cart);
                        Core.Context.SaveChanges();
                        Carts.Remove(cart);
                    }
                }
                Console.WriteLine("Заказ оформлен и скоро убдет доставлен");
            }
        }
        public static void history_of_orders()
        {
            int tempID= Lusers.First(x => x.Login == temp_login).ID;
            List<order> order_user = Orders.Where(u => u.UsersID == tempID).ToList();
            var groupedOrders = order_user
    .GroupBy(order => new DateTime(
        order.Date.Year,
        order.Date.Month,
        order.Date.Day,
        order.Date.Hour,
        order.Date.Minute,
        0)) // Обнуляем секунды - теперь группируем только до минут
    .OrderBy(group => group.Key)
    .ToList();

            foreach (var orderGroup in groupedOrders)
            {
                Console.WriteLine($"Заказ от {orderGroup.Key:dd.MM.yyyy HH:mm}");
                Console.WriteLine("Товары в заказе:");

                foreach (var item in orderGroup)
                {
                    foreach (tovary tovar in tovars) {
                        if (tovar.ID == item.TovarID)
                        {
                            Console.WriteLine($"  - {tovar.Name},{tovar.Price}");
                        }
                    }
                }
               
            }


        }
        static void Main(string[] args)
        {
            Console.WriteLine("Выберете действие");
            while (true)
            {
                Console.WriteLine("Выберете:" +
                    "1://просмотр товара" +
                    "2://регистрация" +
                    "3://вход в аккаунт");
                int temp_choice = Convert.ToInt32(Console.ReadLine());
                switch (temp_choice) {
                    case 1://просмотр товара
                        viewing_tovar();
                        break;
                    case 2://регистрация
                        registration();
                        break;

                    case 3://вход в аккаунт
                        
                        Console.WriteLine("Войдите в аакаунт,введите ваш логин");
                        temp_login = Console.ReadLine();
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
                                    while (true) {
                                        Console.WriteLine("Выберете:" +
                                            "1://список товаров и добавление в корзину" +
                                            "2://корзина и оформление заказа" +
                                            "3://просмотр истории заказов с датой");
                                        int temp = Convert.ToInt32(Console.ReadLine());
                                        switch (temp)
                                        {
                                            case 1://список товаров и добавление в корзину
                                                list_tovar_and_add_to_cart();
                                                break;
                                            case 2://корзина и оформление заказа
                                                placing_an_order();

                                                break;
                                            case 3://просмотр истории заказов с датой
                                                history_of_orders();
                                                break;
                                        }
                                    }


                                }
                            }
                        } 

                    break;
                    
                }
            }

        }
    }
}
