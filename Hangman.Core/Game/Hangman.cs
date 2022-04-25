using System;
using HangmanRenderer.Renderer;

namespace Hangman.Core.Game
{
    public class HangmanGame
    {
        private GallowsRenderer _renderer;
        private string _Chosenword;
        private string guess;
        //private int index;
        private int lives;
        private string _dashhyphen;
        private char[] overWritehyp;
       // private string _guessprogress;
      

        public HangmanGame()
        {
            _renderer = new GallowsRenderer();

            string[] MovieList =new string[] { "captain america", "iron man", "spider man", "captain hook", "infinite", "restless", "black crab", "the batman", "shang chi", "free guy", "snake eyes", "tomb raider", "spider man", "uncharted", "deadpool", "bloodshot", "mortal kombat", "the adam project" };
            int index = new Random().Next(MovieList.Length);
            _Chosenword = MovieList[index];
            
            for (int i = 0; i < _Chosenword.Length; i++)
            {
                _dashhyphen += "_";//console.writeline
            }
            
        }

        public string Returndash()
        {
            return _dashhyphen;
        }

        public bool Overwrite(char guess)
        {

            
                overWritehyp = _dashhyphen.ToCharArray();

            bool correct = false;            
            for (int i = 0; i < _Chosenword.Length; i++)
            {
                if (_Chosenword[i] == guess)
                {
                    overWritehyp[i] = guess;

                    correct = true;
                    // guess correct


                }

            }

            _dashhyphen = new string(overWritehyp);

            return correct;
        }
        public void Run()
        {
            lives = 6;
            //for (int lives = 6; 0 < lives ; lives--)

            bool won = false;

            while (lives > 0 && !won)
            {
                _renderer.Render(5, 5, lives);
            

                Console.SetCursorPosition(0, 13);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Your current guess: ");

                Console.SetCursorPosition(0, 15);

                Console.Write(_dashhyphen);

                Console.ForegroundColor = ConsoleColor.Green;

                

                Console.Write("What is your next guess: ");
                guess = Console.ReadLine();
                guess = guess.ToLower();

                bool correctGuess = Overwrite(guess[0]);

//                guess = Console.ReadLine();
  //              guess = guess.ToLower();
    //            Console.WriteLine(" ");

               
                if (!correctGuess)
                    lives--;

                if (_Chosenword == _dashhyphen)
                {
                    won = true;
                }

            }

            if (lives == 0)
            {
                Console.WriteLine("You have died :(");
            }
            else 
            {
                Console.WriteLine("You have survived :)");
            }



        }
    }
}
