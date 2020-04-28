using AppointmentProj.Domain;
using AppointmentProj.Persistance;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace TestProject.AppointmentTests.Repository
{
    public class AppointmentRepositoryTests
    {

        [Fact]
        public void GetByIdAsync_Returns_Appointment()
        {
            using (var dbContext = AppointmentDbContextInMemory.CreateInMemoryDbContext())
            {
                //Arrange
                int getId = 5;
                var appointment = new Appointment { Id = getId, Title = "test" };
                dbContext.Appointments.Add(appointment);
                dbContext.SaveChanges();
                //Act
                var sut = new AppointmentRepository(dbContext);
                var result = sut.GetByIdAsync(getId, It.IsAny<CancellationToken>());
                //Assert
                Assert.NotNull(result);
                Assert.IsType<Task<Appointment>>(result);
                Assert.Equal(appointment.Id, result.Result.Id);
            }
        }

        [Fact]
        public void GetAllAsync_Returns_AppointmentsList()
        {
            using (var dbContext = AppointmentDbContextInMemory.CreateInMemoryDbContext())
            {
                //Arrange
                var appointment1 = new Appointment { Id = 5, Title = "test1" };
                var appointment2 = new Appointment { Id = 6, Title = "test2" };
                var appointment3 = new Appointment { Id = 7, Title = "test3" };

                dbContext.Appointments.Add(appointment1);
                dbContext.Appointments.Add(appointment2);
                dbContext.Appointments.Add(appointment3);
                dbContext.SaveChanges();

                //Act
                var sut = new AppointmentRepository(dbContext);
                var result = sut.GetAsync(It.IsAny<CancellationToken>());

                //Assert
                Assert.NotNull(result);
                Assert.IsType<Task<List<Appointment>>>(result);
            }
        }

        [Fact]
        public async Task PutAsync_Updates_AppointmentAsync()
        {
            using (var dbContext = AppointmentDbContextInMemory.CreateInMemoryDbContext())
            {
                //Arrange
                var changedTitle = "ChangedTitle";
                var id = 8;
                var appointment1 = new Appointment { Id = id, Title = "test1" };
                dbContext.Appointments.Add(appointment1);
                dbContext.SaveChanges();
                appointment1.Title = changedTitle;

                //Act
                var sut = new AppointmentRepository(dbContext);
                await sut.PutAsync(appointment1, It.IsAny<CancellationToken>());
                var result = sut.GetByIdAsync(id, It.IsAny<CancellationToken>());

                //Assert
                Assert.Equal(changedTitle, result.Result.Title);
            }
        }

        [Fact]
        public async Task DeleteByIdAsync_Deletes_AppointmentAsync()
        {
            using (var dbContext = AppointmentDbContextInMemory.CreateInMemoryDbContext())
            {
                //Arrange
                var appointment1 = new Appointment { Id = 9, Title = "test1" };
                var appointment2 = new Appointment { Id = 10, Title = "test2" };
                var appointment3 = new Appointment { Id = 11, Title = "test3" };

                dbContext.Appointments.Add(appointment1);
                dbContext.Appointments.Add(appointment2);
                dbContext.Appointments.Add(appointment3);
                dbContext.SaveChanges();

                //Act
                var sut = new AppointmentRepository(dbContext);
                await sut.DeleteByIdAsync(9, It.IsAny<CancellationToken>());
                var result = sut.GetByIdAsync(9,It.IsAny<CancellationToken>());

                //Assert
                Assert.Null(result.Result);
            }
        }


        [Fact]
        public async Task AddAsync_Adds_AppointmentAsync()
        {
            using (var dbContext = AppointmentDbContextInMemory.CreateInMemoryDbContext())
            {
                //Arrange
                var appointment1 = new Appointment { Id = 12, Title = "test1" };
                var appointment2 = new Appointment { Id = 13, Title = "test2" };
                var appointment3 = new Appointment { Id = 14, Title = "test3" };

                //Act
                var sut = new AppointmentRepository(dbContext);
                await sut.SaveAsync(appointment1, It.IsAny<CancellationToken>());
                await sut.SaveAsync(appointment2, It.IsAny<CancellationToken>());
                await sut.SaveAsync(appointment3, It.IsAny<CancellationToken>());
                var result = sut.GetAsync(It.IsAny<CancellationToken>());

                //Assert
                Assert.Equal(3, result.Result.Count);
            }
        }
    }
}
