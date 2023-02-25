int[] nums = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
MergeSort<int>.Sort(nums);
Console.WriteLine(string.Join(' ', nums));


public class MergeSort<T> where T : IComparable
{
    private static T[] aux;

    public static void Sort(T[] arr)
    {
        aux = new T[arr.Length];
        Sort(arr, 0, arr.Length - 1);
    }
    public static void Sort(T[] arr, int lo, int hi)
    {
        if (lo >= hi)
        {
            return;
        }

        int mid = (lo + hi) / 2;
        Sort(arr, lo, mid);
        Sort(arr, mid + 1, hi);
        Merge(arr, lo, mid, hi);
    }

    private static void Merge(T[] arr, int lo, int mid, int hi)
    {
        if (IsLess(arr[mid], arr[mid + 1]))
        {
            return;
        }
        for (int index = lo; index < hi + 1; index++)
        {
            aux[index] = arr[index];
        }

        int i = lo;
        int j = mid + 1;
        for (int k = lo; k <= hi; k++)
        {
            if (i > mid)
            {
                arr[k] = aux[j++];
            }
            else if (j > hi)
            {
                arr[k] = aux[i++];
            }
            else if (IsLess(aux[i], aux[j]))
            {
                arr[k] = aux[i++];
            }
            else
            {
                arr[k] = aux[j++];
            }
        }
    }

    private static bool IsLess(T t1, T t2)
    {
        return t1.CompareTo(t2) == 1 ? false : true;
    }
}