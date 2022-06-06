namespace EventMessenger.Event
{
    public class EventManager
    {
        public event EventHandler<MessageEventArgs> OnEventPublishedEvent;
        private static readonly EventManager _instance = new EventManager();
        static EventManager()
        {

        }
        private EventManager()
        {

        }

        public static EventManager Instance { get { return _instance; } }

        protected virtual void OnEventPublished(MessageEventArgs e)
        {
            EventHandler<MessageEventArgs> handler = OnEventPublishedEvent;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public void PublishEvent(string messageTopic, object? data)
        {
            MessageEventArgs args = new MessageEventArgs();
            args.MessageTopic = messageTopic;
            args.Data = data;
            OnEventPublished(args);
        }
    }
}
