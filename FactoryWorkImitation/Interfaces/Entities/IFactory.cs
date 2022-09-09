namespace FactoryWorkImitation.Interfaces.Entities
{
    public interface IFactory
    {
        string Name { get; set; }
        int ProducedProductCount { get; }
        IStock Stock { get; set; }
        int ManufactureSpeed { get; set; }
        IProduct FactoryProduct { get; set; }
        void CreateProduct();
    }
}
