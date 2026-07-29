using CustomerCommLib;
using Moq;
using NUnit.Framework;

namespace CustomerComm.Tests;

[TestFixture]
public class CustomerCommTests
{
    private Mock<IMailSender> _mockMailSender;

    [OneTimeSetUp]
    public void Setup()
    {
        _mockMailSender = new Mock<IMailSender>();
    }

    [TestCase]
    public void SendMailToCustomer_ShouldReturnTrue()
    {
        // Arrange
        _mockMailSender
            .Setup(x => x.SendMail(It.IsAny<string>(), It.IsAny<string>()))
            .Returns(true);

        CustomerCommLib.CustomerComm customerComm =
    new CustomerCommLib.CustomerComm(_mockMailSender.Object);

        // Act
        bool result = customerComm.SendMailToCustomer();

        // Assert
        Assert.That(result, Is.True);
    }
}