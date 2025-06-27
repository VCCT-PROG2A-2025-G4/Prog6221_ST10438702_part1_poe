using ChatBotPoePart3Gui.MyClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ChatBotPoePart3Gui.MyClasses.ChatBotClass;
using static ChatBotPoePart3Gui.MyClasses.QuizClass;

namespace ChatBotPoePart3Gui
{
    public partial class Form1 : Form
    {
        private readonly ChatBotClass _bot = new ChatBotClass();
        private SpeechClass SpeechClassObject = new SpeechClass();
        private QuizClass _quiz;
        private int _lastTaskIndex = -1;
        Boolean introFlag = false;
        int reminder = 0;


        public Form1()
        {
            InitializeComponent();
            ShowIntro();

            // Optional: Allow Enter key to send
            UserInputText.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnSend.PerformClick();
                    e.SuppressKeyPress = true;
                }
            };

            var questions = new List<Question>// chatgpt used to generate these questions and answers
        {
            new Question {
                Text = "What is phishing?",
                Options = new[]
        {
            "A type of malware that locks your files",
            "An encryption method for emails",
            "A firewall setting",
            "A social engineering attack that tricks you into giving personal data",
        },
                CorrectIndex = 3,
                Explanation = "Phishing relies on tricking people, e.g. via fake emails, to hand over their credentials."
            },
            new Question
    {
            Text = "Which of these is the strongest password?",
            Options = new[]
            {
                "P@ssw0rd123",
                "4&thOrseb4tteryStapl3!",
                "12345678",
                "qwerty"
            },
            CorrectIndex = 1,
            Explanation = "4&thOrseb4tteryStapl3! is the strongest password because it contains special chars , intgers and letters while not being common"
    },
            new Question
    {
                Text = "What does 2FA (two-factor authentication) require?",
                Options = new[]
                {
                    "Two people to log in",
                    "Password + a second method of authentication",
                    "Extra long password",
                    "Password + username"
                },
                CorrectIndex = 1,
                Explanation = "Two factor authentication is the practice of having 2 separate means of account authentication"
    },
            new Question
    {
                Text = "Which practice helps protect you on public Wi-Fi?",
                Options = new[]
                {
                    "Sharing your screen",
                    "Using a VPN (Virtual Private Network)",
                    "Disabling antivirus",
                    "Downloading files only from torrents"
                },
                CorrectIndex = 1,
                Explanation = "A VPN encrypts your internet connection on public Wi-Fi, creating a secure tunnel that prevents others on the same network from intercepting or viewing your data."
    },
            new Question
    {
                Text = "What is social engineering?",
                Options = new[]
                {
                    "Engineering software to detect people",
                    "Hacking hardware directly",
                    "Manipulating people to reveal confidential info",
                    "Encrypting data securely"
                },
                CorrectIndex = 2,
                Explanation = "Social engineering is the practise of tricking people to bye pass cyber secruity"
    },
            new Question
    {
                Text = "Which URL looks safest to visit?",
                Options = new[]
                {  
                    "https://secure-example.com",
                    "http://bank.example.com.login.page",
                    "ftp://secure-example.com",
                    "https://bank.secure-example.com.fake"
                },
                CorrectIndex = 0,
                Explanation = "Look for HTTPS and ensure the url is correct with no added values to trick users"
    },
            new Question
    {
                Text = "What should you do before opening an unexpected email attachment?",
                Options = new[]
                {
                    "Open it in Safe Mode",
                    "Forward it to everyone you know",
                    "Ensure the sender is correct and don't click",
                    "Rename the file extension"
                },
                CorrectIndex = 2,
                Explanation = "Don't open email attachments without ensuring you know the sender is and that they are who you thing they"
    },
            new Question
    {
                Text = "Why keep your software up to date?",
                Options = new[]
                {
                    "To get new wallpapers",
                    "To increase CPU usage",
                    "To delete old files",
                    "To patch security vulnerabilities"
                },
                CorrectIndex = 3,
                Explanation = "Old software might have know vulnerabilities that might be patched in latest versions of software"
    },
            new Question
    {
                Text = "What is the main purpose of encryption?",
                Options = new[]
                {
                    "To speed up your internet",
                    "To scramble data so only authorized parties can read it",
                    "To make files smaller",
                    "To change file formats"
                },
                CorrectIndex = 1,
                Explanation = "Encryption is used to secure data and communication digitally"
    },
            new Question
    {
                Text = "How can you verify a website is using HTTPS correctly?",
                Options = new[]
                {
                    "By checking for a padlock icon in the address bar",
                    "By refreshing the page twice",
                    "By disabling browser extensions",
                    "By right-clicking and selecting 'View Source'"
                },
                CorrectIndex = 0,
                Explanation = "HTTPS combined with the padlock will help ensure that a website is using HTTPS correctly by clicking on the padlock"
    }
    
    };
            _quiz = new QuizClass(questions);

            LoadCurrentQuestion();

        }



        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            String inputText = UserInputText.Text.Trim();
            

            if (string.IsNullOrWhiteSpace(inputText))
            {
                MessageBox.Show("Please enter a valid non null value!!!");
                return;
            }

            if (introFlag == true)
            {
                //checks if user input is a new task and if it is valid
                if (_bot.CheckTask(inputText))
                  {
                    _bot.addTask(inputText);// adds the task to the bot's task list
                    _lastTaskIndex = _bot.Tasks.Count - 1;
                    RefreshTaskList();
                    

                    var last = _bot.Tasks.Last();
                    ChatResponse.AppendText(
                             $"🗒️ Task added:\n" +
                             $"   Title: {last.Title}\n" +
                             $"   Description: {last.Description}\n" +
                             $"   Reminder: {last.Reminder}\n\n");
                    Log($"Task added: Title=\"{last.Title}\", Description=\"{last.Description}\"");

                    ChatResponse.AppendText(Environment.NewLine+"Would you like to set a reminder for that task?"
                        );
                    UserInputText.Clear();
                  
                    return;  
                  }


                    // pass user input to method that will take data and give valid output
                var response = _bot.GetResponse(inputText, out var extraFact);
                Log($"Question asked: {inputText}");
                Log($"Chat response: {response}");

                // Display both user and bot chat in the chat response box
                ChatResponse.AppendText($"User: {inputText}{Environment.NewLine}");
                ChatResponse.AppendText($"Bot: {response}{Environment.NewLine}");

                this.SpeechClassObject.Talk(response);

                if (!string.IsNullOrEmpty(extraFact))
                    ChatResponse.AppendText($"💡 Also: {extraFact}{Environment.NewLine}");

                // Clear input for next question
                UserInputText.Clear();
                UserInputText.Focus();
                ChatResponse.Text += "Please enter a question or Add a task" + Environment.NewLine;
                this.SpeechClassObject.Talk("Please enter you a question or Add a task");
            }
            else if (introFlag == false)
            {  
                var Username = UserInputText.Text.Trim();

                ChatResponse.Clear();
                UserInputText.Clear();
                ChatResponse.AppendText($"Hello {Username}, Welcome to the ChatBot!{Environment.NewLine}");
                ChatResponse.Text += "Please enter a question or Add a task" + Environment.NewLine;
                this.SpeechClassObject.Talk("Please enter a question or Add a task");
                introFlag = true; // Set the flag to true after the first interaction
            } 

           
        }



        private async void ShowIntro()
        {
            // Your ASCII arrays
            string[] logo = {
                "------++++-----------++++---+++-------+++---+++++++---+++++++---+++++++------",
                "-----++--++--------+++-------+++-----+++----++---++---+++++++---++---++------",
                "----+++---+++-----+++---------+++---+++-----++---++---++--------++--++-------",
                "---+++-----+++----+++----------+++++++------++--++----++--------++-++--------",
                "---+++++++++++----+++-----------+++++-------++++------+++++++---++++---------",
                "---+++++++++++----+++-----------+++++-------++--++----++--------++-++--------",
                "---+++++++++++----+++-----------+++++-------++---++---++--------++--++-------",
                "---+++++++++++-----+++----------+++++-------++---++---+++++++---++---++------",
                "---+++++++++++------++++--------+++++-------+++++++---+++++++---++----++-----",
                "-----------------------------------------------------------------------------"
        };


            ChatResponse.Clear();
          
            foreach (var line in logo)
            {
                // Print each character in the line
                foreach (char c in line)
                {
                    ChatResponse.AppendText(c.ToString());
                }
                ChatResponse.AppendText(Environment.NewLine); // Move to the next line after each line is printed
            }

            SoundPlayer GreetingAudio = new SoundPlayer(Properties.Resources.Recording);// creating an instance of soundplayer 
            GreetingAudio.Play();



            await Task.Delay(3000);
            ChatResponse.Clear();
            ChatResponse.AppendText(Environment.NewLine + "What is your Name ?" + Environment.NewLine);

        }

        private void ReminderIntBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void reminderBtn_Click(object sender, EventArgs e)
        {

            // vallidates value of reminder up down control
            if (_lastTaskIndex < 0 || _lastTaskIndex >= _bot.Tasks.Count)
            {
                MessageBox.Show("You must add a task first before setting a reminder.");
                return;
            }

            
            int days = (int)ReminderUpDown.Value;

            
            _bot.UpdateTaskReminder(_lastTaskIndex, days);
            RefreshTaskList();
           

            var task = _bot.Tasks[_lastTaskIndex];
            ChatResponse.AppendText(
                $"🔔 Reminder for “{task.Title}” set to {task.Reminder} days.{Environment.NewLine}{Environment.NewLine}");
            Log($"Reminder set: Task=\"{task.Title}\", In={days} min");
        }

        private void RefreshTaskList()
        {
            // Use a binding list so that the grid will update if you add/remove items
            var binding = new BindingList<TaskItem>(_bot.Tasks.ToList());
            ReminderDataGrid.DataSource = binding;

            
            ReminderDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (ReminderDataGrid.CurrentRow == null)
            {
                MessageBox.Show("Please select a task to delete.");
                return;
            }

            // The row’s index matches the task index
            int idx = ReminderDataGrid.CurrentRow.Index;

            // Remove it from the bot
            _bot.DeleteTask(idx);

            // Refresh the grid to show the change
            RefreshTaskList();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnEnterQuiz_Click(object sender, EventArgs e)
        {
            var rbs = new[] { rbtn1, rbtn2, rbtn3, rbtn4 };
            int selectedIndex = Array.FindIndex(rbs, rb => rb.Checked);
            if (selectedIndex < 0)
            {
                MessageBox.Show("Please choose an answer.");
                return;
            }

      
            var q = _quiz.CurrentQuestion;                
            bool correct = _quiz.SubmitAnswer(selectedIndex);
            

            if (correct)
            {
                // Show the explanation for the correct answer
                txtboxAnswer.Text = "✅ Correct! " + q.Explanation;
            }
            else
            {
                // Show which option was right, plus the explanation
                string rightText = q.Options[q.CorrectIndex];
                txtboxAnswer.Text = $"❌ Incorrect. The correct answer was “{rightText}”.\n{q.Explanation}";
            }
            
            


            ScoreLabel.Text = $"Score: {_quiz.Score}/{_quiz.CurrentIndex}";

            
            btnEnterQuiz.Enabled = false;
            nextbtn.Enabled = true;

        }

        private void nextbtn_Click(object sender, EventArgs e)
        {
            if (_quiz.IsFinished)
            {
                Log($"Quiz completed: Score={_quiz.Score}/{_quiz.TotalQuestions}");

                // All done—time for the final message
                if (_quiz.Score == _quiz.TotalQuestions)
                {
                    MessageBox.Show(
                        $"🎉 Well done! You got every question right: {_quiz.Score}/{_quiz.TotalQuestions}!",
                        "Quiz Complete",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(
                        $"✅ You scored {_quiz.Score} out of {_quiz.TotalQuestions}.\nKeep learning and try again!",
                        "Quiz Complete",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }

                return;
            }

            // loads next question
            LoadCurrentQuestion();
        }
        private void LoadCurrentQuestion()
        {
            var q = _quiz.CurrentQuestion;
            if (q == null) return;  

            
            QuestionNum.Text = q.Text;

            
            var rbs = new[] { rbtn1, rbtn2, rbtn3, rbtn4 };
            for (int i = 0; i < rbs.Length; i++)
            {
                rbs[i].Text = $"{(char)('A' + i)}) {q.Options[i]}";
                rbs[i].Checked = false;
            }

            
            txtboxAnswer.Text = "";
            btnEnterQuiz.Enabled = true;
            nextbtn.Enabled = false;

            
            ScoreLabel.Text = $"Score: {_quiz.Score}/{_quiz.CurrentIndex}";
        }

        //logger for timestamps
        private void Log(string message)
        {
            if (!txtbLog.Multiline)
                txtbLog.Multiline = true;

            
            var entry = $"{DateTime.Now:HH:mm:ss} – {message}{Environment.NewLine}";
            txtbLog.AppendText(entry);

            // Scroll to bottom so the newest entry is visible
            txtbLog.SelectionStart = txtbLog.Text.Length;
            txtbLog.ScrollToCaret();
        }

    }
}
