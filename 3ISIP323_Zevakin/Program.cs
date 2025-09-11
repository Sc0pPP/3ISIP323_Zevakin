using System.Security.Authentication;

int size;

int sum=0;
Console.WriteLine("Введите колличество товаров");
size=Convert.ToInt32 (Console.ReadLine());
string[] prompt = new string[size];
int[] cost = new int[size];
Console.WriteLine("Вводите товары по шаблону (Название услуги или товара; Количество денег)");
string[] input;
for (int i = 0; i < size; i++)
{
    input = Console.ReadLine().Split("; ");

    prompt[i] = input[0];
    cost[i] = Convert.ToInt32(input[1]);
    sum+= cost[i];
}

int temp1=0;

for (int i = 0; i < size; i++)
{
    if (cost[i] > temp1)
    {
        temp1 = cost[i];
    }
}
Console.WriteLine($"МАКСИМАЛЬНОЕ-{temp1}");

for (int i = 0; i < size; i++)
{
    if (cost[i] < temp1)
    {
        temp1 = cost[i];
    }
}
Console.WriteLine($"минимальное-{temp1}");
Console.WriteLine($"Среднее-{sum / size}");
string temp2;
for (int i = 0; (i) < cost.Length; (i)++)
{
    for (int j = 0; j < cost.Length - 1; j++)
    {
        if (cost[j] < cost[j + 1])
        {
            int temp = cost[j];
            cost[j] = cost[j + 1];
            cost[j + 1] = temp;
           
            temp2 = prompt[j];
            prompt[j] = prompt[j + 1];
            prompt[j + 1] = temp2;
        }
    }
}
for (int i = 0;i< size; i++)
{
    Console.WriteLine($"{cost[i]},{prompt[i]}");
}
Console.WriteLine("Напишите запрос для поиска");
string promp = Console.ReadLine();
bool bl = false;
foreach (string massi in prompt)
{
    if (massi.Contains(promp))
    {
        Console.WriteLine(massi + " есть в списке");
        bl = true;
    }

}
if (!bl)
{
    Console.WriteLine("Не найденно");
}