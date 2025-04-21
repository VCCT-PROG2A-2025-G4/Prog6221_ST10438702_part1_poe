using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static CyberSecruityHelpChatBotPoe.MyClasses.SpeechClass;

namespace CyberSecruityHelpChatBotPoe.MyClasses
{
    class ChatBotClass
    {
        bool Flag = true;//flag while loop to determine when user is done asking questions
        bool Flag2 = true;// flag to determine if its the first time question for different message to be shown to user
        bool Flag3 = true;// flag used to loop if invalid or no answer avalible to user so they dont have to get a message prompting to go again and have to say yes to new question
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

            SoundPlayer GreetingAudio = new SoundPlayer(Properties.Resources.Recording);// creating an instance of soundplayer 
            GreetingAudio.Play();//plays greeting audio file
            
            
            foreach(var line in logo)
                {
                Console.WriteLine(line);
                }
            
            Console.Write("What is your name? :");

            var username = Console.ReadLine();//prompt user for their name
            Console.WriteLine("Hello :" +username+" !");
            this.SpeechClassObject.Talk("Hello :" + username + " !");
            Console.WriteLine("--------------------------------------------------------------------------------------------");

            Console.WriteLine("Succesfully created");
            while (Flag)
            {
                UserInputStart(); //calling method for prompting user for input
                this.SpeechClassObject.Talk("Would you like to ask another question? Type N for no");
                Console.WriteLine("Would you like to ask another question? (Y/N)"); //prompt user if they want to ask another question
                Console.WriteLine("--------------------------------------------------------------------------------------------");
                if (Console.ReadLine().ToUpper() == "N")
                {
                    Console.WriteLine("Bye!");
                    this.SpeechClassObject.Talk("BYYEE!");
                    Flag = false; //Sets flag to false if user wants to exit the loop
                }
            }
        }
        /// <summary>
        /// Method use to prompt user for input and pass it through appropriate methods
        ///<summary>
        public void UserInputStart()
        {
            
                if (Flag2)
                {
                    Console.WriteLine("Hello, this is a chatbot that is designed to answer basic questions on cyber security that you may have.");
                    Console.WriteLine("--------------------------------------------------------------------------------------------");
                    this.SpeechClassObject.Talk("Hello, this is a chatbot that is designed to answer basic questions on cyber security that you may have.");
                    Flag2 = false;// Sets flag to false so this message is only gets shown once to user
                }
                else
                {
                    Console.WriteLine("--------------------------------------------------------------------------------------------");
                    this.SpeechClassObject.Talk("Please ask another question");
                    Console.WriteLine("Please ask another question");            
                }
            while (Flag3)//used to check if no valid results are found in the dictionary and loop to ask user for another question or reword the question
            {
                Console.Write("Please enter your question:   "); //prompt user for input
                String SearchValue = Console.ReadLine().ToLower();// reminder to convert all user input into caps or no caps to prevent false negatives in searched values being not found in the dictionary

                var result = this.Data.SearchUserInput(SearchValue); // passes user input to search method 
                
                string failmessage = "No value found, Sorry could you please try again with differant wording or a differant question";// copy of fail message to compare with result string

                Console.WriteLine(result);
                Console.WriteLine("--------------------------------------------------------------------------------------------");
                this.SpeechClassObject.Talk(result);
                if (!result.Equals(failmessage))//used to break from while loop if value is found in the dictionary 
                {
                    break;
                }
                
            }
        }
        
    }
}
