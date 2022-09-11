using FactoryWorkImitation.Interfaces.Entities;

namespace FactoryWorkImitation.Common.Entities
{
    public class Market : IMarket
    {
        public List<IProduct> Products { get; } = new();

        public void PutOnMarket(IProduct product)
        {
            Products.Add(product);
            Console.WriteLine($"{product.Name} на рынке");
        }
    }
}
