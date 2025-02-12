
using System.Reflection.Metadata;

namespace S13L3
{
    public class Conto
    {
        public string? Nome {  get; set; }
        public string? Cognome { get; set; }
        public string? Residenza { get; set; }
        public int Saldo { get; set; }

        public void AperturaConto()
        {
            Console.WriteLine("Aprire un nuovo conto e versare 1000€ ?");
            string result = Console.ReadLine();
            if (result.ToLower() == "si")
            {
                Console.WriteLine("inserire Nome");
                Nome = Console.ReadLine().ToLower();
                Console.WriteLine("inserire Cognome");
                Cognome = Console.ReadLine().ToLower();
                Saldo = 1000;
                Console.WriteLine($"Saldo aperto, saldo attuale: {Saldo}€");
                UlterioriOperazioni();
            }
            else if(result.ToLower() == "no")
            {
                Console.WriteLine("peccato :(");
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("errore risposta non valida, si prega di rispondere SI o NO");
                AperturaConto();
            }
        }

        public void VersamentoConto()
        {
            Console.WriteLine("Quanto si desidera versare?");
            string? controlloVersamento = Console.ReadLine();
            if(int.TryParse(controlloVersamento, out int versamento))
            {
                Saldo += versamento;
                Console.WriteLine($"Aggiornamento saldo totale: {Saldo}€");
                UlterioriOperazioni();
            }
            else
            {
                Console.WriteLine("Risposta non valida, inserire solamente una cifra!");
                VersamentoConto();
            }
        }

        public void PrelievoConto()
        {
            Console.WriteLine("Quanti si desidera prelevare?");
            string? controlloPrelievo = Console.ReadLine();
            if (int.TryParse(controlloPrelievo, out int prelievo))
            {
                Saldo -= prelievo;
                if (Saldo > 0)
                {
                    Console.WriteLine($"Aggiornamento saldo totale: {Saldo}€");
                    UlterioriOperazioni();
                }
                else
                {
                    Console.WriteLine("Impossibile effetuare il prelievo, fondi non sufficienti");
                    UlterioriOperazioni();
                }
            }
            else
            {
                Console.WriteLine("Risposta non valida, inserire solamente una cifra!");
                PrelievoConto();
            }

        }

        public void UlterioriOperazioni()
        {
            bool erroreInput = false;
            do
            {
                erroreInput = false;
                Console.WriteLine("------------------");
                Console.WriteLine("Desidera eseguire ulteriori operazioni?");
                string ulterioreResult = Console.ReadLine();
                if (ulterioreResult.ToLower() == "si")
                {
                    Console.WriteLine("Inserire il numero dell'operazione da effettuare: ");
                    Console.WriteLine("1. Prelievo");
                    Console.WriteLine("2. Versamento");
                    Console.WriteLine("3. Controllo saldo");
                    string operazioneResult = Console.ReadLine();
                    Console.WriteLine("--------------------");
                    switch (operazioneResult)
                    {
                        case "1":
                            PrelievoConto();
                            break;
                        case "2":
                            VersamentoConto();
                            break;
                        case "3":
                            Console.WriteLine($"il saldo disponibile è pari a: {Saldo}€");
                            break;
                        default:
                            erroreInput = true;
                            Console.WriteLine("input non valido");
                            break;

                    }
                }
                else if (ulterioreResult.ToLower() == "no")
                {
                    Console.WriteLine("------------------");
                    Console.WriteLine("grazie e arrivederci :)");
                }
                else
                {
                    erroreInput = true;
                    Console.WriteLine("------------------");
                    Console.WriteLine("errore nella risposta, inserire SI per effettuare ulteriori operazioni, NO per concludere");
                }

            }
            while (erroreInput);
        }

    }
}
