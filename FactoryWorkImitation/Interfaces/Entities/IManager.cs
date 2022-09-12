using FactoryWorkImitation.Interfaces.Entities.Props;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryWorkImitation.Interfaces.Entities
{
    public interface IManager
    {
        List<IManageable> ManageableObjects { get; set; }
        IManageStrategy ManageStrategy { get; }
        void Manage();
    }
}
