using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;
//referances
//inspired heavily by rudolph's speech chat bot code
namespace CyberSecruityHelpChatBotPoe.MyClasses
{
    internal class SpeechClass
    {
            ///
            // Speech object used to output speech
            ///
            public SpeechSynthesizer OutSpeech = new SpeechSynthesizer();

            //---------------------------------//
            /// <summary>
            /// Default Constructor
            /// </summary>
            public SpeechClass()
            {
                this.OutSpeech.SetOutputToDefaultAudioDevice();
            }

            /// <summary>
            /// Method used to parse strings to speech combineded with basic error handling try catch
            /// </summary>

            public void Talk(String stringin)
            {
                try
                {
                    this.OutSpeech.Speak(stringin);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading Keywords:{ex.Message}");
                }

            }
        
    }
    //-----------------------------------------------END OF FILE---------------------------------------------------//
}
