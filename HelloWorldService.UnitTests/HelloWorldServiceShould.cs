using HelloWorldService.Data;
using HelloWorldService.Logic;
using HelloWorldService.Repositories;
using Xunit;

namespace HelloWorldService.UnitTests
{
    public class HelloWorldServiceShould
    {
        
        [Fact]
        public void GetMessageSuccess()
        {
            string message = "Hello World!!!";
            var repo = new HelloWorldRepo();
            var options = new ConfigOptions() { DefaultMessage = message, FetchFromDb = false };
            var logic = new HelloWorldLogic(repo, options);

            var result = logic.GetMessage();

            Assert.True(result.Success);
            Assert.Equal("Hello World!!!", result.Dto);

        }

        [Fact]
        public void GetMessageFail()
        {
            var repo = new HelloWorldRepo();
            var options = new ConfigOptions() { FetchFromDb = true};
            var logic = new HelloWorldLogic(repo, options);

            var result = logic.GetMessage();

            Assert.False(result.Success);
            Assert.Equal("Not implemented yet.", result.ErrorMessage);
        }
    }
}
