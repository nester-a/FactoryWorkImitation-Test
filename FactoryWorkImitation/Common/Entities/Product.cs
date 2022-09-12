using FactoryWorkImitation.Interfaces.Entities;
using FactoryWorkImitation.Interfaces.Entities.Props;

namespace FactoryWorkImitation.Common.Entities
{
    public class Product : IProduct
    {
        public string Name { get; }

        public int Weight { get; }

        public PackingType PackingType { get; }

        public Product() { }
        public Product(string name, int weight, PackingType packingType)
        {
            Name = name;
            Weight = weight;
            PackingType = packingType;
        }
    }
}
