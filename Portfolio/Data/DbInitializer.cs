using Microsoft.EntityFrameworkCore;
using Portfolio.Models.BookingsModels;

namespace Portfolio.Data
{
    public class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PortfolioContext(serviceProvider
                .GetRequiredService<DbContextOptions<PortfolioContext>>()))
            {
                //context.Database.EnsureCreated();

                if (context.Employees.Any())
                {
                    // Database has already been seeded
                    return;
                }

                var employees = new Employee[]
                {
                    new Employee
                    {
                        FirstName = "Joe",
                        LastName = "Admin",
                        EmailAddress = "joe.admin@mybookingsite.com",
                        NextAvailability = null,
                        HasAdminRights = true,
                        Gender = gender.Male
                    },
                    new Employee
                    {
                        FirstName = "Trish",
                        LastName = "Dish",
                        EmailAddress = "dish.trish@mybookingsite.com",
                        NextAvailability = null,
                        HasAdminRights = false,
                        Gender = gender.Female
                    },
                    new Employee
                    {
                        FirstName = "Michael",
                        LastName = "King",
                        EmailAddress = "MichaelLKing@dayrep.com",
                        NextAvailability = null,
                        HasAdminRights = false,
                        Gender = gender.Male
                    },
                    new Employee
                    {
                        FirstName = "John",
                        LastName = "Melby",
                        EmailAddress = "johnmmelby@mailg.com",
                        NextAvailability = null,
                        HasAdminRights = false,
                        Gender = gender.Male
                    },
                    new Employee
                    {
                        FirstName = "Carr",
                        LastName = "Francisco",
                        EmailAddress = "FranciscoSCarr@rhyta.com",
                        NextAvailability = null,
                        HasAdminRights = false,
                        Gender = gender.Male
                    },
                    new Employee
                    {
                        FirstName = "Andrea",
                        LastName = "Fallon",
                        EmailAddress = "AndreaRFallon@dayrep.com",
                        NextAvailability = null,
                        HasAdminRights = false,
                        Gender = gender.Female
                    },
                };

                foreach (var employee in employees)
                {
                    context.Employees.Add(employee);
                }
                context.SaveChanges();

                var serviceGroups = new ServiceGroup[]
                {
                    new ServiceGroup
                    {
                        ServiceGroupName = "Haircut",
                    },
                    new ServiceGroup
                    {
                        ServiceGroupName = "Hair Care",
                    },
                    new ServiceGroup
                    {
                        ServiceGroupName = "Shaves",
                    }
                };

                foreach (var sg in serviceGroups)
                {
                    context.ServiceGroups.Add(sg);
                }
                context.SaveChanges();

                var service = new Service[]
                {
                    new Service
                    {
                        ServiceName = "Buzz Cut",
                        ServiceDescription = "Clipper cut with a single guard over the entire head.",
                        ServicePrice = 30,
                        ServiceDurationInMinutes = 20,
                        ServiceGroupId = serviceGroups.Single(sg => sg.ServiceGroupName == "Haircut").ServiceGroupId
                    },
                    new Service
                    {
                        ServiceName = "Standard Cut",
                        ServiceDescription = "A standard haircut using clippers and shears.",
                        ServicePrice = 30,
                        ServiceDurationInMinutes = 30,
                        ServiceGroupId = serviceGroups.Single(sg => sg.ServiceGroupName == "Haircut").ServiceGroupId
                    },
                    new Service
                    {
                        ServiceName = "Skin Fade",
                        ServiceDescription = "A bald fade tapered down to the skin.",
                        ServicePrice = 35,
                        ServiceDurationInMinutes = 45,
                        ServiceGroupId = serviceGroups.Single(sg => sg.ServiceGroupName == "Haircut").ServiceGroupId
                    },
                    new Service
                    {
                        ServiceName = "Shampoo",
                        ServiceDescription = "Classic shampoo and conditioner hair wash.",
                        ServicePrice = 5,
                        ServiceDurationInMinutes = 5,
                        ServiceGroupId = serviceGroups.Single(sg => sg.ServiceGroupName == "Hair Care").ServiceGroupId
                    },
                    new Service
                    {
                        ServiceName = "Deep Conditioning",
                        ServiceDescription = "A moisture treatment for dry, damaged hair.",
                        ServicePrice = 25,
                        ServiceDurationInMinutes = 30,
                        ServiceGroupId = serviceGroups.Single(sg => sg.ServiceGroupName == "Hair Care").ServiceGroupId
                    },
                    new Service
                    {
                        ServiceName = "Classic Shave",
                        ServiceDescription = "Classing straight razor face shave.",
                        ServicePrice = 25,
                        ServiceDurationInMinutes = 30,
                        ServiceGroupId = serviceGroups.Single(sg => sg.ServiceGroupName == "Shaves").ServiceGroupId
                    },
                };

                foreach (var s in service)
                {
                    context.Services.Add(s);
                }
                context.SaveChanges();

                var employeeAssignments = new EmployeeServiceAssignment[]
                {
                    new EmployeeServiceAssignment
                    {
                        EmployeeId = employees.Single(e => e.EmployeeId == 1).EmployeeId,
                        ServiceId = service.Single(s => s.ServiceName == "Buzz Cut").ServiceId
                    },
                    new EmployeeServiceAssignment
                    {
                        EmployeeId = employees.Single(e => e.EmployeeId == 1).EmployeeId,
                        ServiceId = service.Single(s => s.ServiceName == "Standard Cut").ServiceId
                    },
                    new EmployeeServiceAssignment
                    {
                        EmployeeId = employees.Single(e => e.EmployeeId == 1).EmployeeId,
                        ServiceId = service.Single(s => s.ServiceName == "Skin Fade").ServiceId
                    },
                    new EmployeeServiceAssignment
                    {
                        EmployeeId = employees.Single(e => e.EmployeeId == 1).EmployeeId,
                        ServiceId = service.Single(s => s.ServiceName == "Classic Shave").ServiceId
                    },
                    new EmployeeServiceAssignment
                    {
                        EmployeeId = employees.Single(e => e.EmployeeId == 2).EmployeeId,
                        ServiceId = service.Single(s => s.ServiceName == "Buzz Cut").ServiceId
                    },
                    new EmployeeServiceAssignment
                    {
                        EmployeeId = employees.Single(e => e.EmployeeId == 2).EmployeeId,
                        ServiceId = service.Single(s => s.ServiceName == "Standard Cut").ServiceId
                    },
                    new EmployeeServiceAssignment
                    {
                        EmployeeId = employees.Single(e => e.EmployeeId == 2).EmployeeId,
                        ServiceId = service.Single(s => s.ServiceName == "Skin Fade").ServiceId
                    },
                    new EmployeeServiceAssignment
                    {
                        EmployeeId = employees.Single(e => e.EmployeeId == 2).EmployeeId,
                        ServiceId = service.Single(s => s.ServiceName == "Shampoo").ServiceId
                    },
                    new EmployeeServiceAssignment
                    {
                        EmployeeId = employees.Single(e => e.EmployeeId == 2).EmployeeId,
                        ServiceId = service.Single(s => s.ServiceName == "Deep Conditioning").ServiceId
                    },
                    new EmployeeServiceAssignment
                    {
                        EmployeeId = employees.Single(e => e.EmployeeId == 2).EmployeeId,
                        ServiceId = service.Single(s => s.ServiceName == "Classic Shave").ServiceId
                    },
                    new EmployeeServiceAssignment
                    {
                        EmployeeId = employees.Single(e => e.EmployeeId == 3).EmployeeId,
                        ServiceId = service.Single(s => s.ServiceName == "Buzz Cut").ServiceId
                    },
                    new EmployeeServiceAssignment
                    {
                        EmployeeId = employees.Single(e => e.EmployeeId == 3).EmployeeId,
                        ServiceId = service.Single(s => s.ServiceName == "Standard Cut").ServiceId
                    },
                    new EmployeeServiceAssignment
                    {
                        EmployeeId = employees.Single(e => e.EmployeeId == 3).EmployeeId,
                        ServiceId = service.Single(s => s.ServiceName == "Skin Fade").ServiceId
                    },
                    new EmployeeServiceAssignment
                    {
                        EmployeeId = employees.Single(e => e.EmployeeId == 4).EmployeeId,
                        ServiceId = service.Single(s => s.ServiceName == "Buzz Cut").ServiceId
                    },
                    new EmployeeServiceAssignment
                    {
                        EmployeeId = employees.Single(e => e.EmployeeId == 4).EmployeeId,
                        ServiceId = service.Single(s => s.ServiceName == "Standard Cut").ServiceId
                    },
                    new EmployeeServiceAssignment
                    {
                        EmployeeId = employees.Single(e => e.EmployeeId == 4).EmployeeId,
                        ServiceId = service.Single(s => s.ServiceName == "Skin Fade").ServiceId
                    },
                    new EmployeeServiceAssignment
                    {
                        EmployeeId = employees.Single(e => e.EmployeeId == 5).EmployeeId,
                        ServiceId = service.Single(s => s.ServiceName == "Buzz Cut").ServiceId
                    },
                    new EmployeeServiceAssignment
                    {
                        EmployeeId = employees.Single(e => e.EmployeeId == 5).EmployeeId,
                        ServiceId = service.Single(s => s.ServiceName == "Standard Cut").ServiceId
                    },
                    new EmployeeServiceAssignment
                    {
                        EmployeeId = employees.Single(e => e.EmployeeId == 6).EmployeeId,
                        ServiceId = service.Single(s => s.ServiceName == "Buzz Cut").ServiceId
                    },
                    new EmployeeServiceAssignment
                    {
                        EmployeeId = employees.Single(e => e.EmployeeId == 6).EmployeeId,
                        ServiceId = service.Single(s => s.ServiceName == "Standard Cut").ServiceId
                    },
                    new EmployeeServiceAssignment
                    {
                        EmployeeId = employees.Single(e => e.EmployeeId == 6).EmployeeId,
                        ServiceId = service.Single(s => s.ServiceName == "Skin Fade").ServiceId
                    },
                    new EmployeeServiceAssignment
                    {
                        EmployeeId = employees.Single(e => e.EmployeeId == 6).EmployeeId,
                        ServiceId = service.Single(s => s.ServiceName == "Shampoo").ServiceId
                    },
                    new EmployeeServiceAssignment
                    {
                        EmployeeId = employees.Single(e => e.EmployeeId == 6).EmployeeId,
                        ServiceId = service.Single(s => s.ServiceName == "Deep Conditioning").ServiceId
                    },
                    new EmployeeServiceAssignment
                    {
                        EmployeeId = employees.Single(e => e.EmployeeId == 6).EmployeeId,
                        ServiceId = service.Single(s => s.ServiceName == "Classic Shave").ServiceId
                    }
                };

                foreach (var esa in employeeAssignments)
                {
                    context.EmployeeServiceAssignments.Add(esa);
                }
                context.SaveChanges();
            }
        }
    }
}
