namespace Telephony.Model
{
    using Interfaces;
    internal class StationaryPhone : IStationaryPhone
    {
        public virtual string Call(string number) => $"Dialing... {number}";
    }
}
