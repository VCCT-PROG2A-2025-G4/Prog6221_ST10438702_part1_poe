using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;
using static ChatBotPoePart3Gui.MyClasses.SpeechClass;


namespace ChatBotPoePart3Gui.MyClasses
{

    public class ChatBotClass
    {
        private readonly DictionaryClass Data = new DictionaryClass();
        private readonly Random _rng = new Random();
        private readonly List<TaskItem> _tasks = new List<TaskItem>();
        public IReadOnlyList<TaskItem> Tasks => _tasks;

        // Simplified: takes user input, returns bot reply (plus optional extra fact)
        public string GetResponse(string userInput, out string extraFact)
        {
            extraFact = null;

            //  Primary answer
            var answer = Data.SearchUserInput(userInput);

            //  Sentiment prefix (if any)
            var sentiment = Data.SearchUserSentiment(userInput);
            var fullAnswer = sentiment != "No sentiment found in the dictionary"
                ? $"{sentiment} Here’s your answer: {answer}"
                : $"Here’s your answer: {answer}";

            //  Optional extra fact from previous questions
            //    (assumes you stored past queries in a List<string> PastQuestions)
            if (PastQuestions.Count > 0)
            {
                var randomPast = PastQuestions[_rng.Next(PastQuestions.Count)];
                if (randomPast != userInput)
                    extraFact = Data.SearchUserInput(randomPast);
            }

            //  Track this question
            PastQuestions.Add(userInput);

            return fullAnswer;
        }

        // A list to hold past queries
        private List<string> PastQuestions { get; } = new List<string>();



        // method to check if user input is a new task and if new task is valid
        public bool CheckTask(string inputText)
        {
            bool validState = false;

            const string prefix = "add task";
            // Check if the input starts with the prefix "add task"
            if (inputText.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
            {
                var response = GetResponse(inputText, out var extraFact);
                if (!(response=="No value found, sorry. Could you please try again with different wording or a different question?")) 
                {
                    validState = true;
                }
            }

            return validState;
        }

        // creates a new task to be tracked
        public void addTask(string inputText)
        {
            var description = GetResponse(inputText, out var extraFact);

            const string prefix2 = "Here’s your answer:";

            // If the response starts with it, remove it:
            if (description.StartsWith(prefix2, StringComparison.OrdinalIgnoreCase))
            {
                description = description.Substring(prefix2.Length);
            }

            const string prefix = "add task ";

            var title = inputText.Length > prefix.Length
             ? inputText.Substring(prefix.Length).Trim()
                                  : "No title provided";
            int reminder = 0;


     
            var task = new TaskItem
            {
                Title = title,
                Description = description,
                Reminder = reminder
            };
            _tasks.Add(task);
        }
        public class TaskItem
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public int Reminder { get; set; }
            public bool IsCompleted { get; set; } = false;
        }


        public void UpdateTaskReminder(int index, int minutes)
        {
            if (index >= 0 && index < _tasks.Count)
                _tasks[index].Reminder = minutes;
            
        }

        public void DeleteTask(int index)
        {
            if (index < 0 || index >= _tasks.Count)
                throw new ArgumentOutOfRangeException(nameof(index));
            _tasks.RemoveAt(index);
        }

    }
    
}
//-----------------------------------------------END OF FILE---------------------------------------------------//


