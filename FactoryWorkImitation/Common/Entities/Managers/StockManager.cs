using FactoryWorkImitation.Interfaces.Entities;
using FactoryWorkImitation.Interfaces.Entities.Manageables;
using FactoryWorkImitation.Interfaces.Entities.Managers;
using FactoryWorkImitation.Interfaces.Entities.Props;

namespace FactoryWorkImitation.Common.Entities.Managers
{
    public class StockManager : IStockManager
    {
        public List<IProductFactory> Factories { get; set; } = new();
        public IMarket Market { get; set; }
        public IStock Stock { get; set; }
        public ITruckManager? LogisticSpecialist { get; set; }

        public IManageStrategy ManageStrategy { get; set; } = null!;

        public void Manage()
        {
            Console.WriteLine("Менеджер начал работу");
            Stock.StockIsAlmostFull += Stock_StockIsAlmostFull;
            foreach (var factory in Factories)
            {
                ManageStrategy.Do(factory, Stock);
            }
        }

        private void Stock_StockIsAlmostFull(object? sender, EventArgs e)
        {
            Console.WriteLine("Менеджер получил уведомление о том, что склад заполнен на 95%");
            LogisticSpecialist?.DeliveryOrder(Stock, Market);
            LogisticSpecialist?.Manage();
        }
    }
}
