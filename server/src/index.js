const express = require('express') //modulo framework express utile per il lavoro serverside, per gestire richieste http
const helmet = require('helmet') //modulo per la sicurezza


const port = 8011
const app = express() //Istanza del server


app.use(helmet())
app.use(express.json())


//Quì metto le rotte
// Rotta per il metodo GET
app.get('/', (req, res) => {
    res.send('Risposta per la richiesta GET');
});

// Rotta per il metodo POST
app.post('/', (req, res) => {
    console.log('Dati ricevuti:', req.body);
    res.json({ message: 'Dati ricevuti correttamente', data: req.body });
});

// avvio il server
app.listen(port, () => {
    console.log(`Server avviato su http://localhost:${port}`)
 })