namespace Dal.Entities
{
    public class SyncState
    {
        public string BookmarkId { get; set; }
        public bool FullSync { get; set; }
        //public SyncStatuses SyncSchoolsStatus { get; set; }
        //public SyncStatuses SyncStudentsStatus { get; set; }
        //public DateTime LastUpdated { get; set; }
    }

    public enum SyncStatuses
    {
        Idle,
        RetrievingData,
        Updating,
        Inserting,
        Deleting
    }
}