
namespace S13L3
{
    public class CercaNomi
    {
        string[] nomi = { "giulia", "marco", "sofia", "luca", "aurora", "matteo", "alice", "alessandro", "emma", "lorenzo", "greta", "simone", "martina", "andrea", "chiara", "gabriele", "ludovica", "riccardo", "vittoria", "tommaso" };

        public void Cerca()
        {
            Console.WriteLine("Quanti nomi vuoi generare? (massimo 20 nomi)");
            string arrayLength = Console.ReadLine();
            if (int.TryParse(arrayLength, out int num) && num<=20)
            {
                Array.Resize(ref nomi, num);
                Console.WriteLine();
                bool riprova = false;
                do
                {
                    riprova = false;
                    Console.WriteLine("Quale nome vuoi cercare?");
                    string nome = Console.ReadLine().ToLower();
                    if (nomi.Contains(nome))
                    {
                        Console.WriteLine();   
                        Console.WriteLine($"{nome} è presente nell'array");
                    }
                    else
                    {
                        Console.WriteLine($"{nome} non è presente nell'array, vuoi riprovare?");
                        string response = Console.ReadLine();
                        if (response.ToLower() == "si")
                        {
                            riprova = true;
                        }
                        else if (response.ToLower() == "no")
                        {
                            Console.WriteLine("grazie e arrivederci :)");
                        }
                        else Console.WriteLine("errore input");
                    }
                }
                while (riprova);
            }
            else
            {
                Console.WriteLine("input non valido, inserire un numero da 1 a 20");
                Console.WriteLine();
                Cerca();
            }
        }
    }
}
