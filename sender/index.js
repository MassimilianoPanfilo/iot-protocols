 const express = require(express)

 const port = 3100
 const app = express()

 //Quì metto le rotte

 app.listen(port, () => {
    console.log(`Server avviato su http://localhost:$(port)`)
 })