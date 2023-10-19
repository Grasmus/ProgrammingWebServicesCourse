using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TrainStation.DTOs;
using TrainStation.Services.Interfaces;

namespace TrainStation.Controllers
{
    public class EmailController : Controller
    {
        private readonly IEmailSender _emailSender;

        public EmailController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        [HttpPost("email/send")]
        public async Task<IActionResult> SendAsync(EmailDTO emailDTO)
        {
            await _emailSender.SendEmailAsync(emailDTO.Email);

            return Redirect("~/");
        }
    }
}
