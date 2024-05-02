const mqtt = require('mqtt') //Protocollo

const express = require('express');
const bodyParser = require('body-parser');
const sqlite3 = require('sqlite3').verbose();
const helmet = require('helmet');
const path = require('path')
//MQTT
    // Connessione al broker MQTT
    const client  = mqtt.connect('mqtt://test.mosquitto.org')

    client.on('connect', function () {
        console.log("Connesso al broker MQTT");
        client.subscribe('iot2024/barbipanf/#');
    })

    client.on('error', function (error) {
    console.error('Errore durante la connessione al broker MQTT:', error);
    });

//DB
   // SQLite - Connessione al database
    // const db = new sqlite3.Database(':memory:'); // Usa un database in memoria
    const db = new sqlite3.Database(    
        path.join(
        __dirname, 
        '../db', 
        'db2.db'
    ))

    // Creazione dell'app Express
    const app = express();

    // Utilizzo di Helmet per aumentare la sicurezza dell'applicazione
    app.use(helmet());

    app.use(bodyParser.json());

    // Logica per la gestione dei messaggi ricevuti dal broker MQTT
    client.on('message', function (topic, messageJSON) {
        console.log('Messaggio ricevuto:');
        console.log('TOPIC: ' + topic);
    
        // Dividi la stringa in base al carattere '/'
        const parts = topic.split('/');
        // Ottieni l'ultima parola (ultimo elemento dell'array)
        const nameSensor = parts[parts.length - 1];
    
        // Converti il messaggio JSON in una stringa
        const stringaMessage = messageJSON.toString();
        // Rimuovi i paragrafi e gli apostrofi dalla stringa JSON
        const cleanMessage = stringaMessage.replace(/[\n\r'"{}]/g, '');
        console.log('MESSAGE: ' + cleanMessage + ' , SENSOR: ' + nameSensor);
    
        // Ottenere la data corrente
        const currentDate = new Date();
        // Formattazione della data nel formato desiderato (ad esempio, YYYY-MM-DD HH:MM:SS)
        const formattedDate = currentDate.toISOString().slice(0, 19).replace('T', ' ');
    
        // Inserimento del messaggio nel database SQLite
        db.run("INSERT INTO items (body, date, sensor) VALUES ($body, $date, $sensor)", {$body: cleanMessage, $date: formattedDate, $sensor: nameSensor}, function (err) {
            if (err) {
                console.error('Errore durante l\'inserimento del messaggio nel database:', err);
            } else {
                console.log('Messaggio e data inseriti nel database SQLite con successo');
            }
        });
    });
    

    // Avvio del server Express
    const port = 8011;
    app.listen(port, () => {
        console.log(`Server in ascolto sulla porta ${port}`);
    });


    

