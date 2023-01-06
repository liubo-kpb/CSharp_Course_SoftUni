namespace BorderControl.Model.Interfaces
{
    public interface ICitizen : IRegister, IBiological
    {
        int Age { get; }
    }
}
