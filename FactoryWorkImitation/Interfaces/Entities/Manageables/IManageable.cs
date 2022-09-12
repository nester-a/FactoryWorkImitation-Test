namespace FactoryWorkImitation.Interfaces.Entities.Manageables
{
    public interface IManageable
    {
        bool IsFull { get; }
        bool IsEmpty { get; }
        bool Load(IProduct product);
        IProduct Unload();
    }
}
