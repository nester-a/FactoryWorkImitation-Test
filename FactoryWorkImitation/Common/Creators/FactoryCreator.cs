using FactoryWorkImitation.Common.Entities;
using FactoryWorkImitation.Common.Entities.Manageables;
using FactoryWorkImitation.Interfaces.Creators;
using FactoryWorkImitation.Interfaces.Entities;
using FactoryWorkImitation.Interfaces.Entities.Manageables;
using FactoryWorkImitation.Interfaces.Entities.Props;

namespace FactoryWorkImitation.Common.Creators
{
    public class FactoryCreator : IFactoryCreator
    {
        double SpeedCoef = 1.0;
        int FactoriesCount { get; set; }

        public int ManufactureSpeed { get; set; } = 50;

        public IProductFactory CreateFactory()
        {
            FactoriesCount++;
            var product = GetFactoryProduct();
            var factory = new ProductFactory($"Фабрика-{FactoriesCount}", (int)(ManufactureSpeed * SpeedCoef), product);
            SpeedCoef += 0.1;
            return factory;
        }

        private IProduct GetFactoryProduct()
        {
            Random random = new Random();
            var weight = random.Next(5, 10);
            var packing = random.Next(0, 3);

            return new Product($"Товар-{FactoriesCount}", weight, (PackingType)packing);
        }
    }
}
