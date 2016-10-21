namespace Clever.Entities
{
    public class SISDistrict
    {
        public SISDistrictData Data { get; set; }
        public string Uri { get; set; }
    }

    public class SISDistrictData
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}