namespace Telephony.Model
{
    using Interfaces;
    internal class Smartphone : StationaryPhone, ISmartphone
    {
        public string Browse(string url) => $"Browsing: {url}!";

        public override string Call(string number) => $"Calling... {number}";

    }
}
