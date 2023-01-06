namespace Telephony.Engine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Telephony.Model;

    public class RunApplication
    {
        List<string> phoneNumbers;
        List<string> urls;
        public RunApplication()
        {
            Start();
        }

        private void Start()
        {
            phoneNumbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            urls = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            Smartphone smartphone = new Smartphone();
            StationaryPhone stationaryPhone = new StationaryPhone();

            CallNumbers(smartphone, stationaryPhone);

            foreach (var url in urls)
            {
                try
                {
                    if (ValidateURL(url))
                    {
                        Console.WriteLine(smartphone.Browse(url));
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }

        private void CallNumbers(Smartphone smartphone, StationaryPhone stationaryPhone)
        {
            foreach (var number in phoneNumbers)
            {
                try
                {
                    if (IsValidNumber(number))
                    {
                        if (number.Length == 7)
                        {

                            Console.WriteLine(stationaryPhone.Call(number));
                        }
                        else if (number.Length == 10)
                        {
                            Console.WriteLine(smartphone.Call(number));
                        }
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }

        private bool ValidateURL(string url)
        {

            foreach (char ch in url)
            {
                if (char.IsDigit(ch))
                {
                    throw new ArgumentException("Invalid URL!");
                }
            }

            return true;
        }
        private bool IsValidNumber(string number)
        {
            foreach (char ch in number)
            {
                if (char.IsSymbol(ch) || char.IsLetter(ch))
                {
                    throw new ArgumentException("Invalid number!");
                }
            }

            return true;
        }
    }
}
