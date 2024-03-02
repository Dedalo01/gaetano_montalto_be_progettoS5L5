# COME POPOLARE IL DATABASE
## Per creare e popolare il database:
- creare nuovo database da SQL Server Management Studio 19
- cliccare su _nuova query_ in modo da selezionare il database appena creato
- andare nella cartella sql (da file explorer) ed cliccare due volte col mouse sul file `CreateAllTables.sql`:
   - Si aprirà in SSMS19 e dovrete semplicemente cliccare sul bottone _Esegui_
- Rifare lo stesso procedimento, questa volta con il file `PopulateDB.sql`
- Rifare un'ultima volta il procedimento, però con il file `PopulateVerbale.sql`

Se tutto funziona dovreste avere 3 tabelle: **Anagrafica**, **Verbale** e **TipoViolazione**, ognuna contenente 5 record.

N.B: Ricordatevi di cambiare i valori della connection string! O non partirà mai il progetto.

## Per inserire correttamente il verbale:
Siccome non ci sono i controlli, se volete avere successo nell'inserimento del verbale dovrete inserire i dati in questo modo nei punti critici:

### Anagrafica del Trasgressore
- CAP: vanno messe esattamente 5 caratteri
- Codice Fiscale: vanno messe esattamente 16 caratteri
### Dati per Verbale
- Data Violazione: inserire esattamente in questo formato: YYYY-MM-DD (es. 2024-03-02)
- Nominativo Agente: inserire esattamente 6 caratteri
- Importo: Inserire cifre intere o con virgola, ma la virgola deve essere indicata dal carattere punto "." e non dal carattere ","
- Decurtamento punti: inserire un numero intero
