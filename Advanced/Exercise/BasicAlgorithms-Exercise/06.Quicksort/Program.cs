
int[] nums = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
Quick.Sort(nums);
Console.WriteLine(string.Join(' ', nums));

public class Quick
{
    public static void Sort<T>(T[] a) where T : IComparable<T>
    {
        Sort(a, 0, a.Length - 1);
        Console.WriteLine(string.Join(' ', a));
    }
    private static void Sort<T>(T[] a, int lo, int hi) where T : IComparable<T>
    {
        if (lo >= hi)
        {
            return;
        }

        int p = Partition(a, lo, hi);
        Sort(a, lo, p - 1);
        Sort(a, p + 1, hi);
    }

    private static int Partition<T>(T[] a, int lo, int hi) where T : IComparable<T>
    {
        if (lo >= hi)
        {
            return lo;
        }

        int i = lo;
        int j = hi + 1;
        while (true)
        {
            while (Less(a[++i], a[lo]))
            {
                if (i == hi)
                {
                    break;
                }
            }

            while (Less(a[lo], a[--j]))
            {
                if (j == lo)
                {
                    break;
                }
            }
            if (i >= j)
            {
                break;
            }
            Swap(a, i, j);
        }

        return j;
    }

    private static void Swap<T>(T[] a, int i, int j) where T : IComparable<T>
    {
        T temp = a[i];
        a[i] = a[j];
        a[j] = temp;
    }

    private static bool Less<T>(T t1, T t2) where T : IComparable<T>
    {
        return t1.CompareTo(t2) == 1 ? false : true;
    }
}