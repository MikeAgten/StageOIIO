using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using TravelingSalesmanProblemOIIO.Controllers;
using ContactProj.Domain;
using ContactProj.Persistance;
using ContactProj.Application.Commands.CreateContact;
using ContactProj.Application.Commands.PutContact;
using ContactProj.Application.Queries.DeleteContactById;
using ContactProj.Application.Queries.CreateContact;
using ContactProj.Application.Queries.GetContactById;
using ContactProj.Application.Contacts.Queries.GetContactById;

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
                FirstName = "zzz",
                Surname = "zzz",
                EmailAddress = "zzz@gmail.com",
                ContactType = 1
            };
            var mockContactRepository = new Mock<ContactRepository>(null);
            //Act
            
            var sut = new CreateContactHandler(mockContactRepository.Object);
            await sut.Handle(command, CancellationToken.None);
            //Assert
            mockContactRepository.Verify(x => x.SaveAsync(It.Is<Contact>(a => a.FirstName == command.FirstName &&
                                                                                      a.Surname == command.Surname &&
                                                                                      a.EmailAddress == command.EmailAddress), It.IsAny<CancellationToken>()), Times.Once);
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
                FirstName = "zzz",
                Surname = "zzz",
                EmailAddress = "zzz@gmail.com",
                ContactType = 1
            };
            Contact contact = new Contact();
            var mockContactRepository = new Mock<ContactRepository>(null);
            //Act
            mockContactRepository.Setup(x => x.GetByIdAsync(command.Id, It.IsAny<CancellationToken>())).ReturnsAsync(contact);
            var sut = new PutContactHandler(mockContactRepository.Object);
            await sut.Handle(command, CancellationToken.None);
            mockContactRepository.Verify(x => x.PutAsync(It.Is<Contact>(a => a.FirstName == command.FirstName &&
                                                                                      a.Surname == command.Surname &&
                                                                                      a.EmailAddress == command.EmailAddress), It.IsAny<CancellationToken>()), Times.Once);
            mockContactRepository.Verify(x => x.GetByIdAsync(command.Id, It.IsAny<CancellationToken>()), Times.Once);
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
            var mockContactRepository = new Mock<ContactRepository>(null);
            //Act
            var sut = new DeleteContactByIdHandler(mockContactRepository.Object);
            await sut.Handle(command, CancellationToken.None);
            //Act
            mockContactRepository.Verify(x => x.DeleteByIdAsync(deleteId, It.IsAny<CancellationToken>()), Times.Once);
            mockContactRepository.VerifyNoOtherCalls();
        }
        #endregion

        #region GetAllAsync test
        [Fact]
        public async Task ContactHandler_Get_GetAllAsync()
        {
            //Arrange
            var dateTimeNow = DateTime.Now;
            var command = new GetContactsQuery();
            var mockContactRepository = new Mock<ContactRepository>(null);
            //Act
            mockContactRepository.Setup(x => x.GetAsync(It.IsAny<CancellationToken>())).ReturnsAsync(It.IsAny<List<Contact>>);
            var sut = new GetContactsQueryHandler(mockContactRepository.Object);
            var result = await sut.Handle(command, CancellationToken.None);
            //Act
            mockContactRepository.Verify(x => x.GetAsync(It.IsAny<CancellationToken>()), Times.Once);
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
            GetContactByIdQueryDto resultDto = new GetContactByIdQueryDto();
            var command = new GetContactByIdQuery(getId);
            var mockContactRepository = new Mock<ContactRepository>(null);
            //Act
            mockContactRepository.Setup(x => x.GetByIdAsync(getId, It.IsAny<CancellationToken>())).ReturnsAsync(result);
            var sut = new GetContactByIdQueryHandler(mockContactRepository.Object);
            resultDto = await sut.Handle(command, CancellationToken.None);
            //Act
            Assert.NotNull(result);
            Assert.Equal(resultDto.Id, getId);
            mockContactRepository.Verify(x => x.GetByIdAsync(getId, It.IsAny<CancellationToken>()), Times.Once);
            mockContactRepository.VerifyNoOtherCalls();
        }
        #endregion
    }
}
