using FactoryWorkImitation.Common.Entities.Props;
using FactoryWorkImitation.Interfaces.Entities;

namespace FactoryWorkImitation.Common.Entities
{
    public class MediumTruck : Truck
    {
        public MediumTruck() : base("Средний грузовик", 125, 100)
        {
            WorkStatus = new WorkStoppedStatus();
        }
    }
}
