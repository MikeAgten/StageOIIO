using AppointmentProj.Application.Commands.CreateCommand;
using AppointmentProj.Application.Commands.DeleteAppointmentById;
using AppointmentProj.Application.Commands.PutAppointment;
using AppointmentProj.Application.Commands.GetAppointmentById;
using AppointmentProj.Application.Commands.GetAppointments;
using AppointmentProj.Domain;
using AppointmentProj.Persistance;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using TravelingSalesmanProblemOIIO.Controllers;

namespace TestProject.AppointmentTests.Handlers
{
    public class AppointmentHandlerTests
    {
        #region CreateSaveAsync test
        [Fact]
        public async Task AppointmentHandler_Create_SaveAsync()
        {
            //Arrange
            var dateTimeNow = DateTime.Now;
            var command = new CreateAppointmentCommand
            {
                Title = "testTitle",
                Description = "testDescription",
                Latitude = 50.9761276,
                Longitude = 5.8207892,
                Start = dateTimeNow,
                End = dateTimeNow,
                ClientId = 9,
                TenantId = 1
            };
            var mockAppointmentRepository = new Mock<AppointmentRepository>();
            //Act
            var sut = new CreateAppointmentHandler(mockAppointmentRepository.Object);
            var result = await sut.Handle(command, CancellationToken.None);
            //Assert
            Assert.NotNull(result);
            Assert.Equal(command.Title, result.Title);
            Assert.Equal(command.Description, result.Description);
            Assert.Equal(command.Latitude, result.Latitude);
            Assert.Equal(command.Longitude, result.Longitude);
            Assert.Equal(command.Start, result.Start);
            Assert.Equal(command.End, result.End);
            Assert.Equal(command.ClientId, result.ClientId);
            Assert.Equal(command.TenantId, result.TenantId);
            mockAppointmentRepository.Verify(x => x.SaveAsync(It.Is<Appointment>(a => a.Title == command.Title &&
                                                                                      a.Description == command.Description &&
                                                                                      a.Latitude == command.Latitude &&
                                                                                      a.Longitude == command.Longitude &&
                                                                                      a.Start == command.Start &&
                                                                                      a.End == command.End &&
                                                                                      a.ClientId == command.ClientId &&
                                                                                      a.TenantId == command.TenantId)), Times.Once);
            mockAppointmentRepository.VerifyNoOtherCalls();
        }
        #endregion

        #region PutPutAsync test
        [Fact]
        public async Task AppointmentHandler_Put_PutAsync()
        {
            //Arrange
            var dateTimeNow = DateTime.Now;
            var command = new PutAppointmentCommand
            {
                Id = 0,
                Title = "testTitle",
                Description = "testDescription",
                Latitude = 50.9761276,
                Longitude = 5.8207892,
                Start = dateTimeNow,
                End = dateTimeNow,
                ClientId = 9,
                TenantId = 1
            };
            var mockAppointmentRepository = new Mock<AppointmentRepository>();
            //Act
            var sut = new PutAppointmentHandler(mockAppointmentRepository.Object);
            await sut.Handle(command, CancellationToken.None);
            //Assert
            /*Assert.NotNull(result);
            Assert.Equal(command.Title, result.Title);
            Assert.Equal(command.Description, result.Description);
            Assert.Equal(command.Latitude, result.Latitude);
            Assert.Equal(command.Longitude, result.Longitude);
            Assert.Equal(command.Start, result.Start);
            Assert.Equal(command.End, result.End);
            Assert.Equal(command.ClientId, result.ClientId);
            Assert.Equal(command.TenantId, result.TenantId);*/
            mockAppointmentRepository.Verify(x => x.PutAsync(It.Is<Appointment>(a => a.Title == command.Title &&
                                                                                      a.Description == command.Description &&
                                                                                      a.Latitude == command.Latitude &&
                                                                                      a.Longitude == command.Longitude &&
                                                                                      a.Start == command.Start &&
                                                                                      a.End == command.End &&
                                                                                      a.ClientId == command.ClientId &&
                                                                                      a.TenantId == command.TenantId)), Times.Once);
            mockAppointmentRepository.VerifyNoOtherCalls();
        }
        #endregion

        #region DeleteAsync test
        [Fact]
        public async Task AppointmentHandler_Delete_DeleteAsync()
        {
            //Arrange
            var deleteId = 1;
            var command = new DeleteAppointmentByIdCommand(deleteId);
            var mockAppointmentRepository = new Mock<AppointmentRepository>();
            //Act
            var sut = new DeleteAppointmentByIdHandler(mockAppointmentRepository.Object);
            var result = await sut.Handle(command, CancellationToken.None);
            //Act
            Assert.NotNull(result);
            mockAppointmentRepository.Verify(x => x.DeleteByIdAsync(deleteId), Times.Once);
            mockAppointmentRepository.VerifyNoOtherCalls();
        }
        #endregion

        #region GetAllAsync test
        [Fact]
        public async Task AppointmentHandler_Get_GetAllAsync()
        {
            //Arrange
            var dateTimeNow = DateTime.Now;
            var command = new GetAppointmentsCommand();
            var mockAppointmentRepository = new Mock<AppointmentRepository>();
            //Act
            var sut = new GetAppointmentsHandler(mockAppointmentRepository.Object);
            var result = await sut.Handle(command, CancellationToken.None);
            //Act
            Assert.NotNull(result);
            mockAppointmentRepository.Verify(x => x.GetAsync(), Times.Once);
            mockAppointmentRepository.VerifyNoOtherCalls();
        }
        #endregion

        #region GetByIdAsync test
        [Fact]
        public async Task AppointmentHandler_Get_GetAllByIdAsync()
        {
            //Arrange
            var getId = 1;
            var command = new GetAppointmentByIdCommand(getId);
            var mockAppointmentRepository = new Mock<AppointmentRepository>();
            //Act
            var sut = new GetAppointmentByIdHandler(mockAppointmentRepository.Object);
            var result = await sut.Handle(command, CancellationToken.None);
            //Act
            Assert.NotNull(result.Id);
            Assert.Equal(result.Id, getId);
            mockAppointmentRepository.Verify(x => x.GetByIdAsync(getId), Times.Once);
            mockAppointmentRepository.VerifyNoOtherCalls();
        }
        #endregion
    }
}
