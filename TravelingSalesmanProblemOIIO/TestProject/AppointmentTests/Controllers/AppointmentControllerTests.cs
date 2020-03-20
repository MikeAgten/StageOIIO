using AppointmentProj.Application.Commands.CreateCommand;
using AppointmentProj.Domain;
using AppointmentProj.Persistance;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TravelingSalesmanProblemOIIO.Controllers;
using Xunit;

namespace TestProject.AppointmentTests.Controllers
{
    public class AppointmentControllerTests
    {

        [Fact]
        public async Task<object> AppointmentController_Create_Post()
        {
            //Arrange
            var appointmentId = 1;
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

            var appointment = new Appointment
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

            var mockMediator = new Mock<IMediator>();
            AppointmentsController appointmentsController = new AppointmentsController(mockMediator.Object);
            var mockAppointmentRepository = new Mock<AppointmentRepository>();
            
            CreateAppointmentCommand createAppointmentCommand = new CreateAppointmentCommand();
            //Act
            var sut = new CreateAppointmentHandler(mockAppointmentRepository.Object);

            var result = await sut.Handle(command, CancellationToken.None);

            mockAppointmentRepository.Verify(x => x.SaveAsync(appointment), Times.Exactly(1));
            mockAppointmentRepository.VerifyNoOtherCalls();

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

            return null;
        }

        [Fact]
        public async void Test()
        {
            int i = 1;
            Assert.NotNull(i);
        }
    }
}
