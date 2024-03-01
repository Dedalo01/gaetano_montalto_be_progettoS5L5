-- Popola la tabella Anagrafica
INSERT INTO Anagrafica (Cognome, Nome, Indirizzo, Citta, CAP, Cod_Fisc)
VALUES 
    ('Rossi', 'Mario', 'Via Roma 123', 'Roma', '00100', 'RSSMRA80M01H501Z'),
    ('Bianchi', 'Laura', 'Corso Italia 456', 'Milano', '20100', 'LRA85L01H123X'),
    ('Verdi', 'Roberto', 'Viale Garibaldi 789', 'Napoli', '80100', 'VRDRRT78C01A456Y'),
    ('Ferrari', 'Anna', 'Largo Europa 234', 'Firenze', '50100', 'FRRNNA75D01F789Z'),
    ('Russo', 'Luigi', 'Piazza del Popolo 567', 'Bologna', '40100', 'RSSLGI70A01G012Y');

-- Popola la tabella TipoViolazione
INSERT INTO TipoViolazione (Descrizione)
VALUES 
    ('Eccesso di velocità'),
    ('Guida senza cintura'),
    ('Attraversamento vietato'),
    ('Semaforo rosso'),
    ('Telefono durante la guida');
