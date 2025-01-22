using CleanArchitectureSetup.Domain.Abstractions;

namespace CleanArchitectureSetup.Domain.Employees;

public sealed class Employee : BaseEntity
{
    public required string PartyIdentification { get; set; }
    public required string FirstName { get; set; }
    public required string FamilyName { get; set; }
    
    public string FullName => string.Join("", FirstName, FamilyName); // Database'de yer almayacak ama ekranda çıktısı görebileceğiz.
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