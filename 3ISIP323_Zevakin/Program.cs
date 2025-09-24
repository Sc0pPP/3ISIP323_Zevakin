Console.WriteLine("Введите текст");
string txt=Console.ReadLine();
string[] txt_mass;
int glasny = 0;
int soglasny = 0;
txt_mass = txt.Split(" ");
int length=txt_mass.Length;
Console.WriteLine(length);
string temp="adf";
for (int i = 1; i < length; i++)
{
    if (txt_mass[i].Length < temp.Length)
    {
        temp = txt_mass[i];
    }
    
}


Console.WriteLine(temp);
string[] txt_mass_point=txt.Split(".");
int count=txt_mass_point.Length;
Console.WriteLine(count);
string vowels = "аеёиоуыэюяАЕЁИОУЫЭЮЯ";
string consonants = "бвгджзйклмнпрстфхцчшщБВГДЖЗЙКЛМНПРСТФХЦЧШЩ";

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