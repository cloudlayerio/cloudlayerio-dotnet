using System;

namespace cloudlayerio_dotnet.responses
{
    public class RateLimits
    {
        /// <summary>
        ///     The current rate limit (Number of requests/min).
        /// </summary>
        public int Limit { get; set; }

        /// <summary>
        ///     Number of requests remaining before hitting the limit.
        /// </summary>
        public int Remaining { get; set; }

        /// <summary>
        ///     When the curreent rate limit window ends, in seconds from the current date (UnixTime)
        /// </summary>
        public int Reset { get; set; }
    }
}