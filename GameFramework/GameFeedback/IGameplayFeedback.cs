namespace GameFramework.GameFeedback
{
    public interface IGameplayFeedback
    {
        FeedbackLevel Level { get; }
        string Message { get; }
    }
}
