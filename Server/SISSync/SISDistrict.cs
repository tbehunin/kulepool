﻿namespace SISSync
{
    public class SISDistrict
    {
        public DistrictData Data { get; set; }
        public string Uri { get; set; }
        public bool Synced { get; set; }

        public class DistrictData
        {
            public string Id { get; set; }
            public string Name { get; set; }
        }
    }
}