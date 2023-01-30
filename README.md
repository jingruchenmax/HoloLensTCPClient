# HoloLensTCPClient
 TCP socket connection between Hololens (client) to PC (server)


Quickest Server Mockup (Processing)
```
import processing.net.*;

Server WoZServer;

void setup() {
  size(800, 800);
  textSize(24);
  // Starts a WoZServer on port 8888
  WoZServer = new Server(this, 8888); 
}

void keyPressed() {
  WoZServer.write(key);
}

```
