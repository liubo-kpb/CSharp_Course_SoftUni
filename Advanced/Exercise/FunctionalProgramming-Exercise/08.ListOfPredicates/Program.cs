int end = int.Parse(Console.ReadLine());
int[] dividableBy = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

Predicate<int> isDividable = num =>
{
    bool wasDividedByAll = true;
    foreach (var divider in dividableBy)
    {
        if (num % divider != 0)
        {
            wasDividedByAll = false;
            break;
        }
    }
    return wasDividedByAll;
};
Func<int[]> findDividableNumbers = () =>
{
    int[] nums = new int[end];
    int newNumIndex = 0;
    for (int i = 1; i <= end; i++)
    {
        if (isDividable(i))
        {
            nums[newNumIndex++] = i;
        }
    }
    int[] newNums = new int[end - nums.Where(x => x == 0).ToArray().Length];
    for (int i = 0; i < newNums.Length; i++)
    {
        newNums[i] = nums[i];
    }
    return newNums;
};

Console.WriteLine(string.Join(' ', findDividableNumbers()));