using System.IO.Ports;

namespace CoolmasterConfigurator.CoolPlug
{
    public class CoolPlugCom
    {
        public TextboxConsole? Console { get; set; } = null;
        private readonly SerialPort SerialPort = new SerialPort();
        public bool IsOpen => SerialPort.IsOpen;
        ICommand? currentCommand = null;

        public void Open(string com, int baud = 9600)
        {
            SerialPort.PortName = com;
            SerialPort.BaudRate = baud;
            SerialPort.Open();
            SerialPort.DataReceived += (s, e) => ReadData();
        }

        public void Close()
        {
            SerialPort.Close();
        }

        void SendData(string data)
        {
            Console?.AppendText(data, Color.FromArgb(unchecked((int)0xFF4287f5)));
            SerialPort.Write(data);
        }

        void ReadData()
        {
            try
            {
                string? data;
                while ((data = SerialPort.ReadLine()) != null)
                {
                    Console?.AppendText(data, Color.FromArgb(unchecked((int)0xFFFFFF00)));
                    currentCommand?.Parse(data);
                }
            }catch (Exception ex) { }
            
        }

        protected async Task Execute(ICommand command, CancellationToken token = default)
        {
            currentCommand = command;
            SendData(command.Command + "\r\n");
            await currentCommand.WaitForCompletion(token);

        }
    }
}