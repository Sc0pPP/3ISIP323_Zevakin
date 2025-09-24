
Console.WriteLine("Введите текст");
string txt = Console.ReadLine();
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
    foreach(KeyValuePair<char, int> c in stat)
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

