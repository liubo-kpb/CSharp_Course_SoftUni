double[] prices = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();

Func<double, double> addVAT = price => price *= 1.2;

for(int i = 0;i < prices.Length; i++)
{
    Console.WriteLine($"{addVAT(prices[i]):F2}");
}
