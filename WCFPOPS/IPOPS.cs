using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCFPOPS
{
    [ServiceContract]
    public interface IPOPS
    {
        // Create Operations

        void AddSupplier(Supplier supplier);

        void AddItem(Item item);

        void MakeOrder(POMaster pOMaster, List<PODetail> pODetails);

        // Read Operations

        // Update Operations

        // Delete Operations
    }
}
