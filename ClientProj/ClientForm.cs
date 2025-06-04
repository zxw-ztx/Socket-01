using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientProj
{
    public partial class ClientForm : Form
    {
        ClientSocket clientSocket = new ClientSocket();
        public ClientForm()
        {
            InitializeComponent();
        }

        //连接-按钮
        private void ConnentBtn_Click(object sender, EventArgs e)
        {
            bool isConnent = clientSocket.CreateSocket(IPText.Text, PortText.Text, UIShow);//给到后端,string 
            if (!isConnent)
            {
                MessageBox.Show("已经连接成功");
            }
        }

        //发送-按钮
        private void SendBtn_Click(object sender, EventArgs e)
        {
            //未启动连接时,不能发送 

            //字符串接收 输入文本
            string message = SendText.Text;

            if (!string.IsNullOrEmpty(message))
            {
                //将文本编码为字节数组 
                byte[] data = Encoding.UTF8.GetBytes(message);
                //实际数据
                clientSocket.SendMessage(data);
                SendText.Text = "";//清除文本框
            }
            else if(string.IsNullOrEmpty(message))
            {
                MessageBox.Show("不能发送空消息");
            }
        }

        /// <summary>
        ///   客户端的委托
        /// </summary>
        /// <param name="msg"></param>
        public void UIShow(string msg)
        {
            //Invoke: Control / Delegate; 即控件/委托对象
            // 每次广播都可能触发客户端回应，
            this.Invoke(ShowMsg, msg);

        }
        public void ShowMsg(string msg)
        {
            // 消息框文本
            MessageListText.Text += msg + "\r\n";
        }

    }
}
