using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerProj
{
    internal class ServerSocket
    {

        Socket welcomeSocket;
        //给到 ClientList
        List<Socket> clientSocketList = new List<Socket>();

        //涉及线程安全(两个线程池共同操作了一个成员),需添加互斥锁
        // 即以同步机制来确保一次只有一个线程使用该资源
        Mutex mutex = new Mutex();

        public bool CreateSocket(string IP, string Port, Action<string, int> ShowMsg)
        {
            // 1.实例
            if (welcomeSocket == null)
            {
                // 寻址方案.IPv4 - InterNetwork
                // 指定套接字类型.双向字节流 - Stream
                // 获取Socket协议类型.传输控制协议 - Tcp
                welcomeSocket = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream, ProtocolType.Tcp);


                // 2.本地端口绑定 ;直到连接成功或超时。
                // 限定寻址方案,传入IPv6时抛异常
                welcomeSocket.Bind(new IPEndPoint(IPAddress.Parse(IP), int.Parse(Port)));

                // 3.监听(未处理数量)
                // :转为被动的socket,面向连接,仅影响连接建立的瞬时峰值
                welcomeSocket.Listen(10);

                // 4.接收请求(不间歇)
                // 线程池 ThreadPool -- 同步回调与异步回调(防止阻塞)
                // .将方法排入队列(WaitCallback回调)
                ThreadPool.QueueUserWorkItem((a) =>
                {
                    int messageLength = 0;
                    while (true)
                    {
                        /// <summary>
                        ///   限制(明确)客户端连接
                        ///   打印 clientSocket信息
                        /// </summary>
                        /// <param name="clientSocket"></param>
                        // 连接成功后返回新Socket对象--独立通信通道 
                        Socket clientSocket = welcomeSocket.Accept();
                        // 端口号
                        // 为1判定==客户端信息;为2判定==收到的聊天信息
                        string clientInfo = clientSocket.RemoteEndPoint.ToString();
                        ShowMsg(clientInfo,1);

                        // 多客户端通信(统一管理)
                        // lock是同一进程内锁,自动释放
                        lock (mutex)
                        {
                            clientSocketList.Add(clientSocket);//添加到集合
                        }

                        // @线程池-阻塞式(等待)
                        ThreadPool.QueueUserWorkItem((a) =>
                        {
                            while (true)
                            {
                                //判断连接状态(最近操作)
                                if (!clientSocket.Connected)
                                {
                                    break;
                                }
                                // 5.收信息 -- 客户端字节数据 
                                byte[] buffer = new byte[1024];
                                //在关闭界面时会抛异常
                                try
                                {
                                    // Receive 阻塞,收到客户端消息继续运行代码
                                    //给到新对象,返回int32字节长度--Receive
                                    messageLength = clientSocket.Receive(buffer);
                                }
                                catch (Exception e)
                                {
                                    MessageBox.Show("异常:" + e.Message);
                                    break;
                                }
                                //将服务器收到的消息转换为字符串(需解码的字节数组,索引1,字节数)
                                //需传给UI,通过委托
                                string message = Encoding.UTF8.GetString(buffer, 0, messageLength);
                                ShowMsg(message,2);

                                // 6.发信息 -- 广播给所有客户端
                                lock (mutex)
                                {
                                    //:整理后的再赋值
                                    // buffer数据可能不足,sendMessage仅包含Receive处理的有效数据;
                                    byte[] sendMessage = new byte[messageLength];
                                    //将一个 Array 的一部分元素复制到另一个 Array 中，并根据需要执行类型转换和装箱。
                                    Array.Copy(buffer, sendMessage, messageLength);// ,,使用buffer.Length可能导致越界复制或数据污染

                                    // #广播给所有客户端(应答)
                                    clientSocketList.ForEach((socket) =>
                                        socket.Send(sendMessage)//将数据发送到连接的 Socket。
                                     );//遍历 
                                }
                            }////while-内
                        });
                    }//while-外
                });
                return true;
            }
            else
            {
                return false;
            }

        }//CreateSocket
    }//ServerSocket
}

