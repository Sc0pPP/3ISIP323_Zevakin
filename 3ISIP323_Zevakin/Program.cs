List<book> history = new List<book>();
history.Add(new book("чебурашка", "Алексей", genre.fnatastics, 1998,345));
history.Add(new book("букварь", "максим", genre.novel, 1948, 745));
history.Add(new book("энциклопедия", "Алексей", genre.comedy, 1997, 895));
history.Add(new book("7 гномов", "Алексей анисимов", genre.novel, 2007, 1200));
history.Add(new book("чебурашка", "Алексей", 0, 1998, 345));


void add()
{

}

void delete()
{

}
void search()
{

}

void sort()
{

}

void dorogo()
{

}

void group()
{

}
public enum genre{
    fnatastics=0,
    comedy=1,
    novel=2
}

public class book
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


