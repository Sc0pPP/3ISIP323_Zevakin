using System.Diagnostics.Tracing;
using System.Runtime.ExceptionServices;


class Program
{
    static void Main()
    {
        Random random = new Random();
        List<weapon> weapons = new List<weapon>();
        weapon wp1 = new weapon(1, 30);
        weapons.Add(wp1);
        weapon wp2 = new weapon(2, 40);
        weapons.Add(wp2);
        weapon wp3 = new weapon(1, 50);
        weapons.Add(wp3);
        armor ar1 = new armor(30, 1);
        armor ar2 = new armor(50, 2);
        armor ar3 = new armor(100, 3);
        List<armor> armors = new List<armor>();
        armors.Add(ar1);
        armors.Add(ar2);
        armors.Add(ar3);
        player igrok = new player(100, "player", weapons[0], armors[0]);
        goblin gb = new goblin(15, 50, 30, 40);
        skelet sk = new skelet(igrok.armor.armr, 30, 20, 30);
        mag mg = new mag(false, 20, 35, 20, 38);
        goblin_boss g_b = new goblin_boss(15, 50, 30, 40);
        skelet_boss_kova s_b_k = new skelet_boss_kova(igrok.armor.armr, 30, 20, 30);
        skelet_boss_pest s_b_p = new skelet_boss_pest(igrok.armor.armr, 30, 20, 30);
        magc_boss m_b = new magc_boss(false, 20, 35, 20, 38);
        List<enemy> vragy = new List<enemy>();
        vragy.Add(gb);
        vragy.Add(sk);
        vragy.Add(mg);
        vragy.Add(g_b);
        vragy.Add(s_b_k);
        vragy.Add(s_b_p);
        vragy.Add(m_b);
        Console.WriteLine($"{g_b.health},{g_b.ataka}");
        while (true)
        {
            int progress = random.Next(1);
            if (progress == 0)//сундук
            {
                int temp_item = random.Next(2);
                if (temp_item == 0)
                {
                    Console.WriteLine("Вам выпало зелье регенерации!");
                    igrok.health = 100;
                }
                if (temp_item == 1)//выбор оружия
                {
                    int temp_weapon = random.Next(2);
                    if (temp_weapon == 0)
                    {
                        Console.WriteLine("Согласны ли вы выбрать палку 1 ровня?y/n");
                        string temp_wp = Console.ReadLine();
                        if (temp_wp == "y")
                        {
                            igrok.weapon = weapons[0];
                        }
                        if (temp_weapon == 1)
                        {
                            Console.WriteLine("Согласны ли вы выбрать топор 2 ровня?y/n");
                            temp_wp = Console.ReadLine();
                            if (temp_wp == "y")
                            {
                                igrok.weapon = weapons[1];
                            }
                        }
                        if (temp_weapon == 0)
                        {
                            Console.WriteLine("Согласны ли вы выбрать меч  3 ровня?y/n");
                            temp_wp = Console.ReadLine();
                            if (temp_wp == "y")
                            {
                                igrok.weapon = weapons[2];
                            }
                        }
                        if (temp_item == 2)
                        {
                            int temp_armor = random.Next(2);
                            if (temp_weapon == 0)
                            {
                                Console.WriteLine("Согласны ли вы выбрать палку 1 ровня?y/n");
                                string temp_ar = Console.ReadLine();
                                if (temp_ar == "y")
                                {
                                    igrok.armor = armors[0];
                                }
                                if (temp_armor == 1)
                                {
                                    Console.WriteLine("Согласны ли вы выбрать топор 2 ровня?y/n");
                                    temp_wp = Console.ReadLine();
                                    if (temp_ar == "y")
                                    {
                                        igrok.armor = armors[1];
                                    }
                                }
                                if (temp_armor == 0)
                                {
                                    Console.WriteLine("Согласны ли вы выбрать меч  3 ровня?y/n");
                                    temp_wp = Console.ReadLine();
                                    if (temp_ar == "y")
                                    {
                                        igrok.armor = armors[2];
                                    }
                                }
                            }

                        }
                        if (progress == 1)//бой
                        {
                            int temp_fight=random.Next(6);
                            if(temp_fight == 0)
                            {
                                Console.WriteLine("Ты встретил гоблина!");
                                if (igrok.health / vragy[0].ataka > vragy[0].health / igrok.weapon.damage)
                                {
                                    Console.WriteLine("Ты победил!");
                                }
                                else
                                {
                                    Console.WriteLine("увы ты проиграл...");
                                }

                            }
                            if (temp_fight == 1)
                            {
                                Console.WriteLine("Ты встретил гоблина!");
                                if (igrok.health / vragy[0].ataka > vragy[0].health / igrok.weapon.damage)
                                {
                                    Console.WriteLine("Ты победил!");
                                }
                                else
                                {
                                    Console.WriteLine("увы ты проиграл...");
                                }
                            }
                            if (temp_fight == 2)
                            {
                                Console.WriteLine("Ты встретил гоблина!");
                                if (igrok.health / vragy[0].ataka > vragy[0].health / igrok.weapon.damage)
                                {
                                    Console.WriteLine("Ты победил!");
                                }
                                else
                                {
                                    Console.WriteLine("увы ты проиграл...");
                                }
                            }
                            if (temp_fight == 3)
                            {
                                Console.WriteLine("Ты встретил гоблина!");
                                if (igrok.health / vragy[0].ataka > vragy[0].health / igrok.weapon.damage)
                                {
                                    Console.WriteLine("Ты победил!");
                                }
                                else
                                {
                                    Console.WriteLine("увы ты проиграл...");
                                }
                            }
                            if (temp_fight == 4)
                            {
                                Console.WriteLine("Ты встретил гоблина!");
                                if (igrok.health / vragy[0].ataka > vragy[0].health / igrok.weapon.damage)
                                {
                                    Console.WriteLine("Ты победил!");
                                }
                                else
                                {
                                    Console.WriteLine("увы ты проиграл...");
                                }
                            }
                            if (temp_fight == 5)
                            {
                                Console.WriteLine("Ты встретил гоблина!");
                                if (igrok.health / vragy[0].ataka > vragy[0].health / igrok.weapon.damage)
                                {
                                    Console.WriteLine("Ты победил!");
                                }
                                else
                                {
                                    Console.WriteLine("увы ты проиграл...");
                                }
                            }
                            if (temp_fight == 6)
                            {
                                Console.WriteLine("Ты встретил гоблина!");
                                if (igrok.health / vragy[0].ataka > vragy[0].health / igrok.weapon.damage)
                                {
                                    Console.WriteLine("Ты победил!");
                                }
                                else
                                {
                                    Console.WriteLine("увы ты проиграл...");
                                }
                            }

                        }
                    }
                }
            }
        }
    }







    public class player
    {
        public int health = 100;
        public string name { get; set; }
        public weapon weapon;
        public armor armor;
        public player(int health, string name, weapon weapon, armor armor)
        {
            this.health = health;
            this.name = name;
            this.weapon = weapon;
            this.armor = armor;
        }
    }
    public class enemy
    {
        public double health { get; protected set; }
        public double ataka { get; protected set; }
        public double armor { get; protected set; }

        public enemy(double health, double ataka, double armor)
        {
            this.health = health;
            this.ataka = ataka;
            this.armor = armor;
        }
    }


    public class weapon
    {
        public int rare { get; private set; }
        public int damage { get; private set; }

        public weapon(int rare, int damage)
        {
            this.rare = rare;
            this.damage = damage;
        }

    }

    public class armor
    {
        public int armr { get; private set; }
        public int rare { get; private set; }
        public armor(int armr, int rare)
        {
            this.rare = armr;
            this.armr = rare;
        }


    }



    public class goblin : enemy
    {
        public int chance { get; set; }

        public goblin(int chance, double health, double ataka, double armor) : base(health, ataka, armor)
        {
            this.chance = chance;

        }
    }

    public class skelet : enemy
    {
        public int dop_ataka { get; set; }
        public skelet(int dop_ataka, double health, double ataka, double armor) : base(health, ataka, armor)
        {
            this.dop_ataka = dop_ataka;
        }

    }

    public class mag : enemy
    {
        public bool freeze { get; set; }
        public int freeze_chance { get; set; }
        public mag(bool freeze, int freeze_chance, double health, double ataka, double armor) : base(health, ataka, armor)
        {
            this.freeze = freeze;
            this.freeze_chance = freeze_chance;
            this.ataka = ataka;
        }

    }

    public class goblin_boss : goblin
    {
        public goblin_boss(int chance, double health, double ataka, double armor) : base(chance, health, ataka, armor)
        {
            this.chance = chance + 10;
            this.health = health * 2;
            this.ataka = ataka * 1.5;
            this.armor = armor * 1.2;
        }

    }

    public class skelet_boss_kova : skelet
    {
        public skelet_boss_kova(int dop_ataka, double health, double ataka, double armor) : base(dop_ataka, health, ataka, armor)
        {
            this.dop_ataka = dop_ataka;
            this.health = health * 2.5;
            this.ataka = ataka * 1.3;
            this.armor = armor * 1.4;

        }

    }
    public class skelet_boss_pest : skelet
    {
        public skelet_boss_pest(int dop_ataka, double health, double ataka, double armor) : base(dop_ataka, health, ataka, armor)
        {
            this.dop_ataka = dop_ataka;
            this.health = health * 1.3;
            this.ataka = ataka * 1.6;
            this.armor = armor * 1.1;

        }

    }

    public class magc_boss : mag
    {
        public magc_boss(bool freeze, int freeze_chance, double health, double ataka, double armor) : base(freeze, freeze_chance, health, ataka, armor)
        {
            this.freeze = freeze;
            this.freeze_chance = freeze_chance + 10;
            this.health = health * 1.8;
            this.ataka = ataka * 1.6;
            this.armor = armor * 1.1;
        }

    }
}

