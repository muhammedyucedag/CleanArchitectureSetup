using AutoMapper;
using CleanArchitectureSetup.Application.Employees.Base;
using CleanArchitectureSetup.Domain.Constants;
using CleanArchitectureSetup.Domain.Employees;
using FluentValidation;
using GenericRepository;
using MediatR;
using TS.Result;

namespace CleanArchitectureSetup.Application.Employees.Command;

public sealed record EmployeeCreateCommand : EmployeeBaseCommand,IRequest<Result<string>>
{
}

public sealed class EmployeeCreateCommandValidator : EmployeeBaseCommandValidator<EmployeeCreateCommand>
{
    public EmployeeCreateCommandValidator()
    {
    }
}

public sealed class EmployeeCreateCommandHandler(IEmployeeRepository repository, IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<EmployeeCreateCommand, Result<string>>
{
    public async Task<Result<string>> Handle(EmployeeCreateCommand request, CancellationToken cancellationToken)
    {
        var employeeExists = await repository.AnyAsync(x => x.PartyIdentification == request.PartyIdentification, cancellationToken);
        if (employeeExists)
            return Result<string>.Failure("Bu T.C. Numarası daha önce kaydedildi.");
        
        var employee = mapper.Map<Employee>(request);
        
        await repository.AddAsync(employee, cancellationToken);
        
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Personel Kaydı Başarılı Bir Şekilde Tamamlandı.";
    }
}