using System.IO;

namespace cloudlayerio_dotnet.responses
{
    public class ReturnResponse
    {
        /// <summary>
        ///     If the response IsOk true, will contain the binary data of the result.
        /// </summary>
        public Stream Stream { private get; set; }

        /// <summary>
        ///     Indicates if the response was successful (true), or failed (false).
        ///     Check FailureResponse if there was a failure for more information about the failure.
        /// </summary>
        public bool IsOk { private get; set; }

        /// <summary>
        ///     Contains information about the current RateLimits for your request.
        /// </summary>
        public RateLimits RateLimits { get; set; }

        /// <summary>
        ///     Contains information about the failure if there was one.
        ///     Check IsOk to check for failure.
        /// </summary>
        public FailureResponse FailureResponse { get; set; }
    }
}