int[] bounds = Console.ReadLine().Split().Select(int.Parse).ToArray();
string oddOrEven = Console.ReadLine();

Predicate<int> isEven = (num) =>
{
    return num % 2 == 0;
};

for (int i = bounds[0]; i <= bounds[^1]; i++)
{
    if ((isEven(i) && oddOrEven == "even") || (!isEven(i) && oddOrEven == "odd"))
    {
        Console.Write(i + " ");
    }
}