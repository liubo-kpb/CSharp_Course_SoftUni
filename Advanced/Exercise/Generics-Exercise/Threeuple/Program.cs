namespace Threeuples
{
    public class Program
    {
        public static void Main()
        {
            string[] line1 = Console.ReadLine().Split();
            string fullName = line1[0] + " " + line1[1];
            string address = line1[2];
            string town = line1[3];
            if (line1.Length > 4)
            {
                town = line1[3] + " " + line1[4];
            }
            Threeuple<string, string,string> threeuple1 = new Threeuple<string, string, string>(fullName, address, town);

            string[] line2 = Console.ReadLine().Split();
            bool isDrunk = line2[2] == "drunk" ? true : false;
            Threeuple<string, int, bool> threeuple2 = new Threeuple<string, int, bool>(line2[0], int.Parse(line2[1]), isDrunk);

            string[] line3 = Console.ReadLine().Split();
            Threeuple<string, double, string> threeuple3 = new Threeuple<string, double, string>(line3[0], double.Parse(line3[1]), line3[2]);
            
            Console.WriteLine(threeuple1);
            Console.WriteLine(threeuple2);
            Console.WriteLine(threeuple3);
        }
    }
}