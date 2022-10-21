namespace BackendInnovationAPI.DatabaseSettings
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string IdeaCollectionName { get; set; }
        public string ConnectionStrings { get; set; }
        public string DatabaseName { get; set; }
        //  public string FeedbackCollectionName { get ; set; }
    }
}
