namespace FactoryWorkImitation.Interfaces.Entities
{
    public interface IFactory
    {
        string Name { get; set; }
        int ProducedProductCount { get; }
        int ManufactureSpeed { get; set; }
        IProduct FactoryProduct { get; set; }
        IProduct CreateProduct();
        void CreateProductAndPlaceOnStock(IStock stock);
    }
}
