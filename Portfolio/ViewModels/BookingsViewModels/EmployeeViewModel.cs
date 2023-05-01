using Portfolio.Models.BookingsModels;

namespace Portfolio.ViewModels.BookingsViewModels
{
    public class EmployeeViewModel
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public ICollection<Service> Services { get; set; }
        public DateTime? NextAvailability { get; set; }
        public bool HasAdminRights { get; set; }
    }
}
