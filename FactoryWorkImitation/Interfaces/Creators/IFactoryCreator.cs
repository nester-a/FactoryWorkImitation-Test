using FactoryWorkImitation.Interfaces.Entities;

namespace FactoryWorkImitation.Interfaces.Creators
{
    public interface IFactoryCreator
    {
        IStock CommonStock { get; set; }
        int FactorysCount { get; }
        List<IFactory> Factories { get; }
        IFactory CreateFactory();
    }
}
