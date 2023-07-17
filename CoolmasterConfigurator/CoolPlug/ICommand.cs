namespace CoolmasterConfigurator.CoolPlug
{
    public interface ICommand
    {
        public string Command { get; }
        void Parse(string message);
        Task WaitForCompletion(CancellationToken token = default);
    }
}