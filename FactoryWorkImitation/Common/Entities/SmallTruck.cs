using FactoryWorkImitation.Common.Entities.Props;
using FactoryWorkImitation.Interfaces.Entities;
namespace FactoryWorkImitation.Common.Entities
{
    public class SmallTruck : Truck
    {
        public SmallTruck() : base("Маленький грузовик", 75)
        {
            WorkStatus = new WorkStoppedStatus();
        }
    }
}
