namespace HelloWorldService.Repositories
{
    public interface IHelloWorldRepo
    {
        string FetchMessage();

        void ProcessMessageRequest();

    }
}
