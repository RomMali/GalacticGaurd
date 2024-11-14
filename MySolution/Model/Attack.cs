using System;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace Model
{
    [DataContract]
    public class Attack : BaseEntity
    {
        [DataMember]
        public string sourceIp { get; set; }

        [DataMember]
        public string destinationIp { get; set; }

        [DataMember]
        public string attackType { get; set; }

        [DataMember]
        public string protocol { get; set; }

        [DataMember]
        public string payload { get; set; }

        [DataMember]
        public string severityLevel { get; set; }

        [DataMember]
        public string geolocation { get; set; }

        [DataMember]
        public DateTime timestamp { get; set; }

        [DataMember]
        public string responseAction { get; set; }
    }



    [CollectionDataContract]
    public class AttackList : List<Attack>
    {
        public AttackList() { }

        public AttackList(IEnumerable<Attack> list) : base(list) { }

        public AttackList(IEnumerable<BaseEntity> list) : base(list.Cast<Attack>().ToList()) { }

        public AttackList SearchBySeverity(string severity)
        {
            return new AttackList(this.FindAll(a => a.severityLevel.Equals(severity)));
        }
    }
}
