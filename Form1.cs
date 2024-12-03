using System.Net.Sockets;
using System.Net;

namespace PortSend
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button_Start_Click(object sender, EventArgs e)
        {
            try
            {
                
                LOCAL_HOST = "0.0.0.0";
                LOCAL_PORT = Convert.ToInt32(textBox2.Text);
                REMOTE_HOST = textBox3.Text;
                REMOTE_PORT = Convert.ToInt32(textBox4.Text);
                StartUdpForwarding();
                TcpListener listener = new TcpListener(IPAddress.Parse(LOCAL_HOST), LOCAL_PORT);
                listener.Start();
                Console.WriteLine($"[*] Listening on {LOCAL_HOST}:{LOCAL_PORT}");
                textBox5.Text += "开始....\r\n";
                while (true)
                {
                    TcpClient client = await listener.AcceptTcpClientAsync();
                    Console.WriteLine("[*] Accepted connection");
                    textBox5.Text += "接收到TCP连接....\r\n";
                    _ = HandleClientAsync(client);
                }
               
            }
            catch (Exception ex)
            {
                textBox5.Text += ex.ToString()+"\r\n";
            }
            
        }
        private string LOCAL_HOST = "127.0.0.1";
        private int LOCAL_PORT = 8080;
        private string REMOTE_HOST = "example.com";
        private int REMOTE_PORT = 80;

        //static async Task Main(string[] args)
        //{
        //    TcpListener listener = new TcpListener(IPAddress.Parse(LOCAL_HOST), LOCAL_PORT);
        //    listener.Start();
        //    Console.WriteLine($"[*] Listening on {LOCAL_HOST}:{LOCAL_PORT}");

        //    while (true)
        //    {
        //        TcpClient client = await listener.AcceptTcpClientAsync();
        //        Console.WriteLine("[*] Accepted connection");
        //        _ = HandleClientAsync(client);
        //    }
        //}

        private async Task HandleClientAsync(TcpClient client)
        {
            using (client)
            {
                using (TcpClient remoteClient = new TcpClient())
                {
                    await remoteClient.ConnectAsync(REMOTE_HOST, REMOTE_PORT);
                    Console.WriteLine("[*] Connected to remote server");

                    NetworkStream clientStream = client.GetStream();
                    NetworkStream remoteStream = remoteClient.GetStream();

                    var buffer = new byte[4096];
                    Task receivingFromClient = Task.Run(async () =>
                    {
                        while (true)
                        {
                            int bytesRead = await clientStream.ReadAsync(buffer, 0, buffer.Length);
                            if (bytesRead == 0) break;
                            await remoteStream.WriteAsync(buffer, 0, bytesRead);
                        }
                    });

                    Task receivingFromRemote = Task.Run(async () =>
                    {
                        while (true)
                        {
                            int bytesRead = await remoteStream.ReadAsync(buffer, 0, buffer.Length);
                            if (bytesRead == 0) break;
                            await clientStream.WriteAsync(buffer, 0, bytesRead);
                        }
                    });

                    await Task.WhenAny(receivingFromClient, receivingFromRemote);
                }
            }
        }

        private async Task StartUdpForwarding()
        {
            using (UdpClient udpListener = new UdpClient(LOCAL_PORT))
            {
                Console.WriteLine($"[*] Listening for UDP on {LOCAL_HOST}:{LOCAL_PORT}");
                IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Parse(REMOTE_HOST), REMOTE_PORT);

                while (true)
                {
                    // 使用 ReceiveAsync 方法接收数据
                    var receiveResult = await udpListener.ReceiveAsync();
                    Console.WriteLine("[*] Received UDP packet, forwarding it to remote");
                    textBox5.Text += "接收到UDP连接....\r\n";
                    // 将数据转发到远程端
                    await udpListener.SendAsync(receiveResult.Buffer, receiveResult.Buffer.Length, remoteEndPoint);
                }
            }
        }
    }
}
