using System.Runtime.Serialization;

namespace Model
{
    [DataContract]
    public class LastPasses : BaseEntity
    {
        [DataMember]
        public int userId { get; set; }

        [DataMember]
        public string pass1 { get; set; }

        [DataMember]
        public string pass2 { get; set; }

        [DataMember]
        public string pass3 { get; set; }

        [CollectionDataContract]
        public class LastPassList : List<LastPasses>
        {
            public LastPassList() { }

            public LastPassList(IEnumerable<LastPasses> list) : base(list) { }

            public LastPassList(IEnumerable<BaseEntity> list) : base(list.Cast<LastPasses>().ToList()) { }

            public LastPassList SearchByUserId(int userId)
            {
                return new LastPassList(this.FindAll(p => p.userId == userId));
            }
        }
    }
}
