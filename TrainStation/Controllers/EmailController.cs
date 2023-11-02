using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using TrainStation.DTOs;
using TrainStation.Services.Interfaces;

namespace TrainStation.Controllers
{
    public class EmailController : Controller
    {
        private readonly IEmailSender _emailSender;
        private readonly ILogger _logger;

        public EmailController(IEmailSender emailSender, ILogger<EmailController> logger)
        {
            _emailSender = emailSender;
            _logger = logger;
        }

        [HttpPost("email/send")]
        public async Task<IActionResult> SendAsync(EmailDTO emailDTO)
        {
            await _emailSender.SendEmailAsync(emailDTO.Email);

            return Redirect("~/");
        }
    }
}
