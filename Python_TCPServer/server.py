from random import Random, random
import time
import socket
import random

s = socket.socket()

port = 8888

s.bind(('', port))

s.listen(5)

while True:
    c, addr = s.accept()
    print("Got connect from", addr)
    while True:
        msg = (str(random.uniform(0.0,1.0)) + "," + str(random.uniform(0.0,1.0)))
        print(msg)
        c.send(msg.encode())
        time.sleep(0.1)