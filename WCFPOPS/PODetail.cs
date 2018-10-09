using System;
using System.Runtime.Serialization;

namespace WCFPOPS
{
    [DataContract]
    public class PODetail
    {
        [DataMember]
        public string PurchaseOrderNO { get; set; }

        [DataMember]
        public string ItemCode { get; set; }

        [DataMember]
        public string Quantity { get; set; }
    }
}
