double[] nums = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();

Func<string, double[], double[]> operations = (operation, nums) =>
{
    for (int i = 0; i < nums.Length; i++)
    {
        switch (operation)
        {
            case "add":
                nums[i] += 1;
                break;
            case "multiply":
                nums[i] *= 2;
                break;
            case "subtract":
                nums[i] -= 1;
                break;
            case "print":
                Console.WriteLine(string.Join(' ', nums));
                return nums;
        }
    }
    return nums;
};
string input = Console.ReadLine();
while (input != "end")
{
    nums = operations(input, nums);
    input = Console.ReadLine();
}