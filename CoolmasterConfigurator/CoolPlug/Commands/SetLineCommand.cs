using System.Text;

namespace CoolmasterConfigurator.CoolPlug.Commands
{
    public class SetLineCommand : ICommand
    {
        public string L2Address { get; set; } = "0x55";
        public string Command => "line myid L2 " + L2Address;

        #region RESULT
        public bool Result { get; private set; } = false;
        #endregion

        #region PARSER
        private readonly TaskCompletionSource tcs = new TaskCompletionSource();
        private readonly StringBuilder reply = new StringBuilder();
        private bool recievedEnd = false;
        public void Parse(string message)
        {
            reply.Append(message);
            string fullReply = reply.ToString();

            if (fullReply.Contains("OK"))
            {
                recievedEnd = true;
                Result = true;
            }
                

            if (recievedEnd)
                tcs.TrySetResult();
        }

        public async Task WaitForCompletion(CancellationToken token = default)
        {
            await tcs.Task;
        }
        #endregion
    }
}