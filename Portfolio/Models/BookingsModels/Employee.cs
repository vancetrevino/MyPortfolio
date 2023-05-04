namespace Portfolio.Models.BookingsModels
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public ICollection<Service>? Services { get; set; }
        public DateTime? NextAvailability { get; set; }
        public bool HasAdminRights { get; set; } = false;
        public gender Gender { get; set; }
    }

    public enum gender
    {
        Male = 1,
        Female = 2
    }
}
