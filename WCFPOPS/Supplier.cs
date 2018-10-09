using System;
using System.Runtime.Serialization;

namespace WCFPOPS
{
    [DataContract]
    public class Supplier
    {
        [DataMember]
        public string SupplierNumber { get; set; }

        [DataMember]
        public string SupplierName { get; set; }

        [DataMember]
        public string SupplierAddress { get; set; }
    }
}
