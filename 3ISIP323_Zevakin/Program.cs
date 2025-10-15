using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;

public static class GlobalLists
{
    public static List<student> spisok_st = new List<student>();
    public static List<person> people = new List<person>();
    public static List<prepod> prepods = new List<prepod>();
    public static List<student> students = new List<student>();
    public static Dictionary<university_course, List<student>> cour_stud = new Dictionary<university_course, List<student>>();
}

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("------------------------------------------------\n" +
                "выберете\n" +
                "добавить студента-1\n" +
                "добавить преподавателя-2\n" +
                "добавить курс-3\n" +
                "записаться на курс-4\n" +
                "вывести всех людей-5\n" +
                "вывести одного студента и все его курсы-6\n" +
                "вывести преподавателя-7\n" +
                "Вывести все курсы и всех студентов этих курсов\n"+
                "------------------------------------------------");
            int ttemp = Convert.ToInt32(Console.ReadLine());
            switch (ttemp)
            {
                case 1:
                    student.add_student();
                    break;
                case 2:
                    prepod.add();
                    break;
                case 3:
                    university_course.add();
                    break;
                case 4:
                    student.sign_up();
                    break;
                case 5:
                    foreach (person p in GlobalLists.people)
                    {
                        p.vivod();
                    }
                    break;
                case 6:
                    int temp = Convert.ToInt32(Console.ReadLine());
                    foreach (var pair in GlobalLists.cour_stud)
                    {
                        foreach (student s in pair.Value)
                        {
                            if (s.Id == temp)
                            {
                                Console.WriteLine($"курс:{pair.Key.NameCour}");
                            }
                        }
                    }
                    break;
                case 7:
                    foreach (prepod k in GlobalLists.prepods)
                    {
                        Console.WriteLine(k.Id + " " + k.Name);
                    }
                    break;
                case 8:
                    foreach (KeyValuePair<university_course, List<student>> cs in GlobalLists.cour_stud)
                    {
                        Console.WriteLine(cs.Key.NameCour);
                        foreach (student s in cs.Value)
                        {
                            Console.WriteLine(s.Id + " " + s.Name);
                        }
                    }

                    break;
            }
        }
    }
}

public class person
{
    private static int ids = 0;
    public int Id { get; private set; }
    public int Phone { get; private set; }
    public string Name { get; private set; }

    public person(int phone, string name)
    {
        ids += 1;
        this.Id = ids;
        this.Phone = phone;
        this.Name = name;
    }

    public void vivod()
    {
        Console.WriteLine($"{Id},{Phone},{Name}");
    }
}

public class prepod : person
{
    public int Experience { get; private set; }

    public prepod(int experience, int phone, string name) : base(phone, name)
    {
        this.Experience = experience;
    }

    public static void add()
    {
        Console.WriteLine("Введите имя препода");
        string name = Console.ReadLine();
        Console.WriteLine("Введите его номер телефона");
        int phone = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите его опыт работы");
        int exp = Convert.ToInt32(Console.ReadLine());
        prepod newPrepod = new prepod(exp, phone, name);
        GlobalLists.prepods.Add(newPrepod);
        GlobalLists.people.Add(newPrepod);
    }
}

public class student : person
{
    public int Group { get; private set; }
    public int Course { get; private set; }

    public student(int group, int course, int phone, string name) : base(phone, name)
    {
        this.Group = group;
        this.Course = course;
    }

    public static void add_student()
    {
        Console.WriteLine("Введите имя студента");
        string name = Console.ReadLine();
        Console.WriteLine("Введите группу");
        int group = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите курс");
        int course = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите телефон");
        int phone = Convert.ToInt32(Console.ReadLine());
        student newStudent = new student(group, course, phone, name);
        GlobalLists.students.Add(newStudent);
        GlobalLists.people.Add(newStudent);
    }

    public static void sign_up()
    {
        student temp = null;
        Console.WriteLine("Напишите id");
        int id = Convert.ToInt32(Console.ReadLine());
        foreach (student s in GlobalLists.students)
        {
            if (s.Id == id)
            {
                temp = s;
                break;
            }
        }

        if (temp == null)
        {
            Console.WriteLine("Студент не найден!");
            return;
        }

        Console.Write("Напишите название курса");
        string temp1 = Console.ReadLine();
        foreach (var key in GlobalLists.cour_stud.Keys)
        {
            if (key.NameCour == temp1)
            {
                GlobalLists.cour_stud[key].Add(temp);
                Console.WriteLine("Студент записан на курс!");
                return;
            }
        }
        Console.WriteLine("Курс не найден!");
    }
}

public class university_course
{
    private static int ids = 0;
    public int Id { get; private set; }
    public string NameCour { get; private set; }
    public string Time { get; private set; }
    public prepod Prepod { get; private set; }

    public university_course(string name_cour, string time, prepod prepod)
    {
        ids += 1;
        this.Id = ids;
        this.NameCour = name_cour;
        this.Time = time;
        this.Prepod = prepod;
    }

    public static void add()
    {
        Console.WriteLine("Введите название курса ");
        string name = Console.ReadLine();
        Console.WriteLine("Введите время  ");
        string time = Console.ReadLine();
        Console.WriteLine("Введите id препода  ");
        int ID = Convert.ToInt32(Console.ReadLine());

        prepod foundPrepod = null;
        foreach (prepod p in GlobalLists.prepods)
        {
            if (p.Id == ID)
            {
                foundPrepod = p;
                break;
            }
        }

        if (foundPrepod == null)
        {
            Console.WriteLine("Преподаватель не найден!");
            return;
        }

        university_course newCourse = new university_course(name, time, foundPrepod);
        GlobalLists.cour_stud.Add(newCourse, new List<student>());
        Console.WriteLine("Курс добавлен!");
    }
}