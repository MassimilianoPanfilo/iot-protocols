const express = require('express') //modulo framework express utile per il lavoro serverside, per gestire richieste http
const helmet = require('helmet') //modulo per la sicurezza
const mongoose = require('mongoose');

const port = 8011
const app = express() //Istanza del server
const mongoURI = 'mongodb://localhost:27017/db_IoT_Protocols';// URL di connessione al database MongoDB

app.use(helmet())
app.use(express.json())

// Connessione al database
mongoose.connect(mongoURI, { useNewUrlParser: true, useUnifiedTopology: true })
    .then(() => console.log('Connessione al database MongoDB avvenuta con successo'))
    .catch(err => console.error('Errore durante la connessione al database', err));
/*
* Continua
*/

    //Quì metto le rotte
// Rotta per il metodo GET
app.get('/', (req, res) => {
    // Qui puoi gestire la logica per elaborare la richiesta GET
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