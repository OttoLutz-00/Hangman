using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanApp
{
    public class ProgramUI
    {

        string[] city = { "london", "tokyo", "paris", "berlin", "washington", "budapest", "bangkok" };

        string[] animal = { "donkey", "goat", "horse", "cat", "sheep", "penguin", "kangaroo", "rabbit", "goldfish" };

        string[] foodAndDrinks = { "spaghetti", "pizza", "salad", "fanta", "hamburger", "steak", "eggs", "water", "juice" };


        public void Run()
        {
            Menu();
        }

        string word;
        List<char> guessedLetters = new List<char>();
        double numberOfGamesPlayed = 0;
        double numberOfGamesWon = 0;
        double winPercentage = 0.0;
        public void Menu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.Write("Welcome to Hangman\n" +
                    "Press any key to choose your category and turns.");
                Console.ReadKey();
                word = PickCategoryAndWord();
                Console.Write("\n(for testing purposes) The hidden word is: " + word + "\n" +
                    "Enter the number of guesses you would like to have per word: ");
                string stringInput = Console.ReadLine();
                int intInput = Convert.ToInt32(stringInput);
                AssignAndRunNumberOfTurns(intInput);

                
                guessedLetters.Clear();
                
            }
        }

  
        //FEATURES TO ADD
        //A way to keep score that does not delete between the rounds
        //if the user doesn't guess the entire word before their turns are up, it should reveal the word
        //if we store this value we can show the user statistics on their games like win percentage
        //thats one way we could do it, we could keep it as a percentage

        //winPercent = 100 * (totalWins / totalGamesPlayed)


        // - (extra feature if we have time for it) start the round with one letter already revealed to help the user guess. Ask the user if they would like to start with a hint? 

        



        //GetGuess - takes in a guess from the user, if the guess is valid(if it is a single character) it will add the guessed character to the list of characters the user has guessed.
        public void GetGuess()
        {

            Console.Clear();
            DisplayWord();
            Console.Write("\nEnter a guess: ");
            string guess = Console.ReadLine();
            if (guess.Length == 1)
                guessedLetters.Add(Convert.ToChar(guess));
            else
            {
                Console.WriteLine("\nPlease enter a single valid character.");
                foreach (var item in guessedLetters)
                {
                    Console.Write(item + " ");
                }
                ContinueMessage();
                GetGuess();
            }
        }
        public bool CheckIfWordIsGuessed()
        {
            bool completed = true;
            foreach (char wordLetter in word)
            {
                if (!guessedLetters.Contains(wordLetter))
                {
                    completed = false;
                }
            }
            return completed;
        }
        public void DisplayWord()
        {
            
            foreach (char wordLetter in word)
            {
                if (guessedLetters.Contains(wordLetter))
                {
                    Console.Write(" " + wordLetter + " ");
                }
                else
                {
                    Console.Write(" _ ");
                }
            }
        }
        public void ContinueMessage()
        {
            Console.WriteLine("Enter any character to continue...");
            Console.ReadKey();
        }
        public string PickCategoryAndWord()
        {
            Console.Clear();
            Random rand = new Random();
            Console.Write("\nWhat category would you like to play?\n" +
                "1. Cities\n" +
                "2. Animals\n" +
                "3. Food And Drinks\n" +
                "Enter the category number you want to play: ");
            string input = Console.ReadLine();
            int intInput = Convert.ToInt32(input);
            switch (intInput)
            {
                case 1:
                    int index = rand.Next(0, city.Length);
                    return city[index];
                    break;
                case 2:
                    int indexx = rand.Next(0, animal.Length);
                    return animal[indexx];
                    break;
                case 3:
                    int indexxx = rand.Next(0, foodAndDrinks.Length);
                    return foodAndDrinks[indexxx];
                    break;
                default:
                    int indexxxx = rand.Next(0, city.Length);
                    return city[indexxxx];
                    break;
            }


        }
        /*   public string help()
            {
                Console.WriteLine("Do you want a hint?\n"+
                    "1. Yes\n"+
                    "2. No\n"+
                    "Enter the number: ");
                string input = Console.ReadLine();
                int wantHint = Convert.ToInt32(input);
                

    // the only way i can think of is you make a Dictionary with the key being the word and the value being the hint
    
            }

        */

        
        public void DisplayWinPercentage()
        {
            winPercentage = 100 * (numberOfGamesWon / numberOfGamesPlayed);
            Console.WriteLine("Your current win percentage: " + winPercentage + "%.");
        }
        
        public void AssignAndRunNumberOfTurns(int numberOfTurns)
        {
            
            for (int i = numberOfTurns; i > 0; i--,numberOfTurns--)
            {
                GetGuess();
                if (CheckIfWordIsGuessed()) {
                    Console.Clear();
                    DisplayWord();
                    Console.WriteLine("\nYou Win!");
                    numberOfGamesWon++;
                    numberOfGamesPlayed++;
                    DisplayWinPercentage();
                    ContinueMessage();
                    break;
                }
            }
            if (numberOfTurns <= 0 && !CheckIfWordIsGuessed())
            {
                DisplayWinPercentage();
                ContinueMessage();
            }
                    numberOfGamesPlayed++;
            
        }

    }
}
