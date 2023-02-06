using GenericBoxOfString;

int stringsToRead = int.Parse(Console.ReadLine());
//List<Box<int>> strs = new List<Box<int>>();
Box<double> box = new Box<double>();
for (int i = 0; i < stringsToRead; i++)
{
    //string str = Console.ReadLine();
    double str = double.Parse(Console.ReadLine());
    //int str = int.Parse(Console.ReadLine());
    box.Items.Add(str);
    //  strs.Add(box);
}
//string value = Console.ReadLine();
double value = double.Parse(Console.ReadLine());
Console.WriteLine(box.Count(value));
//Swap(strs);
//foreach (Box<int> box in strs)
//{
//    Console.WriteLine(box);
//}

static void Swap<T>(List<T> list)
{
    int[] swapIndexes = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
    T temp = list[swapIndexes[0]];
    list[swapIndexes[0]] = list[swapIndexes[1]];
    list[swapIndexes[1]] = temp;
}
