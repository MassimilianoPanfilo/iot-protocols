    // const express = require('express');
    // const bodyParser = require('body-parser');
    // const mongoose = require('mongoose');
    // const helmet = require('helmet'); // Aggiunta del pacchetto Helmet

    // // Connessione al database MongoDB
    // mongoose.connect('mongodb://localhost:27017/iot_protocols');
    // const db = mongoose.connection;
    // db.on('error', console.error.bind(console, 'Errore nella connessione al database:'));
    // db.once('open', () => {
    //   console.log('Connesso al database');
    // });

    // // Definizione dello schema del documento
    // const Schema = mongoose.Schema;
    // const itemSchema = new Schema({
    //     body: String
    //     //date: Date,
    //     // speedValue: Number,
    //     // positionValue: String
    //   });

    // // Creazione del modello dallo schema
    // const Item = mongoose.model('Item', itemSchema);

    // // Creazione dell'app Express
    // const app = express();

    // // Utilizzo di Helmet per aumentare la sicurezza dell'applicazione
    // app.use(helmet());

    // app.use(bodyParser.json());

    // // Endpoint per ottenere tutti gli elementi
    // app.get('/items', async (req, res) => {
    //   try {
    //     const items = await Item.find();
    //     res.json(items);
    //   } catch (err) {
    //     res.status(500).json({ message: err.message });
    //   }
    // });

    // // Endpoint per creare un nuovo elemento
    // app.post('/items/post', async (req, res) => {
    //   const item = new Item({
    //     body: req.body.body
    //     //date: req.body.date,
    //     // positionSpeed: req.body.positionSpeed,
    //     // positionValue: req.body.positionValue
        
    //   });

    //   try {
    //     const newItem = await item.save();
    //     res.status(201).json(newItem);
    //   } catch (err) {
    //     res.status(400).json({ message: err.message });
    //   }
    // });

    // // Endpoint per eliminare un elemento
    // app.delete('/items/delete/:id', async (req, res) => {
    //   try {
    //     await Item.findByIdAndDelete(req.params.id);
    //     res.status(204).send();
    //   } catch (err) {
    //     res.status(500).json({ message: err.message });
    //   }
    // });

    // // Avvio del server
    // const port = 8011;
    // app.listen(port, () => {
    //   console.log(`Server in ascolto sulla porta ${port}`);
    // });