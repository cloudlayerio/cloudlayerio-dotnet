using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cloudlayerio_dotnet.Interfaces
{
    /// <summary>
    /// Wait options for puppeteer.
    /// </summary>
    interface IWaitForSelectorOptions
    {
        /// <summary>
        /// Wait until the selector is visible. If you set hidden to true, it will negate this option.
        /// </summary>
        public bool? Visible { get; set; }

        /// <summary>
        /// Wait until the selector is hidden. If you set visible to true, it will negate this option.
        /// </summary>
        public bool? Hidden { get; set; }

        /// <summary>
        /// Amount of time to wait for either of the options within waitForSelector to complete 
        /// before aborting the request. This is inclusive to timeout property, and delay is additive 
        /// occurring after this completes.
        /// </summary>
        public int? Timeout { get; set; }
    }
}
