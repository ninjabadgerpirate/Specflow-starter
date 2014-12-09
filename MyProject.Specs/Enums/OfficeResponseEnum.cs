namespace MyProject.Specs.Enums
{
    public class OfficeResponseEnum
    {
        /// <summary>
        /// Possible ENUM Responses when validating OfficeCodes
        /// </summary>
        public enum ValidationResponses
        {
            Exception = 0,
            InvalidOfficeCode = 1,
            InactiveOfficeCode = 2,
            OfficeCodeDoesNotExist = 3,
            Valid = 4
        }
    }
}
