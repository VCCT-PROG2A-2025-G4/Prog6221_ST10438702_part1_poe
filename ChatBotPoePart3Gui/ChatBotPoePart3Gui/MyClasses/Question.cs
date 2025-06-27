using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBotPoePart3Gui.MyClasses
{
    
        public class Question
        {
            public string Text { get; set; }           // The question text
            public string[] Options { get; set; }      // A, B, C, D values
            public int CorrectIndex { get; set; }      //stores index for correct answer
            public string Explanation { get; set; }
    }
    
}
