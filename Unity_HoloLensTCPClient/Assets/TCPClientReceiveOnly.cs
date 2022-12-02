using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using System.Net.Sockets;
public class TCPClientReceiveOnly
{

    TcpClient client;
    NetworkStream stream;
    private Task exchangeTask;
    private bool exchangeStopRequested = false;
    public string lastPacket = null;
    Byte[] bytes = new Byte[1024];

    public void Connect(string host, string port)
    {
        //   Task.Run(() => InitializeSocket(host, port));
        InitializeSocket(host, port);
    }

    void InitializeSocket(string host, string port)
    {
        try
        {
            client = new System.Net.Sockets.TcpClient(host, Int32.Parse(port));
            stream = client.GetStream();
            RestartExchange();
            //if(host!="localhost")
            //    await client.ConnectAsync(System.Net.IPAddress.Parse(host), Int32.Parse(port));
            //else
            //    await client.ConnectAsync("localhost", Int32.Parse(port));

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
            // Get a stream object for reading 				
            using (stream = client.GetStream())
            {
                int length;
                // Read incomming stream into byte arrary. 					
                while ((length = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    var incommingData = new byte[length];
                    Array.Copy(bytes, 0, incommingData, 0, length);
                    // Convert byte array to string message. 						
                    lastPacket = Encoding.ASCII.GetString(incommingData);
                    Debug.Log("server message received as: " + lastPacket);
                }
            }
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
