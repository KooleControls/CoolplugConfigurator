using CoolmasterConfigurator.CoolPlug.Commands;
using static CoolmasterConfigurator.CoolPlug.Commands.GetLineCommand;

namespace CoolmasterConfigurator.CoolPlug
{
    public class CoolPlugDevice : CoolPlugCom
    {

        public async Task<LineResult> GetLine(CancellationToken token = default)
        {
            GetLineCommand command = new GetLineCommand();
            await Execute(command);
            return command.Result;
        }

        public async Task<bool> SetLine(string L2Address, CancellationToken token = default)
        {
            SetLineCommand command = new SetLineCommand();
            command.L2Address = L2Address;
            await Execute(command);
            return command.Result;
        }
    }







}