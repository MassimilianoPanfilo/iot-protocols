 const express = require('express')
 const bodyParser = require('body-parser');

 const port = 8011
 const app = express()
app.use(bodyParser.json());// Middleware per gestire i dati in formato JSON

 //Quì metto le rotte
 // Definisci una rotta di base
app.get('/car', (req, res) => {
   res.send('Benvenuto!');
 });

// Rotta per gestire le richieste POST
app.post('/car', (req, res) => {
   const data = json.parse(data)
   // Stampiamo i dati ricevuti dalla richiesta POST sulla console
   console.log('Dati ricevuti:', data);
 
   // Inviamo una risposta al client
   res.send('Dati ricevuti correttamente!');
 });

 app.listen(port, () => {
    console.log(`Server avviato su http://localhost:$(port)`)
 })