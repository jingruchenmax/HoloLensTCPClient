const WebSocket = require('ws')
const wss=new WebSocket.Server({port:8080},()=>{
    console.log('server started')
})

wss.on('connection',(ws)=>{
    ws.send('connected!')
})

wss.on('listening',()=>{
    console.log('server is listening to 8080')
})