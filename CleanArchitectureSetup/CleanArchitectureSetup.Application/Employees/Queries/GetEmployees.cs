using AutoMapper;
using CleanArchitectureSetup.Application.Employees.Queries.Dtos;
using CleanArchitectureSetup.Domain.Employees;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureSetup.Application.Employees.Queries;

public sealed record GetEmployeesQuery : IRequest<IEnumerable<EmployeeDto>>;

public sealed record EmployeeGetByIdQueryHandler(IEmployeeRepository Repository, IMapper Mapper) : IRequestHandler<GetEmployeesQuery, IEnumerable<EmployeeDto>>
{
    public async Task<IEnumerable<EmployeeDto>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
    {
        var employees = await Repository.GetAll().ToListAsync(cancellationToken);
        return Mapper.Map<IEnumerable<EmployeeDto>>(employees);
    }
}