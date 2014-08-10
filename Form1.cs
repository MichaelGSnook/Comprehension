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

        private void comprehend_Click(object sender, EventArgs e)
        {
            char[] delimiterChars = { ' ', ',', '.', ':', '\t' };

            String input = richTextBox.Text;
            ArrayList words = new ArrayList { };

            //convert String[] to ArrayList and delete spaces/punctuation.
            String [] wordsArray = input.Split(' ');
            foreach (string s in wordsArray)
            {
                String sTemp = cleanInput(s);
                //if empty element, do not add it to the ArrayList
                if (sTemp.Equals(""))
                {
                    continue;
                }

                words.Add(sTemp);
            }

            //print out each word
            foreach (string s in words)
            {
                System.Console.Write(s);
            }

            //ArrayList words = new ArrayList();
            //words.Add(
        }

        private String cleanInput(String sTemp)
        {
            //Removing punctuation
            if (sTemp.Contains(' '))
            {
                sTemp = sTemp.Replace(" ", String.Empty);
            }
            if (sTemp.Contains(","))
            {
                sTemp = sTemp.Replace(",", String.Empty);
            }
            if (sTemp.Contains("."))
            {
                sTemp = sTemp.Replace(".", String.Empty);
            }
            if (sTemp.Contains("?"))
            {
                sTemp = sTemp.Replace("?", String.Empty);
            }
            if (sTemp.Contains("!"))
            {
                sTemp = sTemp.Replace("!", String.Empty);
            }
            if (sTemp.Contains("\""))
            {
                sTemp = sTemp.Replace("\"", String.Empty);
            }
            if (sTemp.Contains("\'"))
            {
                sTemp = sTemp.Replace("\'", String.Empty);
            }
            if (sTemp.Contains(";"))
            {
                sTemp = sTemp.Replace(";", String.Empty);
            }
            if (sTemp.Contains(":"))
            {
                sTemp = sTemp.Replace(":", String.Empty);
            }
            return sTemp;
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox_MouseMove(object sender, MouseEventArgs e)
        {
            Point P = new Point(e.X, e.Y);
            Char ch = richTextBox.GetCharFromPosition(P);
            int hoverIndex = richTextBox.GetCharIndexFromPosition(P);
            Comprehend_Button.Text = /*hoverIndex + "";*/this.getHoverdOverWord(hoverIndex, e);
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Word test = new Word("dummy");
            richTextBox.Text = test.getDefinition();
        }

        private void testTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.Text = Comprehension.Word.lookUpType("dummy");
        }

        private String getHoverdOverWord(int hoverIndex, MouseEventArgs e)
        {
            if (richTextBox.TextLength > 0 && hoverIndex != 0)
            {

                //convert text in textbox to a character array.
                char[] textboxArray = richTextBox.Text.ToCharArray(0, richTextBox.TextLength);

                int beginIndex = hoverIndex;
                int endIndex = hoverIndex;

                //while beginIndex is a Letter, and is greater than 1
                while (char.IsLetter(textboxArray[beginIndex]) && beginIndex >= 1)
                {
                    //if preceeding char is not a letter, exit while loop, beginIndex now contains the index of the first char in desired word.
                    if (!char.IsLetter(textboxArray[beginIndex - 1]))
                    {
                        break;
                    }
                    //if preceeding char is a letter, decrement to preceeding char's index
                    else
                    {
                        beginIndex--;
                    }
                }

                //while endIndex is a Letter, and is less than or equal to 2nd to last char in textbox
                while (char.IsLetter(textboxArray[beginIndex]) && endIndex <= richTextBox.TextLength - 2)
                {
                    //if following char is not a letter, exit while loop, endIndex now contains the index of the last char in desired word.
                    if (!char.IsLetter(textboxArray[endIndex + 1]))
                    {
                        break;
                    }
                    //if following char is a letter, increment to following char's index
                    else
                    {
                        beginIndex++;
                    }
                }

                //return desired word being hoverd over.
                //ex. Substring method --> Substring(beginningIndex, lenght); length = endIndex - (beginIndex - 1)
                int length = (endIndex - (beginIndex - 1));

                return richTextBox.Text.Substring(beginIndex, length);
            }
            else
            {
                return "Enter text in the textbox below";
            }

        }

    }
}
