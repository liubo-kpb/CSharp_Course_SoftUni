namespace Tuples
{
    public class Program
    {
        public static void Main()
        {
            string[] line1 = Console.ReadLine().Split();
            string fullName = line1[0] + " " + line1[1];
            string address = line1[2];
            Tuple<string, string> tuple1 = new Tuple<string, string>(fullName, address);
            Console.WriteLine(tuple1.ToString());

            string[] line2 = Console.ReadLine().Split();
            Tuple<string, int> tuple2 = new Tuples.Tuple<string, int>(line2[0], int.Parse(line2[1]));
            Console.WriteLine(tuple2.ToString());

            string[] line3 = Console.ReadLine().Split();
            Tuple<int, double> tuple3 = new Tuples.Tuple<int, double>(int.Parse(line3[0]), double.Parse(line3[1]));
            Console.WriteLine(tuple3.ToString());
        }
    }
}