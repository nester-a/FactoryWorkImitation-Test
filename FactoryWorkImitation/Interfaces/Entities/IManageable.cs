namespace FactoryWorkImitation.Interfaces.Entities
{
    public interface IManageable
    {
        bool IsFull { get; }
        bool IsEmpty { get; }
        bool Load(IProduct product);
        IProduct Unload();
    }
}
