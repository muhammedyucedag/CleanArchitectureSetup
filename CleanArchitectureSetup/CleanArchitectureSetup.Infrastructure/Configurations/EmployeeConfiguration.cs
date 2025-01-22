using CleanArchitectureSetup.Domain.Constants;
using CleanArchitectureSetup.Domain.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitectureSetup.Infrastructure.Configurations;

public sealed class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.Property(x => x.PartyIdentification).IsRequired().HasMaxLength(ConfigurationConsts.MaxPartyIdentificationLength);   
        builder.Property(x => x.Address).IsRequired().HasMaxLength(ConfigurationConsts.MaxFullAddressLength);
        builder.Property(x => x.ElectronicMail).IsRequired().HasMaxLength(ConfigurationConsts.MaxElectronicMailLength);
        builder.Property(x => x.Telephone).IsRequired().HasMaxLength(ConfigurationConsts.MaxPhoneNumberLength);
        builder.Property(x => x.BirthDate).IsRequired().HasMaxLength(ConfigurationConsts.MaxBirthDateLength);
        builder.Property(x => x.FamilyName).IsRequired().HasMaxLength(ConfigurationConsts.MaxFamilyNameLength);
        builder.Property(x => x.FirstName).IsRequired().HasMaxLength(ConfigurationConsts.MaxFirstNameLength);
        builder.Property(x => x.EmergencyContactNumber).HasMaxLength(ConfigurationConsts.MaxPhoneNumberLength);
        builder.Property(x => x.SgkIdentityNumber).IsRequired().HasMaxLength(ConfigurationConsts.MaxSgkNumberLength);
        
        //Relations
    }
}