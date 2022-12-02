import processing.net.*;

Server WoZServer;
PImage bg;
float xVal = 0;
float yVal = 0;

void setup() {
 
  bg = loadImage("cozychat.png");
  size(800, 800);
  background(bg);
  textSize(24);
  // Starts a WoZServer on port 8888
  WoZServer = new Server(this, 8888); 
}

void draw() {

}

void mousePressed() {
  background(bg);
  xVal=(float)mouseX/width;
  yVal=(float)mouseY/height;
  text(xVal+", "+yVal + " Pressed",20,20);
  WoZServer.write(xVal+","+yVal);
}

void mouseDragged() {
  background(bg);
  xVal=(float)mouseX/width;
  yVal=(float)mouseY/height;
  text(xVal+", "+yVal + " Dragged",20,20);
  WoZServer.write(xVal+","+yVal);
}

void mouseReleased() {
  background(bg);
  xVal=(float)mouseX/width;
  yVal=(float)mouseY/height;
  text(xVal+", "+yVal + " Released",20,20);
  WoZServer.write(xVal+","+yVal);
}
