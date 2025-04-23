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

        private Dictionary<string, string> ChatBotDictionary = new Dictionary<string, string>();

        ///
        /// Constructor for dictionary
        ///

        public DictionaryClass()
        {
            this.addToDictionary();
        }

        /// <summary>
        /// Method too set preset values to the dictionary
        /// </summary>
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


        /// <summary>
        /// Method used to search by comparing words in user input into the dictionary
        /// </summary>
        
        public string SearchUserInput(string keywordIn) //chat gpt helped with making this method work as i was struggling to get it to work on my own.
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
    }
    //-----------------------------------------------END OF FILE---------------------------------------------------//
}
