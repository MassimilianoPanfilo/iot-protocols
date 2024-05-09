const express = require('express');
const bodyParser = require('body-parser');
const sqlite3 = require('sqlite3').verbose();
const path = require('path');

const port = 8011;
const app = express();

// Middleware per gestire i dati in formato JSON
app.use(bodyParser.json());

// SQLite - Connessione al database
const dbPath = path.join(__dirname, 'db_http.db');
const db = new sqlite3.Database(dbPath, (err) => {
  if (err) {
    return console.error('Errore durante la connessione al database:', err.message);
  }
  console.log('Connessione al database SQLite riuscita');
});

// Rotta per gestire le richieste POST
app.post('/', (req, res) => {
  // Accedi ai dati inviati tramite la richiesta POST
  const data = req.body; // req.body contiene i dati inviati dal client
   
  // Stampiamo i dati ricevuti dalla richiesta POST sulla console
  console.log('Dati ricevuti:', data);

  // Inserimento dei dati nel database
  const { value, date } = data; // Supponiamo che i dati contengano campi 'field1' e 'field2'
  const insertQuery = `INSERT INTO items (value, date) VALUES (value, date)`;

  db.run(insertQuery, [value, date], function(err) {
    if (err) {
      console.error('Errore durante l\'inserimento dei dati nel database:', err.message);
      res.status(500).send('Errore durante l\'inserimento dei dati nel database');
    } else {
      console.log(`Dati inseriti correttamente nel database. ID inserimento: ${this.lastID}`);
      res.status(200).send('Dati ricevuti e inseriti correttamente nel database');
    }
  });
});

// Avvio del server Express
app.listen(port, () => {
  console.log(`Server avviato su http://localhost:${port}`);
});

// Chiudi la connessione al database quando hai finito di utilizzarlo
process.on('SIGINT', () => {
  db.close((err) => {
    if (err) {
      return console.error('Errore durante la chiusura del database:', err.message);
    }
    console.log('Connessione al database SQLite chiusa correttamente');
    process.exit(0);
  });
});