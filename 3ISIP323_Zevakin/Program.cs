
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