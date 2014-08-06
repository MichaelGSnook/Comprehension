using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Comprehension
{
    class Word
    {
        private String word = "";

        private String definition = "";

        //word type: noun, verb, pronoun, adjective, adverb, proposition, conjunction, interjection
        private String type = "";

        // constructor
        public Word(String wordToLookUp)
        {
            word = wordToLookUp;
            definition = lookUpDefinition(wordToLookUp);
            type = lookUpType(wordToLookUp);
        }

        public String getDefinition()
        {
            return definition;
        }

        public String getWord()
        {
            return word;
        }

        /// <summary>
        /// Gets the Definition of a Word. Example from the internet adapted to my purposes.
        /// </summary>
        /// <param name="Word">The Word to get the Definition of.</param>
        /// <returns>The Word's Definition</returns>
        public static String lookUpDefinition(String Word)
        {
            String def = "";

            String SearchText = "<meta name=\"description\" content=\"";
            System.Net.WebClient client = new System.Net.WebClient();
            String source = client.DownloadString("http://dictionary.reference.com/browse/" + Word);
            
            Int32 start = source.IndexOf(SearchText) + SearchText.Length;
            source = source.Remove(0, start + Word.Length + " definition, ".Length);
            Int32 end = source.IndexOf(" See more.\"/>");
            source = source.Remove(end);
            
            def = source;

            return def;
        }

        /// <summary>
        /// Gets the type of a Word. Example from the internet adapted to my purposes.
        /// </summary>
        /// <param name="Word">The Word to get the Type of.</param>
        /// <returns>The Word's Type</returns>
        public static String lookUpType(String Word)
        {
            String type = "";

            String SearchText = "\"> <span class=\"pg\">";
            System.Net.WebClient client = new System.Net.WebClient();
            String source = client.DownloadString("http://dictionary.reference.com/browse/" + Word);
            
            Int32 start = source.IndexOf(SearchText) + SearchText.Length;
            source = source.Remove(0, start);
            /*Int32 end = source.IndexOf(" </span> <div class=\"");
            source = source.Remove(end);*/
            
            //Sometimes there is garbage after the type, this removes all but first word
            if(source.Contains(" "))
            {
                source = source.Substring(0, source.IndexOf(" "));
            }

            //Removes non-letter characters from string
            Regex rgx = new Regex("[^a-zA-Z0-9 -]");
            source = rgx.Replace(source, "");
            
            type = source;

            return type;
        }




    }
}
