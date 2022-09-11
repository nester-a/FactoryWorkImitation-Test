using FactoryWorkImitation.Interfaces.Entities;

namespace FactoryWorkImitation.Interfaces.Creators
{
    public interface IFactoryCreator
    {
        int FactorysCount { get; }
        List<IFactory> Factories { get; }
        IFactory CreateFactory();
    }
}
