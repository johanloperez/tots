namespace challenge.application.layer.UseCases.Events
{
    public interface IDeleteEvents
    {
        Task<string> DeleteById(string userId,string eventId);
    }
}
