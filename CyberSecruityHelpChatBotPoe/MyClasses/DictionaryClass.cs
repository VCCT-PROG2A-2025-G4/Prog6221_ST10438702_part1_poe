using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//referances 
//chatGPT
//Rudolph's speech chat bot code on dictionaries is where i based the start of this code of 
namespace CyberSecruityHelpChatBotPoe.MyClasses
{
    internal class DictionaryClass
    {
        ///
        /// Dictionary used to store keywords and associated answers for user answers to users input
        ///

        //private Dictionary<string, string> ChatBotDictionary = new Dictionary<string, string>();

        //Dictionary<string, List<string>>// added testing 

        ///
        /// Constructor for dictionary
        ///

        /* public DictionaryClass()
         {
             this.addToDictionary();
         }
         */

        public DictionaryClass()
        {
            // 2) Initialize it (you can also pass StringComparer.OrdinalIgnoreCase if you want case-insensitive keys):
            ChatBotDictionary = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);

            // then populate
            AddToDictionary();
        }

        /// <summary>
        /// Method too set preset values to the dictionary
        /// </summary>
        /*
        private void addToDictionary()  //Made with the help of chat gpt to create preset text values for each key word
        {
            this.ChatBotDictionary.Add("email", "Dont click on anylinks in any email");
            this.ChatBotDictionary.Add("phishing", "A social engineering attack that tricks users into revealing sensitive information by masquerading as a trustworthy entity");
            this.ChatBotDictionary.Add("virus", "A malicious program that attaches itself to legitimate software and replicates to infect other files when the host runs");
            this.ChatBotDictionary.Add("worm", "A standalone piece of malware that self‑replicates across networks without needing a host file or user action");
            this.ChatBotDictionary.Add("malware", "Software designed to infiltrate, damage, or gain unauthorized access to a computer system without the user’s consent");
            this.ChatBotDictionary.Add("worms", "Self‑replicating malware similar to worms, intended to spread quickly across systems and networks");
            this.ChatBotDictionary.Add("tempvalue", "A temporary storage variable used to hold intermediate data during processing");
            this.ChatBotDictionary.Add("trojan", "Malicious software that disguises itself as legitimate to trick users into installing it");
            this.ChatBotDictionary.Add("ransomware", "Malware that encrypts files or locks systems and demands payment for restoration");
            this.ChatBotDictionary.Add("how are you", "I am doing great thank you!");
            this.ChatBotDictionary.Add("what is your purpose", "To help you stay secure!!");
            this.ChatBotDictionary.Add("what can i ask you about", "You can ask basic question on cyber secruity and i will answer based on my limited dictionary based results");
        }
        */
        private readonly Random _rng = new Random();
        private Dictionary<string, List<string>> ChatBotDictionary;
        private void AddToDictionary()// the use of lists in the dictionary to allow multiple responses for the same keyword, chat gpt helped with edits to create this compared to the previos dictionary
        {
            ChatBotDictionary = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase)
            {
                ["email"] = new List<string>
        {
            "Don't click on any links in suspicious emails.",
            "Be cautious—phishing emails often disguise themselves as legitimate.",
            "Always verify the sender's address before replying to email requests."
        },
                ["phishing"] = new List<string>
        {
            "Phishing tricks you into giving up sensitive info by pretending to be someone you trust.",
            "Never enter your credentials on a link you received out of the blue.",
            "If an email asks for personal data, go straight to the official site instead of clicking links."
        },
                ["virus"] = new List<string>
        {
            "A virus attaches to legit software and replicates when that host runs.",
            "Watch for unexpected file behavior—viruses can hide in executables.",
            "Keep your anti-virus software up to date."
        },
                
                ["how are you"] = new List<string>
        {
            "I'm doing great—thanks for asking!",
            "All systems operational!",
            "Feeling secure and ready to help!"
        },
                ["what is your purpose"] = new List<string>
        {
            "To help you stay secure!!",
            "To assist in giving cybersecruity tips and information",
            "To help guide you through basic cybersecruity tips"
        },
                ["what can i ask you about"] = new List<string>
        {
            "You can ask basic question on cyber secruity and i will answer based on my limited dictionary based results",
            "Any basic information that is based on cyber secruity",
            "Ask about questions based on cyber secruity and a response will be given best to my ability"
        },
                ["password"] = new List<string>
         {
        "Use a unique, strong password of at least 12 characters—mix uppercase, lowercase, numbers & symbols.",
        "Store and autofill your passwords with a reputable password manager instead of reusing or writing them down.",
        "Enable multi-factor authentication wherever possible to add an extra layer of protection."
         },

                ["scam"] = new List<string>
        {
        "Never trust unsolicited requests for money or personal info—verify the sender’s identity through a separate channel.",
        "Hover over links (or long-press on mobile) to inspect the real URL before clicking to avoid phishing sites.",
        "If an offer sounds too good to be true, walk away and do your own research—scammers prey on FOMO."
        },

                ["privacy"] = new List<string>
        {
        "Review app permissions regularly and revoke any you don’t actually need (location, camera, contacts, etc.).",
        "Use a VPN on public or untrusted Wi-Fi to keep your browsing and data traffic encrypted.",
        "Clear cookies and browser cache periodically, or use your browser’s private/incognito mode to limit tracking."
        }


            };
        }

        /// <summary>
        /// Method used to search by comparing words in user input into the dictionary
        /// </summary>

        /* public string SearchUserInput(string keywordIn) //chat gpt helped with making this method work as i was struggling to get it to work on my own.
         {
             var lowerValue = keywordIn.ToLower(); //used to convert all user input to lower case to prevent false negatives in searched values being not found in the dictionary

             var spaces = new char[] {' ',',','.',':',';','!','?'};//used to split user input into seperate words

             var tempvalue = lowerValue.Split(spaces,StringSplitOptions.RemoveEmptyEntries);//splits user input into words and removes any empty entries

             for (int i = 1; i + 1 <= tempvalue.Length; i++)
             {
                 String tempSentence = string.Join(" ", tempvalue, 0, i+1);//used to add words from user input that have been separated into one string with spaces one string at a time

                 // Console.WriteLine(tempSentence);//for testing
                 for (int current = 0; current + i <= tempvalue.Length; current++)
                 {    
                    foreach (var textValue in this.ChatBotDictionary.Keys) // loops for each key value in the dictionary 
                         {
                             if (tempSentence.Equals(textValue))//checks to see if word of user input is equal to key value in dictionary
                             {
                                 return this.ChatBotDictionary[textValue];//returns value associated with the key value when found
                             }
                         }
                 }
                 if (i <= tempvalue.Length)
                 {   
                     for (int x = 1; x + 1 <= tempvalue.Length; x++)
                     {
                         String reverseTempSentence = string.Join(" ", tempvalue, i, tempvalue.Length - i);//removes one string at a time but basically the same

                         for (int current2 = 0; current2 + x <= tempvalue.Length; current2++)
                         {
                             foreach (var textValue in this.ChatBotDictionary.Keys) // loops for each key value in the dictionary 
                             {
                                 if (reverseTempSentence.Equals(textValue))//checks to see if word of user input is equal to key value in dictionary
                                 {
                                     return this.ChatBotDictionary[textValue];//returns value associated with the key value when found
                                 }
                             }

                         }
                     }
                 }
             }

             foreach (var word in tempvalue)//loops for each individual word in the user input
             {
                 foreach (var textValue in this.ChatBotDictionary.Keys) // loops for each key value in the dictionary 
                 {
                     if (word.Equals(textValue))//checks to see if word of user input is equal to key value in dictionary
                     {
                         return this.ChatBotDictionary[textValue];//returns value associated with the key value when found
                     }
                 }
             }
             return "No value found, Sorry could you please try again with differant wording or a differant question";

         }
        */


        public string SearchUserInput(string keywordIn)//chat gpt used to help optimized and recreate the functionality but in a more efficient way
        {
            var delimiters = new[] { ' ', ',', '.', ':', ';', '!', '?' };
            var words = keywordIn.ToLower().Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            // Join all consecutive word combinations from largest to smallest to prioritize longer phrases
            for (int length = words.Length; length >= 1; length--)
            {
                for (int start = 0; start <= words.Length - length; start++)
                {
                    var phrase = string.Join(" ", words.Skip(start).Take(length));
               
                    if (ChatBotDictionary.TryGetValue(phrase, out var replies))
                      {

                        //Console.WriteLine($"[LOG] Match found: \"{phrase}\"");// helps find what the answer is for debugging purposes
                        string reply = replies[_rng.Next(replies.Count)];//uses a random number to select a response from the list of responses
                        return reply;
                      }
               
                }
            }

            return "No value found, sorry. Could you please try again with different wording or a different question?";
        }
    }


    //-----------------------------------------------END OF FILE---------------------------------------------------//
}
