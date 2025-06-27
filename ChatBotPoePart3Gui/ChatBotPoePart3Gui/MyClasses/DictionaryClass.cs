using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//referances 
//chatGPT
//Rudolph's speech chat bot code on dictionaries is where i based the start of this code of 

namespace ChatBotPoePart3Gui.MyClasses
{

    internal class DictionaryClass
    {
        private Dictionary<string, string> addSentimentResponsesDictionary;
        ///
        /// Constructor for dictionary
        ///

        public DictionaryClass()
        {
            // 2) Initialize it (you can also pass StringComparer.OrdinalIgnoreCase if you want case-insensitive keys):
            ChatBotDictionary = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);
            addSentimentResponsesDictionary = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            // then populate
            AddToDictionary();
            AddSentimentResponses();
        }


        private void AddSentimentResponses() //used chat gpt to help generate responses for the sentiment dictionary
        {
            addSentimentResponsesDictionary["worried"] = "I understand it’s normal to feel worried—let me help put your mind at ease.";
            addSentimentResponsesDictionary["concerned"] = "It’s natural to be concerned; I’m here to answer any questions you have.";
            addSentimentResponsesDictionary["anxious"] = "Feeling anxious can be overwhelming—let’s tackle it one step at a time.";
            addSentimentResponsesDictionary["frustrated"] = "I hear your frustration—what can I clarify for you?";
            addSentimentResponsesDictionary["confused"] = "It’s okay to be confused; tell me what’s unclear and I’ll explain.";
            addSentimentResponsesDictionary["excited"] = "Your excitement is great—what would you like to explore first?";
        }

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

        public string SearchUserSentiment(string keywordIn)//chat gpt used to help optimized and recreate the functionality but in a more efficient way
        {
            var delimiters = new[] { ' ', ',', '.', ':', ';', '!', '?' };
            var words = keywordIn.ToLower().Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            // Join all consecutive word combinations from largest to smallest to prioritize longer phrases
            for (int length = words.Length; length >= 1; length--)
            {
                for (int start = 0; start <= words.Length - length; start++)
                {
                    var phrase = string.Join(" ", words.Skip(start).Take(length));

                    if (addSentimentResponsesDictionary.TryGetValue(phrase, out var replies))
                    {
                        string reply = replies;//uses a random number to select a response from the list of responses
                        return reply;
                    }

                }
            }

            return "No sentiment found in the dictionary";
        }
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
