const express = require('express') //modulo framework express utile per il lavoro serverside, per gestire richieste http
const helmet = require('helmet') //modulo per la sicurezza


const port = 8011
const app = express() //Istanza del server

app.use(helmet())
app.use(express.json())

//Quì metto le rotte
//app.use('/value', valueRouter) //quando vai su /position utilizzi i file di positionRouter


// Middleware per il parsing del corpo delle richieste
// app.use(bodyParser.json());
// app.use(bodyParser.urlencoded({ extended: true }));

// Rotta per il metodo GET
app.get('/', (req, res) => {
    // Qui puoi gestire la logica per elaborare la richiesta GET
    res.send('Risposta per la richiesta GET');
});

// Rotta per il metodo POST
app.post('/', (req, res) => {
    // Qui puoi gestire la logica per elaborare la richiesta POST
    const datiRicevuti = req.body;
    // Esempio di elaborazione: stampare i dati ricevuti
    console.log('Dati ricevuti:', datiRicevuti);
    res.send('Risposta per la richiesta POST');
});


// avvio il server
app.listen(port, () => {
    console.log(`Server avviato su http://localhost:${port}`)
 })