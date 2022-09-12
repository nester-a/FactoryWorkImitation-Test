namespace FactoryWorkImitation.Interfaces.Entities.Manageables.Base
{
    public interface IManageable : IUnloadable, ILoadable
    {
        string Name { get; }
        bool IsEmpty { get; }
        bool IsFull { get; }
    }
}
