-- Popola la tabella Verbale
INSERT INTO Verbale (DataViolazione, IndirizzoViolazione, Nominativo_Agente, DataTrascrizioneVerbale, Importo, DecurtamentoPunti, AnagraficaId, TipoViolazioneId)
VALUES 
    ('2022-03-01T08:30:00', 'Via Nazionale 56', 'AGT001', '2022-03-01T12:00:00', 50.00, 3, 1, 3),
    ('2022-03-02T10:15:00', 'Corso Vittorio 78', 'AGT002', '2022-03-02T15:30:00', 75.50, 5, 2, 5),
    ('2022-03-03T14:45:00', 'Viale Trastevere 112', 'AGT003', '2022-03-03T18:20:00', 30.00, 2, 3, 3),
    ('2022-03-04T09:20:00', 'Lungotevere 34', 'AGT004', '2022-03-04T13:45:00', 40.25, 4, 4, 4),
    ('2022-03-05T12:00:00', 'Via della Repubblica 78', 'AGT005', '2022-03-05T16:30:00', 60.75, 6, 4, 2);
