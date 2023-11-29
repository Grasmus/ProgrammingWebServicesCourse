using TrainStation.Core.Entities;

namespace TrainStation.Core.Entities
{
    public class TicketEntity
    {
        public int Id { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public int FromId { get; set; }
        public int ToId { get; set; }
        public decimal Price { get; set; }

        public CityEntity From { get; set; }
        public CityEntity To { get; set; }
    }
}
