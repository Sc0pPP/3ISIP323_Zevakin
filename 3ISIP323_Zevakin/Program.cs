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


