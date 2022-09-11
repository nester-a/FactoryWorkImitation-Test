using FactoryWorkImitation.Interfaces.Entities.Props;

namespace FactoryWorkImitation.Interfaces.Entities
{
    public interface IFactory
    {
        IWorkStatus WorkStatus { get; set; }
        string Name { get; set; }
        int ProducedProductCount { get; }
        int ManufactureSpeed { get; set; }
        IProduct FactoryProduct { get; set; }
        IProduct CreateProduct();
        void CreateProductAndPlaceOnStock(IStock stock);
    }
}
