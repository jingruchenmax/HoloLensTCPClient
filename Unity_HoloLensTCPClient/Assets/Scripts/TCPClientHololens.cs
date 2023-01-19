using UnityEngine;
using Microsoft.MixedReality.Toolkit.Experimental.UI;
using TMPro;
using UnityEngine.Events;


public class TCPClientHololens : MonoBehaviour
{
    public MRTKTMPInputField ip_input;
    public MRTKTMPInputField port_input;
    public TextMeshProUGUI consoleText;
    public TCPClientReceiveOnly tCPClientReceiveOnly;
    public UnityEvent onMessageReceived;
    public Vector2 message;
    private void Start()
    {
        tCPClientReceiveOnly = new TCPClientReceiveOnly();
    }

    public void StartConnect()
    {        
        tCPClientReceiveOnly.Connect(ip_input.text, port_input.text);      
    }


    public void Update()
    {
        if (tCPClientReceiveOnly.lastPacket != null)
        {
            //do something
            ShowData(tCPClientReceiveOnly.lastPacket);
            //validate message
            if (tCPClientReceiveOnly.lastPacket.Contains(","))
            {
                string[] temp = tCPClientReceiveOnly.lastPacket.Substring(1, tCPClientReceiveOnly.lastPacket.Length - 1).Split(',');
                float.TryParse(temp[temp.Length - 2], out message.x);
                float.TryParse(temp[temp.Length - 1], out message.y);
                onMessageReceived.Invoke();
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

    public void CloseConnect()
    {
        tCPClientReceiveOnly.StopExchange();
    }

    public void OnDestroy()
    {
        CloseConnect();
    }

}