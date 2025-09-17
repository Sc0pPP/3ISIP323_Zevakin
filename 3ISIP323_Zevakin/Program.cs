//проверка
List<tovar> tovary = new List<tovar>();
foreach(tovar t in tovary)
{
    
}
void add()
{

    tovar.ids++;
    Console.WriteLine("Введите название товара");
    string nname = Console.ReadLine();
    tovar.name = nname;
    Console.WriteLine("Введите цену товара");
    tovar.cost = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Введите колличесвто товара");
    tovar.count = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Введите категорию товара\nwater/snack/chebumany");
    tovar.category = Console.ReadLine();
}
void delete()
{

}


enum category : long
{
    water,
    snack,
    chebumany
}


class tovar
{

    public static int ids = 1;
    public static int id;
    public static string name;
    public static int cost;
    public static int count;
    public static bool presence;
    public static string category;
   
}

