using System;
using Common;

namespace SISSync
{
    public class SISSchool
    {
        public SchoolData Data { get; set; }
        public string Uri { get; set; }

        public class SchoolData
        {
            public DateTime Created { get; set; }
            public string District { get; set; }
            public GradeLevel HighGrade { get; set; }
            public DateTime LastModified { get; set; }
            public PhysicalLocation Location { get; set; }
            public GradeLevel LowGrade { get; set; }
            public string Name { get; set; }
            public string NcesId { get; set; }
            public string Phone { get; set; }
            public SimpleContact Principal { get; set; }
            public string SchoolNumber { get; set; }
            public string SisId { get; set; }
            public string StateId { get; set; }
            public string Id { get; set; }
        }
    }
}