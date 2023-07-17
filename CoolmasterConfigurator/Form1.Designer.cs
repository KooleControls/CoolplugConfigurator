namespace CoolmasterConfigurator
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            richTextBox1 = new RichTextBox();
            label2 = new Label();
            textBox3 = new TextBox();
            checkBox_debug = new CheckBox();
            checkBox_clearAfter = new CheckBox();
            SuspendLayout();
            // 
            // richTextBox1
            // 
            richTextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            richTextBox1.Location = new Point(12, 41);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(686, 397);
            richTextBox1.TabIndex = 2;
            richTextBox1.Text = "";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 15);
            label2.Name = "label2";
            label2.Size = new Size(105, 15);
            label2.TabIndex = 8;
            label2.Text = "L2 address to write";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(123, 12);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(100, 23);
            textBox3.TabIndex = 7;
            textBox3.Text = "0x01";
            // 
            // checkBox_debug
            // 
            checkBox_debug.AutoSize = true;
            checkBox_debug.Checked = true;
            checkBox_debug.CheckState = CheckState.Checked;
            checkBox_debug.Location = new Point(229, 14);
            checkBox_debug.Name = "checkBox_debug";
            checkBox_debug.Size = new Size(61, 19);
            checkBox_debug.TabIndex = 9;
            checkBox_debug.Text = "Debug";
            checkBox_debug.UseVisualStyleBackColor = true;
            checkBox_debug.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // checkBox_clearAfter
            // 
            checkBox_clearAfter.AutoSize = true;
            checkBox_clearAfter.Checked = true;
            checkBox_clearAfter.CheckState = CheckState.Checked;
            checkBox_clearAfter.Location = new Point(296, 14);
            checkBox_clearAfter.Name = "checkBox_clearAfter";
            checkBox_clearAfter.Size = new Size(131, 19);
            checkBox_clearAfter.TabIndex = 10;
            checkBox_clearAfter.Text = "Clear on disconnect";
            checkBox_clearAfter.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(710, 450);
            Controls.Add(checkBox_clearAfter);
            Controls.Add(checkBox_debug);
            Controls.Add(label2);
            Controls.Add(textBox3);
            Controls.Add(richTextBox1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private RichTextBox richTextBox1;
        private Label label2;
        private TextBox textBox3;
        private CheckBox checkBox_debug;
        private CheckBox checkBox_clearAfter;
    }
}