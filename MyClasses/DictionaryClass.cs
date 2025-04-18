using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecruityHelpChatBotPoe.MyClasses
{
    internal class DictionaryClass
    {
        ///
        /// Dictionary used to store keywords and associated answers for user answers to users input
        ///

        private Dictionary<string, string> ChatBotDictionary = new Dictionary<string, string>();

        ///
        /// Constructor
        ///

        public DictionaryClass()
        {
            this.addToDictionary();
        }

        /// <summary>
        /// Method too set preset values to the dictionary
        /// </summary>
        private void addToDictionary()
        {
            this.ChatBotDictionary.Add("email safety","Dont click on anylinks in any email");
            this.ChatBotDictionary.Add("phishing", "A type of malware");
            this.ChatBotDictionary.Add("virus", "A type of malware");
            this.ChatBotDictionary.Add("worm", "A type of malware");
            this.ChatBotDictionary.Add("malware", "Any type of malicous code!!!");
            this.ChatBotDictionary.Add("worms", "A type of malware");
            this.ChatBotDictionary.Add("tempvalue", "A type of malware");
            this.ChatBotDictionary.Add("tempvalues", "A type of malware");
            this.ChatBotDictionary.Add("trojan", "A type of malware");
            this.ChatBotDictionary.Add("ransomware", "A type of malware");
            this.ChatBotDictionary.Add("how are you", "I am doing great thank you!");
            this.ChatBotDictionary.Add("what is your purpose", "To help you stay secure!!");
            this.ChatBotDictionary.Add("what can i ask you about", "You can ask basic question on cyber secruity and i will answer based on my limited dictionary based results");
        }


        /// <summary>
        /// Method used to search by comparing words in user input into the dictionary
        /// </summary>
        
        public string SearchUserInput(string keywordIn)
        {
            var lowerValue = keywordIn.ToLower(); //used to convert all user input to lower case to prevent false negatives in searched values being not found in the dictionary

            var spaces = new char[] {' ', ',','.',':',';','!','?'};//used to split user input into words

            var tempvalue = lowerValue.Split(spaces,StringSplitOptions.RemoveEmptyEntries);//splits user input into words and removes any empty entries

            
            foreach (var word in tempvalue)//loops for each word in the user input
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


    }
}
