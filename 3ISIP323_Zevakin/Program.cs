
Console.WriteLine("Введите текст");
string txt = Console.ReadLine();
List<text_history> history = new List<text_history>();

while (true)
{
    Console.WriteLine("Выберете\n1-продолжить\n2-закончить\n3-вывести всю статистику");
    int vibor = Convert.ToInt32(Console.ReadLine());
    switch (vibor) {
        case 1:
            Console.WriteLine("Введите текст");
            txt = Console.ReadLine();
            string[] txt_mass;
    int glasny = 0;
    int soglasny = 0;
    txt_mass = txt.Split(" ");
    int length = txt_mass.Length;
    Console.WriteLine(length);
    string temp = "adf";
    for (int i = 1; i < length; i++)
    {
        if (txt_mass[i].Length < temp.Length)
        {
            temp = txt_mass[i];
        }

    }


    Console.WriteLine(temp);
    string[] txt_mass_point = txt.Split(".");
    int count = txt_mass_point.Length;
    Console.WriteLine(count);
    string vowels = "аеёиоуыэюя";
    string consonants = "бвгджзйклмнпрстфхцчшщ";

    int vowelCount = 0;
    int consonantCount = 0;

    foreach (char c in txt)
    {
        if (vowels.Contains(c))
        {
            vowelCount++;
        }
        else if (consonants.Contains(c))
        {
            consonantCount++;
        }
    }
    Console.WriteLine($"Гласные: {vowelCount}");
    Console.WriteLine($"Согласные: {consonantCount}");

    string temp_2 = "a";
    for (int i = 1; i < length; i++)
    {
        if (txt_mass[i].Length > temp_2.Length)
        {
            temp_2 = txt_mass[i];
        }
    }
    Console.WriteLine(temp_2);
    Dictionary<char, int> stat = new Dictionary<char, int>();

    char[] gl_mass = vowels.ToCharArray();
    char[] sg_mass = consonants.ToCharArray();
    char[] all = txt.ToCharArray();
    for (int i = 0; i < gl_mass.Length; i++)
    {
        stat.Add(gl_mass[i], 1);
    }
    for (int i = 0; i < sg_mass.Length; i++)
    {
        stat.Add(sg_mass[i], 1);
    }
    foreach (char t in all)
    {
        foreach (KeyValuePair<char, int> c in stat)
        {
            if (t == c.Key)
            {
                stat[c.Key] += 1;
            }
        }
    }

    foreach (KeyValuePair<char, int> c in stat)
    {
        Console.WriteLine($"буква: {c.Key}, Колличество: {c.Value}");
    }
            history.Add(new text_history(length, temp, count, vowelCount, consonantCount, temp_2, stat));
            break;
        case 3:
            foreach (text_history t in history)
            {
                vivod(t);
            }
                break;
        case 2:
            return 0;
}
}
void vivod(text_history t)
{
    Console.WriteLine($"id={t.id},cw={t.count_world},sw={t.short_word},cp={t.count_pred},cg={t.count_glasn},cs={t.count_soglasn},lw={t.long_word}\nstatistic:");
    foreach(KeyValuePair<char,int> d in t.statistic)
    {
        Console.WriteLine($"буква: {d.Key}, Колличество: {d.Value}");
    }
}
public class text_history
{
    public static int ids=0;
    public int id;
    public int count_world;
    public string short_word;
    public int count_pred;
    public int count_glasn;
    public int count_soglasn;
    public string long_word;
    public Dictionary<char, int> statistic;

    public text_history(int count_world, string short_word, int count_pred, int count_glasn, int count_soglasn, string long_word, Dictionary<char, int> statistic)
    {
        ids += 1;
        id = ids;
        this.count_world = count_world;
        this.short_word = short_word;
        this.count_pred = count_pred;
        this.count_glasn = count_glasn;
        this.count_soglasn = count_soglasn;
        this.long_word = long_word;
        this.statistic = statistic;
    }
}
