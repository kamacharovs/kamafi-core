using System;

namespace kamafi.core.data
{
    public class Event
    {
        public string EventType { get; set; }
        public EventSource Source { get; set; } = new EventSource();
        public EventUser User { get; set; } = new EventUser();
        public EventEntity Entity { get; set; } = new EventEntity();
    }

    public class EventSource
    {
        public string Api { get; }
        public string Ip { get; set; }
    }

    public class EventUser
    {
        public int? Id { get; set; }
        public Guid? PublicKey { get; set; }
    }

    public class EventEntity
    {
        public int? Id { get; set; }
        public string Type { get; set; }
        public object Payload { get; set; }
    }
}
