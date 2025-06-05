using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerProj
{
    public partial class ServerForm : Form
    {
        ServerSocket serverSocket = new ServerSocket();//后端实例
        public ServerForm()
        {
            InitializeComponent();
        }

        //启动服务器
        private void StartServer_Click(object sender, EventArgs e)
        {
            //调用
            bool isStart = serverSocket.CreateSocket(IPText.Text, PortText.Text, UIShow);
            if (isStart)
            {
                ClientListText.Text = "启动了服务器: "+"\r\n";
                // TCP/IP协议栈会自动为客户端随机分配临时端口号,
            }
            else
            {
                MessageBox.Show("已经启动了服务器");
            }
        }

        /// <summary>
        ///   服务器的委托
        /// </summary>
        /// <param name="msg"></param>
        public void UIShow(string msg, int v)
        {
            //Invoke: Control / Delegate; 即控件/委托对象
            this.Invoke(ShowMsg, msg, v);// 将ShowMsg委托到UI线程执行,ShowMsg(message);
            // 服务端广播后,客户端收到消息会再次发送(三次握手),导致服务端再次触发 Receive.
            // 每次广播都可能触发客户端回应，
        }
        public void ShowMsg(string msg, int v)
        {
            if (v == 1)
            {
                //客户端信息
                ClientListText.Text += msg + "\r\n";
            }
            else if (v == 2)
            {
                //收到的信息
                MessageListText.Text+= msg + "\r\n";
            }
        }

    }
}
