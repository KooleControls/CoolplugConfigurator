namespace CoolmasterConfigurator
{
    public class TextboxConsole
    {
        public bool ShowTimestamp { get; set; } = true;
        private readonly RichTextBox richTextBox;
        public TextboxConsole(RichTextBox richTextBox)
        {
            this.richTextBox = richTextBox;
            richTextBox.ReadOnly = true;
            richTextBox.BackColor = Color.Black;
            richTextBox.Font = new Font("Consolas", 8.0f);
        }

        public void AppendText(string text, Color color)
        {
            richTextBox.InvokeIfRequired(() => {
                richTextBox.SelectionStart = richTextBox.TextLength;
                richTextBox.SelectionLength = 0;
                richTextBox.SelectionColor = color;
                richTextBox.AppendText(text);
                richTextBox.SelectionColor = richTextBox.ForeColor;
                richTextBox.SelectionStart = richTextBox.Text.Length;
                richTextBox.ScrollToCaret();
            });
            
        }
        public void AppendLine(string text, Color color)
        {
            if(ShowTimestamp)
                AppendText(DateTime.Now.ToString() + ": ", color);    
            AppendText(text + "\r\n", color);
        }


    }







}