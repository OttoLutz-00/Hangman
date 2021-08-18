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
                if (numberOfGamesPlayed == 0)
                {
                    Console.WriteLine("  Welcome to Hangman.\n");

                    Console.WriteLine("  Press any key to configure a game.");
                    Console.ReadKey();
                }
                word = PickCategoryAndWord();
                Console.Write("\n(for testing purposes) The hidden word is: " + word + "\n" +
                    "Enter the number of guesses you want for this round: ");
                string stringInput = Console.ReadLine();
                AssignAndRunNumberOfTurns(Convert.ToInt32(stringInput));

                guessedLetters.Clear();
            }
        }

  
        //FEATURES TO ADD
        //only display "welcome to hangman..." if numberofroundsplayed is 0, else take the user straight to the screen where they choose categories
        //

        //if the user doesn't guess the entire word before their turns are up, it should reveal the word

        // - (extra feature if we have time for it) start the round with one letter already revealed to help the user make their first guess. Ask the user if they would like to start the round with a hint? 

        



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
                    Console.Write(" " + Convert.ToString(wordLetter).ToUpper() + " ");
                }
                else
                {
                    Console.Write(" _ ");
                }
            }
        }
        public void ContinueMessage()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        public string PickCategoryAndWord()
        {
            Console.Clear();
            Random rand = new Random();
            Console.Write("\n  CATEGORIES:\n\n" +
                " (1) Cities\n" +
                " (2) Animals\n" +
                " (3) Food And Drinks\n" +
                " \nEnter the category number you want to play: ");
            string input = Console.ReadLine();
            while (input.Length > 1)
            {
                Console.Write("INVALID INPUT: Please enter a single number\n" +
                    "Enter the category number you want to play: ");
                input = Console.ReadLine();
            }
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
            //Console.WriteLine("");

            Console.WriteLine("Current win percentage: " + (int)winPercentage + "%");
            Console.WriteLine("games played: " + numberOfGamesPlayed + "\n" + "games won: " + numberOfGamesWon);
        }
        
        public void AssignAndRunNumberOfTurns(int numberOfTurns)
        {
            for (int i = numberOfTurns; i > 0; i--,numberOfTurns--)
            {
                GetGuess();
                //this will run if the player wins
                if (CheckIfWordIsGuessed()) {
                    Console.Clear();
                    DisplayWord();
                    Console.WriteLine("\n\nYou Win!");
                    numberOfGamesWon++;
                    numberOfGamesPlayed++;
                    DisplayWinPercentage();
                    ContinueMessage();
                    break;
                }
            }
            //this will run if the player loses
            if (!CheckIfWordIsGuessed())
            {
                numberOfGamesPlayed++;
                Console.WriteLine("\nYou Lost.\n" +
                    "The word was '" + word + "'");
                
                DisplayWinPercentage();
                ContinueMessage();
            }
        }
    }
}
