using IndexaCapital.Api.Client.Contracts.Users;
using Moq;
using Moq.Protected;
using NUnit.Framework;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IndexaCapital.Api.Client.Tests
{
    [Category("Unit")]
    public class IndexaCapitalClientTests
    {
        private Mock<HttpMessageHandler> _httpMessageHandlerMock;

        private IndexaCapitalClient _sut;

        [SetUp]
        public void SetUp()
        {
            _httpMessageHandlerMock = new Mock<HttpMessageHandler>();
            var client = new HttpClient(_httpMessageHandlerMock.Object);
            _sut = new IndexaCapitalClient(client);
        }

        #region GET /users/me
        [Test]
        public async Task GetUserDetailsAsync_Returns_Result_WhenPendingActivation()
        {
            // Arrange
            const string expectedResult = "{\"username\":\"asdasd@adad.com\",\"roles\":[\"ROLE_USER\"],\"email\":\"asdasd@adad.com\",\"phone\":\"+34678987123\",\"document\":\"78196523L\",\"document_type\":\"nif\",\"is_activated\":false,\"phone_activated\":false,\"email_activated\":false,\"affiliate_fee\":0}";


            // Arrange
            _httpMessageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage { StatusCode = HttpStatusCode.OK, Content = new StringContent(expectedResult, Encoding.UTF8, "application/json") });


            // Act
            var actual = await _sut.GetUserDetailsAsync();

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, actual.HttpStatusCode);
            var result = actual.Result;
            Assert.AreEqual("asdasd@adad.com", result.Username);
            Assert.AreEqual("ROLE_USER", result.Roles.Single());
            Assert.AreEqual("asdasd@adad.com", result.Email);
            Assert.AreEqual("+34678987123", result.Phone);
            Assert.AreEqual("78196523L", result.Document);
            Assert.AreEqual(DocumentType.NIF, result.DocumentType);
            Assert.IsFalse(result.IsActivated);
            Assert.IsFalse(result.PhoneActivated);
            Assert.IsFalse(result.EmailActivated);
            Assert.AreEqual(0M, result.AffiliateFee);
        }

        [Test]
        public async Task GetUserDetailsAsync_Returns_Result_WhenUserWithProfileWithoutAccount()
        {
            // Arrange
            const string expectedResult = "{\"username\":\"asdasd@adad.com\",\"roles\":[\"ROLE_USER\"],\"email\":\"asdasd@adad.com\",\"phone\":\"+34678987123\",\"document\":\"78196523L\",\"document_type\":\"nif\",\"is_activated\":true,\"phone_activated\":true,\"email_activated\":true,\"affiliate_fee\":0,\"profiles\":[\"e5cfe6e9-d40e-4211-96b9-45c1cd78a958\"]}";


            // Arrange
            _httpMessageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage { StatusCode = HttpStatusCode.OK, Content = new StringContent(expectedResult, Encoding.UTF8, "application/json") });


            // Act
            var actual = await _sut.GetUserDetailsAsync();

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, actual.HttpStatusCode);
            var result = actual.Result;
            Assert.AreEqual("asdasd@adad.com", result.Username);
            Assert.AreEqual("ROLE_USER", result.Roles.Single());
            Assert.AreEqual("asdasd@adad.com", result.Email);
            Assert.AreEqual("+34678987123", result.Phone);
            Assert.AreEqual("78196523L", result.Document);
            Assert.AreEqual(DocumentType.NIF, result.DocumentType);
            Assert.IsTrue(result.IsActivated);
            Assert.IsTrue(result.PhoneActivated);
            Assert.IsTrue(result.EmailActivated);
            Assert.AreEqual(0M, result.AffiliateFee);
            Assert.AreEqual("e5cfe6e9-d40e-4211-96b9-45c1cd78a958", result.Profiles.Single().ToString());
        }

        [Test]
        public async Task GetUserDetailsAsync_Returns_Result_WhenFullUser()
        {
            // Arrange
            const string expectedResult = "{\"username\":\"asdasd@adad.com\",\"roles\":[\"ROLE_USER\"],\"email\":\"asdasd@adad.com\",\"phone\":\"+34678987123\",\"document\":\"78196523L\",\"document_type\":\"nif\",\"is_activated\":true,\"phone_activated\":true,\"email_activated\":true,\"affiliate_fee\":0,\"accounts_relations\":[{\"account_number\":\"PBKLBYZ5\",\"relation\":\"owner\"},{\"account_number\":\"PBKRBYY1\",\"relation\":\"owner\"}],\"accounts\":[{\"account_number\":\"PBKRBYY1\",\"status\":\"active\",\"type\":\"pension\",\"@path\":\"/accounts/PBKRBYY1\"},{\"account_number\":\"PBKLBYZ5\",\"status\":\"active\",\"type\":\"mutual\",\"@path\":\"/accounts/PBKLBYZ5\"}]}";


            // Arrange
            _httpMessageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage { StatusCode = HttpStatusCode.OK, Content = new StringContent(expectedResult, Encoding.UTF8, "application/json") });


            // Act
            var actual = await _sut.GetUserDetailsAsync();

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, actual.HttpStatusCode);
            var result = actual.Result;
            Assert.AreEqual("asdasd@adad.com", result.Username);
            Assert.AreEqual("ROLE_USER", result.Roles.Single());
            Assert.AreEqual("asdasd@adad.com", result.Email);
            Assert.AreEqual("+34678987123", result.Phone);
            Assert.AreEqual("78196523L", result.Document);
            Assert.AreEqual(DocumentType.NIF, result.DocumentType);
            Assert.IsTrue(result.IsActivated);
            Assert.IsTrue(result.PhoneActivated);
            Assert.IsTrue(result.EmailActivated);
            Assert.AreEqual(0M, result.AffiliateFee);

            Assert.AreEqual("PBKLBYZ5", result.AccountRelations.ElementAt(0).AccountNumber);
            Assert.AreEqual("owner", result.AccountRelations.ElementAt(0).Relation);
            Assert.AreEqual("PBKRBYY1", result.AccountRelations.ElementAt(1).AccountNumber);
            Assert.AreEqual("owner", result.AccountRelations.ElementAt(1).Relation);

            Assert.AreEqual("PBKRBYY1", result.Accounts.ElementAt(0).AccountNumber);
            Assert.AreEqual("active", result.Accounts.ElementAt(0).Status);
            Assert.AreEqual("pension", result.Accounts.ElementAt(0).Type);
            Assert.AreEqual("/accounts/PBKRBYY1", result.Accounts.ElementAt(0).Path);

            Assert.AreEqual("PBKLBYZ5", result.Accounts.ElementAt(1).AccountNumber);
            Assert.AreEqual("active", result.Accounts.ElementAt(1).Status);
            Assert.AreEqual("mutual", result.Accounts.ElementAt(1).Type);
            Assert.AreEqual("/accounts/PBKLBYZ5", result.Accounts.ElementAt(1).Path);

        }

        [Test]
        public async Task GetUserDetailsAsync_Returns_Result_WhenInvalidCredentials()
        {
            // Arrange
            const string expectedResult = "{\"code\":403,\"message\":\"Invalid credentials.\"}";


            // Arrange
            _httpMessageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage { StatusCode = HttpStatusCode.Forbidden, Content = new StringContent(expectedResult, Encoding.UTF8, "application/json") });


            // Act
            var actual = await _sut.GetUserDetailsAsync();

            // Assert
            Assert.AreEqual(HttpStatusCode.Forbidden, actual.HttpStatusCode);
            Assert.AreEqual("Invalid credentials.", actual.ErrorMessage);
        }

        [Test]
        public async Task GetUserDetailsAsync_Returns_Result_WhenAccountIsLocked()
        {
            // Arrange
            const string expectedResult = "{\"code\":423,\"message\":\"Account is locked\"}";


            // Arrange
            _httpMessageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage { StatusCode = HttpStatusCode.Locked, Content = new StringContent(expectedResult, Encoding.UTF8, "application/json") });


            // Act
            var actual = await _sut.GetUserDetailsAsync();

            // Assert
            Assert.AreEqual(HttpStatusCode.Locked, actual.HttpStatusCode);
            Assert.AreEqual("Account is locked", actual.ErrorMessage);
        }
        #endregion
    }
}
