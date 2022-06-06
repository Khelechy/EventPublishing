using EventMessenger.Dtos;
using EventMessenger.Helpers;

namespace EventMessenger.Event
{
    public class EventMessageHub : BackgroundService
    {
        private readonly ILogger<EventMessageHub> _logger;
        public EventMessageHub(ILogger<EventMessageHub> logger)
        {
            _logger = logger;

        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            EventManager.Instance.OnEventPublishedEvent += e_OnEventPublished;
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("EventMessageHub running at: {time}", DateTimeOffset.Now);

                await Task.Delay(1000, stoppingToken);
            }
        }

        static void e_OnEventPublished(object sender, MessageEventArgs e)
        {
            switch (e.MessageTopic)
            {
                case "SendWelcomeEmail":
                    //Cast Object to type , if json deserialize
                    var data = (RegistrationRequestDto)e.Data;
                    EmailHelper.SendWelcomeEmail(data.Email);
                    break;
                default:
                    break;
            };
        }
    }
}
