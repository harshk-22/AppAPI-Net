namespace AppAPI.Errors
{
    public class ApiException(int statusCode,string message,string? details)
    {

        public int statusCode { get; set; }

        public string message { get; set; }

        public string? details { get; set; }
    }
}
