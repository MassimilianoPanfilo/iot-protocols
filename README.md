# Corso protocolli di comunicazione IoT

Progetto gruppo Panfilo Massimiliano - Barbiero Matteo

I messaggi vengono inviati nel TOPIC: "iot2024/barbipan/“

Vengono inviati i messaggi di velocità(speed) e di posizione(position) nello stesso TOPIC ma con l'aggiunta di /sensor per differenziare da altri e vari TOPIC che potrebbero essere implementati, tutti e due i dati serializzati in json. I dati inviati e ricevuti dal server iscritto al broker vengono salvati poi in un DB(il quale salva differenziando ogni record con data e sensore/topic di provenienza)

Abbiamo ipotizzato che il retain flag possa servire per salvarsi i dati dell’ultima posizione, così se si accede da una pagina web si può ricreare la mappatura dell'auto anche se la pagina non era connessa all topic.

Lastwillmessage(da implementare) ci servirebbe per segnare quando si è disconnesso un device

Inoltre il flag keep alive(da implementare)puó esserci di aiuto per monitorare la comunicazione, mettendo un tempo in cui deve esserci uno scambio di messaggi monitorando se va tutto bene

Per l'invio di altri tipi di dati o comandi si possono creare altri TOPIC, ad esempio nel TOPIC "iot2024/barbipanf/comandi" si potrebbe inviare comandi relativi  allo sblocco delle serrature per poter far usare l'auto al cliente; se l'auto è prenotata invece non sarà possibile prenotarla da altri utenti.

Panfilo Massimiliano
Barbiero Matteo
