Ho realizzato una semplice applicazione client(C#) e server(Node.js) che, grazie al protocollo http si scambia un messaggio generato dal client, contenente il tipo di sensore, il valore generato random, e il datetime di quando è stato generato.
Ho realizzato il messaggio con questa struttura, per far si  che resti invariata nel caso decidessi di aggiungere altri tipi di sensore, in quanto creando la classe del sensore basterà creare un campo con scritto il tipo di sensore, che verrà aggiunto al messaggio nel metodo i creazione di quest'ultimo, qualunque sia il valore del del sensore, può essere inserito tranquillamente nel campo valore del messaggio, il datetime viene autogenerato.
il metodo di creazione del valore, e di invio è quindi sempre uguale, basterà solo creare una classe del nuovo sensore, fare il metodo per generare il valore.
Il server alla ricezione del messaggio, inserirà il valore dentro una tabella items in un db Sqlite.
All'avvio e alla chiusura del server viene gestita la connessione al db.
E' gestita inoltre la connessione e comunicazione tra client e server, dove in caso di errori vengono lanciate delle ecezioni che indicato l'errore riscontrato.

Feature future:
- In caso il client non riceva una risposta dal server indicato la corretta ricezione del messaggio, sarebbe utile implementare per esempio una coda FIFO dove i messaggi vengono man mano inseriti, nel mentre il client dovrebbe continuare a cercare di inviare per esempio un ping al server fin quando esso risponde correttamente, quando questo succede la coda si sblocca e invia al server i messaggi seguendo l'ordine di entrata di questi nella coda.
- Stessa cosa sarebbe da implementare nel caso il database non ricevesse i dati inviati dal server.
- Il Db potrebbe essere maggiormente suddiviso per tabelle in base al sensore, senza averne una sola dove vengono inseriti tutti i valori
- Si potrebe implementare un seriale che va maggiormente ad indicizzare i sensori nel caso ci vossere più sensori dello stesso tipo( es. due sensori temperatura, bisognerebbe sapere che temperatura misura uno e quale misura l'altro(Es. TempMotorOil, TempBrakeOil))