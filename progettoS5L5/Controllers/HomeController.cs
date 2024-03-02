using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using progettoS5L5.Models;
using System.Diagnostics;

namespace progettoS5L5.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            string selectViolazioniQuery = "SELECT * FROM TipoViolazione";
            string selectTrasgressoriQuery = "SELECT * FROM Anagrafica";

            List<TipoViolazioneModel> violazioni = new List<TipoViolazioneModel>();
            List<AnagraficaModel> anagrafiche = new List<AnagraficaModel>();
            AnagraficheViolazioniModel listeContainer = new AnagraficheViolazioniModel();

            try
            {
                DB.conn.Open();

                SqlCommand selectViolazioniCmd = new SqlCommand(selectViolazioniQuery, DB.conn);
                SqlCommand selectTrasgressoriCmd = new SqlCommand(selectTrasgressoriQuery, DB.conn);

                // ciclo tabella violazioni
                SqlDataReader tableTipoViolazioniReader = selectViolazioniCmd.ExecuteReader();
                if (tableTipoViolazioniReader.HasRows)
                {
                    while (tableTipoViolazioniReader.Read())
                    {
                        TipoViolazioneModel violazione = new TipoViolazioneModel()
                        {
                            IdViolazione = (int)tableTipoViolazioniReader["IdViolazione"],
                            Descrizione = tableTipoViolazioniReader["Descrizione"].ToString(),
                        };

                        violazioni.Add(violazione);
                    }
                }

                tableTipoViolazioniReader.Close();

                // ciclo tabella anagrafica
                SqlDataReader tableAnagraficaReader = selectTrasgressoriCmd.ExecuteReader();
                if (tableAnagraficaReader.HasRows)
                {
                    while (tableAnagraficaReader.Read())
                    {
                        AnagraficaModel anagrafica = new AnagraficaModel()
                        {
                            IdAnagrafica = (int)tableAnagraficaReader["IdAnagrafica"],
                            Cognome = tableAnagraficaReader["Cognome"].ToString(),
                            Nome = tableAnagraficaReader["Nome"].ToString(),
                            Indirizzo = tableAnagraficaReader["Indirizzo"].ToString(),
                            Citta = tableAnagraficaReader["Citta"].ToString(),
                            CAP = tableAnagraficaReader["CAP"].ToString(),
                            Cod_Fisc = tableAnagraficaReader["Cod_Fisc"].ToString(),
                        };

                        anagrafiche.Add(anagrafica);
                    }
                }
                tableAnagraficaReader.Close();

                listeContainer.Violazioni = violazioni;
                listeContainer.Anagrafiche = anagrafiche;

            }
            catch (Exception ex) { }
            finally { DB.conn.Close(); }
            return View(listeContainer);
        }

        [HttpPost]
        public IActionResult Index(int violazioneId, string cognome, string nome, string indirizzo, string citta, string cap, string cf,
            string dataV, string indirizzoV, string nominativoV, string dataTV, double importo, int punti
            )
        {
            try
            {
                DB.conn.Open();

                string insertAnagraficaInDbQuery = @"INSERT INTO Anagrafica (Cognome, Nome, Indirizzo, Citta, CAP, Cod_Fisc)
                    VALUES (@cognome, @nome, @indirizzo, @citta, @cap, @cf); SELECT SCOPE_IDENTITY();
                        ";

                SqlCommand insertAnagraficaInDbCmd = new SqlCommand(insertAnagraficaInDbQuery, DB.conn);
                insertAnagraficaInDbCmd.Parameters.AddWithValue("cognome", cognome);
                insertAnagraficaInDbCmd.Parameters.AddWithValue("nome", nome);
                insertAnagraficaInDbCmd.Parameters.AddWithValue("indirizzo", indirizzo);
                insertAnagraficaInDbCmd.Parameters.AddWithValue("citta", citta);
                insertAnagraficaInDbCmd.Parameters.AddWithValue("cap", cap);
                insertAnagraficaInDbCmd.Parameters.AddWithValue("cf", cf);

                int actualAnagraficaId = Convert.ToInt32(insertAnagraficaInDbCmd.ExecuteScalar());

                string insertVerbaleInDbQuery = @"INSERT INTO Verbale (DataViolazione, IndirizzoViolazione, Nominativo_Agente, DataTrascrizioneVerbale, Importo, DecurtamentoPunti, AnagraficaId, TipoViolazioneId)
                       VALUES (@dataV, @indirizzoV, @nominativo, @dataVerb, @importo, @decurtamento, @anaId, @tipoV)
                    ";

                SqlCommand insertVerbaleInDbCmd = new SqlCommand(insertVerbaleInDbQuery, DB.conn);
                insertVerbaleInDbCmd.Parameters.AddWithValue("dataV", dataV + " 00:00:00");
                insertVerbaleInDbCmd.Parameters.AddWithValue("indirizzoV", indirizzoV);
                insertVerbaleInDbCmd.Parameters.AddWithValue("nominativo", nominativoV);
                insertVerbaleInDbCmd.Parameters.AddWithValue("dataVerb", dataTV + " 00:00:00");
                insertVerbaleInDbCmd.Parameters.AddWithValue("importo", importo);
                insertVerbaleInDbCmd.Parameters.AddWithValue("decurtamento", punti);
                insertVerbaleInDbCmd.Parameters.AddWithValue("anaId", actualAnagraficaId);
                insertVerbaleInDbCmd.Parameters.AddWithValue("tipoV", violazioneId);

                int rowsAffected = insertVerbaleInDbCmd.ExecuteNonQuery();

            }

            // TODO eseguila, poi fai una select per prendere l'id appena salvato per immetterlo nel verbale! FATTO IN ACTUALANAGRAID

            catch (Exception ex) { }
            finally { DB.conn.Close(); }

            TempData["addSuccess"] = "L'inserimento del verbale è riuscito.";
            return RedirectToAction("Index");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
