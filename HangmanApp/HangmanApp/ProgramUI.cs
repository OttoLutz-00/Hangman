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
        string[] city = { "london", "tokyo", "paris", "berlin", "washington", "budapest", "bangkok", "dubai", "singapore", "seoul", "barcelona", "osaka", "shanghai", "miami", "taipei", "istanbul" };

        string[] animal = { "donkey", "goat", "horse", "cat", "sheep", "penguin", "kangaroo", "rabbit", "goldfish", "rhinoceros", "hedgehog", "gorilla", "leopard", "chimpanzee", "impala", "hippopotamus" };

        string[] foodAndDrinks = { "spaghetti", "pizza", "salad", "fanta", "hamburger", "steak", "pretzel", "water", "juice", "sausage", "yogurt", "coffee", "omelet", "kebadb", "breadsticks",  "croissant" };


        public void Run()
        {
            Menu();
        }
        //the word the player is trying to guess
        string word;
        //stores every character the player has already guessed for the current word, resets every round
        List<char> guessedLetters = new List<char>();
        int guessesLeft;
        //if the player wants a hint this will be true and didplayword will randomly show a letter form the word
        bool playerWantsHint = false;
        //category name stored for displaycategory
        string category;
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
                //Console.Write("\n The hidden word is: " + word + "\n");
                Console.Write("How many guesses would you like to complete the word: ");
                string stringInput = Console.ReadLine();
                guessesLeft = Convert.ToInt32(stringInput);

                AskUserForHint();

                AssignAndRunNumberOfTurns(Convert.ToInt32(stringInput));

                //this will run at the end of each round, clearing the list of prevoiusly guessed characters and number of guesses left
                guessedLetters.Clear();
                guessesLeft = 0;
            }
        }


        //FEATURES TO ADD
        //display the current category the user is in, (CITIES, ANIMALS, FOOD & DRINK)

        //(do this last if we have time)start the round with one letter already revealed to help the user make their first guess. Ask the user if they would like to "start the round with a hint?"


        // and if the word is "museum" and 'm' is chosen it needs to reveal both and not just one 'm', just something to watch out for.


        //METHODS

        //GetGuess - takes in a guess from the user, if the guess is valid(if it is a single character) it will add the guessed character to the list of characters the user has guessed.
        public void GetGuess()
        {

            Console.Clear();
            DisplayCategory();
            DisplayWord();
            DisplayNumberOfGuessesLeft();
            DisplayGuessedLetters();
            Console.Write("\n  Enter a guess: ");
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

        public void DisplayCategory()
        {
            Console.WriteLine("Category: " + category);
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

            Console.Write("\n  ");

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
                    category = "cities";
                    return city[index];
                    break;
                case 2:
                    int indexx = rand.Next(0, animal.Length);
                    category = "animals";
                    return animal[indexx];
                    break;
                case 3:
                    int indexxx = rand.Next(0, foodAndDrinks.Length);
                    category = "food & drink";
                    return foodAndDrinks[indexxx];
                    break;
                default:
                    int indexxxx = rand.Next(0, city.Length);
                    return city[indexxxx];
                    break;
            }
            
        }
        //im going to test now
        //just figured out that i can't put that switch after the other one because it wont run, i will make a method to contain the stuff
              
        //asks the user if they want a hint, if yes then the displayword method will reveal the a random letter from word.
        public void AskUserForHint()
        {
            Console.Write("Would you like to start the round with a hint? (y/n): ");
            string hintInput = Console.ReadLine();
            switch (hintInput)
            {
                case "y":
                case "ye":
                case "yes":
                    AddHintedLetterToGuessedLetters();
                    break;
                case "n":
                case "no":
                    break;
                default:
                    break;
            }
            ContinueMessage();
        }

        //runs inside the AskUserForHint method if the user accepts the hint, the method will then take a random letter from word and add it to the list of guessed letters
        public void AddHintedLetterToGuessedLetters()
        {
            Random rand = new Random();
            string str = word.Substring(rand.Next(0, word.Length + 1), 1);
            char character = Convert.ToChar(str);
            guessedLetters.Add(character);
            
        }
        
        //prints the win rate as a percentage, also prints the number of wins, and number of games played
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
            for (int i = numberOfTurns; i > 0; i--,guessesLeft--)
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

        //DisplayNumberOfGuessesLeft - shows the player how many guesses they have left to complete the word
        public void DisplayNumberOfGuessesLeft()
        {
            Console.WriteLine("\n\n  Guesses Remaining: " + guessesLeft);
        }

        // - shows the player each letter that they have already guessed
        public void DisplayGuessedLetters()
        {
            Console.Write("\n  Guessed Letters:");
            foreach (var letter in guessedLetters)
            {
                Console.Write(" " + letter + " ");
            }
            Console.WriteLine();
        }

    }
}
