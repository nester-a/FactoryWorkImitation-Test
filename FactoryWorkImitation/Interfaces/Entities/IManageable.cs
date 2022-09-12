namespace FactoryWorkImitation.Interfaces.Entities
{
    public interface IManageable
    {
        bool Load(IProduct product);
        IProduct Unload();
    }
}
