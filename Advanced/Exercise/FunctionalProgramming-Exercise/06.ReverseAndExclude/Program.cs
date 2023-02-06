int[] nums = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
int dividableBy = int.Parse(Console.ReadLine());

Predicate<int> isDividable = num => num % dividableBy == 0;
Func<int[], int> excludedNums = nums => nums.Where(n => !isDividable(n)).Count();
Func<int[], int[]> reverseAndExclude = nums =>
{
    int[] newNums = new int[excludedNums(nums)];
    int newNumIndex = 0;
    for (int i = nums.Length - 1; i >= 0; i--)
    {
        if (!isDividable(nums[i]))
        {
            newNums[newNumIndex++] = nums[i];
        }
    }

    return newNums;
};

Console.WriteLine(string.Join(' ', reverseAndExclude(nums)));