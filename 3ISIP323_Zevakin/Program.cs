using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
List < student > spisok_st= new List<student>();
List<person> people = new List<person>();
List<prepod> prepods = new List<prepod>();
List<student> students = new List<student>();
Dictionary<university_course, spisok_st> cour_stud = new Dictionary<university_course, spisok_st>();

public class person
{
    private static int ids;
    private int id { get;set }
    private int phone{ get;set }
    private string name{ get;set }
    
}
public class prepod:person
{
    private static int ids;
    private int experience { get;set }

    public prepod(int experience,int phone, string name):base(id,phone,name)
    {
        ids += 1;
        this.id = ids;
        this.experience = experience;
        this.phone = phone;
        this.name = name;

    }
    public void add()
    {
        Console.WriteLine("Введите имя препода");
        string name = Console.ReadLine();
        Console.WriteLine("Введите его номер телефона");
        int phone = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите его опыт работы");
        int exp = Convert.ToInt32(Console.ReadLine());
        prepods.Add(new prepod(int exp, int phone, string name);
        people.Add(new prepod(int exp, int phone, string name);
    }
}
public class student : person
{
    private static int ids;
    private int group { get; set }
    private List<university_course> course { get; set }

    public prepod(int group,int course,int phone,string name) : base(id, phone, name)
    {
        ids += 1;
        this.id = ids;
        this.name_pr = name_pr;
        this.group_num = group_num;
    }
    public void add()
    {
        Console.WriteLine("Введите имя препода");
        string name = Console.ReadLine();
        Console.WriteLine("Введие группу");
        int group = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите курс");
        int course = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите телефон");
        int phone = Convert.ToInt32(Console.ReadLine());
        prepods.Add(new student(int group,int course,int phone,string name);
        people.Add(new student(int group, int course, int phone, string name);


    }

}
public class university_course
{
    private static int ids;
    private int id;
    private string name_cour { get;set }
    private string time { get;set }
    private prepod prepod { get;set }
    public university_course(string name_cour,string time,int prepod.id)
    {
        ids += 1;
        this.id = ids;
        this.name_cour = name_cour;
        this.time = time;
        this.prepod = prepod;
    }

    public void add()
    {
        Console.WriteLine("Введите название курса ");
        string name = Console.ReadLine();
        Console.WriteLine("Введите время  ");
        string time = Console.ReadLine();
        Console.WriteLine("Введите id препода  ");
        int ID = Convert.ToInt32(Console.ReadLine());
        cour_stud.Add(new university_course(string name, string time, int ID), spisok_st);
    }
}