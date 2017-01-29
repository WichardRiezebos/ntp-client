using NUnit.Framework;
using System;

namespace NtpClient
{
    [TestFixture]
    public class NtpConnectionTests
    {
        [TestCase(null), TestCase("")]
        public void Constructor_WhenServerIsNullOrEmpty_ThrowsException(string server)
        {
            var exc = Assert.Throws<ArgumentException>(() => new NtpConnection(server));

            Assert.That(exc.ParamName, Is.EqualTo(nameof(server)));
        }
    }
}
