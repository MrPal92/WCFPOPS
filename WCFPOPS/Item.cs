using System;
using System.Runtime.Serialization;
namespace WCFPOPS
{
    [DataContract]
    public class Item
    {
        [DataMember]
        public string ItemCode { get; set; }

        [DataMember]
        public string ItemDescription { get; set; }

        [DataMember]
        public string ItemRate { get; set; }
    }
}
