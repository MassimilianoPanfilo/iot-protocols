I programm simula l'aquisizione di dati da sensori virtuali. I dati vengono inviati a un server utilizzando il protocollo AMQP comunicante con un Broker RabbitMQ.
Questa connessione viene mantenuta aperta per l'invio di tutti i messaggi durante l'esecuzione del programma.
Prima di inviare messaggi, verifica l'esistenza della coda specificata e, se necessario, la crea. Questo assicura che i messaggi non vengano persi se la coda non esiste ancora.
