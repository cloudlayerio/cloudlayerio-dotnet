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
        ///     When the current rate limit window ends, in seconds
        /// </summary>
        public int ResetSeconds => Convert.ToInt32(((DateTimeOffset) DateTime.Now).ToUnixTimeSeconds() - Reset);

        /// <summary>
        ///     When the curreent rate limit window ends, in seconds from the current date (UnixTime)
        /// </summary>
        public long Reset { get; set; }
    }
}