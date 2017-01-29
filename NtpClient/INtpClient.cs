using System;

namespace NtpClient
{
    public interface INtpClient
    {
        DateTime GetUtc();
    }
}