using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Twilio.Clients;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Twillio.ViewModels;

namespace Twillio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmsController : ControllerBase
    {
        private readonly ITwilioRestClient _client;
        public SmsController(ITwilioRestClient client)
        {
            _client = client;
        }

        [HttpPost("send-sms")]
        public IActionResult SendSms(SmsMessage model)
        {
            var message = MessageResource.Create(
                to: new PhoneNumber(model.To),
                from: new PhoneNumber(model.From),
                body: model.Message,
                client: _client); // pass in the custom client
            return Ok("Success" + message.Sid);
        }
    }
}
