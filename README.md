I programm simula l'aquisizione di dati da sensori virtuali. I dati vengono serializzati in formato JSON e inviati a un server di messaggistica utilizzando il protocollo AMQP comunicante con il server RabbitMQ.
Questa connessione viene mantenuta aperta per l'invio di tutti i messaggi durante l'esecuzione del programma.
Prima di inviare messaggi, verifica l'esistenza della coda specificata e, se necessario, la crea. Questo assicura che i messaggi non vengano persi se la coda non esiste ancora.
