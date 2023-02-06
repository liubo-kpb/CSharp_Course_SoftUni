int[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

Func<int[], int> findMin = intArray => 
{
    int minNumber = int.MaxValue;
    foreach (int number in numbers)
    {
        if (minNumber > number)
        {
            minNumber = number;
        }
    }
    return minNumber;
};

Console.WriteLine(findMin(numbers));