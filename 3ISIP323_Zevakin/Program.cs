//проверка
using System.Diagnostics;
using System.Xml.Linq;
using static tovar;

List<tovar> tovary = new List<tovar>();
int total = 0;
int temp_sale_tovar = 0;
Stack<tovar.SaleRecord> history = new Stack<tovar.SaleRecord>();
tovary.Add(new tovar("lesha", 100, 25, (category)3));
tovary.Add(new tovar("bread", 3949, 1099, (category)2));
tovary.Add(new tovar("water", 50, 566, (category)1));
tovary.Add(new tovar("tomato", 400, 900, (category)2));
tovary.Add(new tovar("potato", 67, 300, (category)2));
while (true)
{
    Console.WriteLine("------------------------------------------------"+
        "выбери\n" +
        "добавить-1\n" +
        "удалить-2\n" +
        "Заказать товар-3\n" +
        "Продать товар-4\n" +
        "Поиск-5\n"+
        "вывести весь товар-6\n"+
        "Отменить последнюю продажу-7\n"+
        "статистика продаж - 8\n"+
        "------------------------------------------------");
    int ttemp=Convert.ToInt32(Console.ReadLine());
    switch (ttemp)
    {
        case 1:
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
            case 7:
            undoSale();
            break;
            case 8:
            stat();
                break;
        case 0:
            return 0;
    }
}

void undoSale()
{
    Console.WriteLine("Хотите отменить последнюю операцию?(y/n)");
    string temp=Console.ReadLine();
    if (temp == "y")
    {
        history.Pop();
    }
}

void stat()
{
    int temp_count = 0;
    int temp_cost = 0;

    foreach(tovar.SaleRecord t in history)
    {
        temp_count += t.Quantity;
        temp_cost += t.Quantity * t.TotalPrice;
        Console.WriteLine($"{t.ProductName},{t.Quantity} проданно на сумму:{t.Quantity * t.TotalPrice}");
    }
    Console.WriteLine($"{temp_count} колличество всего проданного товара");
    Console.WriteLine($"{temp_cost} цена всего проданного товара");
}
void poiskID() {
    bool temp1=true;  
    Console.WriteLine("Введите id товара");
    int temp=Convert.ToInt32(Console.ReadLine());
foreach(tovar t in tovary)
{
        if (t.id == temp)
        {
            Console.WriteLine($"{t.name}, {t.id}, {t.cost}, {t.count},{t.presence},{t.categ}");
            temp1= false;
        }
        else
        {
            Console.WriteLine("товар не найден");
        }
}
if(temp1)
    {
        Console.WriteLine("товар не найден");
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
    bool temp2=true;
    Console.WriteLine("Напишите уже добавленный товар,на который вы хотите оформить поставку");
    string temp= Console.ReadLine();
    foreach(tovar t in tovary)
    {
        if (temp == t.name)
        {
            Console.WriteLine("напишите колличество товара который хотите заказать");
            int temp1=Convert.ToInt32(Console.ReadLine());
            t.count += temp1;
            temp2 = false;
            
        }

    }
    if (temp2)
    {
        Console.WriteLine("Не нашлось(");
    }
}
void prodat()
{
    Console.WriteLine("Напишите уже добавленный товар,который вы хотите продать");
    string temp = Console.ReadLine();
    bool temp4 = true;
    bool temp5 = true;
    foreach (tovar t in tovary)
    {
        if (temp == t.name)
        {
            Console.WriteLine("напиишите колличество товара который хотите продать");
            temp_sale_tovar = Convert.ToInt32(Console.ReadLine());
            if (t.count >= temp_sale_tovar)
            {
                
                var temp3= new SaleRecord(t.id, t.name, temp_sale_tovar, t.cost);
                history.Push(temp3);
                total += (temp_sale_tovar * t.count);
                t.count -= temp_sale_tovar;
                //Console.WriteLine(total);
                temp4= false;
            }
            
            }
        else
        {
            temp5= false;
        }
    }
    if (temp4)
    {
        Console.WriteLine("товара недостаточно");
    }

    if (temp5)
    {
        Console.WriteLine("Товар не найден");
    }
}
void add()
{
    
    tovar.ids += 1;
    Console.WriteLine("Введите название товара");
    string nnam = Console.ReadLine();
    Console.WriteLine("Введите цену товара");
    int cos = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Введите колличесвто товара");
    int coun = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Введите категорию товара\nwater-1/snack-2/chebumany-3");
    int cate= Convert.ToInt32(Console.ReadLine());
    tovar newtowar = new tovar(nnam,cos,coun,(category)cate);
    newtowar.id = tovar.ids;
    newtowar.presence = true;
    tovary.Add(newtowar);
}
void delete()
{
    Console.WriteLine("Введите название товара для удаления");
    string input = Console.ReadLine();

    foreach (tovar t in tovary.ToList())
    {
        if (t.name == input)
        {
            tovary.Remove(t);
        }
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
    public static int ids = 0;
    public int id;
    public string name;
    public int cost;
    public int count;
    public bool presence;
    public category categ;

        public tovar(string n, int cos, int cou, category cat)
    {
        if (string.IsNullOrWhiteSpace(n)) throw new ArgumentException("Название товара не должно быть пустым");
        if (cos <= 0) throw new ArgumentException("Цена должна быть положительной");
        if (cou < 0) throw new ArgumentException("Количество не может быть отрицательным");
        ids += 1;
        id = ids;
        name = n.Trim();
        cost = cos;
        count = cou;
        categ = cat;
        presence = true;
    }
    public class SaleRecord 
{
    public tovar tovhis;
    public int ProductId { get; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public int TotalPrice { get; set; }
    public  SaleRecord(int productId, string productName, int quantity, int totalPrice)
    {
        ProductId=productId;
        ProductName=productName;
        Quantity=quantity;
        TotalPrice=totalPrice;
        
    }
}

}
