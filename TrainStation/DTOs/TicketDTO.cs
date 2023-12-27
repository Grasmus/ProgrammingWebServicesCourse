namespace TrainStation.DTOs
{
    public class TicketDTO
    {
        public string From { get; set; }
        public string To { get; set; }
        public DateOnly DepartureDate { get; set; }
        public string DepartureTime { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Middlename { get; set; }
        public string Email { get; set; }
    }
}
