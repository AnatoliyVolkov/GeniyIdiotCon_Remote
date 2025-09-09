using System;
using System.Collections.Generic;
using System.Linq;

namespace GeniyIdiotApp
{
    public static class DiagnosticTestResources
    {
        public static List<string> Questions = new List<string>()
    {
        "Сколько будет два плюс два умноженное на два?",
        "Бревно нужно распилить на 10 частей. Сколько распилов нужно сделать?",
        "На двух руках 10 пальцев. Сколько пальцев на 5 руках?",
        "Укол делают каждые полчаса. Сколько нужно минут, чтобы сделать три укола?",
        "Пять свечей горело, три потухли. Сколько свечей осталось?"
    };
        public static List<int> Answers = new List<int>() { 6, 9, 25, 60, 2 };
        public static List<string> Diagnoses = new List<string>()
    {
        "Кретин",
        "Идиот",
        "Дурак",
        "Нормальный",
        "Талант",
        "Гений",
    };

        public static List<int> GetMixiForQuestion()
        {
            var randomQuestion = new Random();
            var questionIndexes = Enumerable.Range(0, Questions.Count).ToList();
            for (var i = questionIndexes.Count - 1 ; i > 0 ; i--)
            {
                var j = randomQuestion.Next(i + 1);
                (questionIndexes[i], questionIndexes[j]) = (questionIndexes[j], questionIndexes[i]);
            }
            return questionIndexes;
        }
        public static string UserInput(string name)
        {

            if (string.IsNullOrEmpty(name) || short.TryParse(name, out var number))
            {
                throw new Exception("Нельзя вводить числа и оставлять поле пустым, будьте внимательней");
            }
            else
            {
                var nameUser = name.Substring(0, 1).ToUpper() + name.Substring(1).ToLower();
                return nameUser;
            }
        }
        public static bool GetRestartQuestion(string answer, string name)
        {
            if (answer != "Да" && answer != "дА" && answer != "да" && answer != "ДА")
            {
                Console.WriteLine($"Спасибо {name}, что прошли наш тест. Всего хорошего.");
                return false;
            }
            else return true;

        }
    }

}
