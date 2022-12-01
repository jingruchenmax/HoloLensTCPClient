using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
public class TCPClientReceiveOnly
{

    System.Net.Sockets.TcpClient client;
    System.Net.Sockets.NetworkStream stream;
    private Task exchangeTask;
    private bool exchangeStopRequested = false;
    public string lastPacket = null;


    public void Connect(string host, string port)
    {
        Task.Run(() => InitializeSocket(host, port));
    }

    private async Task InitializeSocket(string host, string port)
    {
        try
        {
            client = new System.Net.Sockets.TcpClient(host, Int32.Parse(port));
            stream = client.GetStream();
            RestartExchange();
            await client.ConnectAsync(System.Net.IPAddress.Parse(host), Int32.Parse(port));
            
        }
        catch (Exception e)
        {
            lastPacket = e.ToString();
        }
    }


    public void RestartExchange()
    {
        if (exchangeTask != null) StopExchange();
        exchangeStopRequested = false;
        exchangeTask = Task.Run(() => ReceivePackets());
    }

    public void ReceivePackets()
    {
        byte[] bytes = new byte[client.ReceiveBufferSize];
        while (!exchangeStopRequested)
        {
            int recv = 0;
            recv = stream.Read(bytes, 0, client.ReceiveBufferSize);
            lastPacket = Encoding.UTF8.GetString(bytes, 0, recv);
        }
    }

    public void StopExchange()
    {
        exchangeStopRequested = true;
        // stop the read task 
        if (exchangeTask != null)
        {
            stream.Close();
            client.Close();
            exchangeTask = null;
        }
    }
}
