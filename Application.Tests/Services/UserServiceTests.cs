using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FluentAssertions;
using UA.Application.Dtos;
using UA.Application.Interfaces;
using UA.Application.Services;
using UA.Domain.Entities;
using UA.Infrastructure.Data;
using UA.Infrastructure.Extension;


namespace Application.Tests.Services
{
    public class UserServiceTests
    {
        private UserServices CreateService(out ApplicationDbContext context)
        {
            // Here you would typically set up any dependencies the UserService has,
            // such as a mock database context or repository.
            var inMemorySettings = new Dictionary<string, string>
            {
                { "ConnectionStrings:DefaultConnection", "Data Source=UserAppDb.db" }
            };

            IConfiguration configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();

            var services = new ServiceCollection();
            services.AddInfrastructure(configuration);

            var provider = services.BuildServiceProvider();

            context = provider.GetRequiredService<ApplicationDbContext>();
            bool CheckDatabase = context.Database.EnsureCreated();
            var repo = provider.GetRequiredService<IRepository<User>>();
            return new UserServices(repo); // assuming ctor needs repo

        }

        [Fact]
        public async Task CreateUser_Success()
        {
            var Userservice = CreateService(out var context);
            string userEmail = "testuser7@gmail.com";
            var result = await Userservice.CreateUserAsync(new UserCreateUpdateDto("Test User", userEmail));
            result.Id.Should().NotBeEmpty();
            result.Name.Should().Be("Test User");
            result.Email.Should().Be(userEmail);
        }
        [Fact]
        public async Task UpdateUserEmail_Success()
        {
            var Userservice = CreateService(out var context);
            var userCreated = await Userservice.CreateUserAsync(new UserCreateUpdateDto("Test User", "oldemail@gmail.com"));
            var userUpdated = await Userservice.UpdateUserEmail(userCreated.Id, new UserEmailUpdateDto("newemail@gmail2.com"));
            userUpdated.Email.Should().Be("newemail@gmail2.com");
        }
        [Fact]
        public async Task DeleteUser_Success()
        {
            var Userservice = CreateService(out var context);
            var userCreated = await Userservice.CreateUserAsync(new UserCreateUpdateDto("Test User", "deletethisuser@gmail.com"));
            var deleteResult = await Userservice.DeleteUserAsync(userCreated.Id);
            deleteResult.Should().BeTrue();
            var userFetch= await Userservice.GetUserByIdAsync(userCreated.Id);
            userFetch.Should().BeNull();
        }
        [Fact]
        public async Task LinqFilterLogic_success()
        {
            var Userservice = CreateService(out var context);
            await Userservice.CreateUserAsync(new UserCreateUpdateDto("Test User101", "user1001@yahoo.com"));
            await Userservice.CreateUserAsync(new UserCreateUpdateDto("Test User102", "user1002@yahoo.com"));
            await Userservice.CreateUserAsync(new UserCreateUpdateDto("Test User103", "user1003@Hosting.com"));
            var filteredUsers = await Userservice.GetUsersByEmails("yahoo.com");            
            filteredUsers.Select(u => u.Email).Should().OnlyContain(e => e.EndsWith("@yahoo.com"));
        }
    }
}
