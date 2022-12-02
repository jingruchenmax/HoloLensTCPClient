using UnityEngine;
using UnityEngine.UI;


public class TCPClient : MonoBehaviour
{
    public InputField ip_input;
    public InputField port_input;
    public Text consoleText;

    TCPClientReceiveOnly tCPClientReceiveOnly;
    private void Start()
    {
        tCPClientReceiveOnly = new TCPClientReceiveOnly();
    }
    public void StartConnect()
    {
        tCPClientReceiveOnly.Connect(ip_input.text, port_input.text);

    }



    public void LateUpdate()
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



    public void OnDestroy()
    {
        tCPClientReceiveOnly.StopExchange();
    }

}