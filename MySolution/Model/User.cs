using System;
using System.Runtime.Serialization;

namespace Model
{
    [DataContract]
    public class User : BaseEntity
    {
        [DataMember]
        public string username { get; set; }

        [DataMember]
        public string email { get; set; }

        [DataMember]
        public string passwordHash { get; set; }

        [DataMember]
        public DateTime createdAt { get; set; }

        [DataMember]
        public bool isAdvanced { get; set; }

        [CollectionDataContract]
        public class UserList : List<User>
        {
            public UserList() { }

            public UserList(IEnumerable<User> list) : base(list) { }

            public UserList(IEnumerable<BaseEntity> list) : base(list.Cast<User>().ToList()) { }

            public UserList Search(string text)
            {
                return new UserList(this.FindAll(m => m.username.Equals(text)));
            }
        }
    }
}