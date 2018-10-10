using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WCFPOPS
{
    [DataContract]
    public class Order
    {
        [DataMember]
        public string PurchaseOrderNO { get; set; }

        [DataMember]
        public string ItemDescription { get; set; }

        [DataMember]
        public string Quantity { get; set; }

        [DataMember]
        public DateTime Date { get; set; }

        [DataMember]
        public string SupplierName { get; set; }
    }
}
