using FactoryWorkImitation.Interfaces.Entities.Manageables.Base;

namespace FactoryWorkImitation.Interfaces.Entities.Manageables
{
    public interface IProductFactory : IManageable
    {
        int ManufactureSpeed { get; }
        IProduct FactoryProduct { get; }
    }
}
