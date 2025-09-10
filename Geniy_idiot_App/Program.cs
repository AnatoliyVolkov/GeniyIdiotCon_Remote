using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace GeniyIdiotApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добрый день, вы сейчас будете проходить тест на определение вашей гениальности.\nПожалуйста введите свое имя.");
            var userName = GetValidUserName();
            Console.WriteLine($"Добро пожаловать {userName}! Мы приступаем.");

            var restart = true;
            while (restart)
            {
                var score = RunTest(userName);
                ShowResults(userName, score);
                Console.WriteLine($"{userName} хотите пройти тест еще раз?");
                restart = DiagnosticTestResources.GetRestartQuestion(Console.ReadLine(), userName);
            }
        }

        static string GetValidUserName()
        {
            while (true)
            {
                try
                {
                    var name = Console.ReadLine();
                    return DiagnosticTestResources.GetUserInput(name);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Повторите попытку ввода еще раз.");
                }
            }
        }

        static int RunTest(string userName)
        {
            var countRightAnswers = 0;
            var questionOrder = DiagnosticTestResources.GetMixiForQuestion();

            for (var i = 0 ; i < DiagnosticTestResources.Questions.Count ; i++)
            {
                var questionIndex = questionOrder[i];

                Console.WriteLine($"Вопрос номер: {i + 1}");
                Console.WriteLine(DiagnosticTestResources.Questions[questionIndex]);

                countRightAnswers += GetProcessAnswer(userName, questionIndex);
            }

            return countRightAnswers;
        }

        static int GetProcessAnswer(string userName, int questionIndex)
        {
            while (true)
            {
                try
                {
                    var userInput = Console.ReadLine();

                    if (short.TryParse(userInput, out var answer))
                    {
                        return answer == DiagnosticTestResources.Answers[questionIndex] ? 1 : 0;
                    }

                    Console.WriteLine($"{userName}, вы ввели букву, а нужно число, введите корректное число не длинее 6 знаков.");
                }
                catch
                {
                    Console.WriteLine($"{userName}, произошла ошибка. Попробуйте еще раз.");
                }
            }
        }

        static void ShowResults (string userName, int answer)
        {
            Console.WriteLine($"{userName}, вы ответили верно на {answer} вопросов.");
            Console.WriteLine($"Ваш результат: {DiagnosticTestResources.Diagnoses[answer]}");
        }
    }
}
