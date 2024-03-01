# COME POPOLARE IL DATABASE
Per creare e popolare il database:
- creare nuovo database da SQL Server Management Studio 19
- cliccare su _nuova query_ in modo da selezionare il database appena creato
- andare nella cartella sql (da file explorer) ed cliccare due volte col mouse sul file `CreateAllTables.sql`:
   - Si aprirà in SSMS19 e dovrete semplicemente cliccare sul bottone _Esegui_
- Rifare lo stesso procedimento, questa volta con il file `PopulateDB.sql`
- Rifare un'ultima volta il procedimento, però con il file `PopulateVerbale.sql`

Se tutto funziona dovreste avere 3 tabelle: **Anagrafica**, **Verbale** e **TipoViolazione**, ognuna contenente 5 record.

N.B: Ricordati di cambiare i valori della connection string! O non partirà mai il progetto.
