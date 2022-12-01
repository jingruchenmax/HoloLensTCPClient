import processing.net.*;

Server WoZServer;
float xVal = 0;
float yVal = 0;

void setup() {
  size(800, 600);
  background(0);
  textSize(24);
  // Starts a WoZServer on port 8888
  WoZServer = new Server(this, 8888); 
}

void draw() {

}

void mousePressed() {
  background(0);
  xVal=(float)mouseX/width;
  yVal=(float)mouseY/height;
  text(xVal+", "+yVal,20,20);
  WoZServer.write(xVal+","+yVal);
}
