namespace TrainStation.Entities
{
    public class Ticket
    {
        public string From { get; set; }
        public string To { get; set; }
        public DateOnly DepartureDate { get; set; }
        public TimeOnly DepartureTime { get; set; }
        public DateTime Created {  get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Middlename { get; set; }
        public decimal Price { get; set; }
        public string Email { get; set; }
    }
}
