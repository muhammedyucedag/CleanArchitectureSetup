using CleanArchitectureSetup.Domain.Employees;
using GenericRepository;

namespace CleanArchitectureSetup.Infrastructure.Repositories;

internal sealed class EmployeeRepository(ApplicationDbContext context) : Repository<Employee, ApplicationDbContext>(context), IEmployeeRepository;

