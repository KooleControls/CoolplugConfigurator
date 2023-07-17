using System.Text;
using System.Text.RegularExpressions;

namespace CoolmasterConfigurator.CoolPlug.Commands
{
    public class GetLineCommand : ICommand
    {
        public string Command => "line";

        #region RESULT
        public LineResult Result { get; } = new LineResult();
        public class LineResult
        {
            public string? AddressL2 { get; set; }
            public bool IsValid()
            {
                return !string.IsNullOrWhiteSpace(AddressL2);
            }

        }
        #endregion

        #region PARSER
        private readonly TaskCompletionSource tcs = new TaskCompletionSource();
        private readonly StringBuilder reply = new StringBuilder();
        private bool recievedEnd = false;
        public void Parse(string message)
        {
            reply.Append(message);
            string fullReply = reply.ToString();
            Match match = Regex.Match(fullReply, "L2.+?Address:(0x..)");
            if (match.Success)
                Result.AddressL2 = match.Groups[1].Value;

            if (fullReply.Contains("OK"))
                recievedEnd = true;

            if (Result.IsValid() && recievedEnd)
                tcs.TrySetResult();
        }

        public async Task WaitForCompletion(CancellationToken token = default)
        {
            await tcs.Task;
        }
        #endregion
    }
}