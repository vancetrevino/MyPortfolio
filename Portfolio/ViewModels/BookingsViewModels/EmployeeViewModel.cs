using Microsoft.AspNetCore.Mvc.Rendering;
using Portfolio.Models.BookingsModels;

namespace Portfolio.ViewModels.BookingsViewModels
{
    public class EmployeeViewModel
    {
        public Employee Employee { get; set; }
        public IEnumerable<Service> AllServices { get; set; }

        public List<int> _selectedServices;
        public List<int> SelectedServices
        {
            get
            {
                if (_selectedServices == null)
                {
                    _selectedServices = Employee.EmployeeServices.Select(es => es.ServiceId).ToList();
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
