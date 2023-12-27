using FluentValidation;
using TrainStation.DTOs;

namespace TrainStation.Validation
{
    public class TicketDTOValidator: AbstractValidator<TicketDTO>
    {
        public TicketDTOValidator()
        {
            RuleFor(t => t.From)
                .NotEmpty();

            RuleFor(t => t.To)
                .NotEqual(t => t.From)
                .WithMessage("Departure city can't equal destination!")
                .NotEmpty();

            RuleFor(t => t.DepartureDate)
                .GreaterThanOrEqualTo(DateOnly.FromDateTime(DateTime.Now))
                .WithMessage("Departure date cannot be in the past!");

            RuleFor(t => t.DepartureTime)
                .NotEmpty();

            RuleFor(t => t.Name)
                .MaximumLength(100)
                .WithMessage("Name cannont be longer than 100 symbols!")
                .NotEmpty();

            RuleFor(t => t.Surname)
               .MaximumLength(100)
               .WithMessage("Surname cannont be longer than 100 symbols!")
               .NotEmpty();

            RuleFor(t => t.Middlename)
               .MaximumLength(100)
               .WithMessage("Middlename cannont be longer than 100 symbols!")
               .NotEmpty();

            RuleFor(t => t.Email)
                .EmailAddress()
                .NotEmpty();
        }
    }
}
