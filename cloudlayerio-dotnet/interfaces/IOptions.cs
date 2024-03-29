﻿namespace cloudlayerio_dotnet.interfaces
{
    /// <summary>
    ///     Base options that are shared across all endpoints.
    /// </summary>
    public interface IOptions
    {
        /// <summary>
        ///     Amount of time (in seconds) allowed to run, if exceeded your job will be terminated.
        /// </summary>
        int? Timeout { get; set; }

        /// <summary>
        ///     The amount of time (in milliseconds) to wait for the page to complete rendering
        ///     before the conversion. Useful where you may have animations or some element on page
        ///     that has delayed loading.
        /// </summary>
        int? Delay { get; set; }

        /// <summary>
        ///     If used with inline = false, will set the Content-Disposition filename so that the
        ///     downloaded file will be set to this value.  For inline = true, the value is ignored.
        /// </summary>
        string Filename { get; set; }

        /// <summary>
        ///     If set to true, sets the Content-Disposition to "inline", if set to false it will set
        ///     the Content-Disposition to "attachment". See <see cref="Filename" /> property if you want to
        ///     set the filename value for the attachment.
        /// </summary>
        bool? Inline { get; set; }
        
        /// <summary>
        ///     If set to true (default), sets the endpoint to be an asynchronous call so that the response returns
        ///     back immediately and does not wait for the job to complete. To check the status of the job
        ///     you will need to check the job:id or use the callback functionality. If set to false, the
        ///     response will not be returned until the job is completed.
        /// </summary>
        bool? Async { get; set; }
    }
}