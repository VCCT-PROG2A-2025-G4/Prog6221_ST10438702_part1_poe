using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBotPoePart3Gui.MyClasses
{
    internal class QuizClass
    {
        public int TotalQuestions => _questions.Count;//counts the total number of questions in the quiz

        private readonly List<Question> _questions;
        public int CurrentIndex { get; private set; }
        public int Score { get; private set; }

        public QuizClass(IEnumerable<Question> questions)
        {
            _questions = questions.ToList();
            CurrentIndex = 0;
            Score = 0;
        }

        public Question CurrentQuestion =>
       (CurrentIndex < _questions.Count) ? _questions[CurrentIndex] : null;

        public bool SubmitAnswer(int selectedIndex)
        {
            bool correct = (CurrentQuestion.CorrectIndex == selectedIndex);
            if (correct) Score++;
            CurrentIndex++;
            return correct;
        }

        public bool IsFinished => CurrentIndex >= _questions.Count;


    }
}
