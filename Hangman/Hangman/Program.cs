using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace HangMan
{
    class Program
    {

        //Pulbic Variable
        static string userName = "";
        static string input = "";
        static List<string> lettersGuessed = new List<string>();
        static List<string> correctGuessed = new List<string>();
        static List<string> tempCorrectGuessed = new List<string>();
        static int guessesLeft = 10;
        static bool gotOne = false;
        static bool wordGuessed = false;
        static string[] wordArray = { "fuchsia", "blue", "white", "orange", "brown", "pink", "purple", "red", "black", "green", "yellow" };
        static System.Random randomTemp = new Random();
        static int random = randomTemp.Next(0, wordArray.Length);
        static string word = wordArray[random];

        static void Main(string[] args)
        {
            for (int i = 0; i < word.Length; i++)
            {
                correctGuessed.Add("_ ");
            }
            Print("Please enter your name");
            userName = Console.ReadLine();
            Console.Clear();
            Welcome();
            Stats();
        }

        //Welcome Function
        static void Welcome()
        {
            Print("Welcome to the game " + userName);
            Thread.Sleep(500);
            Print("You will be guessing letters to find a randomly generated word");
            Thread.Sleep(500);
            Print("You can guess the entire word as well!");
            Thread.Sleep(500);
            Print("If you guess the word correctly, you win");
            Thread.Sleep(500);
            Print("If you take too many guesses, you will lose");
            Thread.Sleep(500);
            Console.WriteLine();
            Print("Press any key to continue...");
            Console.ReadKey();
        }

        //Stats Function
        static void Stats()
        {
            Console.Clear();
            Console.Write("Letters Guessed: ");
            foreach (var item in lettersGuessed)
            {
                Console.Write(item.ToUpper() + " ");
            }
            Console.WriteLine();
            Print("Guesses Left: " + guessesLeft);
            Console.Write("Word: ");
            foreach (var item in correctGuessed)
            {
                Console.Write(item);
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Print("Enter a letter or word now");
            Console.ResetColor();
            Console.WriteLine();
            input = Console.ReadLine().ToString().ToLower();
            Add();
        }

        //Add Function
        static void Add()
        {
            for (int i = 0; i < word.Length; i++)
            {
                if (input == word[i].ToString())
                {
                    gotOne = true;
                }
                else if (input == word)
                {
                    wordGuessed = true;
                }
            }


            tempCorrectGuessed = new List<string>();
            foreach (var item in correctGuessed)
            {
                tempCorrectGuessed.Add(item);
            }
            var isIndex = tempCorrectGuessed.IndexOf("_");


            for (int i = 0; i < word.Length; i++)
            {

                if (input == word[i].ToString())
                {
                    correctGuessed.Remove("_ ");
                    correctGuessed.Add(input.ToUpper() + " ");
                }
                //else if (word[i].ToString() != "_" || word[i].ToString() != " ")
                //{
                //    correctGuessed.Add(word[i].ToString().ToUpper() + " ");
                //}
                else
                {
                    correctGuessed.Remove("_ ");
                    correctGuessed.Add("_ ");
                }
                if (tempCorrectGuessed[i] != "_")
                {
                    correctGuessed.Insert(i, tempCorrectGuessed[i]);
                    correctGuessed.Remove(tempCorrectGuessed[i]);
                }

            }



            if (gotOne)
            {
                Print("Good job, you guessed a letter!");
                lettersGuessed.Add(input.ToString().ToUpper());
                gotOne = false;
                Thread.Sleep(1500);
                Stats();
            }
            else if (wordGuessed)
            {
                Winner();
            }
            else if (guessesLeft == 0)
            {
                Loser();
            }
            else
            {
                Print("The letter you guessed was not in the word");
                lettersGuessed.Add(input.ToString().ToUpper());
                guessesLeft--;
                Thread.Sleep(1500);
                Stats();
            }
        }

        //Winner Function
        static void Winner()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Print("Congratulations " + userName + ". You win!");
            Console.ResetColor();
            Console.WriteLine();
            Print("Guesses Left: " + guessesLeft);
            Print("Word: " + word);
            End();
        }

        //Loser Function
        static void Loser()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Print("Oh, no " + userName + "! You Lose");
            Console.ResetColor();
            Print("You took too many guesses to guess the word");
            Console.WriteLine();
            Print("Guesses Left: " + guessesLeft);
            Print("Word: " + word);
            End();
        }

        //Print Function
        static void Print(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                Console.Write(input[i]);
                Thread.Sleep(1);
            }
            Console.WriteLine();
        }

        //End Function
        static void End()
        {
            Console.WriteLine();
            Print("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
