namespace BackendInnovationAPI.DatabaseSettings
{
    public interface IDatabaseSettings
    {

        string IdeaCollectionName { get; set; }
        // string FeedbackCollectionName { get; set; }
        string ConnectionStrings { get; set; }
        string DatabaseName { get; set; }
    }
}
