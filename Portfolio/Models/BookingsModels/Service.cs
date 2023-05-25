namespace Portfolio.Models.BookingsModels
{
    public class Service
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }
        public int ServicePrice { get; set; }
        public int ServiceDurationInMinutes { get; set; }
        public int ServiceGroupId { get; set; }

        public ServiceGroup ServiceGroup { get; set; }
        //public ICollection<Employee> Employees { get; set; }
        public ICollection<EmployeeServiceAssignment> EmployeeServices { get; set; }
    }
}
