using CustomStack;
internal class Program
{
    private static void Main(string[] args)
    {
        string input = string.Empty;
        CustomStack<int> stack = new CustomStack<int>();
        while ((input = Console.ReadLine()) != "END")
        {
            if (input.Length > 3)
            {
                int[] elements = input.Substring(5).Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int i = 0; i < elements.Length; i++)
                {
                    stack.Push(elements[i]);
                }
            }
            else
            {
                try
                {
                stack.Pop();
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        foreach (var item in stack)
        {
            Console.WriteLine(item);
        }
        foreach (var item in stack)
        {
            Console.WriteLine(item);
        }
    }
}