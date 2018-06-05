using HelloWorldService.Data;
using HelloWorldService.Repositories;
using Microsoft.Extensions.Options;
using System;

namespace HelloWorldService.Logic
{
    public class HelloWorldLogic : IHelloWorldLogic
    {
        IHelloWorldRepo _repo;
        ConfigOptions _options;

        public HelloWorldLogic(IHelloWorldRepo repo,IOptions<ConfigOptions> options)
        {
            _repo = repo;
            _options = options.Value;
        }

        public HelloWorldLogic(IHelloWorldRepo repo, ConfigOptions options)
        {
            _repo = repo;
            _options = options;
        }

        public ResponseDto<string> GetMessage()
        {
            var response = new ResponseDto<String>() { ErrorMessage = "Failed to fetch message. ", Success = false };
            try
            {
                ProcessMessageRequest();
                response = FetchMessage();
            }
            catch(Exception ex)
            {
                //Error logging
                response.Message = ex.Message;
            }
            return response;
        }

        private void ProcessMessageRequest()
        {
            //For future use
            //Database functionality here
        }

        private ResponseDto<String> FetchMessage()
        {
            var response = new ResponseDto<String>() { ErrorMessage = "Failed to fetch message. "};
            try
            {
                if (_options.FetchFromDb)
                {
                    response.ErrorMessage = "Not implemented yet.";
                }
                else
                {
                    response.Dto = _options.DefaultMessage;
                    response.Success = true;
                }
            }
            catch(Exception ex)
            {
                //Error logging
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
