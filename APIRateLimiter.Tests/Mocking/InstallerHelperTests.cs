using System.Net;
using APIRateLimiter.Mocking;
using Moq;

namespace APIRateLimiter.Tests.Mocking
{
    public class InstallerHelperTests
    {
        private Mock<IFileManager> _fileManger;
        private InstallerHelper _installerHelper;

        [SetUp]
        public void Setup()
        {
            _fileManger = new Mock<IFileManager>();
            _installerHelper = new InstallerHelper();
        }

        [Test]
        public void DownloadInstaller_DownloadFails_ReturnFalse()
        {
            _fileManger.Setup(f => f.DownloadFile(It.IsAny<string>(), It.IsAny<string>())).Throws<WebException>();

            var result = _installerHelper.DownloadInstaller("customer", "123");

            Assert.That(result, Is.False);
        }
    }
}
