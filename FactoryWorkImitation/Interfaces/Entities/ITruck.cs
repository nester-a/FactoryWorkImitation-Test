namespace FactoryWorkImitation.Interfaces.Entities
{
    public interface ITruck : IManageable
    {
        int WeightCapacity { get; }
        int WeightFactLoad { get; }
    }
}
