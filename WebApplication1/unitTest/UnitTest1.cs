
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WebApplication1.Model;

namespace TestProject1
{
    public class Tests
    {
        private Mock<IUserStore<ApplicationUser>> mockStore;
        private Mock<IUserStore<ApplicationUser>> mockUserStore;
        private Mock<IUserStore<IdentityUser>> mockStore2;
        private Mock<IUserStore<IdentityUser>> mockUserStore2;
        private FakeUserManager fakeUserManager;
        private ApplicationUser user;
        private HttpRequestMessage request;
        private const string APIKEY = "5260bcabdbmshfc303d95310ec07p1f2548jsn8016847b4731";

        [SetUp]
        public void Setup()
        {
            mockStore = new Mock<IUserStore<ApplicationUser>>();
            mockUserStore = new Mock<IUserStore<ApplicationUser>>();
            mockStore2 = new Mock<IUserStore<IdentityUser>>();
            mockUserStore2 = new Mock<IUserStore<IdentityUser>>();
            user = new ApplicationUser()
            {
                Email = "mockTest2@mockTest.com",
            };

        }

        [Test]
        public void CreateUserTest()
        {

            mockStore.Setup(s => s.CreateAsync(It.IsAny<ApplicationUser>(), CancellationToken.None))
            .Returns(Task.FromResult(IdentityResult.Success));
            mockStore.Setup(s => s.FindByNameAsync(It.IsAny<string>(), CancellationToken.None))
            .Returns(Task.FromResult(user)).Verifiable();

            fakeUserManager = new FakeUserManager(mockStore.Object);
            Assert.NotNull(fakeUserManager);
        }

        [Test]
        public void findByEmailTest()
        {

            mockStore.Setup(s => s.CreateAsync(It.IsAny<ApplicationUser>(), CancellationToken.None))
            .Returns(Task.FromResult(IdentityResult.Success));
            mockStore.Setup(s => s.FindByNameAsync(It.IsAny<string>(), CancellationToken.None))
            .Returns(Task.FromResult(user)).Verifiable();

            fakeUserManager = new FakeUserManager(mockStore.Object);
            var res2 = fakeUserManager.FindByEmailAsync(user.Email);
            res2.Wait();

            Assert.NotNull(res2);
            Assert.AreEqual("mockTest2@mockTest.com", res2.Result.Email);
        }

        [Test]
        public void updateEmailTest()
        {
            mockStore.Setup(s => s.CreateAsync(It.IsAny<ApplicationUser>(), CancellationToken.None))
            .Returns(Task.FromResult(IdentityResult.Success));
            fakeUserManager = new FakeUserManager(mockStore.Object);
            var res2 = fakeUserManager.FindByEmailAsync(user.Email);
            res2.Wait();
            user.Email = "newEmailTest@e.com";
            fakeUserManager.UpdateAsync(user);
            var res3 = fakeUserManager.FindByEmailAsync(user.Email);
            res3.Wait();

            Assert.NotNull(res2);
            Assert.NotNull(res3);
            Assert.AreEqual("newEmailTest@e.com", res3.Result.Email);
        }

        [Test]
        public void DeleteUserTestAsync()
        {
            mockStore.Setup(s => s.CreateAsync(It.IsAny<ApplicationUser>(), CancellationToken.None))
            .Returns(Task.FromResult(IdentityResult.Success));
            fakeUserManager = new FakeUserManager(mockStore.Object);
            var res2 = fakeUserManager.DeleteAsync(user);
            res2.Wait();
            Assert.IsNull(res2.Result);
        }

        [Test]
        public async Task ApiFootballTest()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://sportscore1.p.rapidapi.com/sports/1"),
                Headers =
                {
                    { "X-RapidAPI-Host", "sportscore1.p.rapidapi.com" },
                    { "X-RapidAPI-Key", APIKEY },
                },
            };
            var client = new HttpClient();
            dynamic res;
            using (var response = await client.SendAsync(request))
            {
                //response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();


                res = JsonConvert.DeserializeObject(body);

                string sportType = res.data["name"];
                Assert.IsTrue(sportType.Equals("Football"));
            }

        }

        [Test]
        public async Task ApiBasketballTest()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://sportscore1.p.rapidapi.com/sports/3"),
                Headers =
                {
                    { "X-RapidAPI-Host", "sportscore1.p.rapidapi.com" },
                    { "X-RapidAPI-Key", APIKEY},
                },
            };
            var client = new HttpClient();
            dynamic res;
            using (var response = await client.SendAsync(request))
            {
                //response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();


                res = JsonConvert.DeserializeObject(body);

                string sportType = res.data["name"];
                Assert.IsTrue(sportType.Equals("Basketball"));
            }

        }

        [Test]
        public async Task ApiTennisTest()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://sportscore1.p.rapidapi.com/sports/2"),
                Headers =
                {
                    { "X-RapidAPI-Host", "sportscore1.p.rapidapi.com" },
                    { "X-RapidAPI-Key", APIKEY },
                },
            };
            var client = new HttpClient();
            dynamic res;
            using (var response = await client.SendAsync(request))
            {
                //response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();


                res = JsonConvert.DeserializeObject(body);

                string sportType = res.data["name"];
                Assert.IsTrue(sportType.Equals("Tennis"));
            }

        }

        [Test]
        public async Task ApiHockeyTest()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://sportscore1.p.rapidapi.com/sports/4"),
                Headers =
                {
                    { "X-RapidAPI-Host", "sportscore1.p.rapidapi.com" },
                    { "X-RapidAPI-Key", APIKEY },
                },
            };
            var client = new HttpClient();
            dynamic res;
            using (var response = await client.SendAsync(request))
            {
                //response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();


                res = JsonConvert.DeserializeObject(body);

                string sportType = res.data["name"];
                Assert.IsTrue(sportType.Equals("Ice Hockey"));
            }

        }

        [Test]
        public async Task ApiVolleyballTest()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://sportscore1.p.rapidapi.com/sports/5"),
                Headers =
                {
                    { "X-RapidAPI-Host", "sportscore1.p.rapidapi.com" },
                    { "X-RapidAPI-Key", APIKEY },
                },
            };
            var client = new HttpClient();
            dynamic res;
            using (var response = await client.SendAsync(request))
            {
                //response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();


                res = JsonConvert.DeserializeObject(body);

                string sportType = res.data["name"];
                Assert.IsTrue(sportType.Equals("Volleyball"));
            }

        }

        [Test]
        public async Task ApiHandballTest()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://sportscore1.p.rapidapi.com/sports/6"),
                Headers =
                {
                    { "X-RapidAPI-Host", "sportscore1.p.rapidapi.com" },
                    { "X-RapidAPI-Key", APIKEY },
                },
            };
            var client = new HttpClient();
            dynamic res;
            using (var response = await client.SendAsync(request))
            {
                //response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();


                res = JsonConvert.DeserializeObject(body);

                string sportType = res.data["name"];
                Assert.IsTrue(sportType.Equals("Handball"));
            }

        }

        [Test]
        public async Task ApiExceptionTest()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://sportscore1.p.rapidapi.com/sports/7"),
                Headers =
                {
                    { "X-RapidAPI-Host", "sportscore1.p.rapidapi.com" },
                    { "X-RapidAPI-Key", APIKEY },
                },
            };
            var client = new HttpClient();
            dynamic res;
            using (var response = await client.SendAsync(request))
            {
                //response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();


                res = JsonConvert.DeserializeObject(body);

                string sportType = res.message;
                Assert.IsTrue(sportType.Equals("Not found"));
            }

        }
    }



    public class FakeUserManager : UserManager<ApplicationUser>
    {
        public FakeUserManager(IUserStore<ApplicationUser> userStore) : base(userStore,
                new Mock<IOptions<IdentityOptions>>().Object,
                new Mock<IPasswordHasher<ApplicationUser>>().Object,
                new IUserValidator<ApplicationUser>[0],
                new IPasswordValidator<ApplicationUser>[0],
                new Mock<ILookupNormalizer>().Object,
                new Mock<IdentityErrorDescriber>().Object,
                new Mock<IServiceProvider>().Object,
                new Mock<ILogger<UserManager<ApplicationUser>>>().Object)
        { }

        public override Task<ApplicationUser> FindByEmailAsync(string email)
        {
            return Task.FromResult(new ApplicationUser { Email = email });
        }
        public override Task<ApplicationUser> FindByNameAsync(string username)
        {
            return Task.FromResult(new ApplicationUser { UserName = username });
        }
    }

    public class FakeUserManager2 : UserManager<IdentityUser>
    {
        public FakeUserManager2(IUserStore<IdentityUser> userStore) : base(userStore,
                new Mock<IOptions<IdentityOptions>>().Object,
                new Mock<IPasswordHasher<IdentityUser>>().Object,
                new IUserValidator<IdentityUser>[0],
                new IPasswordValidator<IdentityUser>[0],
                new Mock<ILookupNormalizer>().Object,
                new Mock<IdentityErrorDescriber>().Object,
                new Mock<IServiceProvider>().Object,
                new Mock<ILogger<UserManager<IdentityUser>>>().Object)
        { }

        public override Task<IdentityUser> FindByEmailAsync(string email)
        {
            return Task.FromResult(new IdentityUser { Email = email });
        }
        public override Task<IdentityUser> FindByNameAsync(string username)
        {
            return Task.FromResult(new IdentityUser { UserName = username });
        }
    }


    //public class FakeUserManager : UserManager<User>
    //{
    //    public FakeUserManager()
    //        : base(new Mock<IUserStore<User>>().Object,
    //          new Mock<IOptions<IdentityOptions>>().Object,
    //          new Mock<IPasswordHasher<User>>().Object,
    //          new IUserValidator<User>[0],
    //          new IPasswordValidator<User>[0],
    //          new Mock<ILookupNormalizer>().Object,
    //          new Mock<IdentityErrorDescriber>().Object,
    //          new Mock<IServiceProvider>().Object,
    //          new Mock<ILogger<UserManager<User>>>().Object)
    //    { }

    //    public override Task<IdentityResult> CreateAsync(User user, string password)
    //    {
    //        return Task.FromResult(IdentityResult.Success);
    //    }

    //    public override Task<IdentityResult> AddToRoleAsync(User user, string role)
    //    {
    //        return Task.FromResult(IdentityResult.Success);
    //    }

    //    public override Task<string> GenerateEmailConfirmationTokenAsync(User user)
    //    {
    //        return Task.FromResult(Guid.NewGuid().ToString());
    //    }

    //    public override Task<IdentityResult> ConfirmEmailAsync(User user, string token)
    //    {
    //        return Task.FromResult(IdentityResult.Success);
    //    }

    //    public override Task<User> FindByEmailAsync(string email)
    //    {
    //        return base.FindByEmailAsync(email);
    //    }
    //}

    //public class SignInManagerMock : SignInManager<ApplicationUser>
    //{
    //    public SignInManagerMock(
    //        UserManager<ApplicationUser> userManager,
    //        IHttpContextAccessor contextAccessor,
    //        IUserClaimsPrincipalFactory<ApplicationUser> claimsFactory,
    //        IOptions<IdentityOptions> optionsAccessor,
    //        ILogger<SignInManager<ApplicationUser>> logger,
    //        IAuthenticationSchemeProvider authProvider)
    //        : base(
    //              userManager,
    //              contextAccessor,
    //              claimsFactory,
    //              optionsAccessor,
    //              logger,
    //              authProvider)
    //    {
    //    }

    //    public override Task<SignInResult> PasswordSignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure)
    //    {
    //        if (userName == "valid@valid.com" && password == "valid")
    //        {
    //            return Task.FromResult(SignInResult.Success);
    //        }

    //        return Task.FromResult(SignInResult.Failed);
    //    }
    //}


}