using FactoryWorkImitation.Interfaces.Entities;

namespace FactoryWorkImitation.Common.Entities
{
    public class Manager : IManager
    {
        public List<IFactory> Factories { get; set; }

        public IStock Stock {get; set;}

        public Manager(List<IFactory> factories, IStock stock)
        {
            Factories = factories;
            Stock = stock;
        }

        public void ManageWork()
        {
            foreach (var factory in Factories)
            {
                Console.WriteLine($"{factory.Name} начала работу");
                new Thread(() =>
                {
                    while (!Stock.IsFull)
                    {
                        factory.CreateProductAndPlaceOnStock(Stock);
                    }
                }).Start();
            }
        }
    }
}
