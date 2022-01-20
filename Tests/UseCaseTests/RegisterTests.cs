using System;
using Application.UseCases.Register;
using Domain.CustomerAggregate;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace Tests.UseCaseTests
{
    public class RegisterTests
    {
        [Test]
        public void Should_throw_exception_when_customer_already_exists()
        {
            // act
            var ssn = new SSN("741214-3054");

            var repository = new Mock<ICustomerRepository>();
            repository.Setup(x => x.GetBySSN(It.IsAny<SSN>()))
                .ReturnsAsync(() => new Customer("Jean", "Bono", ssn));

            // arrange
            var useCase = new RegisterCustomerUseCase(repository.Object);

            // assert
            var sut = async () => await useCase.Handle(new RegisterCustomerInput("Kev", "Yolo", ssn));
            sut.Should().ThrowAsync<InvalidOperationException>();
        }
    }
}