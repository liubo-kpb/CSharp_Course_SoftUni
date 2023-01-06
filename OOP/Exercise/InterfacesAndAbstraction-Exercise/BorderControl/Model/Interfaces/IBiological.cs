namespace BorderControl.Model.Interfaces
{
    public interface IBiological : IRegister
    {
        string Name { get; }
        string Birthday { get; }
    }
}
