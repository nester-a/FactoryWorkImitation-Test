using FactoryWorkImitation.Interfaces.Entities;

namespace FactoryWorkImitation.Common.Entities
{
    public class Market : IMarket
    {
        public List<IProduct> Products { get; } = new();

        public ITruck? Truck { get; set; }

        public void PutProductsOnMarket()
        {
            if (Truck is null) return;
            else
            {
                do
                {
                    Thread.Sleep(1);
                    var product = Truck.UnloadProduct();
                    Products.Add(product);
                    if (product is null) break;
                    Console.WriteLine($"{product.Name} на рынке");
                }while (Truck.Products.Any());
            }
            Console.WriteLine("Разгрузка товара на рынке завершена");
            Truck.MoveHome();
            Truck = null;
        }
    }
}
