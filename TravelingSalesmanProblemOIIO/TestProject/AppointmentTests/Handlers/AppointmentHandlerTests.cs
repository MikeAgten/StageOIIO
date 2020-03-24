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
            Appointment result = new Appointment();
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
            await sut.Handle(command, CancellationToken.None);
            //Assert
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
            Appointment appointment = new Appointment();
            var mockAppointmentRepository = new Mock<AppointmentRepository>();
            //Act
            mockAppointmentRepository.Setup(x => x.GetByIdAsync(command.Id)).ReturnsAsync(appointment);
            var sut = new PutAppointmentHandler(mockAppointmentRepository.Object);
            await sut.Handle(command, CancellationToken.None);
            mockAppointmentRepository.Verify(x => x.PutAsync(It.Is<Appointment>(a => a.Title == command.Title &&
                                                                                      a.Description == command.Description &&
                                                                                      a.Latitude == command.Latitude &&
                                                                                      a.Longitude == command.Longitude &&
                                                                                      a.Start == command.Start &&
                                                                                      a.End == command.End &&
                                                                                      a.ClientId == command.ClientId &&
                                                                                      a.TenantId == command.TenantId)), Times.Once);
            mockAppointmentRepository.Verify(x => x.GetByIdAsync(command.Id),Times.Once);
            mockAppointmentRepository.VerifyNoOtherCalls();
        }
        #endregion

        #region DeleteAsync test
        [Fact]
        public async Task AppointmentHandler_Delete_DeleteAsync()
        {
            //Arrange
            int deleteId = 1;
            var command = new DeleteAppointmentByIdCommand(deleteId);
            var mockAppointmentRepository = new Mock<AppointmentRepository>();
            //Act
            var sut = new DeleteAppointmentByIdHandler(mockAppointmentRepository.Object);
            await sut.Handle(command, CancellationToken.None);
            //Act
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
            mockAppointmentRepository.Setup(x => x.GetAsync()).ReturnsAsync(It.IsAny<List<Appointment>>);
            var sut = new GetAppointmentsHandler(mockAppointmentRepository.Object);
            var result = await sut.Handle(command, CancellationToken.None);
            //Act
            mockAppointmentRepository.Verify(x => x.GetAsync(), Times.Once);
            mockAppointmentRepository.VerifyNoOtherCalls();
        }
        #endregion

        #region GetByIdAsync test
        [Fact]
        public async Task AppointmentHandler_Get_GetAllByIdAsync()
        {
            //Arrange
            var getId = 0;
            Appointment result = new Appointment();
            var command = new GetAppointmentByIdCommand(getId);
            var mockAppointmentRepository = new Mock<AppointmentRepository>();
            //Act
            mockAppointmentRepository.Setup(x => x.GetByIdAsync(getId)).ReturnsAsync(result);
            var sut = new GetAppointmentByIdHandler(mockAppointmentRepository.Object);
            result = await sut.Handle(command, CancellationToken.None);
            //Act
            Assert.NotNull(result);
            Assert.Equal(result.Id, getId);
            mockAppointmentRepository.Verify(x => x.GetByIdAsync(getId), Times.Once);
            mockAppointmentRepository.VerifyNoOtherCalls();
        }
        #endregion
    }
}
