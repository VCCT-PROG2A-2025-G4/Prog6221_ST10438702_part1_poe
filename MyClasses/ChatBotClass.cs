using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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

        private SpeechClass SpeechClassObject = new SpeechClass();

        private DictionaryClass Data = new DictionaryClass();

        /// <summary>
        /// Constructor for the ChatBotClass
        /// </summary>
        public ChatBotClass()
        {

            SoundPlayer GreetingAudio = new SoundPlayer(Properties.Resources.Recording);// creating an instance of soundplayer 
            GreetingAudio.Play();//plays greeting audio file










            Console.WriteLine("What is your name?");

            var username = Console.ReadLine();//prompt user for their name
            Console.WriteLine("Hello :" +username+" !");
            this.SpeechClassObject.Talk("Hello :" + username + " !");


            Console.WriteLine("Succesfully created");
            while (Flag)
            {
                UserInputStart(); //calling method for prompting user for input
                this.SpeechClassObject.Talk("Would you like to ask another question? Type N for no");
                Console.WriteLine("Would you like to ask another question? (Y/N)"); //prompt user if they want to ask another question
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
                this.SpeechClassObject.Talk("Hello, this is a chatbot that is designed to answer basic questions on cyber security that you may have.");
                Flag2 = false;// Sets flag to false so this message is only gets shown once to user
            }
            else
            {
                Console.WriteLine("Please ask another question");
                this.SpeechClassObject.Talk("Please ask another question");
            }
            String SearchValue = Console.ReadLine().ToLower();// reminder to convert all user input into caps or no caps to prevent false negatives in searched values being not found in the dictionary

            var result = this.Data.SearchUserInput(SearchValue); // passes user input to search method 

            Console.WriteLine(result);
            this.SpeechClassObject.Talk(result);
        }
      
        
    }
}
