using FactoryWorkImitation.Common.Entities.Props;
using FactoryWorkImitation.Interfaces.Entities;
using FactoryWorkImitation.Interfaces.Entities.Props;

namespace FactoryWorkImitation.Common.Entities
{
    public class Manager : IManager
    {
        public List<IFactory> Factories { get; set; }
        public IStock Stock {get; set;}
        public IWorkStatus WorkStatus { get; private set; } = new WorkStoppedStatus();

        public IShipCompany? ShipCompany { get; set; }
        public IMarket? Market { get; set; }


        public Manager(List<IFactory> factories, IStock stock)
        {
            Factories = factories;
            Stock = stock;
        }

        public void ManageWork()
        {
            WorkStatus = new OnWorkStatus();
            while(WorkStatus is OnWorkStatus)
            {
                if (Factories.All(f => f.WorkStatus is WorkStoppedStatus)) StartAllFactories();
                if (Factories.Any(f => f.WorkStatus is WorkStoppedStatus)) StartStoppedFactory();
                if (Stock.FactLoadPercent >= 95)
                {
                    var order = new ShipOrder(this, new TruckOrder(Stock, Market));
                    var res = ShipCompany?.PlaceShipOrder(order);
                }
            }
        }

        private void StartFactory(IFactory factory)
        {
            factory.WorkStatus = new OnWorkStatus();
            Console.WriteLine($"{factory.Name} начала работу");
            Task.Factory.StartNew(() =>
            {
                while (!Stock.IsFull)
                {
                    factory.CreateProductAndPlaceOnStock(Stock);
                }
                factory.WorkStatus = new WorkStoppedStatus();
                Console.WriteLine($"{factory.Name} закончила работу, так как склад полный");
            });
        }
        private void StartAllFactories()
        {
            Console.WriteLine("Менеджер запускает все фабрики");
            foreach (var factory in Factories)
            {
                StartFactory(factory);
            }
        }
        private void StartStoppedFactory()
        {
            var factory = Factories.FirstOrDefault(f => f.WorkStatus is WorkStoppedStatus);
            if (factory is not null) StartFactory(factory);
        }
    }
}
