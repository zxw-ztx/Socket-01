namespace ClientProj
{
    partial class ClientForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ConnentBtn = new Button();
            SendText = new TextBox();
            IPName = new Label();
            IPText = new TextBox();
            PortText = new TextBox();
            PortName = new Label();
            SendBtn = new Button();
            MessageListText = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // ConnentBtn
            // 
            ConnentBtn.Location = new Point(425, 152);
            ConnentBtn.Name = "ConnentBtn";
            ConnentBtn.Size = new Size(94, 29);
            ConnentBtn.TabIndex = 0;
            ConnentBtn.Text = "连接";
            ConnentBtn.UseVisualStyleBackColor = true;
            ConnentBtn.Click += ConnentBtn_Click;
            // 
            // SendText
            // 
            SendText.Location = new Point(47, 362);
            SendText.Multiline = true;
            SendText.Name = "SendText";
            SendText.Size = new Size(270, 47);
            SendText.TabIndex = 3;
            // 
            // IPName
            // 
            IPName.AutoSize = true;
            IPName.Location = new Point(373, 39);
            IPName.Name = "IPName";
            IPName.Size = new Size(67, 20);
            IPName.TabIndex = 4;
            IPName.Text = "服务器IP";
            // 
            // IPText
            // 
            IPText.Location = new Point(485, 36);
            IPText.Name = "IPText";
            IPText.Size = new Size(125, 27);
            IPText.TabIndex = 5;
            IPText.Text = "127.0.0.1";
            // 
            // PortText
            // 
            PortText.Location = new Point(485, 88);
            PortText.Name = "PortText";
            PortText.Size = new Size(125, 27);
            PortText.TabIndex = 7;
            PortText.Text = "8080";
            // 
            // PortName
            // 
            PortName.AutoSize = true;
            PortName.Location = new Point(371, 95);
            PortName.Name = "PortName";
            PortName.Size = new Size(99, 20);
            PortName.TabIndex = 6;
            PortName.Text = "服务端端口号";
            // 
            // SendBtn
            // 
            SendBtn.Location = new Point(425, 360);
            SendBtn.Name = "SendBtn";
            SendBtn.Size = new Size(94, 29);
            SendBtn.TabIndex = 8;
            SendBtn.Text = "发送";
            SendBtn.UseVisualStyleBackColor = true;
            SendBtn.Click += SendBtn_Click;
            // 
            // MessageListText
            // 
            MessageListText.Location = new Point(44, 39);
            MessageListText.Multiline = true;
            MessageListText.Name = "MessageListText";
            MessageListText.Size = new Size(273, 282);
            MessageListText.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(44, 335);
            label1.Name = "label1";
            label1.Size = new Size(84, 20);
            label1.TabIndex = 10;
            label1.Text = "发送消息框";
            // 
            // ClientForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(640, 450);
            Controls.Add(label1);
            Controls.Add(MessageListText);
            Controls.Add(SendBtn);
            Controls.Add(PortText);
            Controls.Add(PortName);
            Controls.Add(IPText);
            Controls.Add(IPName);
            Controls.Add(SendText);
            Controls.Add(ConnentBtn);
            Name = "ClientForm";
            Text = "客户端";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button ConnentBtn;
        private TextBox textBox1;
        private Label label1;
        private TextBox SendText;
        private Label IPName;
        private TextBox IPText;
        private TextBox PortText;
        private Label PortName;
        private Button SendBtn;
        private TextBox MessageListText;
    }
}