namespace MyProject.Specs.Enums
{
    public class MerchCodeResponseEnum
    {
        /// <summary>
        /// Possible ENUM Responses when validating MerchCodes
        /// </summary>
        public enum ValidationResponses
        {
            Exception = 0,
            NoMerchCode = 1,
            InvalidMerchCode = 2,
            InactiveMerchCode =3,
            MerchCodeDoesNotExist = 4,
            Valid = 5
        }
    }
}
