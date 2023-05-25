namespace Portfolio.Models.BookingsModels
{
    public class EmployeeServiceAssignment
    {
        public int ServiceAssignmentId { get; set; }
        public int EmployeeId { get; set; }
        public int ServiceId { get; set; }
        public Employee Employee { get; set; } = null!;
        public Service Service { get; set; } = null!;
    }
}
