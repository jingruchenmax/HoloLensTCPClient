using UnityEngine;
using Microsoft.MixedReality.Toolkit.Experimental.UI;
using TMPro;



public class TCPClientHololens : MonoBehaviour
{
    public MRTKTMPInputField ip_input;
    public MRTKTMPInputField port_input;
    public TextMeshProUGUI consoleText;
    TCPClientReceiveOnly tCPClientReceiveOnly;

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