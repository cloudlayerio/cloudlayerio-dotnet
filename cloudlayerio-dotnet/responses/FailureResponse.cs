namespace cloudlayerio_dotnet.responses
{
    public class FailureResponse
    {
        public bool Allowed { get; set; }

        public int StatusCode { get; set; }

        public string Reason { get; set; }
    }
}