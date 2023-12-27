using TrainStation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Localization;
using TrainStation.Entities;
using FluentValidation;
using TrainStation.DTOs;
using TrainStation.Extensions;
using Microsoft.AspNetCore.Hosting.Server;

namespace TrainStation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IValidator<TicketDTO> _ticketValidattor;

        public HomeController(ILogger<HomeController> logger, IValidator<TicketDTO> ticketValidattor)
        {
            _logger = logger;
            _ticketValidattor = ticketValidattor;
        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }

        [HttpPost("Home/CreateTicket")]
        public async Task<IActionResult> CreateTicketAsync(TicketDTO ticketDTO) 
        {
            var result = await _ticketValidattor.ValidateAsync(ticketDTO);

            if (!result.IsValid) 
            {
                List<string> errors = new List<string>();

                foreach (var error in result.Errors)
                {
                    errors.Add(error.ErrorMessage);
                }

                return View("~/Views/Error/HandleError.cshtml", new ErrorModel() { ErrorMessages = errors });
            }

            Ticket ticket = new Ticket()
            {
                From = ticketDTO.From,
                To = ticketDTO.To,
                DepartureDate = ticketDTO.DepartureDate,
                Created = DateTime.Now,
                Name = ticketDTO.Name,
                Surname = ticketDTO.Surname,
                Middlename = ticketDTO.Middlename,
                Email = ticketDTO.Email,
                Price = 800.0M
            };


            TimeOnly.TryParse(ticketDTO.DepartureTime, out var departureTime);

            ticket.DepartureTime = departureTime;

            return Redirect("~/");
        }
    }
}