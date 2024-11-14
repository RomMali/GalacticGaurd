using System;
using System.Runtime.Serialization;

namespace Model
{
    [DataContract]
    public class BlacklistObj : BaseEntity
    {
        [DataMember]
        public string sourceIp { get; set; }

        [DataMember]
        public string reason { get; set; }

        [DataMember]
        public DateTime blockedAt { get; set; }
    }

    [CollectionDataContract]
    public class Blacklist : List<BlacklistObj>
    {
        public Blacklist() { }

        public Blacklist(IEnumerable<BlacklistObj> list) : base(list) { }

        public Blacklist(IEnumerable<BaseEntity> list) : base(list.Cast<BlacklistObj>().ToList()) { }

        public Blacklist SearchBySourceIp(string sourceIp)
        {
            return new Blacklist(this.FindAll(b => b.sourceIp.Equals(sourceIp)));
        }
    }
}