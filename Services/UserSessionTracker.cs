namespace EventEase.Services
{
    public class UserSessionTracker
    {
        public List<Guid> ViewedEventIds { get; } = new();

        public void TrackEventView(Guid eventId)
        {
            if (!ViewedEventIds.Contains(eventId))
                ViewedEventIds.Add(eventId);
        }
    }
}