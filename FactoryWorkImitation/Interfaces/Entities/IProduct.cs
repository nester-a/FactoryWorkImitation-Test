using FactoryWorkImitation.Interfaces.Entities.Props;

namespace FactoryWorkImitation.Interfaces.Entities
{
    public interface IProduct
    {
        string Name { get; }
        int Weight { get; }
        PackingType PackingType { get; }
    }
}
