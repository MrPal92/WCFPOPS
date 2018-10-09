using System;
using System.Runtime.Serialization;

namespace WCFPOPS
{
    [DataContract]
    public class POMaster
    {
        [DataMember]
        public string PurchaseOrderNO { get; set; }

        [DataMember]
        public DateTime Date { get; set; }

        [DataMember]
        public string SupplierNumber { get; set; }
    }
}
