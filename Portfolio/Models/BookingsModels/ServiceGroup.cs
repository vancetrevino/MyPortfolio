namespace Portfolio.Models.BookingsModels
{
    public class ServiceGroup
    {
        public int ServiceGroupId { get; set; }
        public string ServiceGroupName { get; set; }
        public ICollection<Service> Services { get; set; }
    }
}
