namespace EventMessenger.Event
{
    public class MessageEventArgs : EventArgs   
    {
        public string MessageTopic { get; set; }
        public object Data { get; set; }
    }
}
