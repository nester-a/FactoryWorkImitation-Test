using FactoryWorkImitation.Interfaces.Entities.Manageables.Base;

namespace FactoryWorkImitation.Interfaces.Entities.Manageables
{
    public interface IProductFactory : IManageable, IStatisticsHandler
    {
        int ManufactureSpeed { get; }
        IProduct FactoryProduct { get; }
    }
}
