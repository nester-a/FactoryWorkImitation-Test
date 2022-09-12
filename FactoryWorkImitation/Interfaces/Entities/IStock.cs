namespace FactoryWorkImitation.Interfaces.Entities
{
    public interface IStock : IManageable
    {
        int Capacity { get; }
        int FactLoad { get; }
    }
}
