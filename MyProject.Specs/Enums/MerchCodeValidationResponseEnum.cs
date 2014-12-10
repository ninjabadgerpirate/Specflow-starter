namespace MyProject.Specs.Enums
{
    /// <summary>
    /// Possible ENUM Responses when validating MerchCodes
    /// </summary>
    public enum MerchCodeValidationResponseEnum
    {
        NoMerchCode = 1,
        InvalidMerchCode = 2,
        InactiveMerchCode = 3,
        MerchCodeDoesNotExist = 4,
        Valid = 5
    }
}
