using System;
using Xunit;
using SpaceX.LaunchpadService;
using System.Threading.Tasks;
using Moq;
using System.Collections.Generic;
using SpaceX.Models;

namespace SpaceX.Tests
{
    public class UnitTest1
    {         Mock<ILaunchpadService> mock;

        public UnitTest1()
        {
            mock = new Mock<ILaunchpadService>();
            mock.Setup(x => x.Get(0, 0)).ReturnsAsync(new List<Launchpad>
            {
                new Launchpad
                {
                    Id = "first",
                    Name = "The first one",
                    Status = "success"
                },
                new Launchpad
                {
                    Id = "second",
                    Name = "The second one",
                    Status = "success"
                }
            });

            mock.Setup(x => x.Get("first")).ReturnsAsync(new Launchpad
            {
                Id = "first",
                Name = "The first ones",
                Status = "success"
            });
        }

        [Fact]
        public void Test1()
        {
            Assert.True(true);
        }

        [Fact]
        public async Task TestIService()
        {
            var result = await mock.Object.Get(0, 0);
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task TestGetById()
        {
            var result = await mock.Object.Get("first");
            Assert.IsType<Launchpad>(result);
        }
    }
}
