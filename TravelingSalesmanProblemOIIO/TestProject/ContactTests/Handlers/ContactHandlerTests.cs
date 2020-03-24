using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using TravelingSalesmanProblemOIIO.Controllers;
using ContactProj.Domain;
using ContactProj.Application.Commands.CreateCommand;
using ContactProj.Application.Commands.PutCustomer;
using ContactProj.Persistance;
using ContactProj.Application.Commands.GetCustomerById;
using ContactProj.Application.Commands.CreateCustomer;
using ContactProj.Application.Commands.DeleteCustomerById;

namespace TestProject.ContactTests.Handlers
{
    public class ContactHandlerTests
    {
        #region CreateSaveAsync test
        [Fact]
        public async Task ContactHandler_Create_SaveAsync()
        {
            //Arrange
            var dateTimeNow = DateTime.Now;
            Contact result = new Contact();
            var command = new CreateContactCommand
            {
                FirstName = "Mike",
                Surname = "Agten",
                EmailAddress = "mikeagten2@gmail.com",
                ContactType = 1
            };
            var mockContactRepository = new Mock<ContactRepository>();
            //Act
            
            var sut = new CreateContactHandler(mockContactRepository.Object);
            await sut.Handle(command, CancellationToken.None);
            //Assert
            mockContactRepository.Verify(x => x.SaveAsync(It.Is<Contact>(a => a.FirstName == command.FirstName &&
                                                                                      a.Surname == command.Surname &&
                                                                                      a.EmailAddress == command.EmailAddress)), Times.Once);
            mockContactRepository.VerifyNoOtherCalls();
        }
        #endregion

        #region PutPutAsync test
        [Fact]
        public async Task ContactHandler_Put_PutAsync()
        {
            //Arrange
            var dateTimeNow = DateTime.Now;
            var command = new PutContactCommand
            {
                Id = 0,
                FirstName = "Mike",
                Surname = "Agten",
                EmailAddress = "mikeagten2@gmail.com",
                ContactType = 1
            };
            Contact contact = new Contact();
            var mockContactRepository = new Mock<ContactRepository>();
            //Act
            mockContactRepository.Setup(x => x.GetByIdAsync(command.Id)).ReturnsAsync(contact);
            var sut = new PutContactHandler(mockContactRepository.Object);
            await sut.Handle(command, CancellationToken.None);
            mockContactRepository.Verify(x => x.PutAsync(It.Is<Contact>(a => a.FirstName == command.FirstName &&
                                                                                      a.Surname == command.Surname &&
                                                                                      a.EmailAddress == command.EmailAddress)), Times.Once);
            mockContactRepository.Verify(x => x.GetByIdAsync(command.Id), Times.Once);
            mockContactRepository.VerifyNoOtherCalls();
        }
        #endregion

        #region DeleteAsync test
        [Fact]
        public async Task ContactHandler_Delete_DeleteAsync()
        {
            //Arrange
            int deleteId = 1;
            var command = new DeleteContactByIdCommand(deleteId);
            var mockContactRepository = new Mock<ContactRepository>();
            //Act
            var sut = new DeleteContactByIdHandler(mockContactRepository.Object);
            await sut.Handle(command, CancellationToken.None);
            //Act
            mockContactRepository.Verify(x => x.DeleteByIdAsync(deleteId), Times.Once);
            mockContactRepository.VerifyNoOtherCalls();
        }
        #endregion

        #region GetAllAsync test
        [Fact]
        public async Task ContactHandler_Get_GetAllAsync()
        {
            //Arrange
            var dateTimeNow = DateTime.Now;
            var command = new GetContactCommand();
            var mockContactRepository = new Mock<ContactRepository>();
            //Act
            mockContactRepository.Setup(x => x.GetAsync()).ReturnsAsync(It.IsAny<List<Contact>>);
            var sut = new GetContactHandler(mockContactRepository.Object);
            var result = await sut.Handle(command, CancellationToken.None);
            //Act
            mockContactRepository.Verify(x => x.GetAsync(), Times.Once);
            mockContactRepository.VerifyNoOtherCalls();
        }
        #endregion

        #region GetByIdAsync test
        [Fact]
        public async Task ContactHandler_Get_GetAllByIdAsync()
        {
            //Arrange
            var getId = 0;
            Contact result = new Contact();
            var command = new GetContactByIdCommand(getId);
            var mockContactRepository = new Mock<ContactRepository>();
            //Act
            mockContactRepository.Setup(x => x.GetByIdAsync(getId)).ReturnsAsync(result);
            var sut = new GetContactByIdHandler(mockContactRepository.Object);
            result = await sut.Handle(command, CancellationToken.None);
            //Act
            Assert.NotNull(result);
            Assert.Equal(result.Id, getId);
            mockContactRepository.Verify(x => x.GetByIdAsync(getId), Times.Once);
            mockContactRepository.VerifyNoOtherCalls();
        }
        #endregion
    }
}
