using AppointmentProj.Application.Commands.CreateCommand;
using AppointmentProj.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TravelingSalesmanProblemOIIO.Controllers;

namespace UnitTestsProj.AppointmentTests.Controllers
{
    public class AppointmentControllerTests
    {
        /*AppointmentsController appointmentsController;
        private readonly IMediator mediator;

        [SetUp]
        public void SetUp()
        {
            appointmentsController = new AppointmentsController(mediator);
        }

        [Test]
        public async void AppointmentController_Search_Post()
        {
            CreateAppointmentCommand createAppointmentCommand = new CreateAppointmentCommand();
            var AppointmentResult = await appointmentsController.CreateAppointment(createAppointmentCommand);

            Assert.NotNull(AppointmentResult);
        }*/

        [Test]
        public async void Test()
        {
            int i = 1;
            Assert.NotNull(i);
        }

    }
}
