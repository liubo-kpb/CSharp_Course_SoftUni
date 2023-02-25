using ListyIterator;

string input = Console.ReadLine();
ListyIterator<string> listyIterator = null;

listyIterator = new ListyIterator<string>(input.Split().Skip(1).ToArray());

while ((input = Console.ReadLine()) != "END")
{
    try
    {
        switch (input)
        {
            case "Move":
                Console.WriteLine(listyIterator.Move());
                break;
            case "Print":
                listyIterator.Print();
                break;
            case "HasNext":
                Console.WriteLine(listyIterator.HasNext());
                break;
            case "PrintAll":
                listyIterator.PrintAll();
                break;
        }
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}