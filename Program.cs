using System;
using System.Collections.Generic;
using System.Linq;

namespace Arcade
{
    class Program
    {
        static void Main(string[] args)
        {
            bool playArcade = true;
            while(playArcade == true)
            {
                Console.Clear();
                //Main menu
                Console.WriteLine("A R C A D E");
                Console.WriteLine("***********");
                Console.WriteLine("Which game do you want to play?");
                Console.WriteLine("Press 1 for Mastermind");
                Console.WriteLine("Press 2 for Blackjack");
                Console.WriteLine("Press any other key to exit");
                string whatGame = Console.ReadLine();

                if (whatGame == "1")
                {
                    //Mastermind
                    playArcade = false;
                    bool newGame = false;
                    while (newGame == false)
                    {
                        Console.Clear();
                        //Mastermind menu
                        Console.WriteLine("M A S T E R M I N D");
                        Console.WriteLine("*******************");
                        Console.WriteLine("Press 1 to start a new game");
                        Console.WriteLine("Press 2 to see the rules");
                        Console.WriteLine("Press any other key to exit to main menu");
                        string choice = Console.ReadLine();
                        if (choice == "1") //New game
                        {
                            Console.Clear();
                            newGame = true;
                            Mastermind mastermind = new Mastermind();
                            Player player = new Player();
                            int firstDigit = mastermind.RandomNumber(); //Generates a random number combination
                            int secondDigit = mastermind.RandomNumber();
                            while (secondDigit == firstDigit)           //Making sure numbers are unique by testing each number with the previous
                            {
                                secondDigit = mastermind.RandomNumber();
                            }
                            int thirdDigit = mastermind.RandomNumber();
                            while (thirdDigit == secondDigit || thirdDigit == firstDigit)
                            {
                                thirdDigit = mastermind.RandomNumber();
                            }
                            int fourthDigit = mastermind.RandomNumber();
                            while (fourthDigit == firstDigit || fourthDigit == secondDigit || fourthDigit == thirdDigit)
                            {
                                fourthDigit = mastermind.RandomNumber();
                            }
                            bool guessedRight = false;
                            while (guessedRight == false) //Asks the user to guess while the user has not guessed right
                            {
                                Guess guess = new Guess();

                                Console.WriteLine("Guess a 4-digit code using unique numbers or press [x] to go back to the menu:");
                                string guessed = Console.ReadLine().ToLower();
                                int x = 0;
                                if (Int32.TryParse(guessed, out x)) //If guess is a number
                                {
                                    if (x >= 0 && x < 10000 && guessed.Length == 4) //If guess is a 4 digit code
                                    {

                                        string one = guessed.Substring(0, 1);
                                        string two = guessed.Substring(1, 1);
                                        string three = guessed.Substring(2, 1);
                                        string four = guessed.Substring(3, 1);

                                        int intOne = Int32.Parse(one); //Turns the guessed string numbers into int numbers
                                        int intTwo = Int32.Parse(two);
                                        int intThree = Int32.Parse(three);
                                        int intFour = Int32.Parse(four);

                                        if (intOne != intTwo && intTwo != intThree && intThree != intOne && intThree != intFour && intTwo != intFour && intOne != intFour) //Checks if the numbers are unique
                                        {
                                            player.guesses++; //Adds a guess to the guess-count

                                            guess.DigitTest(intOne, firstDigit, secondDigit, thirdDigit, fourthDigit); //Uses method in Guess class to see if guessed numbers are right and in right place, or wrong place

                                            guess.DigitTest(intTwo, secondDigit, firstDigit, thirdDigit, fourthDigit);

                                            guess.DigitTest(intThree, thirdDigit, firstDigit, secondDigit, fourthDigit);

                                            guess.DigitTest(intFour, fourthDigit, firstDigit, secondDigit, thirdDigit);



                                            if (guess.rightPlace == 4) //Checks if all numbers are the right numbers in the right place, if so, player wins
                                            {
                                                Console.WriteLine("Congratulations, the right answer was " + firstDigit + secondDigit + thirdDigit + fourthDigit + " which you guessed in " + player.guesses + " tries. You won!");
                                                guessedRight = true;
                                                Console.WriteLine("Do you want to play again? 1 for yes, any other key for no");
                                                string playAgain = Console.ReadLine();
                                                if(playAgain == "1") //Takes player back to start of mastermind
                                                {
                                                    newGame = false;
                                                } else
                                                { //Takes player back to main menu
                                                    playArcade = true;
                                                }
                                                
                                            }
                                            else //Types out the players progress
                                            {
                                                Console.WriteLine("\n" + guess.rightPlace + " correct numbers in the right place and");
                                                Console.WriteLine(guess.wrongPlace + " correct numbers in the wrong place.");
                                                Console.WriteLine("You have guessed " + player.guesses + " times.\n");
                                            }
                                        }




                                    }
                                    else
                                    {
                                        Console.WriteLine("Guess needs to be a 4-digit code");
                                    }


                                }
                                else if (guessed == "x")
                                {
                                    guessedRight = true;
                                    newGame = false;
                                    Console.Clear();
                                }
                                else
                                {
                                    Console.WriteLine("Guess needs to be a 4-digit code\n");
                                }

                            }
                        }
                        else if (choice == "2") //Displays the mastermind rules
                        {
                            newGame = true;
                            Console.Clear();
                            Console.WriteLine("The rules are as follows:");
                            Console.WriteLine("The goal of the game is to guess four digits in the correct order.");
                            Console.WriteLine("After each guess, I will tell you if you have any correct numbers in the right place,");
                            Console.WriteLine("Or any correct numbers in the wrong place.");
                            Console.WriteLine("Numbers in your guess need to be unique.");
                            Console.WriteLine("Try to guess the right combination in as few guesses as possible.");
                            Console.WriteLine("Good luck!\n\n");
                            Console.WriteLine("Press any key to go back to menu");
                            string key = Console.ReadLine();
                            if (key.Length > 0)
                            {
                                newGame = false;
                            }
                        }
                        else //Takes player back to main menu
                        {
                            playArcade = true;
                            newGame = true;
                        }
                    }
                }
                else if (whatGame == "2")
                {
                    //Blackjack
                    playArcade = false;
                    bool theGame = true;
                    while (theGame == true)
                    {
                        Console.Clear();
                        //Blackjack menu
                        Console.WriteLine("B L A C K J A C K");
                        Console.WriteLine("*****************");
                        Console.WriteLine("Press 1 to start a new game");
                        Console.WriteLine("Press 2 for the rules");
                        Console.WriteLine("Press any other key to exit to main menu");
                        string input = Console.ReadLine();
                        if (input == "1")
                        {
                            theGame = false;
                            //Creates lists for the players cards
                            var cards = new List<string>();
                            var cardInt = new List<int>();

                            Dealer dealer = new Dealer();
                            Player player = new Player();
                            //Creates lists for the dealers cards
                            var dealerCards = new List<string>();
                            var dealerCardInt = new List<int>();

                            player.coins = 10; //Adds 10 coins to the player to start with

                            bool placeBet = true;


                            Console.Clear();

                            while (placeBet == true && player.coins > 0) //Play game while the player has at least 1 coin
                            {
                                cards.Clear();
                                cardInt.Clear();
                                dealerCards.Clear();
                                dealerCardInt.Clear();

                                bool dealerWins = false;
                                bool playerWins = false;
                                Console.WriteLine("You have " + player.coins + " coins. How much do you want to bet?");
                                string bet = Console.ReadLine();
                                int x;
                                if (Int32.TryParse(bet, out x)) //Checks if bet is int
                                {
                                    if (x > 0 && x <= player.coins) //Checks if bet is equal to or less than the players amount of coins, and bigger than 0
                                    {
                                        player.coins = player.coins - x;
                                        placeBet = false;
                                        //Resets the player's and dealer's sum
                                        int playerSum = 0;
                                        int dealerSum = 0;

                                        Console.Clear();
                                        Console.WriteLine("You have bet " + x + " coins. Dealing cards...");
                                        cardInt.Add(dealer.Deal()); //Deals a random card using Dealer method
                                        cardInt.Add(dealer.Deal());
                                        for (int y = 0; y < cardInt.Count; y++)
                                        {
                                            cards.Add(dealer.CardDealt(cardInt[y])); //Adds the cards to the list of strings and then checks if it's a dressed card, if so sets its value to 10
                                            if (cardInt[y] == 11)
                                            {
                                                cardInt[y] = 10;
                                            }
                                            else if (cardInt[y] == 12)
                                            {
                                                cardInt[y] = 10;
                                            }
                                            else if (cardInt[y] == 13)
                                            {
                                                cardInt[y] = 10;
                                            }
                                        }

                                        Console.WriteLine("Your cards are:"); //Shows the users initial cards
                                        Console.WriteLine("[" + cards[0] + "][" + cards[1] + "]");

                                        bool playGame = true;
                                        bool elevenAce = false;
                                        bool gameOver = false;

                                        while (playGame == true)
                                        {
                                            //Prompts the user to draw, stop or exit while game should still be running
                                            Console.WriteLine("\n(1): Draw");
                                            Console.WriteLine("(2): Stop");
                                            Console.WriteLine("(X): Exit game to main menu");
                                            string choice = Console.ReadLine().ToLower();

                                            if (choice == "1") //Draw
                                            {
                                                cardInt.Add(dealer.Deal());
                                                cards.Add(dealer.CardDealt(cardInt[cardInt.Count - 1]));
                                                for (int y = 0; y < cardInt.Count; y++)
                                                {
                                                    if (cardInt[y] == 11)
                                                    {
                                                        cardInt[y] = 10;
                                                    }
                                                    else if (cardInt[y] == 12)
                                                    {
                                                        cardInt[y] = 10;
                                                    }
                                                    else if (cardInt[y] == 13)
                                                    {
                                                        cardInt[y] = 10;
                                                    }
                                                }

                                                Console.WriteLine("Your cards are:");
                                                for (int i = 0; i < cards.Count; i++)
                                                {
                                                    Console.Write("[" + cards[i] + "]");

                                                }

                                                if (cardInt.Sum() > 21)
                                                {
                                                    Console.WriteLine("\nYou got bust, you lose. Try again!"); //Player gets bust if they go over sum 21
                                                    placeBet = true;
                                                    gameOver = true;
                                                    playGame = false;
                                                }

                                            }
                                            else if (choice == "2") //Stop-option
                                            {
                                                playGame = false;


                                                if (!cardInt.Contains(1)) //If players cards does not have an ace
                                                {
                                                    Console.WriteLine("\nYou have a total of " + cardInt.Sum() + ". Dealer's turn...");
                                                    playerSum = cardInt.Sum();
                                                }
                                                else if (cardInt.Contains(1) && cardInt.Sum() + 10 <= 21) //If players card has an ace and the sum plus 10 (high ace) is less than 22
                                                {
                                                    int highAce = cardInt.Sum() + 10; //Sets the sum to contain the high ace (since ace can be both 1 or 11)
                                                    Console.WriteLine("\nYou have a total of " + highAce + ". Dealer's turn...");
                                                    playerSum = cardInt.Sum() + 10;
                                                } else
                                                {
                                                    Console.WriteLine("\nYou have a total of " + cardInt.Sum() + ". Dealer's turn...");
                                                    playerSum = cardInt.Sum();
                                                }

                                                dealerCardInt.Add(dealer.Deal()); //Deals the dealers cards
                                                dealerCardInt.Add(dealer.Deal());
                                                for (int y = 0; y < dealerCardInt.Count; y++)
                                                {
                                                    dealerCards.Add(dealer.CardDealt(dealerCardInt[y]));
                                                    if (dealerCardInt[y] == 11)
                                                    {
                                                        dealerCardInt[y] = 10;
                                                    }
                                                    else if (dealerCardInt[y] == 12)
                                                    {
                                                        dealerCardInt[y] = 10;
                                                    }
                                                    else if (dealerCardInt[y] == 13)
                                                    {
                                                        dealerCardInt[y] = 10;
                                                    }
                                                }

                                                Console.WriteLine("\nDealer's cards are:"); //Displays the dealer's cards
                                                Console.WriteLine("[" + dealerCards[0] + "][" + dealerCards[1] + "]");

                                                //Checks if dealer wins, and if the dealers ace is a high or low
                                                if (dealerCardInt.Sum() > playerSum || dealerCardInt.Sum() == 21 || (dealerCardInt.Contains(1) && dealerCardInt.Sum() + 10 == 21))
                                                {
                                                    dealerWins = true;
                                                    elevenAce = true;
                                                }
                                                else
                                                {

                                                    while (dealerSum < 21 && dealerSum < playerSum && gameOver == false) //While dealers sum is less than 22 and the player's sum, draw cards for dealer
                                                    {
                                                        dealerSum = dealerCardInt.Sum();
                                                        dealerCardInt.Add(dealer.Deal());
                                                        dealerCards.Add(dealer.CardDealt(dealerCardInt[dealerCardInt.Count - 1]));
                                                        for (int y = 0; y < dealerCardInt.Count; y++)
                                                        {
                                                            if (dealerCardInt[y] == 11)
                                                            {
                                                                dealerCardInt[y] = 10;
                                                            }
                                                            else if (dealerCardInt[y] == 12)
                                                            {
                                                                dealerCardInt[y] = 10;
                                                            }
                                                            else if (dealerCardInt[y] == 13)
                                                            {
                                                                dealerCardInt[y] = 10;
                                                            }
                                                        }
                                                        Console.WriteLine("\nDealer draws:");
                                                        for (int i = 0; i < dealerCards.Count; i++)
                                                        {
                                                            Console.Write("[" + dealerCards[i] + "]");
                                                        }
                                                        if (dealerCardInt.Contains(1)) //Checks for ace
                                                        {
                                                            if (dealerCardInt.Sum() + 10 == 21 || dealerCardInt.Sum() == 21 || dealerCardInt.Sum() + 10 >= playerSum || dealerCardInt.Sum() >= playerSum)
                                                            {
                                                                if (dealerCardInt.Sum() + 10 > 21 && dealerCardInt.Sum() > 21)
                                                                {
                                                                    playerWins = true; //Player wins
                                                                    elevenAce = false; //The ace is low
                                                                    gameOver = true;
                                                                    
                                                                }
                                                                else
                                                                {
                                                                    if((dealerCardInt.Sum() <= 21 || dealerCardInt.Sum() + 10 == 21) && dealerCardInt.Sum() >= playerSum)
                                                                    {
                                                                        dealerWins = true; //Dealer wins
                                                                        if(dealerCardInt.Sum() + 10 > 21)
                                                                        {
                                                                            elevenAce = false;
                                                                        } else
                                                                        {
                                                                            elevenAce = true; //Ace is high
                                                                        }
                                                                        
                                                                        gameOver = true;
                                                                    }
                                                                    
                                                                }

                                                            }
                                                            
                                                        }
                                                        else
                                                        {
                                                            if (dealerCardInt.Sum() == 21 || (dealerCardInt.Sum() < 21 && dealerCardInt.Sum() >= playerSum))
                                                            {
                                                                dealerWins = true;
                                                                gameOver = true;
                                                            }
                                                            else if (dealerCardInt.Sum() > 21)
                                                            {
                                                                playerWins = true;
                                                                gameOver = true;
                                                            }
                                                        }
                                                    }
                                                }

                                            }
                                            else if (choice == "x")
                                            {
                                                theGame = true;
                                                placeBet = false;
                                                playGame = false;
                                            }
                                        }
                                        if (elevenAce == true && dealerCardInt.Contains(1)) //Sets the dealers final sum
                                        {
                                            dealerSum = dealerCardInt.Sum() + 10;
                                        }
                                        else
                                        {
                                            dealerSum = dealerCardInt.Sum();
                                        }
                                        if (playerWins == true) //Player wins, shows final sums and adds the coins won
                                        {
                                            player.coins = player.coins + Int32.Parse(bet) * 2;
                                            Console.WriteLine("\nYou win with a sum of " + playerSum + " to the dealer's sum of " + dealerSum + "! Your coins have been added.\n");
                                            placeBet = true;
                                        }
                                        else if (dealerWins == true) //Dealer wins
                                        {
                                            Console.WriteLine("\nDealer wins with a sum of " + dealerSum + " to your sum of " + playerSum + ".\n");
                                            placeBet = true;
                                        }
                                    }
                                }
                            }
                            if (player.coins == 0)
                            {
                                Console.WriteLine("You are out of coins. Game over.");
                                Console.WriteLine("Do you want to play again? 1 for yes, any other key for no");
                                string playAgain = Console.ReadLine();
                                if (playAgain == "1")
                                {
                                    theGame = true;
                                }
                                else
                                {
                                    playArcade = true;
                                }
                                
                            }
                        }
                        else if (input == "2")
                        {
                            //Blackjack rules
                            Console.Clear();
                            Console.WriteLine("The rules are as follows:");
                            Console.WriteLine("The goal is to get as close to 21 as possible, but not go over");
                            Console.WriteLine("Ace is worth either 1 or 11, and dressed cards are worth 10");
                            Console.WriteLine("To get a new card, press Draw. To end your turn, press Stop");
                            Console.WriteLine("The person (player or dealer) that gets the highest score, but under 21, wins.");
                            Console.WriteLine("If you get over 21 you get bust and lose.");
                            Console.WriteLine("If the dealer and the player gets the same sum, the dealer wins.");
                            Console.WriteLine("Good luck!\n");
                            Console.WriteLine("Press any key to go back to menu");
                            string key = Console.ReadLine();
                            if(key.Length > 0)
                            {
                                theGame = true;
                            }
                        }
                        else
                        {
                            theGame = false;
                            playArcade = true;
                        }
                    }
                } else //If user chooses exit game
                {
                    Environment.Exit(0);
                }
            }
        }
    }
}
