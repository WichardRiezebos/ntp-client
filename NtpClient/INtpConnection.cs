using System;

namespace NtpClient
{
    /// <summary>
    /// Provides an interface to enable a class to return the current universal time.
    /// </summary>
    public interface INtpConnection
    {
        /// <summary>
        /// Gets the current universal time.
        /// </summary>
        DateTime GetUtc();
    }
}