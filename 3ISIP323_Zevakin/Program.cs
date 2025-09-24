Console.WriteLine("Введите текст");
string txt=Console.ReadLine();
string[] txt_mass;
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