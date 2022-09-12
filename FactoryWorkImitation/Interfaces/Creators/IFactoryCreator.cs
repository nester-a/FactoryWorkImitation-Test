using FactoryWorkImitation.Interfaces.Entities.Manageables;

namespace FactoryWorkImitation.Interfaces.Creators
{
    public interface IFactoryCreator
    {
        int ManufactureSpeed { get; }

        IProductFactory CreateFactory();
    }
}
