namespace cloudlayerio_dotnet.Interfaces
{
    /// <summary>
    /// Puppeteer has an option called waitUntil where you can pass in several options.  
    /// These options change the behavior of how and when it will complete the rendering of your page, 
    /// and return the results.
    /// </summary>
    public enum WaitUntilOptions
    {
        /// <summary>
        /// Consider navigation to be finished when the load event is fired.
        /// </summary>
        load,
        /// <summary>
        /// Consider navigation to be finished when the DOMContentLoaded event is fired
        /// </summary>
        domcontentloaded,
        /// <summary>
        /// Consider navigation to be finished when there are no more than 0 network 
        /// connections for at least 500 ms.
        /// </summary>
        networkidle0,
        /// <summary>
        ///  Consider navigation to be finished when there are no more than 2 network connections for at least 500 ms
        /// </summary>
        networkidle2
    }
}
