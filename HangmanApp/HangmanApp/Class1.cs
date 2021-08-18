
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanApp
{
    /*
    public class Class1
    {

        string[] wordBank = { "change", "shift", "horse", "puzzle", "wheel", "museum", "wind", "camera", "alienated", "grammar", "ecology", "magnesium", "football", "portugal", "railing" };

        public void Run()
        {
            Menu();
        }

        string word;
        List<char> guessedLetters = new List<char>();
        public void Menu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {


                Console.WriteLine("Welcome to Hangman" +
                    "Press any key begin the game.");
                Console.ReadKey();
                word = AssignRandomWord();
                Console.WriteLine("The hidden word: " + word);
                Console.ReadKey();


                GetGuess();
                GetGuess();
                GetGuess();





                ContinueMessage();
            }
        }


        public void GetGuess()
        {
            StringBuilder displayToPlayer = new StringBuilder(wordBank.Length);
            for (int i = 0; i < word.Length; i++)
                displayToPlayer.Append('_');

            int live = 3;
            bool win = false;
            int revealLetter = 0;

            while ()
            {
                Console.Write("Enter a guess: ");
                char guess = Convert.ToChar(Console.ReadLine());
                guessedLetters.Add(guess);
                if (wordLetter == guessLetter)
                {
                    for (int i = 0; i < word.Length; i++)
                    {
                        if (word[i] == guessedLetter)
                        {
                            displayToPlayer[i] = word[i];
                            revealLetter++;
                        }
                    }

                    if (revealLetter == word.Length)
                        win = true;
                }
                else
                {
                    Console.WriteLine("You are wrong!");live--;
                }
                Console.WriteLine(displayToPlayer.ToString());

            }

            if (win)
                Console.WriteLine("congratulation, you won.")
            else
                Console.WriteLine("You lost!")
            /*
            Console.Clear();
            DisplayWord();
            Console.Write("Enter a guess: ");
            char guess = Convert.ToChar(Console.ReadLine());
            guessedLetters.Add(guess);
        }
        public void DisplayWord()
        {
            foreach (char wordLetter in word)
            {
                foreach (char guessLetter in guessedLetters)
                {
                    if (wordLetter == guessLetter)
                        Console.Write(" " + guessLetter + " ");


                }
                Console.Write(" _ ");
            }
        }
            */
            /*
        public void ContinueMessage()
        {
            Console.WriteLine("Enter any character to continue...");
            Console.ReadKey();
        }

        public string AssignRandomWord()
        {
            Random rand = new Random();
            int index = rand.Next(0, wordBank.Length);
            return wordBank[index];

                
        }

    }
    */
}