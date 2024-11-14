using System.Runtime.Serialization;

[DataContract]
public class BaseEntity
{
    [DataMember]
    public int Id { get; set; }
}
