using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Largest3Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = new List<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList());
            nums = nums.OrderByDescending(x => x).ToList();
            for (int i = 0; i < 3; i++)
            {
                if (i == nums.Count)
                {
                    break;
                }
                Console.Write(nums[i] + " ");
            }
        }
    }
}
