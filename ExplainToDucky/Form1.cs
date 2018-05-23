using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExplainToDucky
{
    public partial class Form1 : Form
    {
        
        private int idleSeconds = 0;
        private int maxGrey = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonSmallerFont_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Font.Size > 8)
            {
                richTextBox1.Font = new Font(richTextBox1.Font.FontFamily, richTextBox1.Font.Size - 1);
            }
            else
            {
                maxGrey += 20;
            }
            
        }

        private void buttonLargerFont_Click(object sender, EventArgs e)
        {
            maxGrey = 0;

            richTextBox1.Font = new Font(richTextBox1.Font.FontFamily, richTextBox1.Font.Size + 1);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            if (richTextBox1.Text.Length > 600)
            {
                int selectionStart = richTextBox1.SelectionStart;

                richTextBox1.Text = richTextBox1.Text.Substring(300);

                richTextBox1.Select(selectionStart, 0);
            }
            
            idleSeconds++;


            int greyTone = maxGrey + (idleSeconds * 5);
            if(greyTone > 255)
            {
                greyTone = 255;
            }

                
            richTextBox1.ForeColor = Color.FromArgb(greyTone, greyTone, greyTone);
                
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            //idleSeconds = 0;
        }


        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            idleSeconds = 0;
        }
    }
}
