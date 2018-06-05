using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace HelloWorld.ConsoleApp
{
    class Program
    {
        static HttpClient client = new HttpClient();

        static void Main(string[] args)
        {
            // Update port # in the following line.
            client.BaseAddress = new Uri("http://localhost:52981/api/HelloWorld/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var response = GetMessage("http://localhost:52981/api/HelloWorld/");
                DisplayResults(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }

        static void DisplayResults(ResponseDto<string> response)
        {
            Console.WriteLine("Success: " + response.Success.ToString());
            Console.WriteLine("Payload: " + response.Dto ?? "Null");
            Console.WriteLine("Error Message: " + response.ErrorMessage ?? "Null");
            Console.WriteLine("Warning Message: " + response.Message ?? "Null");
            Console.WriteLine("Message: " + response.Message ?? "Null");
        }

        static ResponseDto<string> GetMessage(string path)
        {
            string result = string.Empty;
            var response = client.GetAsync(path).Result;
            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsStringAsync().Result;
            }
            return JsonConvert.DeserializeObject<ResponseDto<string>>(result);
        }
    }

    public class ResponseDto<T>
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public string WarningMessage { get; set; }
        public string Message { get; set; }
        public T Dto { get; set; }
    }
}
