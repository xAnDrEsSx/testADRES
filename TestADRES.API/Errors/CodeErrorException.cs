namespace TestADRES.API.Errors
{
    public class CodeErrorException : CodeErrorResponse
    {
        public string? Details { get; set; } = string.Empty;

        public CodeErrorException(int statusCode, string? errorMessage = null, string? details = null) : base(statusCode, errorMessage)
        {
            Details = details;
        }
    }
}
