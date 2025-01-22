using CleanArchitectureSetup.Domain.Constants;
using FluentValidation;

namespace CleanArchitectureSetup.Application.Employees.Base;

public record EmployeeBaseCommand
{
    public required string PartyIdentification { get; set; }
    public required string FirstName { get; set; }
    public required string FamilyName { get; set; }
    public required string SgkIdentityNumber { get; set; }
    public required string Telephone { get; set; }
    public required string? EmergencyContactNumber { get; set; }
    public DateTime BirthDate { get; set; }
    public required string Address { get; set; }
    public decimal Salary { get; set; }
    public required string ElectronicMail { get; set; }
    public required string CitySubDivisionName { get; set; }
    public required string CityName { get; set; }
}

public class EmployeeBaseCommandValidator<T> : AbstractValidator<T> where T : EmployeeBaseCommand
{
    public EmployeeBaseCommandValidator()
    {
        RuleFor(x => x.PartyIdentification)
            .Matches(RegexConstants.PartyIdentification)
            .NotEmpty()
            .MaximumLength(ConfigurationConsts.MaxPartyIdentificationLength);

        RuleFor(x => x.Address)
            .NotEmpty()
            .MaximumLength(ConfigurationConsts.MaxFullAddressLength);

        RuleFor(x => x.CityName)
            .NotEmpty()
            .MaximumLength(ConfigurationConsts.MaxCityNameLength);

        RuleFor(x => x.CitySubDivisionName)
            .NotEmpty()
            .MaximumLength(ConfigurationConsts.MaxCitySubdivisionNameLength);

        RuleFor(x => x.ElectronicMail)
            .EmailAddress()
            .NotEmpty()
            .MaximumLength(ConfigurationConsts.MaxElectronicMailLength);

        RuleFor(x => x.Telephone)
            .NotEmpty()
            .MaximumLength(ConfigurationConsts.MaxPhoneNumberLength);

        RuleFor(x => x.FamilyName)
            .NotEmpty()
            .MaximumLength(ConfigurationConsts.MaxFamilyNameLength);

        RuleFor(x => x.FirstName)
            .NotEmpty()
            .MaximumLength(ConfigurationConsts.MaxFirstNameLength);

        RuleFor(x => x.EmergencyContactNumber)
            .MaximumLength(ConfigurationConsts.MaxPhoneNumberLength);

        RuleFor(x => x.SgkIdentityNumber)
            .NotEmpty()
            .MaximumLength(ConfigurationConsts.MaxSgkNumberLength);
    }
}