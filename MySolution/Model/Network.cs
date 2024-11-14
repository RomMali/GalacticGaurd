using System.Runtime.Serialization;

namespace Model
{
    [DataContract]
    public class Network : BaseEntity
    {
        [DataMember]
        public string networkName { get; set; }

        [DataMember]
        public string subnet { get; set; }

        [DataMember]
        public string gateway { get; set; }

        [CollectionDataContract]
        public class NetworkList : List<Network>
        {
            public NetworkList() { }

            public NetworkList(IEnumerable<Network> list) : base(list) { }

            public NetworkList(IEnumerable<BaseEntity> list) : base(list.Cast<Network>().ToList()) { }

            public NetworkList SearchByName(string networkName)
            {
                return new NetworkList(this.FindAll(n => n.networkName.Equals(networkName)));
            }
        }
    }
}
