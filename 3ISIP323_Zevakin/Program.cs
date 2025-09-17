//проверка
List<tovar> tovary = new List<tovar>();
Stack<tovar> stack = new Stack<tovar>();
while (true)
{
    Console.WriteLine("------------------------------------------------"+
        "выбери\n" +
        "добавить-1\n" +
        "удалить-2\n" +
        "Заказать товар-3\n" +
        "Продать товар-4\n" +
        "Поиск-5\n"+
        "вывести весь товар\n"+
        "------------------------------------------------");
    int ttemp=Convert.ToInt32(Console.ReadLine());
    switch (ttemp)
    {
        case 1:
            Console.WriteLine("введите название");
            string temp=Console.ReadLine();
            add();
            
            break;
        case 2:
            delete();
            break;
        case 3:
            postavka();
            break;
        case 4:
            prodat();
            break;
        case 5:
            Console.WriteLine("Введите поиск по какому признаку вы хотите осуществить\n" +
                "id-1\n" +
                "name-2\n" +
                "category-3\n");
            int temp3=Convert.ToInt32(Console.ReadLine());
            switch (temp3)
            {
                case 1:
                    poiskID();
                    break;
                case 2:
                    poiskName();
                    break;
                case 3:
                    poiskKategory();
                    break;
            }
            break;
        case 6:
            foreach (tovar t in tovary)
            {
                Console.WriteLine($"{t.name}, {t.id}, {t.cost}, {t.count},{t.presence},{t.categ}");
            }
                break;
        case 0:
            return 0;
    }
}
void poiskID() {
    Console.WriteLine("Введите id товара");
    int temp=Convert.ToInt32(Console.ReadLine());
foreach(tovar t in tovary)
{
        if (t.id == temp)
        {
            Console.WriteLine($"{t.name}, {t.id}, {t.cost}, {t.count},{t.presence},{t.categ}");
        }
        else
        {
            Console.WriteLine("товар не найден");
        }
}
}
void poiskName()
{
    Console.WriteLine("Введите навзание товара");
    string temp = Console.ReadLine();
    foreach (tovar t in tovary)
    {
        if (t.name == temp)
        {
            Console.WriteLine($"{t.name}, {t.id}, {t.cost}, {t.count},{t.presence},{t.categ}");
        }
        else
        {
            Console.WriteLine("товар не найден");
        }
    }
}
void poiskKategory()
{
    Console.WriteLine("выберете категорию water=1,\r\n    snack=2,\r\n    chebumany=3");
    int temp = Convert.ToInt32(Console.ReadLine());
    foreach (tovar t in tovary)
    {
        if (t.categ == (category)temp)
        {
            Console.WriteLine($"{t.name}, {t.id}, {t.cost}, {t.count},{t.presence},{t.categ}");
        }
        else
        {
            Console.WriteLine("товар не найден");
        }
    }
}

void postavka()
{
    Console.WriteLine("Напишите уже добавленный товар,на который вы хотите оформить поставку");
    string temp= Console.ReadLine();
    foreach(tovar t in tovary)
    {
        if (temp == t.name)
        {
            Console.WriteLine("напиишите колличество товара который хотите заказать");
            int temp1=Convert.ToInt32(Console.ReadLine());
            t.count += temp1;
        }
        else
        {
            Console.WriteLine("вашего товара не нашлось в списке(");
        }
    }
}
void prodat()
{
    Console.WriteLine("Напишите уже добавленный товар,который вы хотите продать");
    string temp = Console.ReadLine();
    foreach (tovar t in tovary)
    {
        if (temp == t.name)
        {
            Console.WriteLine("напиишите колличество товара который хотите продать");
            int temp1 = Convert.ToInt32(Console.ReadLine());
            if (t.count >= temp1)
            {
                t.count -= temp1;
            }
            else
            {
                Console.WriteLine("вашего товара недостаточно в наличии");
            }
            }
        else
        {
            Console.WriteLine("вашего товара не нашлось в списке(");
        }
    }
}
void add()
{
    tovar newtowar = new tovar();
    tovar.ids+=1;
    newtowar.id = tovar.ids;
    Console.WriteLine("Введите название товара");
    string nname = Console.ReadLine();
    newtowar.name = nname;
    Console.WriteLine("Введите цену товара");
    newtowar.cost = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Введите колличесвто товара");
    newtowar.count = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Введите категорию товара\nwater-1/snack-2/chebumany-3");
    newtowar.categ = (category)Convert.ToInt32(Console.ReadLine());
    newtowar.presence = true;
    tovary.Add(newtowar);
}
void delete()
{
    Console.WriteLine("Введите название товара для удаления");
    string input = Console.ReadLine();

    tovar found = tovary.FirstOrDefault(t => t.name == input);
    if (found != null)
    {
        tovary.Remove(found);
    }

}


enum category : long
{
    water=1,
    snack=2,
    chebumany=3
}


class tovar
{

    public static int ids = 1;
    public int id;
    public string name;
    public int cost;
    public int count;
    public bool presence;
    public  category categ;
   
}


