using FactoryWorkImitation.Interfaces.Entities;

namespace FactoryWorkImitation.Common.Entities
{
    public class Manager : IManager
    {
        bool _isWorkOnManage = false;
        bool _truckCalled = false;
        public IStock Stock { get; }
        public IShipCompany ShipCompany { get; }
        public IMarket Market { get; private set; }
        public Manager(IStock stock, IShipCompany shipCompany, IMarket market)
        {
            Stock = stock;
            ShipCompany = shipCompany;
            Market = market;
        }

        public void ManageWork()
        {
            if (!_isWorkOnManage) StartManageWork();
        }
        private void StartManageWork()
        {
            _isWorkOnManage = true;
            Stock.StockLoadPercent95 += Stock_StockLoadPercent95;
            Console.WriteLine("Менеджер начал следить за работой");
        }
        public void CallATruck()
        {
            ShipCompany.Client = this;
            ShipCompany.SendTruckTo(Stock);
            _truckCalled = true;
        }
        private void Stock_StockLoadPercent95(object? sender, EventArgs e)
        {
            if (_truckCalled) return;
            Console.WriteLine($"Менеджер узнал, что склад заполнен на 95%");
            CallATruck();
        }

        public void StartTruckUnloading()
        {
            Task.Factory.StartNew(() => Market.PutProductsOnMarket());
        }
        private void StartTruckLoadingTask()
        {

            if (Stock.Truck is null)
                Console.WriteLine($"Грузовика нет на стоянке");
            else
            {
                do
                {
                    Thread.Sleep(1);
                    var product = Stock.RemoveFromStock();
                    if (product is null) break;
                    var res = Stock.Truck.PickUp(product);
                    if (!res)
                    {
                        Stock.PutOnStock(product);
                        break;
                    }
                } while (!Stock.Truck.IsFull);
                if (!Stock.Truck.Products.Any())
                    Stock.Truck.MoveHome();

                Stock.Truck!.MoveTo(Market);
                _truckCalled = false;
                Stock.Truck = null;
            }
        }
        public void StartTruckLoading()
        {
            Task.Factory.StartNew(() => StartTruckLoadingTask());
        }
    }
}
