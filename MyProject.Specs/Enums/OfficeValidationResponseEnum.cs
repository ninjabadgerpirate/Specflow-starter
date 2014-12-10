namespace MyProject.Specs.Enums
{
    /// <summary>
    /// Possible ENUM Responses when validating OfficeCodes
    /// </summary>
    public enum OfficeCodeValidationResponseEnum
    {
        NoOfficeCode = 1,
        InvalidOfficeCode = 2,
        InactiveOfficeCode = 3,
        OfficeCodeDoesNotExist = 4,
        Valid = 5
    }
}
