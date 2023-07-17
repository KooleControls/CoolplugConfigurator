using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Windows.Forms;
using CoolmasterConfigurator.CoolPlug;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CoolmasterConfigurator
{
    public partial class Form1 : Form
    {
        private readonly CoolPlugDevice coolPlug;
        private readonly TextboxConsole textboxConsole;
        private readonly BindingList<string> ports = new BindingList<string>();
        public Form1()
        {
            InitializeComponent();
            textboxConsole = new TextboxConsole(richTextBox1);
            coolPlug = new CoolPlugDevice();
            //comboBox1.DataSource = ports;
            RefreshComPorts();
            if (checkBox_debug.Checked)
                coolPlug.Console = textboxConsole;
        }
        public void RefreshComPorts()
        {
            ports.Clear();
            foreach (var port in SerialPort.GetPortNames())
                ports.Add(port);
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 537: //WM_DEVICECHANGE
                    ComChanged().Wait();
                    break;
            }
            base.WndProc(ref m);

        }

        async Task ComChanged()
        {
            List<string> newList = SerialPort.GetPortNames().ToList();
            var diff√dded = newList.Except(ports);
            var diffRemoved = ports.Except(newList);
            var portAdded = diff√dded.FirstOrDefault();
            var portRemoved = diffRemoved.FirstOrDefault();

            RefreshComPorts();

            if (portAdded != null)
            {
                textboxConsole.AppendLine($"{portAdded} detected!", Color.FromArgb(unchecked((int)0xFFf542f5)));
                Start(portAdded);
            }

            if (portRemoved != null)
            {
                textboxConsole.AppendLine($"{portRemoved} disconnected!", Color.FromArgb(unchecked((int)0xFFf542f5)));
                if (checkBox_clearAfter.Checked)
                    richTextBox1.Text = "";
            }

        }

        async Task Start(string com)
        {
            if (coolPlug.IsOpen)
                coolPlug.Close();
            coolPlug.Open(com);
            textboxConsole.AppendLine($"Read line information at {com}", Color.White);
            var getLine = await coolPlug.GetLine();
            textboxConsole.AppendLine($"Reading line, L2 Address = {getLine.AddressL2}", Color.White);

            if (getLine.AddressL2 != textBox3.Text)
            {
                textboxConsole.AppendLine($"Write line, L2 Address {textBox3.Text}", Color.Red);
                await coolPlug.SetLine(textBox3.Text);
            }
            else
                textboxConsole.AppendLine($"Address matches {textBox3.Text}, no write required", Color.White);
            coolPlug.Close();
            textboxConsole.AppendLine($"Done {textBox3.Text}", Color.FromArgb(unchecked((int)0xFF1FFF53)));
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_debug.Checked)
                coolPlug.Console = textboxConsole;
            else
                coolPlug.Console = null;
        }
    }
}