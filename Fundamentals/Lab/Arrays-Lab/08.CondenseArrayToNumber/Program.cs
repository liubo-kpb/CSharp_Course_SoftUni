using System;
using System.Linq;

namespace _08.CondenseArrayToNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums.Length == 1)
                {
                    break;
                }
                int[] condencedNums = new int[nums.Length - 1 - i];
                for (int j = 0; j < nums.Length - 1 - i; j++)
                {
                    condencedNums[j] = nums[j] + nums[j + 1];
                }
                for (int j = 0; j < condencedNums.Length; j++)
                {
                    nums[j] = condencedNums[j];
                }
                for (int j = condencedNums.Length; j < nums.Length; j++)
                {
                    nums[j] = 0;
                }
                bool isReady = true;
                for (int j = 1; j < nums.Length; j++)
                {
                    if (nums[j] != 0)
                    {
                        isReady = false;
                        break;
                    }
                }
                if (isReady)
                {
                    break;
                }
            }
            Console.WriteLine(nums[0]);
        }
    }
}
