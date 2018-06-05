using HelloWorldService.Data;
using System;

namespace HelloWorldService.Logic
{
    public interface IHelloWorldLogic
    {
        ResponseDto<String> GetMessage();
    }
}
