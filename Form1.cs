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

            String input = textBox.Text;
            ArrayList words = new ArrayList { };

            //convert String[] to ArrayList and delete spaces/punctuation.
            String [] wordsArray = input.Split(' ');
            foreach (string s in wordsArray)
            {
                String sTemp = s;
                //if empty element, do not add it to the ArrayList
                if (sTemp.Equals(""))
                {
                    continue;
                }
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
           

                words.Add(sTemp);
            }
            System.Console.WriteLine("{0}", words[2]);

            foreach (string s in words)
            {
                System.Console.WriteLine(s);
            }

            //ArrayList words = new ArrayList();
            //words.Add(
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
    }
}
