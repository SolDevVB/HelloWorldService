using HelloWorldService.Data;
using HelloWorldService.Filters;
using HelloWorldService.Logic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HelloWorldService.Controllers
{
    [Produces("application/json")]
    [Route("api/HelloWorld")]
    [ServiceFilter(typeof(LogRequest))]
    public class HelloWorldController : Controller
    {
        IHelloWorldLogic _logic;

        public HelloWorldController(IHelloWorldLogic logic)
        {
            _logic = logic;
        }

        // GET: api/HelloWorld        
        [HttpGet]
        public  ResponseDto<string> GetMessage()
        {
            return _logic.GetMessage();
        }


    }
}
