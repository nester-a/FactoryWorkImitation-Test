using FactoryWorkImitation.Common.Entities.Manageables;
using FactoryWorkImitation.Interfaces.Entities;
using FactoryWorkImitation.Interfaces.Entities.Managers;
using FactoryWorkImitation.Interfaces.Entities.Props;

namespace FactoryWorkImitation.Common.Entities.Managers
{
    public class StockManager : IManager
    {
        IStock Stock { get; set; }
        List<ProductFactory> Factories { get; set; }
        public IManageStrategy ManageStrategy {get;set;}

        public void Manage()
        {
            foreach (var factory in Factories)
            {
                ManageStrategy.Do(factory, Stock);
            }
        }
    }
}
