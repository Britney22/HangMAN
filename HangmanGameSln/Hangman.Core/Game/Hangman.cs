using System;
using HangmanRenderer.Renderer;

namespace Hangman.Core.Game
{
    public class HangmanGame
    {
        private int _guessCount = 0;
        private bool _incorrectGuess = true;
        public bool _correctGuess = false;
        private GallowsRenderer _renderer;
        private bool _outOfGuesses = false;
        private int _guessLimit = 6;
        public HangmanGame()
        {
            _renderer = new GallowsRenderer();
        }

        public void Run()
        {
            Random random = new Random();

            string[] wordlist = new string[20] { "hello","word" , "noku" ,"tina"," wife" ," apple","pink", "yellow", " blue" , "white",
            "pizza", " burger", "coke" , "purple" , "green" , "cheese" ,"fieka" ,"allan" , "angel" ," nike"};
            var index = random.Next(0, 19);
            string secertWord = wordlist[index];
            char[] letter = new char[secertWord.Length];


            for (int i = 0; i < secertWord.Length; i++)
            {
                letter[i] = '-';
            }

            while (_guessLimit >= 0 && _guessLimit <= 6)
            {

                _renderer.Render(5, 5, _guessLimit);

                Console.SetCursorPosition(0, 13);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Your current guess: ");
                Console.WriteLine(letter);

                Console.WriteLine("--------------");
                Console.SetCursorPosition(0, 15);

                Console.ForegroundColor = ConsoleColor.Green;

                Console.Write("What is your next guess: ");
                var nextGuess = char.Parse(Console.ReadLine());

                bool correctGuess = false;

                for (int w = 0; w < secertWord.Length; w++)
                {
                    if (nextGuess == secertWord[w])
                    {
                        letter[w] = nextGuess;
                        correctGuess = true;

                    }
                }
                if (!correctGuess)
                {
                    _guessLimit--;
                }
            }


            if (_correctGuess == true)
            {
                Console.WriteLine(" You Have Won!");
            }
            else
            {
                Console.WriteLine(" You Have Lost! The word is {0}", secertWord);

            }


        }
    }
}




