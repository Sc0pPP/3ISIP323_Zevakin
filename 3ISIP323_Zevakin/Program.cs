using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
List <student> spisok_st= new List<student>();
List<person> people = new List<person>();
List<prepod> prepods = new List<prepod>();
List<student> students = new List<student>();
Dictionary<university_course, spisok_st> cour_stud = new Dictionary<university_course, spisok_st>();
while true{
    Console.WriteLine("------------------------------------------------" +
        "выберете\n" +
        "добавить студента-1\n" +
        "добавить преподавателя-2\n" +
        "добавить курс-3\n" +
        "записаться на курс-4\n" +
        "вывести всех людей-5\n" +
        "вывести одного студента и все его курсы-6\n" +
        "vivod7" +
        "------------------------------------------------");
    int ttemp = Console.ReadLine();
    switch (ttemp)
    {

    }
}

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
    private int experience { get;private set }

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
    private int group { get;private set }
    private int course { get;private set }

    public prepod(int group,int course,int phone,string name) : base(id, phone, name)
    {
        ids += 1;
        this.id = ids;
        this.name = name;
        this.group = group;
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

    public void sign_up()
    {
        student temp;
        Console.WriteLine("Напишите id")
        int id = Convert.ToInt32(Console.ReadLine());
        foreach(student s in students)
        {
            if (student.ids == id)
            {
                temp = s;
            }
        }
        Console.Write("Напишите курс")
        string temp1 = Console.ReadLine();
        foreach(var key in cour_stud.Keys)
        {
            if (key == temp1)
            {
                cour_stud.Values.add(temp);
            }
        }


    }

}
public class university_course
{
    private static int ids;
    private int id;
    private string name_cour { get;private set }
    private string time { get;private set }
    private prepod prepod { get;private set }
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