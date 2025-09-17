//проверка
List<tovar> tovary = new List<tovar>();
void poiskID() {
    int temp=Convert.ToInt32(Console.ReadLine());
foreach(tovar t in tovary)
{
        if (t.id == temp)
        {
            Console.WriteLine($"{t.name}, {t.id}, {t.cost}, {t.count},{t.presence},{t.category}");
        }
        else
        {
            Console.WriteLine("товар не найден");
        }
}
}
void add()
{
    tovar newtowar = new tovar();
    tovar.ids++;
    newtowar.id = tovar.ids++;
    Console.WriteLine("Введите название товара");
    string nname = Console.ReadLine();
    newtowar.name = nname;
    Console.WriteLine("Введите цену товара");
    newtowar.cost = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Введите колличесвто товара");
    newtowar.count = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Введите категорию товара\nwater/snack/chebumany");
    newtowar.category = Console.ReadLine();
    newtowar.presence = true;
    tovary.Add(newtowar);
}
void delete()
{
    Console.WriteLine("Введите ID или название товара для удаления");
    string input = Console.ReadLine();

    tovar found = tovary.FirstOrDefault(t => t.name == input);
    if (found != null)
    {
        tovary.Remove(found);
    }

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
    public int id;
    public string name;
    public int cost;
    public int count;
    public bool presence;
    public string category;
   
}

