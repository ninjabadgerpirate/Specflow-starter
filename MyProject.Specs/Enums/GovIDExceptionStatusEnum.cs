namespace MyProject.Specs.Enums
{
    /// <summary>
    /// These ENUMS indicate the various statuses for GovIDs.
    /// </summary>
    public enum GovIDExceptionStatusEnum
    {
        NoException = 1,
        Blacklisted = 2,
        MerchBlacklist = 3,
        ClientOptOut = 4,
        PreCancel = 5
    }
}
