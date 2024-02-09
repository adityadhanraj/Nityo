using System;
using System.Net;
using Moq;
using Moq.Protected;
using Nityo.Mocks;
using NUnit.Framework;

namespace Nityo
{
    [TestFixture]
    public class GetNextBirthdayTests
    {
        private HttpClient _client;
        private string _url;

        [SetUp]
        public void Setup()
        {
            _client = new HttpClient();
            _url = "http://example.com/GetNextBirthday"; // Replace with your API endpoint URL
        }

        [TearDown]
        public void TearDown()
        {
            _client.Dispose();
        }

        //Positive Scenarios

        [Test]
        public async Task WhenValidDateProvide_Should_Return_NextBirthday_Response_Content()
        {
            // Arrange
            var expectedResponseContent = "2024-05-15";
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(Utility.IsStringValidDate("1990-05-15"))
                });

            var httpClient = new HttpClient(mockHttpMessageHandler.Object);
            var myHttpClient = new MyHttpClient(httpClient);

            // Act
            var response = await myHttpClient.GetAsync("http://example.com/GetNextBirthday/");
            var date = await response.Content.ReadAsStringAsync();
            // Assert
            Assert.That(expectedResponseContent, Is.EqualTo(date));
            Assert.That("OK", Is.EqualTo(response.StatusCode.ToString()));
        }

        [Test]
        public async Task WhenLeapyearDateProvided_Should_Return_NextBirthday_Response_Content()
        {
            // Arrange
            var expectedResponseContent = "2024-02-29";
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(Utility.IsStringValidDate("2000-02-29"))
                });

            var httpClient = new HttpClient(mockHttpMessageHandler.Object);
            var myHttpClient = new MyHttpClient(httpClient);

            // Act
            var response = await myHttpClient.GetAsync("http://example.com/GetNextBirthday/");
            var date = await response.Content.ReadAsStringAsync();
            // Assert
            Assert.That(expectedResponseContent, Is.EqualTo(date));
            Assert.That("OK", Is.EqualTo(response.StatusCode.ToString()));
        }

        [Test]
        public async Task WhenCurrentDateProvided_Should_Return_NextBirthday_Response_Content()
        {
            // Arrange
            var expectedResponseContent = DateTime.Now.ToString("yyyy-MM-dd");
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(Utility.IsStringValidDate(DateTime.Now.ToString("yyyy-MM-dd")))
                });

            var httpClient = new HttpClient(mockHttpMessageHandler.Object);
            var myHttpClient = new MyHttpClient(httpClient);

            // Act
            var response = await myHttpClient.GetAsync("http://example.com/GetNextBirthday/");
            var date = await response.Content.ReadAsStringAsync();
            // Assert
            Assert.That(expectedResponseContent, Is.EqualTo(date));
            Assert.That("OK", Is.EqualTo(response.StatusCode.ToString()));
        }

        //Negative Scenarios

        [Test]
        public async Task WhenInValidDateProvideShould_Return_NotValidDate_Response()
        {
            // Arrange
            var expectedResponseContent = "Not a valid date";
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Content = new StringContent(Utility.IsStringValidDate("201-05-40"))
                });

            var httpClient = new HttpClient(mockHttpMessageHandler.Object);
            var myHttpClient = new MyHttpClient(httpClient);

            // Act
            var response = await myHttpClient.GetAsync("http://example.com/GetNextBirthday/");
            var date = await response.Content.ReadAsStringAsync();
            // Assert
            Assert.That(expectedResponseContent, Is.EqualTo(date));
            Assert.That("BadRequest", Is.EqualTo(response.StatusCode.ToString()));
        }
        [Test]
        public async Task WhenInValidDateFormatProvided_Should_Return_NotValidDate_Response()
        {
            // Arrange
            var expectedResponseContent = "Not a valid date";
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Content = new StringContent(Utility.IsStringValidDate("2001/05/15"))
                });

            var httpClient = new HttpClient(mockHttpMessageHandler.Object);
            var myHttpClient = new MyHttpClient(httpClient);

            // Act
            var response = await myHttpClient.GetAsync("http://example.com/GetNextBirthday/");
            var date = await response.Content.ReadAsStringAsync();
            // Assert
            Assert.That(expectedResponseContent, Is.EqualTo(date));
            Assert.That("BadRequest", Is.EqualTo(response.StatusCode.ToString()));
        }
        [Test]
        public async Task WhenInValidDateRangeProvided_Should_Return_NotValidDate_Response()
        {
            // Arrange
            var expectedResponseContent = "Not a valid date";
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Content = new StringContent(Utility.IsStringValidDate("2001-13-15"))
                });

            var httpClient = new HttpClient(mockHttpMessageHandler.Object);
            var myHttpClient = new MyHttpClient(httpClient);

            // Act
            var response = await myHttpClient.GetAsync("http://example.com/GetNextBirthday/");
            var date = await response.Content.ReadAsStringAsync();
            // Assert
            Assert.That(expectedResponseContent, Is.EqualTo(date));
            Assert.That("BadRequest", Is.EqualTo(response.StatusCode.ToString()));
        }

        [Test]
        public async Task WhenNullDateProvided_Should_Return_NotValidDate_Response()
        {
            // Arrange
            var expectedResponseContent = "Not a valid date";
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Content = new StringContent(Utility.IsStringValidDate(null))
                });

            var httpClient = new HttpClient(mockHttpMessageHandler.Object);
            var myHttpClient = new MyHttpClient(httpClient);

            // Act
            var response = await myHttpClient.GetAsync("http://example.com/GetNextBirthday/");
            var date = await response.Content.ReadAsStringAsync();
            // Assert
            Assert.That(expectedResponseContent, Is.EqualTo(date));
            Assert.That("BadRequest", Is.EqualTo(response.StatusCode.ToString()));
        }
        [Test]
        public async Task WhenEmptyDateProvided_Should_Return_NotValidDate_Response()
        {
            // Arrange
            var expectedResponseContent = "Not a valid date";
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Content = new StringContent(Utility.IsStringValidDate(""))
                });

            var httpClient = new HttpClient(mockHttpMessageHandler.Object);
            var myHttpClient = new MyHttpClient(httpClient);

            // Act
            var response = await myHttpClient.GetAsync("http://example.com/GetNextBirthday/");
            var date = await response.Content.ReadAsStringAsync();
            // Assert
            Assert.That(expectedResponseContent, Is.EqualTo(date));
            Assert.That("BadRequest", Is.EqualTo(response.StatusCode.ToString()));
        }
        [Test]
        public async Task WhenFutureDateProvided_Should_Return_NotValidDate_Response()
        {
            // Arrange
            var expectedResponseContent = "Not a valid date";
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Content = new StringContent(Utility.IsStringValidDate("2025-01-01"))
                });

            var httpClient = new HttpClient(mockHttpMessageHandler.Object);
            var myHttpClient = new MyHttpClient(httpClient);

            // Act
            var response = await myHttpClient.GetAsync("http://example.com/GetNextBirthday/");
            var date = await response.Content.ReadAsStringAsync();
            // Assert
            Assert.That(expectedResponseContent, Is.EqualTo(date));
            Assert.That("BadRequest", Is.EqualTo(response.StatusCode.ToString()));
        }
        [Test]
        public async Task WhenNotExistentDateProvided_Should_Return_NotValidDate_Response()
        {
            // Arrange
            var expectedResponseContent = "Not a valid date";
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Content = new StringContent(Utility.IsStringValidDate("2023-02-30"))
                });

            var httpClient = new HttpClient(mockHttpMessageHandler.Object);
            var myHttpClient = new MyHttpClient(httpClient);

            // Act
            var response = await myHttpClient.GetAsync("http://example.com/GetNextBirthday/");
            var date = await response.Content.ReadAsStringAsync();
            // Assert
            Assert.That(expectedResponseContent, Is.EqualTo(date));
            Assert.That("BadRequest", Is.EqualTo(response.StatusCode.ToString()));
        }

    }
}
