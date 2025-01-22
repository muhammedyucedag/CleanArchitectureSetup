using AutoMapper;
using CleanArchitectureSetup.Application.Employees.Base;
using CleanArchitectureSetup.Application.Employees.Command;
using CleanArchitectureSetup.Domain.Employees;
namespace CleanArchitectureSetup.Application.Employees.Queries.Dtos;

public record EmployeeDto : EmployeeBaseCommand
{
    public Guid Id { get; set; }
    public DateTime CreateAt { get; set; }
    public DateTime? UpdateAt { get; set; }
    public DateTime? DeleteAt { get; set; }
    public bool IsDeleted { get; set; }
    
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeCreateCommand, Employee>()
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate.ToUniversalTime()));;
        } 
    }
}

public class EmployeeBaseDtoValidator : EmployeeBaseCommandValidator<EmployeeDto>
{
}