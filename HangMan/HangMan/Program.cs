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

        //Puulbic Variable
        static string userName = "";
        static string input = "";
        static List<string> lettersGuessed = new List<string>();
        static int guessesLeft = 10;

        static void Main(string[] args)
        {
            Print("Please enter your name");
            userName = Console.ReadLine();
            Console.Clear();
            Welcome();
            Stats();
        }

        //Welcome Function
        static void Welcome()
        {
            Print("Welcome to the game "+userName);
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
            Print("Letters Guessed: " + lettersGuessed);
            Print("Guesses Left: " + guessesLeft);
            Console.WriteLine();
            Print("Enter a letter or word now");
            input = Console.ReadLine().ToString();
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
