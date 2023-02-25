int factorial = int.Parse(Console.ReadLine());

Console.WriteLine(GetFactorial(factorial));

int GetFactorial(int factorial)
{
    if (factorial == 1)
    {
        return 1;
    }
    return factorial * GetFactorial(factorial - 1);
}