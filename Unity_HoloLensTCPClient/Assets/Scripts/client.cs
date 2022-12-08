using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;

public class client : MonoBehaviour
{
    WebSocket ws;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("CLIENT STARTED");
        ws = new WebSocket("ws://localhost://8888");
        //Debug.Log(ws.ReadyState);
        ws.Connect();
        Debug.Log(ws.ReadyState);
        ws.OnOpen += (sender, e) =>
        {
            Debug.Log("opennnnn");
        };
        ws.OnMessage += (sender, e) =>
        {
            Debug.Log("Message recieved from " + ((WebSocket)sender).Url + ", Data : " + e.Data);
            if (e.Data != null)
            {
            }
        };
    }

    // Update is called once per frame
    void Update()
    {
        if (ws == null)
        {
            Debug.Log("ws is null");
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("space is pressed");
            ws.Send("HELLO WORLD");
        }
    }
}
