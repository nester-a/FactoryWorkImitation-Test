using FactoryWorkImitation.Interfaces.Entities.Manageables;

namespace FactoryWorkImitation.Interfaces.Entities.Managers
{
    public interface IStockManager : IManager
    {
        List<IProductFactory> Factories { get; set; }
        IMarket Market { get; set; }
        IStock Stock { get; set; }
        ITruckManager LogisticSpecialist { get; set; }
    }
}
