const express = require('express') //modulo framework express utile per il lavoro serverside, per gestire richieste http
const helmet = require('helmet') //modulo per la sicurezza


const port = 8011
const app = express() //Istanza del server

app.use(helmet())
app.use(express.json())

//Quì metto le rotte
//app.use('/value', valueRouter) //quando vai su /position utilizzi i file di positionRouter



// Rotta per il metodo GET
app.get('/', (req, res) => {
    // Qui puoi gestire la logica per elaborare la richiesta GET
    res.send('Risposta per la richiesta GET');
});

// Rotta per il metodo POST
app.post('/', (req, res) => {
    console.log('Body della richiesta:', req.body);
    const datiRicevuti = req.body["Data sent"];
    console.log('Dati ricevuti:', datiRicevuti);
    res.json({ message: 'Dati ricevuti correttamente', data: datiRicevuti });
});




// avvio il server
app.listen(port, () => {
    console.log(`Server avviato su http://localhost:${port}`)
 })