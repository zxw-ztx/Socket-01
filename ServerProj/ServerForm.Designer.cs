namespace ServerProj
{
    partial class ServerForm
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
            IPName = new Label();
            StartServer = new Button();
            IPText = new TextBox();
            PortText = new TextBox();
            PortName = new Label();
            MessageListText = new TextBox();
            ClientListText = new TextBox();
            SuspendLayout();
            // 
            // IPName
            // 
            IPName.AutoSize = true;
            IPName.Location = new Point(49, 50);
            IPName.Name = "IPName";
            IPName.Size = new Size(22, 20);
            IPName.TabIndex = 0;
            IPName.Text = "IP";
            // 
            // StartServer
            // 
            StartServer.Location = new Point(291, 407);
            StartServer.Name = "StartServer";
            StartServer.Size = new Size(94, 29);
            StartServer.TabIndex = 1;
            StartServer.Text = "启动服务器";
            StartServer.UseVisualStyleBackColor = true;
            StartServer.Click += StartServer_Click;
            // 
            // IPText
            // 
            IPText.Location = new Point(86, 47);
            IPText.Name = "IPText";
            IPText.Size = new Size(144, 27);
            IPText.TabIndex = 2;
            IPText.Text = "127.0.0.1";
            // 
            // PortText
            // 
            PortText.Location = new Point(444, 50);
            PortText.Name = "PortText";
            PortText.Size = new Size(141, 27);
            PortText.TabIndex = 4;
            PortText.Text = "8080";
            // 
            // PortName
            // 
            PortName.AutoSize = true;
            PortName.Location = new Point(388, 56);
            PortName.Name = "PortName";
            PortName.Size = new Size(39, 20);
            PortName.TabIndex = 3;
            PortName.Text = "端口";
            // 
            // MessageListText
            // 
            MessageListText.Location = new Point(49, 105);
            MessageListText.Multiline = true;
            MessageListText.Name = "MessageListText";
            MessageListText.Size = new Size(221, 280);
            MessageListText.TabIndex = 5;
            // 
            // ClientListText
            // 
            ClientListText.Location = new Point(380, 105);
            ClientListText.Multiline = true;
            ClientListText.Name = "ClientListText";
            ClientListText.Size = new Size(221, 280);
            ClientListText.TabIndex = 6;
            // 
            // ServerForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(722, 473);
            Controls.Add(ClientListText);
            Controls.Add(MessageListText);
            Controls.Add(PortText);
            Controls.Add(PortName);
            Controls.Add(IPText);
            Controls.Add(StartServer);
            Controls.Add(IPName);
            Name = "ServerForm";
            Text = "服务器端";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label IPName;
        private Button StartServer;
        private TextBox IPText;
        private TextBox PortText;
        private Label PortName;
        private TextBox MessageListText;
        private TextBox ClientListText;
    }
}