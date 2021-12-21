using NUnit.Framework;
using System;
using System.Configuration;
using System.Net;
using System.Threading.Tasks;

namespace IndexaCapital.Api.Client.Tests
{
    [Category("Integration")]
    public class IndexaCapitalClientIntegrationTests
    {
        private IndexaCapitalClient _sut;

        [SetUp]
        public void SetUp()
        {
            var token = Environment.GetEnvironmentVariable("INDEXACAPITAL_TOKEN");
            if (token == null)
            {
                throw new ConfigurationErrorsException("Environment variable 'INDEXACAPITAL_TOKEN' is not defined.");
            }
            _sut = new IndexaCapitalClient(token);
        }

        #region GET /users/me
        [Test]
        public async Task GetUserDetailsAsync_Returns_Result()
        {
            // Arrange

            // Act
            var actual = await _sut.GetUserDetailsAsync();

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, actual.HttpStatusCode);
        }

        #endregion
    }
}
