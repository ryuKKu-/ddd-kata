using System;
using Application.UseCases.CreateCustomer;
using BuildingBlocks.Application;
using Domain.CustomerAggregate;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace Tests.UseCaseTests
{
    public class CreateCustomerTests
    {
        private IEmailSender _emailSender = new Mock<IEmailSender>().Object;

        [Test]
        public void Should_throw_exception_when_customer_already_exists()
        {
            // act
            var ssn = new SSN("741214-3054");
            var emailAddress = new EmailAddress("toto@leetchi.com");

            var repository = new Mock<ICustomerRepository>();
            repository.Setup(x => x.GetBySSN(It.IsAny<SSN>()))
                .ReturnsAsync(() => new Customer("Jean", "Bono", ssn));

            // arrange
            var useCase = new CreateCustomerUseCase(repository.Object, _emailSender);

            // assert
            var sut = async () => await useCase.Handle(new CreateCustomerInput("Kev", "Yolo", ssn, emailAddress));
            sut.Should().ThrowAsync<InvalidOperationException>();
        }
    }
}