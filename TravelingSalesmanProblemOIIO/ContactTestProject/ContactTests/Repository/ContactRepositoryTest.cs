using ContactProj.Domain;
using ContactProj.Persistance;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace TestProject.ContactTests.Repository
{
    public class ContactRepositoryTest
    {

        [Fact]
        public void GetByIdAsync_Returns_Contact()
        {
            using (var dbContext = ContactDbContextInMemory.CreateInMemoryDbContext())
            {
                //Arrange
                int getId = 5;
                var contact = new Contact { Id = getId, FirstName = "test" };
                dbContext.Contacts.Add(contact);
                dbContext.SaveChanges();
                //Act
                var sut = new ContactRepository(dbContext);
                var result = sut.GetByIdAsync(getId, It.IsAny<CancellationToken>());
                //Assert
                Assert.NotNull(result);
                Assert.IsType<Task<Contact>>(result);
                Assert.Equal(contact.Id, result.Result.Id);
            }
        }

        [Fact]
        public void GetAllAsync_Returns_ContactsList()
        {
            using (var dbContext = ContactDbContextInMemory.CreateInMemoryDbContext())
            {
                //Arrange
                var contact1 = new Contact { Id = 5, FirstName = "test1" };
                var contact2 = new Contact { Id = 6, FirstName = "test2" };
                var contact3 = new Contact { Id = 7, FirstName = "test3" };

                dbContext.Contacts.Add(contact1);
                dbContext.Contacts.Add(contact2);
                dbContext.Contacts.Add(contact3);
                dbContext.SaveChanges();

                //Act
                var sut = new ContactRepository(dbContext);
                var result = sut.GetAsync(It.IsAny<CancellationToken>());

                //Assert
                Assert.NotNull(result);
                Assert.IsType<Task<List<Contact>>>(result);
            }
        }

        [Fact]
        public async Task PutAsync_Updates_ContactAsync()
        {
            using (var dbContext = ContactDbContextInMemory.CreateInMemoryDbContext())
            {
                //Arrange
                var changedName = "ChangedName";
                var id = 8;
                var contact1 = new Contact { Id = id, FirstName = "test1" };
                dbContext.Contacts.Add(contact1);
                dbContext.SaveChanges();
                contact1.FirstName = changedName;

                //Act
                var sut = new ContactRepository(dbContext);
                await sut.PutAsync(contact1, It.IsAny<CancellationToken>());
                var result = sut.GetByIdAsync(id, It.IsAny<CancellationToken>());

                //Assert
                Assert.Equal(changedName, result.Result.FirstName);
            }
        }

        [Fact]
        public async Task DeleteByIdAsync_Deletes_ContactAsync()
        {
            using (var dbContext = ContactDbContextInMemory.CreateInMemoryDbContext())
            {
                //Arrange
                var contact1 = new Contact { Id = 9, FirstName = "test1" };
                var contact2 = new Contact { Id = 10, FirstName = "test2" };
                var contact3 = new Contact { Id = 11, FirstName = "test3" };

                dbContext.Contacts.Add(contact1);
                dbContext.Contacts.Add(contact2);
                dbContext.Contacts.Add(contact3);
                dbContext.SaveChanges();

                //Act
                var sut = new ContactRepository(dbContext);
                await sut.DeleteByIdAsync(9, It.IsAny<CancellationToken>());
                var result = sut.GetByIdAsync(9, It.IsAny<CancellationToken>());

                //Assert
                Assert.Null(result.Result);
            }
        }


        [Fact]
        public async Task AddAsync_Adds_ContactAsync()
        {
            using (var dbContext = ContactDbContextInMemory.CreateInMemoryDbContext())
            {
                //Arrange
                var contact1 = new Contact { Id = 12, FirstName = "test1" };
                var contact2 = new Contact { Id = 13, FirstName = "test2" };
                var contact3 = new Contact { Id = 14, FirstName = "test3" };

                //Act
                var sut = new ContactRepository(dbContext);
                await sut.SaveAsync(contact1, It.IsAny<CancellationToken>());
                await sut.SaveAsync(contact2, It.IsAny<CancellationToken>());
                await sut.SaveAsync(contact3, It.IsAny<CancellationToken>());
                var result = sut.GetAsync(It.IsAny<CancellationToken>());

                //Assert
                Assert.Equal(3, result.Result.Count);
            }
        }
    }
}
