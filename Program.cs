namespace Hangman
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random((int)DateTime.Now.Ticks);

            string[] s6naPank = { "Tallinn", "Tartu", "Pärnu", "Narva", "Jõgeva", "Elva" };

            string arvatavS6na = s6naPank[random.Next(0, s6naPank.Length)];
            string arvatavS6naUppercase = arvatavS6na.ToUpper();

            StringBuilder n2itaM2ngijale = new StringBuilder(arvatavS6na.Length);
            for (int i = 0; i < arvatavS6na.Length; i++)
                n2itaM2ngijale.Append('_');

            List<char> oigedArvamised = new List<char>();
            List<char> valedArvamised = new List<char>();

            int lives = 5;
            bool won = false;
            int lettersRevealed = 0;

            string input;
            char guess;

            while (!won && lives > 0)
            {
                Console.Write("Arvuti on valinud ühe sõna, arva see tähthaaval ära vähem kui 5 eksimusega: ");

                input = Console.ReadLine().ToUpper();
                guess = input[0];

                if (oigedArvamised.Contains(guess))
                {
                    Console.WriteLine("Täht '{0}' on juba sisestatud ja see on olemas!", guess);
                    continue;
                }
                else if (valedArvamised.Contains(guess))
                {
                    Console.WriteLine("Täht '{0}'on juba sisestatud ja see puudub!", guess);
                    continue;
                }

                if (arvatavS6naUppercase.Contains(guess))
                {
                    oigedArvamised.Add(guess);

                    for (int i = 0; i < arvatavS6na.Length; i++)
                    {
                        if (arvatavS6naUppercase[i] == guess)
                        {
                            n2itaM2ngijale[i] = arvatavS6na[i];
                            lettersRevealed++;
                        }
                    }

                    if (lettersRevealed == arvatavS6na.Length)
                        won = true;
                }
                else
                {
                    valedArvamised.Add(guess);

                    Console.WriteLine("Täht '{0}' puudub sõnast", guess);
                    lives--;
                }

                Console.WriteLine(n2itaM2ngijale.ToString());
            }

            if (won)
                Console.WriteLine("Võit!");
            else
                Console.WriteLine("Kaotasid mängu, õige sõna oli: '{0}'", arvatavS6na);

            Console.Write("Press ENTER to exit...");
            Console.ReadLine();
        }
    }
}