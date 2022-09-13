using FactoryWorkImitation.Interfaces.Entities;

namespace FactoryWorkImitation.Interfaces.Creators
{
    public interface ITruckCreator
    {
        int SetWeightCapacity { get; set; }
        int SetSpeed { get; set; }
        ITruck CreateTruck();
    }
}
