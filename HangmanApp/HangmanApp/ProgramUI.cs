using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanApp
{
    public class ProgramUI
    {
        //themed categories of words
        string[] city = { "london", "tokyo", "paris", "berlin", "washington", "budapest", "bangkok", "fishers" };

        string[] animal = { "donkey", "goat", "horse", "cat", "sheep", "penguin", "kangaroo", "rabbit", "goldfish" };

        string[] foodAndDrinks = { "spaghetti", "pizza", "salad", "fanta", "hamburger", "steak", "eggs", "water", "juice" };


        public void Run()
        {
            Menu();
        }
        //the word the player is trying to guess
        string word;
        //stores every character the player has already guessed for the current word, resets every round
        List<char> guessedLetters = new List<char>();
        //win stats
        double numberOfGamesPlayed = 0;
        double numberOfGamesWon = 0;
        double winPercentage = 0.0;
        //runs the welcome screen, runs the method to pick the category and word, and asks the user for a value to run the number of turns
        public void Menu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                if (numberOfGamesPlayed == 0)
                {
                    Console.WriteLine("\n  Welcome to Hangman.\n");
                    Console.Write("  Press any key to begin the ultimate hang man experience. \n  ");
                    Console.ReadKey();
                }
                word = PickCategoryAndWord();
                //for testing purposes
                Console.Write("\n The hidden word is: " + word + "\n");
                Console.Write("How many guesses would you like to complete the word: ");
                string stringInput = Console.ReadLine();
                AssignAndRunNumberOfTurns(Convert.ToInt32(stringInput));

                guessedLetters.Clear();
            }
        }

  
        //FEATURES TO ADD
        
        //display number of guesses left after each guess

        //add more words to each catalog

        //show the player what letters have already been guessed

        //start the round with one letter already revealed to help the user make their first guess. Ask the user if they would like to "start the round with a hint?"

        

        //METHODS

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

        //CheckIfWordIsGuesses - returns true if every letter of the word has been guessed, returns false if the player has not guessed every letter in the word.
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

        //DisplayWord - prints a " _ " for letters of the word that have not been guessed, and if the player has guessed the letter it will print that letter
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

        //ContinueMessage - prompts the user with a question to "press any key to continue...". this is a good way to prevent the next action from happening until the user is ready
        public void ContinueMessage()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        //displays the available categories to the user, then promts the user to pick a category to draw a random word from.
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
            //this will display if the player enters a number that is not a single digit
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

        
        /*public string help()
          {
             Console.WriteLine("Do you want a hint?\n"+
             "1. Yes\n"+
             "2. No\n"+
             "Enter the number: ");
             string input = Console.ReadLine();
             int wantHint = Convert.ToInt32(input);
            }*/

        //prints the win rate as a percentage, number of wins, and number of games played
        public void DisplayWinPercentage()
        {
            winPercentage = 100 * (numberOfGamesWon / numberOfGamesPlayed);
            //Console.WriteLine("");

            Console.WriteLine("Current win percentage: " + (int)winPercentage + "%");
            Console.WriteLine("games played: " + numberOfGamesPlayed + "\n" + "games won: " + numberOfGamesWon);
        }

        //takes in an integer that will be the number of times the user will get to guess.
        public void AssignAndRunNumberOfTurns(int numberOfTurns)
        {
            for (int i = numberOfTurns; i > 0; i--,numberOfTurns--)
            {
                GetGuess();
                //this will run if the player wins
                if (CheckIfWordIsGuessed()) {
                    numberOfGamesWon++;
                    numberOfGamesPlayed++;
                    Console.Clear();
                    DisplayWord();
                    Console.WriteLine("\n\n You Win!");
                    DisplayWinPercentage();
                    ContinueMessage();
                    break;
                }
            }
            //this will run if the player loses
            if (!CheckIfWordIsGuessed())
            {
                numberOfGamesPlayed++;
                Console.WriteLine("\n You Lost.\n" +
                    "The word was '" + word + "'");
                
                DisplayWinPercentage();
                ContinueMessage();
            }
        }
    }
}
