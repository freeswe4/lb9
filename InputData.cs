using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lb9
{
    internal static class InputData
    {
        static string[] errorMessages = { "Неверный ввод данных. Вводите целые числа", "Неверный ввод. Вводите неотрицательный числа и не превышающего границы" };

        public static bool IntValidate(int num, int min) //провекра ввода на соответствие границ
        {
            return num >= min;
        }

        public static bool IntValidateBord(int num, int min, int max) //провекра ввода на соответствие границ
        {
            return num >= min && num <= max;
        }

        public static int IntInput(string message, string errorMessage) //провекра ввода на соответствие типа входных данных
        {
            bool isCorrect;
            int num;
            do
            {
                Console.WriteLine(message);

                isCorrect = Int32.TryParse(Console.ReadLine(), out num);
                if (!isCorrect) 
                    Console.WriteLine(errorMessage);
            } while (!isCorrect);

            return num;
        }

        public static int InputAndValidateInt(string message, int min) //провекра ввода на соответствие границам и правильности ввода
        {
            bool isCorrect;
            int num;

            do
            {
                Console.WriteLine(message);
                isCorrect = Int32.TryParse(Console.ReadLine(), out num);
                if (!isCorrect)
                    Console.WriteLine(errorMessages[0]);
                if (!IntValidate(num, min))
                {
                    Console.WriteLine(errorMessages[1]);
                    isCorrect = false;
                }  
            } while (!isCorrect);

            return num;
        }

        public static int InputAndValidateIntBord(string message, int min, int max) //провекра ввода на соответствие границам и правильности ввода
        {
            bool isCorrect;
            int num;

            do
            {
                Console.WriteLine(message);
                isCorrect = Int32.TryParse(Console.ReadLine(), out num);
                if (!isCorrect)
                    Console.WriteLine(errorMessages[0]);
                if (!IntValidateBord(num, min, max))
                {
                    Console.WriteLine(errorMessages[1]);
                    isCorrect = false;
                }
            } while (!isCorrect);

            return num;
        }
    }
}
