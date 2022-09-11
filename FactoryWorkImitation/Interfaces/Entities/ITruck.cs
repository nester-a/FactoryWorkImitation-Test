using FactoryWorkImitation.Interfaces.Entities.Props;

namespace FactoryWorkImitation.Interfaces.Entities
{
    public interface ITruck
    {
        string Name { get; }
        IWorkStatus WorkStatus { get; set; }
        int WeightCapacity { get; }
        int FactWeightLoad { get; }
        int FactWeightLoadPercent { get; }
        bool IsFull { get; }
        int FreeSpace { get; }

        bool LoadOnTruck(IProduct product);
        IProduct UnloadFromTruck();
    }
}
