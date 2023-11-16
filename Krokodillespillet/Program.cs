using System;

namespace Krokodillespillet
{
    internal class Program
    {
        static int number1 = 0;
        static int number2 = 0;

        static void generateRandomNumber()
        {
            var random = new Random();
            number1 = random.Next(1, 11);
            number2 = random.Next(1, 11);
        }

        static bool checkPlayerInput(int inNumber1, int inNumber2, string inCheck)
        {
            if (inCheck == "<" && (inNumber1 < inNumber2))
            {
                return true;
            }

            if (inCheck == ">" && (inNumber1 > inNumber2))
            {
                return true;
            }

            if (inCheck == "=" && (inNumber1 == inNumber2))
            {
                return true;
            }

            return false;
        }

        static int updatePoengsum(bool addValue, int inPoengsum)    // addValue: true = increment, false = decrement
        {
            if (addValue)
            {
                inPoengsum++;
            }
            else
            {
                inPoengsum--;
            }

            if (inPoengsum < 0)
            {
                inPoengsum = 0;
            }

            return inPoengsum;
        }

        static void Main(string[] args)
        {
            string playerGuess = "";
            bool isGameOver = false;
            int poengsum = 0;

            Console.WriteLine("Sett inn <, > eller =");

            while (!isGameOver)
            {
                generateRandomNumber();
                Console.WriteLine(number1.ToString() + " _ " + number2.ToString());
                playerGuess = Console.ReadLine();

                if (playerGuess == "")
                {
                    isGameOver = true;
                }

                bool result = checkPlayerInput(number1, number2, playerGuess);

                if (result && !isGameOver)
                {
                    poengsum = updatePoengsum(true, poengsum);

                    Console.WriteLine("Correct! Well done! Your current score: " + poengsum);
                }
                else if (!result && !isGameOver)
                {
                    poengsum = updatePoengsum(false, poengsum);

                    Console.WriteLine("Incorrect! Your current score: " + poengsum);
                }
            }

        }
    }
}
