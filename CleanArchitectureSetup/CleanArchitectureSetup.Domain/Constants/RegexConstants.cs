namespace CleanArchitectureSetup.Domain.Constants;

public static class RegexConstants
{
    /// <summary>
    /// Vergi kimlik numarası kontrolü
    /// </summary>
    public const string PartyIdentification = @"^\d{10,11}$";
}
