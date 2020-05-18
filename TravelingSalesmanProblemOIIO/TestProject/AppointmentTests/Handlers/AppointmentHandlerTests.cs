using AppointmentProj.Application.Commands.CreateCommand;
using AppointmentProj.Application.Commands.DeleteAppointmentById;
using AppointmentProj.Application.Commands.PutAppointment;
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
using AppointmentProj.Application.Queries.GetAppointments;
using AppointmentProj.Application.Queries.GetAppointmentById;
using AppointmentProj.Application.Commands.CreateHandler;
using AppointmentProj.Application.Handlers.GetAppointmentById;

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
            var mockAppointmentRepository = new Mock<AppointmentRepository>(null);
            //Act
            
            var sut = new CreateAppointmentCommandHandler(mockAppointmentRepository.Object);
            var result = await sut.Handle(command, CancellationToken.None);
            //Assert
            Assert.IsType<int>(result);
            mockAppointmentRepository.Verify(x => x.SaveAsync(It.Is<Appointment>(a => a.Title == command.Title &&
                                                                                      a.Description == command.Description &&
                                                                                      a.Latitude == command.Latitude &&
                                                                                      a.Longitude == command.Longitude &&
                                                                                      a.Start == command.Start &&
                                                                                      a.End == command.End &&
                                                                                      a.ClientId == command.ClientId &&
                                                                                      a.TenantId == command.TenantId), It.IsAny<CancellationToken>()), Times.Once);
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
            var mockAppointmentRepository = new Mock<AppointmentRepository>(null);
            //Act
            mockAppointmentRepository.Setup(x => x.GetByIdAsync(command.Id, It.IsAny<CancellationToken>())).ReturnsAsync(appointment);
            var sut = new PutAppointmentCommandHandler(mockAppointmentRepository.Object);
            await sut.Handle(command, CancellationToken.None);
            mockAppointmentRepository.Verify(x => x.PutAsync(It.Is<Appointment>(a => a.Title == command.Title &&
                                                                                      a.Description == command.Description &&
                                                                                      a.Latitude == command.Latitude &&
                                                                                      a.Longitude == command.Longitude &&
                                                                                      a.Start == command.Start &&
                                                                                      a.End == command.End &&
                                                                                      a.ClientId == command.ClientId &&
                                                                                      a.TenantId == command.TenantId), It.IsAny<CancellationToken>()), Times.Once);
            mockAppointmentRepository.Verify(x => x.GetByIdAsync(command.Id, It.IsAny<CancellationToken>()),Times.Once);
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
            var mockAppointmentRepository = new Mock<AppointmentRepository>(null);
            //Act
            var sut = new DeleteAppointmentByIdCommandHandler(mockAppointmentRepository.Object);
            await sut.Handle(command, CancellationToken.None);
            //Act
            mockAppointmentRepository.Verify(x => x.DeleteByIdAsync(deleteId, It.IsAny<CancellationToken>()), Times.Once);
            mockAppointmentRepository.VerifyNoOtherCalls();
        }
        #endregion

        #region GetAllAsync test
        [Fact]
        public async Task AppointmentHandler_Get_GetAllAsync()
        {
            //Arrange
            var dateTimeNow = DateTime.Now;
            var command = new GetAppointmentsQuery();
            var mockAppointmentRepository = new Mock<AppointmentRepository>(null);
            //Act
            mockAppointmentRepository.Setup(x => x.GetAsync(It.IsAny<CancellationToken>())).ReturnsAsync(It.IsAny<List<Appointment>>);
            var sut = new GetAppointmentsQueryHandler(mockAppointmentRepository.Object, null);
            var result = await sut.Handle(command, CancellationToken.None);
            //Act
            mockAppointmentRepository.Verify(x => x.GetAsync(It.IsAny<CancellationToken>()), Times.Once);
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
            GetAppointmentByIdDto resultDto = new GetAppointmentByIdDto();
            var command = new GetAppointmentByIdQuery(getId);
            var mockAppointmentRepository = new Mock<AppointmentRepository>(null);
            //Act
            mockAppointmentRepository.Setup(x => x.GetByIdAsync(getId, It.IsAny<CancellationToken>())).ReturnsAsync(result);
            var sut = new GetAppointmentByIdQueryHandler(mockAppointmentRepository.Object, null);
            resultDto = await sut.Handle(command, CancellationToken.None);
            //Act
            Assert.NotNull(result);
            Assert.Equal(resultDto.Appointment.Id, getId);
            mockAppointmentRepository.Verify(x => x.GetByIdAsync(getId, It.IsAny<CancellationToken>()), Times.Once);
            mockAppointmentRepository.VerifyNoOtherCalls();
        }
        #endregion
    }
}
