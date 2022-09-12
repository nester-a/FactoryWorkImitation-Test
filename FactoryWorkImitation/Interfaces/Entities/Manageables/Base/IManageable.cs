namespace FactoryWorkImitation.Interfaces.Entities.Manageables.Base
{
    public interface IManageable : IUnloadable, ILoadable
    {
        bool IsEmpty { get; }
        bool IsFull { get; }
    }
}
