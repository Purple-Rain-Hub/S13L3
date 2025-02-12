
namespace S13L3
{
    public class Numbers
    {
        Random rnd = new Random();
        public void NumbersInput()
        {
            Console.WriteLine("Quanti numeri vuoi generare? (massimo 99 numeri)");
            string arrayLength = Console.ReadLine();
            if (int.TryParse(arrayLength, out int num) && num <= 99)
            {
                int[] numbersArray = new int[num];
                int accumulatore = 0;
                for (int i = 0; i < num; i++) {
                int randomNumber = rnd.Next(1,99);
                    numbersArray[i] = randomNumber;
                }
                foreach (int number in numbersArray)
                {
                    Console.WriteLine(number);
                    accumulatore += number; 
                }
                Console.WriteLine();
                Console.WriteLine($"totale numeri array: {accumulatore}");
                Console.WriteLine($"media numeri array: {accumulatore/num}");
            }
            else
            {
                Console.WriteLine("errore nell'input, inserisci un numero valido tra 1 e 99");
                Console.WriteLine();
                NumbersInput();
            }
        }
    }
}
