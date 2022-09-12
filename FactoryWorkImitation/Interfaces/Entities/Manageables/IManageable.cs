namespace FactoryWorkImitation.Interfaces.Entities.Manageables
{
    public interface IManageable : IUnloadable, ILoadable
    {
        bool IsEmpty { get; }
        bool IsFull { get; }
    }
}
