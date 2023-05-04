namespace Portfolio.Models.BookingsModels
{
    public class Service
    {
        public int Id { get; set; }
        public string ServiceGroup { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }
        public int ServicePrice { get; set; }
        public int ServiceDurationInMinutes { get; set; }
    }
}
