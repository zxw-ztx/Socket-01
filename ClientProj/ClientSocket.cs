using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientProj
{
    internal class ClientSocket
    {
        Socket clientSocket;
        public bool CreateSocket(string IP, string Port,Action<string> ShowMsg)
        {
            //(只能连接一次)
            if (clientSocket == null)
            {
                //:新建--实例 (Socket相关设置)
                clientSocket = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream, ProtocolType.Tcp);
                //:解析IP,端口;;直到连接成功或超时。
                clientSocket.Connect(new IPEndPoint
                    (IPAddress.Parse(IP), int.Parse(Port)));

                //:收消息(阻塞,不停止)
                ThreadPool.QueueUserWorkItem((a) =>
                {
                    //线程中循环收消息
                    while (true)
                    {
                        //字节数组
                        byte[] buffer = new byte[1024];
                        //返回值: >0(实际字节) =0(连接断开) 异常
                        int dataLength = clientSocket.Receive(buffer);//返回实际接收的字节数
                        string message = Encoding.UTF8.GetString(buffer,0,dataLength);
                        ShowMsg(message);//客户端传给UI

                    }

                });
                return true;
            }
            else
            {
                return false;

            }
            //客户端的连接限制
        }

        //发送时
        public void SendMessage(byte[] message)
        {
            //字节传入--将数据发送到连接的 Socket=>即消息界面。
            clientSocket.Send(message);
        }
    }
}
