using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static CyberSecruityHelpChatBotPoe.MyClasses.SpeechClass;
using Spectre.Console;

//referances chatGPT + rudolph's speech chat bot code
namespace CyberSecruityHelpChatBotPoe.MyClasses
{
    class ChatBotClass
    {
        List<String> UserSearchedValues = new List<string>(); // List to store previously searched values
        private readonly Random _rng = new Random();
        bool Flag = true;//flag while loop to determine when user is done asking questions
        bool SecondQuestionFlag = false; // Flag to check if the user is asking a second question
        string previousAnswer = string.Empty;
        bool FlagNameVal = false;//flag to check if user input is valid for username    
        string UserName = string.Empty; // variable to store username

        private SpeechClass SpeechClassObject = new SpeechClass();

        private DictionaryClass Data = new DictionaryClass();

        /// <summary>
        /// Constructor for the ChatBotClass
        /// </summary>
        public ChatBotClass()
        {
            String[] logo = new[]//ASCI LOCK logo to represet the cybersecurity help chat bot ps I suck at art so this is supposed to be a lock
            {
                "------++++-----------++++---+++-------+++---+++++++---+++++++---+++++++---------------------",
                "-----++--++--------+++-------+++-----+++----++---++---+++++++---++---++---------------------",
                "----+++---+++-----+++---------+++---+++-----++---++---++--------++--++----------------------",
                "---+++-----+++----+++----------+++++++------++--++----++--------++-++-----------------------",
                "---+++++++++++----+++-----------+++++-------++++------+++++++---++++------------------------",
                "---+++++++++++----+++-----------+++++-------++--++----++--------++-++-----------------------",
                "---+++++++++++----+++-----------+++++-------++---++---++--------++--++----------------------",
                "---+++++++++++-----+++----------+++++-------++---++---+++++++---++---++---------------------",
                "---+++++++++++------++++--------+++++-------+++++++---+++++++---++----++--------------------",
                "--------------------------------------------------------------------------------------------"
            };
            String[] WelcomeMess = new[]//ASCI for welcome message // tried to use chatgpt to make asci didnt work very well so heavily edited but the welcome was orginally generated
            {
                "---++------++---+++++++-++---------++++----+++++++--+-----+--+++++++------------------------",  
                "---++------++---+++++++-++--------+++------+-----+--++---++--+++++++------------------------",
                "---++------++---++------++-------+++-------+-----+--+-+-+-+--++-----------------------------",
                "---++--++--++---++------++------+++--------+-----+--+--+--+--++-----------------------------",
                "---++-+--+-++---+++++++-++------+++--------+-----+--+-----+--+++++++------------------------",
                "---+++----+++---++------++------+++--------+-----+--+-----+--++-----------------------------",
                "---++------++---++------++-------+++-------+-----+--+-----+--++-----------------------------",
                "---++------++---+++++++-++--------+++------+-----+--+-----+--+++++++------------------------",
                "---++------++---+++++++-+++++++----++++----+++++++--+-----+--+++++++------------------------",
                "--------------------------------------------------------------------------------------------"
            };

            SoundPlayer GreetingAudio = new SoundPlayer(Properties.Resources.Recording);// creating an instance of soundplayer 
            GreetingAudio.Play();//plays greeting audio file

            Console.ForegroundColor = ConsoleColor.Blue;//to set color for style of text
            foreach (var line in logo)//ASCI lock logo
            {
                Console.WriteLine(line);
                }
            Console.ResetColor();//clears color

            while (!FlagNameVal)//loop to ensure user input username is valid 
            {
                AnsiConsole.Markup("[green]What is your name? : [/]");

                var username = Console.ReadLine();//stores user input username for both validation and greeting

                if (string.IsNullOrWhiteSpace(username)|| int.TryParse(username, out _))//null and int check validation // used chat to get the int validation syntax
                {
                    this.SpeechClassObject.Talk("Please enter a valid Username that is not blank(Null) or a Number");
                    AnsiConsole.Markup("[red]Please enter a valid name that is not blank(Null) or a Number[/]");
                    Console.WriteLine();//makes it easier to read by giving a space between output and ------ break
                    Console.WriteLine("--------------------------------------------------------------------------------------------");
                }
                else
                {
                    UserName = username; //sets username variable to user input for later use 

                    Console.ForegroundColor = ConsoleColor.Blue;
                    foreach (var line in WelcomeMess)//asci welcome message
                    {
                        Console.WriteLine(line);
                    }
                    Console.ResetColor();
                    AnsiConsole.Markup("[green]Hello :" + username + " ![/]");
                    this.SpeechClassObject.Talk("Hello :" + username + " !");
                    Console.WriteLine();
                    Console.WriteLine("--------------------------------------------------------------------------------------------");
                    FlagNameVal = true; //sets flag to true if user input is valid
                }
                
            }
 
            while (Flag)
            {
                UserInputStart(); //calling method for prompting user for input 
                this.SpeechClassObject.Talk("Would you like to ask another question? Type N for no");
                AnsiConsole.Markup("[yellow]Would you like to ask another question? (Y/N)[/]"); //prompt user if they want to ask another question
                Console.WriteLine();
                Console.WriteLine("--------------------------------------------------------------------------------------------");
                if (Console.ReadLine().ToUpper() == "N")
                {
                    AnsiConsole.Markup("[green]Bye![/]");
                    this.SpeechClassObject.Talk("BYYEE!");
                    Flag = false; //Sets flag to false if user wants to exit the loop
                }
            }
        }

        /// <summary>
        /// Method use to prompt user for input and pass it through appropriate methods
        ///<summary>
        ///
        public void UserInputStart()
        {
           
            bool keepGoing = true;
            bool validationFlag = true; // Flag to check if the input is valid
            bool SameAnswerFlag = true;
            bool RandomAnserFlag = true;
            var searchValue = string.Empty; // Variable to store the user input
             

            AnsiConsole.Markup("[green]Hello, this is a chatbot…[/]");
            Console.WriteLine("\n" + new string('-', 80));
            
            while (validationFlag)
            {
                AnsiConsole.Markup("[green]Please enter your question:[/]");
                this.SpeechClassObject.Talk("Please enter your question: ");

                searchValue = Console.ReadLine()?.Trim();

                if (string.IsNullOrWhiteSpace(searchValue) || int.TryParse(searchValue, out _))
                {
                    AnsiConsole.Markup("[red]Invalid, please enter a non null or non integer value please[/]");
                    this.SpeechClassObject.Talk("Invalid, please enter a non null or non integer value please");
                    Console.WriteLine("\n" + new string('-', 80));
                
                }
                else
                {
                    var answer2 = Data.SearchUserInput(searchValue); // Call the method to search for the user input
                    if (!(answer2 == "No value found, sorry. Could you please try again with different wording or a different question?"))
                       {
                        validationFlag = false; // Input is valid, exit the loop
                       }
                    if (validationFlag)
                       Console.WriteLine("No value found, sorry. Could you please try again with different wording or a different question?");
                }
            }
            while (keepGoing)
            {
                
                UserSearchedValues.Add(searchValue); // Add the current search value to the list
                var answer = Data.SearchUserInput(searchValue);

                var sentimentResponse = Data.SearchUserSentiment(searchValue); // Gets sentiment response

                if (answer == previousAnswer) //  Check if the answer is the same as the previous one
                { SameAnswerFlag = true; }

                while (SameAnswerFlag) 
                {
                    answer = Data.SearchUserInput(searchValue);
                    if (!(answer == previousAnswer)) //used to check if the answer is not the same 
                    { 
                        SameAnswerFlag = false;
                    }
                }
                if (SecondQuestionFlag)
                {
                    var randomAnswer = UserSearchedValues[_rng.Next(UserSearchedValues.Count)];
                    while (RandomAnserFlag) //used to make sure the random answer is not the same as the current search value
                    {

                        if (!(randomAnswer == searchValue))
                        {
                           RandomAnserFlag = false; // Break the loop if the random answer is different from the current search value
                        }
                        else
                        {
                            randomAnswer = UserSearchedValues[_rng.Next(UserSearchedValues.Count)];//used to randomly select a previous question to be passed into later
                        }
                    }

                    if (!(sentimentResponse == "No sentiment found in the dictionary"))
                    {
                        AnsiConsole.Markup($"[green]{UserName +" "+sentimentResponse +" here is your answer :" + answer + ": Based on your previous questions you might want to know this fact: " + Data.SearchUserInput(randomAnswer)}[/]");
                        this.SpeechClassObject.Talk(UserName + sentimentResponse + " here is your answer :" + answer);
                    }
                    else
                    {
                        AnsiConsole.Markup($"[green]{UserName + " here is your answer :" + answer + ": Based on your previous questions you might want to know this fact: " + Data.SearchUserInput(randomAnswer)}[/]");
                        this.SpeechClassObject.Talk(UserName +" here is your answer :" + answer);
                    }
                    

                }
                else if(SecondQuestionFlag==false)
                {

                    if (!(sentimentResponse == "No sentiment found in the dictionary"))
                    {
                        AnsiConsole.Markup($"[green]{UserName +" "+ sentimentResponse + " here is your answer :" + answer}[/]");
                        this.SpeechClassObject.Talk(UserName + sentimentResponse +" here is your answer :" + answer);
                    }
                    else 
                    {
                        AnsiConsole.Markup($"[green]{UserName + " here is your answer :" + answer}[/]");
                        this.SpeechClassObject.Talk(UserName + " here is your answer :" +answer);
                    }

                     
                 }
                
                previousAnswer = answer; // Store the previous answer for comparison

                Console.WriteLine("\n" + new string('-', 80));

                Console.Write("Would you like to know more? (Y/N) ");
                var more = Console.ReadLine()?.Trim().ToLower();
                if (more == "n")
                {
                    SecondQuestionFlag = true;//breaks while loop to allow user to ask another question
                    keepGoing = false;
                }
            }
        }

       
        
    }
    //-----------------------------------------------END OF FILE---------------------------------------------------//
}
