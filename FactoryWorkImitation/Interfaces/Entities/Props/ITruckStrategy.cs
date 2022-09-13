namespace FactoryWorkImitation.Interfaces.Entities.Props
{
    public interface ITruckStrategy : IManageStrategy
    {
        ITruck Truck { get; set; }
    }
}
