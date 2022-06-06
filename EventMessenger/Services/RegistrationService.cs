using EventMessenger.Dtos;
using EventMessenger.Event;

namespace EventMessenger.Services
{
    public interface IRegistrationService
    {
        object Register(RegistrationRequestDto requestDto);
    }
    public class RegistrationService : IRegistrationService
    {
        public object Register(RegistrationRequestDto requestDto)
        {
            var response = new
            {
                Id = Guid.NewGuid(),
                Username = requestDto.Username,
                Email = requestDto.Email,
            };

            //Produce Welcome Email Topic
           EventManager.Instance.PublishEvent("SendWelcomeEmail", requestDto);  

            return response;
        }
    }
}
