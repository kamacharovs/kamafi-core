using System;

namespace kamafi.core.data
{
    /// <summary>
    /// Serves as the event base class
    /// </summary>
    public class Event
    {
        public string EventType { get; set; }
        public EventSource Source { get; set; } = new EventSource();
        public EventUser User { get; set; } = new EventUser();
        public EventEntity Entity { get; set; } = new EventEntity();
    }

    /// <summary>
    /// Serves as the event source. Details on where did the event is coming from
    /// </summary>
    public class EventSource
    {
        public string Api { get; }
        public string Ip { get; set; }
    }

    /// <summary>
    /// Serves as the event user. Details on which user the event is coming from
    /// </summary>
    public class EventUser
    {
        public int? Id { get; set; }
        public Guid? PublicKey { get; set; }
    }

    /// <summary>
    /// Serves as the event entity. Details on the entity that the event is coming from
    /// </summary>
    public class EventEntity
    {
        public int? Id { get; set; }
        public string Type { get; set; }
        public object Payload { get; set; }
    }
}
