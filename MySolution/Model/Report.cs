using System;
using System.Runtime.Serialization;

namespace Model
{
    [DataContract]
    public class Report : BaseEntity
    {
        [DataMember]
        public DateTime generatedAt { get; set; }

        [DataMember]
        public string content { get; set; }

        [DataMember]
        public string severityLevel { get; set; }

        [CollectionDataContract]
        public class ReportList : List<Report>
        {
            public ReportList() { }

            public ReportList(IEnumerable<Report> list) : base(list) { }

            public ReportList(IEnumerable<BaseEntity> list) : base(list.Cast<Report>().ToList()) { }

            public ReportList SearchBySeverity(string severity)
            {
                return new ReportList(this.FindAll(r => r.severityLevel.Equals(severity)));
            }
        }
    }
}