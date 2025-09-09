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
                var countRightAnswers = 0;
                var questionNumber = DiagnosticTestResources.GetMixiForQuestion();
                for (var i = 0 ; i < DiagnosticTestResources.Questions.Count ; i++)
                {
                    Console.WriteLine($"Вопрос номер: {i + 1}");
                    var numberQuestion = questionNumber[i];
                    Console.WriteLine(DiagnosticTestResources.Questions[numberQuestion]);
                    var returnNumberUser = true;
                    while (returnNumberUser)
                    {
                        try
                        {
                            if (DiagnosticTestResources.Answers[numberQuestion] == short.Parse(Console.ReadLine()))
                                countRightAnswers++;
                            returnNumberUser = false;
                        }
                        catch
                        {
                            Console.WriteLine($"{userName}, вы ввели букву, а нужно число, введите корректное число не длинее 6 знаков.");
                            returnNumberUser = true;
                        }
                    }
                }
                Console.WriteLine($"{userName}, вы ответили верно на {countRightAnswers} вопросов.\nВаш результат {DiagnosticTestResources.Diagnoses[countRightAnswers]}.");
                Console.WriteLine($"{userName} хотите пройти тест еще раз?");
                restart = DiagnosticTestResources.GetRestartQuestion(Console.ReadLine(), userName);
            }
        }
        public static string GetValidUserName()
        {
            while (true)
            {
                try
                {
                    var name = Console.ReadLine();
                    return DiagnosticTestResources.UserInput(name);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Повторите попытку ввода еще раз.");
                }
            }
        }
    }

}
