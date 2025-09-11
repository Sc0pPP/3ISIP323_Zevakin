int size;

int[] cost = [];
Console.WriteLine("Введите колличество товаров");
size=Convert.ToInt32 (Console.ReadLine());
string[] prompt = new string[size+1];
Console.WriteLine("Вводите товары по шаблону (Название услуги или товара; Количество денег)");
for (int i = 0; i <= size; i++)
{
    prompt[i] = Console.ReadLine();
}
