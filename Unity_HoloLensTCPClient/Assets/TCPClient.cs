using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;


public class TCPClient : MonoBehaviour
{
    public InputField ip_input;
    public InputField port_input;
    public Text consoleText;
    System.Net.Sockets.TcpClient client;
    System.Net.Sockets.NetworkStream stream;
    private Task exchangeTask;


    public void ConnectByUI()
    {
        ConnectUWP(ip_input.text, port_input.text);

    }

    public void Connect(string host, string port)
    {
        ConnectUWP(host, port);

    }


    private void ConnectUWP(string host, string port)
    {
        try
        {
            client = new System.Net.Sockets.TcpClient(host, Int32.Parse(port));
            stream = client.GetStream();
            RestartExchange();

        }
        catch (Exception e)
        {
            // do something
            Debug.Log(e.ToString());
        }
    }

    private bool exchangeStopRequested = false;
    private string lastPacket = null;



    public void RestartExchange()
    {

        if (exchangeTask != null) StopExchange();
        exchangeStopRequested = false;
        exchangeTask = Task.Run(() => ExchangePackets());

    }

    public void LateUpdate()
    {
        if (lastPacket != null)
        {
            //do something
            ShowData(lastPacket);
        }
    }

    public void ExchangePackets()
    {
        while (!exchangeStopRequested)
        {
            string received = null;
            byte[] bytes = new byte[client.ReceiveBufferSize];
            int recv = 0;
            while (true)
            {
                recv = stream.Read(bytes, 0, client.ReceiveBufferSize);
                received = Encoding.UTF8.GetString(bytes, 0, recv);
             //   received = reader.ReadLine();
                lastPacket = received;
            }
        }
    }

    private void ShowData(string data)
    {
        if (data == null)
        {
            consoleText.text = "Received a frame but data was null";
            return;
        }

        consoleText.text = data;
    }



    public void StopExchange()
    {
        exchangeStopRequested = true;


        if (exchangeTask != null)
        {
            exchangeTask.Wait();
            client.Dispose();
            exchangeTask = null;
        }
    }

    public void OnDestroy()
    {
        StopExchange();
    }

}