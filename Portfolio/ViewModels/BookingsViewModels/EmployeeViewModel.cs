using Portfolio.Models.BookingsModels;

namespace Portfolio.ViewModels.BookingsViewModels
{
    public class EmployeeViewModel
    {
        public int EmployeeId { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
        public IEnumerable<Service> Services { get; set; }
        public IEnumerable<ServiceGroup> ServicesGroup { get; set; }
    }

    //public class Service
    //{
    //    public int Id { get; set; }
    //    public ServiceGroup ServiceGroup { get; set; }
    //    public string ServiceName { get; set; }
    //    public string ServiceDescription { get; set; }
    //    public int ServicePrice { get; set; }
    //    public int ServiceDurationInMinutes { get; set; }
    //}

    //public class ServiceGroup
    //{
    //    public int Id { get; set; }
    //    public string ServiceGroupName { get; set; }
    //}
}
