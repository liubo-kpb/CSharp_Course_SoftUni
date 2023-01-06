using System;

namespace _08.OnTimeForTheExam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int hourExam = int.Parse(Console.ReadLine());
            int minuteExam = int.Parse(Console.ReadLine());
            int hourArrival = int.Parse(Console.ReadLine());
            int minuteArrival = int.Parse(Console.ReadLine());

            minuteExam += hourExam * 60;
            minuteArrival += hourArrival * 60;

            int difference = Math.Abs(minuteArrival - minuteExam);
            if (minuteExam >= minuteArrival && difference <= 30)
            {
                Console.WriteLine("On time");
                Console.WriteLine($"{difference} minutes before the start.");
            } else if (minuteExam > minuteArrival && difference >= 60)
            {
                Console.WriteLine("Early");
                Console.WriteLine($"{difference / 60}:{difference % 60:D2} hours before the start.");
            } else if (minuteExam > minuteArrival && difference < 60)
            {
                Console.WriteLine("Early");
                Console.WriteLine($"{difference % 60:D2} minutes before the start.");
            } else if (minuteArrival > minuteExam && difference < 60)
            {
                Console.WriteLine("Late");
                Console.WriteLine($"{difference} minutes after the start");
            } else if (minuteArrival > minuteExam && difference >= 60) 
            {
                Console.WriteLine("Late");
                Console.WriteLine($"{difference / 60}:{difference % 60:D2} hours after the start");
            }
        }
    }
}
