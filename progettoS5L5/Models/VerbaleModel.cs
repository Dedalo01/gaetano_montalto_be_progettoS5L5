namespace progettoS5L5.Models
{
    public class VerbaleModel
    {
        public int IdVerbale { get; set; }
        public DateTime DataViolazione { get; set; }
        public string IndirizzoViolazione { get; set; }
        public string Nominativo_Agente { get; set; }
        public DateTime DataTrascrizioneVerbale { get; set; }
        public double Importo { get; set; }
        public int DecurtamentoPunti { get; set; }
        public int AnagraficaId { get; set; }
        public int TipoViolazioneId { get; set; }
    }
}
