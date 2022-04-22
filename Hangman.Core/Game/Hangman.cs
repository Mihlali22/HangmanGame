using System;
using HangmanRenderer.Renderer;

namespace Hangman.Core.Game
{
    public class HangmanGame
    {
        private GallowsRenderer _renderer;
        private string _Chosenword;
        private string guess;
        private int index;
        private int lives;
        private string _dashhyphen;
        private char[] overWritehyp;
       // private string _guessprogress;
        public string Dash()
        {
            return _dashhyphen;
        }

        public HangmanGame()
        {

            string[] MovieList =new string[] { "captain america", "iron man", "spider man", "captain hook", "infinite", "restless", "black crab", "the batman", "shang chi", "free guy", "snake eyes", "tomb raider", "spider man", "uncharted", "deadpool", "bloodshot", "mortal kombat", "the adam project" };
            index = new Random().Next(MovieList.Length);
            _Chosenword = MovieList[index];
            for (int i = 0; i < MovieList.Length; i++)
            {
                _dashhyphen += "_";
            }
        
            
            {
                _renderer = new GallowsRenderer();
            }

        }
        
        public void Overwrite(char guess)
        {

            _dashhyphen = new string(overWritehyp);// this may be wrong
            {
                overWritehyp = _dashhyphen.ToCharArray();
            }
            for (int i = 0; i < _Chosenword.Length; i++)
            {
                if (_Chosenword[index] == guess)
                {
                    overWritehyp[index] = guess;
                }
            }

        }
            public void Run()
        {
            lives = 6;

            while (true)
            {
                _renderer.Render(5, 5, lives);

                Console.SetCursorPosition(0, 13);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Your current guess: ");
                
                Console.SetCursorPosition(0, 15);

                Console.ForegroundColor = ConsoleColor.Green;

               
                Console.Write("What is your next guess: ");
                var nextGuess = Console.ReadLine();
                guess = Console.ReadLine();
                guess = guess.ToLower();
                Console.WriteLine("                                    ");
                
                
            }
            if (_Chosenword.Contains(guess))
            {

            }
            else if (!_Chosenword.Contains(guess))
            {
                lives--;

                
            }
            if (lives == 0)
            {
                Console.WriteLine("You have died :(");
            }
            //else (lives != 0)
                    {
                Console.WriteLine("You have survived :)");
                    }
        }

    }
}
