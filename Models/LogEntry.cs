namespace DespositMachine.Web.Models
{
    public class LogEntry
    {
        public DateTime TimestampUtc { get; private set; }
        public string EventType { get; private set; }
        public string Description { get; private set; }

        public LogEntry(string eventType, string description)
        {
            TimestampUtc = DateTime.UtcNow;
            EventType = eventType;
            Description = description;
        }
    }
}
