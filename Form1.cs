using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;


namespace Comprehension
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Dictionary<String, Word> dict = new Dictionary<string,Word>();

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void richTextBox_MouseMove(object sender, MouseEventArgs e)
        {

            Point P = new Point(e.X, e.Y);
            Char ch = richTextBox.GetCharFromPosition(P);
            int hoverIndex = richTextBox.GetCharIndexFromPosition(P);
            String word = this.getHoverdOverWord(hoverIndex, e);
            
            //if word hasn't already been added to the local dictionary, add it
            if (!dict.ContainsKey(word))
            {
                dict.Add(word, new Word(word));
            }
            
            //print word information to screen
            def_label.Text = "Definition: " + dict[word].getType() + " - " + dict[word].getDefinition();

            //wait
            System.Threading.Thread.Sleep(50);
        }
        
        private String getHoverdOverWord(int hoverIndex, MouseEventArgs e)
        {
            if (richTextBox.TextLength > 0 && hoverIndex != 0)
            {
                //convert text in textbox to a character array.
                char[] textboxArray = richTextBox.Text.ToCharArray(0, richTextBox.TextLength);

                int beginIndex = hoverIndex;
                int endIndex = hoverIndex;

                //while beginIndex is a Letter or ', and is greater than 1
                while ((char.IsLetter(textboxArray[beginIndex]) || textboxArray[beginIndex] == '\'') && beginIndex >= 1)
                {
                    //if preceeding char is not a letter, exit while loop, beginIndex now contains the index of the first char in desired word.
                    if (!char.IsLetter(textboxArray[beginIndex - 1]))
                    {  
                        //make sure no index out of bounds errors occur
                        if (beginIndex - 2 >= 0)
                        {
                            //if preceeding char is ' or ’ && char before that is a letter (contractions)
                            if (textboxArray[beginIndex - 1] == '\'' && char.IsLetter(textboxArray[beginIndex - 2]))
                            {
                                beginIndex--;
                            }
                            else
                            {
                                break;
                            }
                        } 
                    }
                    //if preceeding char is a letter, decrement to preceeding char's index
                    else
                    {
                        beginIndex--;
                    }
                }

                //while endIndex is a Letter, and is less than or equal to 2nd to last char in textbox
                while ((char.IsLetter(textboxArray[endIndex]) || textboxArray[endIndex] == '\'') && endIndex <= richTextBox.TextLength - 2)
                {
                    //if following char is not a letter, exit while loop, endIndex now contains the index of the last char in desired word.
                    if (!char.IsLetter(textboxArray[endIndex + 1]))
                    {
                        //make sure no index out of bounds errors occur
                        if (endIndex + 2 < richTextBox.TextLength)
                        {
                            //if succeeding  char is ' && char after that is a letter (contractions)
                            if (textboxArray[endIndex + 1] == '\'' && char.IsLetter(textboxArray[endIndex + 2]))
                            {
                                endIndex++;
                            }
                            else
                            { 
                                break;
                            }
                        }
                    }
                    //if following char is a letter, increment to following char's index
                    else
                    {
                        endIndex++;
                    }
                }
                //return desired word being hoverd over.
                //ex. Substring method --> Substring(beginningIndex, lenght); length = endIndex - (beginIndex - 1)
                int length = (endIndex - (beginIndex - 1));

                return richTextBox.Text.Substring(beginIndex, length);
            }
            else
            {
                return " ";
            }
        }

        //Open dictionary.com page for word.
        public void openDictionary(object sender, EventArgs e)
        {
            //String word = this.getHoverdOverWord
            System.Diagnostics.Process.Start("http://dictionary.reference.com/browse/");
        }

        /*
        //TODO Implement the following!
        private void richTextBox_Enter(object sender, EventArgs e)
        {
            richTextBox.Text = "";
        }

        private void richTextBox_Leave(object sender, EventArgs e)
        {
            if (richTextBox.Text == "")
            {
                richTextBox.Text = "Enter or paste text here.";
            }
        }*/
    }
}
