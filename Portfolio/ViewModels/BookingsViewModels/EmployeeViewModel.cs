using Microsoft.AspNetCore.Mvc.Rendering;
using Portfolio.Models.BookingsModels;

namespace Portfolio.ViewModels.BookingsViewModels
{
    public class EmployeeViewModel
    {
        public Employee Employee { get; set; }
        //public EmployeeServiceAssignment EmployeeServiceAssignments { get; set; }
        public IEnumerable<Service> AllServices { get; set; }

        public List<Service> _selectedServices;
        public List<Service> SelectedServices
        {
            get
            {
                if (_selectedServices == null)
                {
                    List<int> employeeServcieIds = Employee.EmployeeServices.Select(es => es.ServiceId).ToList();
                    foreach (var id in employeeServcieIds)
                    {
                        var currentService = AllServices.FirstOrDefault(s => s.ServiceId == id);
                        _selectedServices.Add(currentService);
                    }
                    //_selectedServices = 
                }
                return _selectedServices;
            }
            set
            {
                _selectedServices = value;
            }
        }
    }
}
