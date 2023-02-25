int[] nums = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

Console.WriteLine(SUM(nums, 0));
static int SUM(int[] array, int index)
{
    if (index == array.Length - 1)
    {
        return array[index];
    }
    return array[index] + SUM(array, index + 1);
}