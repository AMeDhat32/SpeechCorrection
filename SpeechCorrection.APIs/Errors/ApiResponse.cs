
namespace SpeechCorrection.APIs.Errors
{
    public class ApiResponse
    {
        public int StatusCode { get; set; } 

        public string? Message { get; set; }

        public ApiResponse(int statusCode, string? message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        private string? GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "What you just said makes no sense",
                401 => "Get the hell out of here",
                404 => "Lost? just like your mind",
                500 => "Something broke, probably my soul",
                _ => "Error? What error?"
            };
        }
    }
}
