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

//referances
//inspired by rudolph's speech chat bot code
namespace CyberSecruityHelpChatBotPoe.MyClasses
{
    class ChatBotClass
    {
        bool Flag = true;//flag while loop to determine when user is done asking questions
        bool Flag2 = true;// flag to determine if its the first time question for different message to be shown to user
        bool Flag3 = true;// flag used to loop if invalid or no answer avalible to user so they dont have to get a message prompting to go again and have to say yes to new question
        bool FlagNameVal = false;//flag to check if user input is valid for username
        bool FlagInputQuesVal = false;//flag used to loop userinput till valid input is given
        bool GoAgainValue = true;
        bool SameAnswerFlag = true; // flag to check if the same answer is returned

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
 
            Console.WriteLine("Succesfully created");
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
            bool SameAnswerFlag = false;
            var searchValue = string.Empty; // Variable to store the user input
            var previousAnswer = string.Empty; // Variable to store the previous answer
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
                    validationFlag = false; // Input is valid, exit the loop
                }
            }
            while (keepGoing)
            {
                var answer = Data.SearchUserInput(searchValue);

                if (answer == previousAnswer)
                { SameAnswerFlag = true; }

                while (SameAnswerFlag) 
                {
                    answer = Data.SearchUserInput(searchValue);
                    if (!(answer == previousAnswer)) 
                    { 
                        SameAnswerFlag = false;
                    }
                }

                AnsiConsole.Markup($"[green]{answer}[/]");
                this.SpeechClassObject.Talk(answer);

                previousAnswer = answer; // Store the previous answer for comparison

                Console.WriteLine("\n" + new string('-', 80));

                Console.Write("Would you like to know more? (Y/N) ");
                var more = Console.ReadLine()?.Trim().ToLower();
                if (more == "n")
                    keepGoing = false;
                
            }
        }

        /*
        public void UserInputStart()
        {
            
                if (Flag2)
                {
                    AnsiConsole.Markup("[green]Hello, this is a chatbot that is designed to answer basic questions on cyber security that you may have.[/]");
                    Console.WriteLine();
                    Console.WriteLine("--------------------------------------------------------------------------------------------");
                    this.SpeechClassObject.Talk("Hello, this is a chatbot that is designed to answer basic questions on cyber security that you may have.");
                    Flag2 = false;// Sets flag to false so this message is only gets shown once to user
                }
                else
                {
                    Flag3 = true; //sets flag to true after looping for validation and searching of user input for any other questions that follow
                    Console.WriteLine("--------------------------------------------------------------------------------------------");
                    this.SpeechClassObject.Talk("Please ask another question");
                    AnsiConsole.Markup("[green]Please ask another question[/]");
                    Console.WriteLine();
                    Console.WriteLine("--------------------------------------------------------------------------------------------");

            }
            while (Flag3)//used to check if no results are found in the dictionary and loop to ask user for another question or reword the question
            {
                FlagInputQuesVal = false; //sets flag to false so the loop can be used to check if user input is valid even if mutiple questions are asked

                while (!FlagInputQuesVal)//loop to ensure user input username is valid 
                {
                    AnsiConsole.Markup("[green]Please enter your question:   [/]"); //prompt user for input
                    Console.WriteLine();
                    String SearchValue = Console.ReadLine().ToLower(); 
                    Console.WriteLine("--------------------------------------------------------------------------------------------");

                    if (string.IsNullOrWhiteSpace(SearchValue) || int.TryParse(SearchValue, out _))//null and int check validation // used chat to get the int validation syntax
                    {
                        this.SpeechClassObject.Talk("Please enter a valid Question that is not blank(Null) or a Number");
                        AnsiConsole.Markup("[red]Please enter a valid Question that is not blank(Null) or a Number[/]");
                        Console.WriteLine();//for readability
                        Console.WriteLine("--------------------------------------------------------------------------------------------");
                    }
                    else
                    {
                        
                        string failmessage = "No value found, Sorry could you please try again with differant wording or a differant question";// copy of fail message to compare with result string
                        var previousResult = "Nothing FOR NOW";

                        while (GoAgainValue)
                        {
                            var result = "Nothing for now";
                            SameAnswerFlag = true; //rests flag

                            while (SameAnswerFlag) 
                           {
                                result = this.Data.SearchUserInput(SearchValue);// passes user input to search method
                                if (!(result == previousResult)||(result==failmessage))
                                { 
                                    SameAnswerFlag = false; 

                                }
                           }

                        previousResult = result;
                        AnsiConsole.Markup("[green]" + result + "[/]");

                        Console.WriteLine();
                        Console.WriteLine("--------------------------------------------------------------------------------------------");
                        this.SpeechClassObject.Talk(result);

                        Console.WriteLine("Would you like to know more about this topic ? Type N for no");
                        this.SpeechClassObject.Talk("Would you like to know more about this topic? Type N for no");
                        

                        if (!result.Equals(failmessage))//used to break from while loop if value is found in the dictionary 
                        {
                            Flag3 = false;
                        }
                            var GoAgainSearchValue = Console.ReadLine();
                            if (String.Equals(GoAgainSearchValue, "n",StringComparison.OrdinalIgnoreCase))
                            {
                                Flag3 = false;
                                FlagInputQuesVal = true;
                                GoAgainValue = false;
                            }
                            FlagInputQuesVal = true; //sets flag to true if user input is valid// not sure if this is redundant
                        }
                    }

                }
               
            }
       
        }*/
        
    }
    //-----------------------------------------------END OF FILE---------------------------------------------------//
}
