namespace LegacyApp.UnitTests
{
    using AutoFixture;
    using FluentAssertions;
    using LegacyApp.DataAccess;
    using LegacyApp.Models;
    using LegacyApp.Providers;
    using LegacyApp.Repositories;
    using LegacyApp.Services;
    using NSubstitute;
    using System;
    using Xunit;

    public class UnitServiceTest
    {
        private readonly UserService _userService;
        private readonly IDateTimeProvider _dateTimeProvider = Substitute.For<IDateTimeProvider>();
        private readonly IClientRepository _clientRepository = Substitute.For<IClientRepository>();
        private readonly IUserCreditService _userCreditService = Substitute.For<IUserCreditService>();
        private readonly IUserDataAccess _userDataAccess = Substitute.For<IUserDataAccess>();
        private readonly IFixture _fixture = new Fixture();

        public UnitServiceTest()
        {
            _userService = new UserService(_dateTimeProvider, _clientRepository, _userCreditService, _userDataAccess);
        }

        [Fact]
        public void AddUser_ShouldAddUser_WhenParametersAreValid()
        {
            //Arrange
            string firname = "Danh";
            string surname = "Nguyen";
            string email = "test123@yahoo.com";
            DateTime dateOfBirth = new DateTime(1993, 7, 30);

            int clientId = default;
            var client = _fixture.Build<Client>()
                .With(x => x.Id, clientId)
                .Create();

            _dateTimeProvider.DateTime.Returns(new DateTime(2021, 2, 16));
            _clientRepository.GetById(clientId).Returns(client);
            _userCreditService.GetCreditLimit(firname, surname, dateOfBirth).Returns(600);

            //Act
            bool result = _userService.AddUser(firname, surname, email, dateOfBirth, clientId);

            //Assert
            result.Should().BeTrue();
            _clientRepository.Received(1).GetById(clientId);
            _userDataAccess.Received(1).AddUser(Arg.Any<User>());
        }
    }
}
