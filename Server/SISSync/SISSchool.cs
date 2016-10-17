namespace SISSync
{
    public class SISSchool
    {
        public SchoolData Data { get; set; }
        public string Uri { get; set; }

        public class SchoolData
        {
            public string Id { get; set; }
            public string Name { get; set; }
        }
    }
}