using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using Microsoft.MixedReality.Toolkit.Experimental.UI;
using TMPro;
using System.Threading.Tasks;


public class TCPClientHololens : MonoBehaviour
{
    public MRTKTMPInputField ip_input;
    public MRTKTMPInputField port_input;
    public TextMeshProUGUI consoleText;

    System.Net.Sockets.TcpClient client;
    System.Net.Sockets.NetworkStream stream;
    private Task exchangeTask;
    public int lastPacketToInt = -1;
    public void Start()
    {

    }

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
            // Do something
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

    public void Update()
    {
        if (lastPacket != null)
        {
            //do something
            ShowData(lastPacket);
            int.TryParse(lastPacket,out lastPacketToInt);
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
                Debug.Log(received);
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
        if (exchangeTask != null) {
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