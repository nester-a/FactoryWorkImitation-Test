using FactoryWorkImitation.Common.Entities;
using FactoryWorkImitation.Interfaces.Creators;
using FactoryWorkImitation.Interfaces.Entities;
using FactoryWorkImitation.Interfaces.Entities.Props;

namespace FactoryWorkImitation.Common.Creators
{
    public class FactoryCreator : IFactoryCreator
    {
        static double _speedCoefficient = 1.0;
        public int FactorysCount { get => Factories.Count; }
        public List<IFactory> Factories { get; }
        public int ManufactureSpeed { get; set; } 

        public FactoryCreator(int manufactureSpeed)
        {
            Factories = new();
            if (manufactureSpeed < 1) ManufactureSpeed = 1;
            else ManufactureSpeed = manufactureSpeed;
        }
        public IFactory CreateFactory()
        {
            var factory = new Factory();
            Factories.Add(factory);
            factory.Name = $"Фабрика-{FactorysCount}";
            factory.ManufactureSpeed = (int)(_speedCoefficient * ManufactureSpeed);
            factory.FactoryProduct = GetFactoryProduct();

            _speedCoefficient += 0.1;
            return factory;
        }

        private IProduct GetFactoryProduct()
        {
            Random random = new Random();
            var weight = random.Next(5, 10);
            var packing = random.Next(0, 3);

            return new Product($"Товар фабрики-{FactorysCount}", weight, (PackingType)packing);
        }
    }
}
