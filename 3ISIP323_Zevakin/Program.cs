using System.Runtime.CompilerServices;

List<book> history = new List<book>();
history.Add(new book("чебурашка", "Алексей", genre.fnatastics, 1998,345));
history.Add(new book("букварь", "максим", genre.novel, 1948, 745));
history.Add(new book("энциклопедия", "Алексей", genre.comedy, 1997, 895));
history.Add(new book("7 гномов", "Алексей анисимов", genre.novel, 2007, 1200));
history.Add(new book("чебурашка", "Алексей", 0, 1998, 345));

while (true)
{
    Console.WriteLine("------------------------------------------------" +
        "выбери\n" +
        "добавить-1\n" +
        "удалить-2\n" +
        "поиск3\n" +
        "сортировка4\n" +
        "дорого дешево5\n" +
        "групировка-6\n" +
        "vivod7"+
        "------------------------------------------------");
    int ttemp = Convert.ToInt32(Console.ReadLine());
    switch (ttemp)
    {
        case 1:
            Console.WriteLine("введите название");
            string temp = Console.ReadLine();
            add();

            break;
        case 2:
            delete();
            break;
        case 3:
            search();
            break;
        case 4:
            sort();
            break;
        case 5:
            dorogo();
            break;
        case 6:
            group();
            break;
        case 7:
            vivod();
            break;
    }
}
void vivod()
{
    foreach (var book in history)
    {
        Console.WriteLine($"{book.name} - {book.author} - {book.year} - {book.price} руб.");
    }
}
void add()
{
    string name = Console.ReadLine();

    string tauthor = Console.ReadLine();
    genre GEnre = (genre)Convert.ToInt32(Console.ReadLine());
    decimal pricee = Convert.ToDecimal(Console.ReadLine());
    int year = Convert.ToInt32(Console.ReadLine());
    history.Add(new book(name, tauthor, GEnre, year, pricee));
    

}

void delete()
{
    void poiskID()
    {
        bool temp1 = true;
        Console.WriteLine("Введите id товара");
        int temp = Convert.ToInt32(Console.ReadLine());
        foreach (book t in history)
        {
            if (t.id == temp)
            {
                history.Remove(t);
            }
            else
            {
                Console.WriteLine("товар не найден");
            }
        }
        if (temp1)
        {
            Console.WriteLine("товар не найден");
        }
    }
}
void search()
{
    Console.WriteLine("Выберете какой поиск выы хотите\n1-имя\n2-автор\n3-жанр");
    int temmp = Convert.ToInt32(Console.ReadLine());
    switch (temmp) {
        case 1:
            poiskName();
            break;
        case 2:
            poiskauth();
            break;
        case 3:
            poiskKategory();
            break;

    void poiskName()
    {
        bool temp1 = true;
        Console.WriteLine("Введите id товара");
        string temp = Console.ReadLine();
        foreach (book t in history)
        {
            if (t.name == temp)
            {
                //Console.WriteLine($"{t.name}, {t.id}, {t.cost}, {t.count},{t.presence},{t.categ}");
                temp1 = false;
            }
            else
            {
                Console.WriteLine("товар не найден");
            }
        }
        if (temp1)
        {
            Console.WriteLine("товар не найден");
        }
    }
    void poiskauth()
    {
        Console.WriteLine("Введите навзание товара");
        string temp = Console.ReadLine();
        foreach (book t in history)
        {
            if (t.author == temp)
            {
                Console.WriteLine($"{t.name}, {t.id}, {t.author}, {t.price},{t.genre},{t.year}");
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
        foreach (book t in history)
        {
            if (t.genre == (genre)temp)
            {
                        Console.WriteLine($"{t.name}, {t.id}, {t.author}, {t.price},{t.genre},{t.year}");
            }
            else
            {
                Console.WriteLine("товар не найден");
            }
        }
    }

}
}

void sort()
{
    Console.WriteLine("Выберете какой поиск выы хотите\n1-год\n2-имя\n3-жанр");
    int temmp = Convert.ToInt32(Console.ReadLine());
    switch (temmp)
    {
        case 1:
            Sortyear();
            break;
        case 2:
            Sortname();
            break;
    }

    void Sortyear()
    {
        var sortedBooks = history.OrderBy(book => book.year).ToList();

        foreach (var book in sortedBooks)
        {
            Console.WriteLine($"{book.name} - {book.year} год");
        }
    }
    void Sortname()
    {
        var sortedBooks = history.OrderBy(book => book.name).ToList();

        foreach (var book in sortedBooks)
        {
            Console.WriteLine($"{book.name} - {book.author}");
        }
    }
}
void dorogo()
{
    
        if (history.Count == 0)
        {
            Console.WriteLine("Список книг пуст");
            return;
        }

        var mostExpensive = history.MaxBy(book => book.price);
        var cheapest = history.MinBy(book => book.price);

        Console.WriteLine("Самая дорогая книга:");
        Console.WriteLine($"\"{mostExpensive.name}\" - {mostExpensive.author} | Цена: {mostExpensive.price} руб.");

        Console.WriteLine("\nСамая дешевая книга:");
        Console.WriteLine($"\"{cheapest.name}\" - {cheapest.author} | Цена: {cheapest.price} руб.");
    }


void group()
{
    
        var groupedBooks = history.GroupBy(book => book.author)
                                 .Select(group => new
                                 {
                                     Author = group.Key,
                                     BookCount = group.Count(),
                                     Books = group.ToList()
                                 })
                                 .OrderByDescending(x => x.BookCount);

        foreach (var authorGroup in groupedBooks)
        {
            Console.WriteLine($"Автор: {authorGroup.Author}");
            Console.WriteLine($"Количество книг: {authorGroup.BookCount}");
            Console.WriteLine("Книги:");

            foreach (var book in authorGroup.Books)
            {
                Console.WriteLine($"  - \"{book.name}\" ({book.year}) - {book.price} руб.");
            }
            Console.WriteLine();
        }
    }

public enum genre{
    fnatastics=0,
    comedy=1,
    novel=2
}

class book
{
    public static int ids=0;
    public int id;
    public string name;
    public string author;
    public genre genre;
    public int year;
    public decimal price;
    

    public book (string name,string author,genre genre, int year,decimal price)
    {
        ids += 1;
        id = ids;
        this.name = name;
        this.author = author;
        this.genre = genre;
        this.year = year;
        this.price = price;

    }
}


