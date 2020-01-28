using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileDiff
{
    public partial class Diversity : Form
    {
        public Diversity()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LCS longest = new LCS(txtString1.Text, txtString2.Text);
            string lcs = longest.LongestSequence();
            AddedValues(lcs);
            RemovedValues(lcs);
        }

        private void AddedValues(string lcs)
        {
            int p1 = 0, p2 = 0;
            bool started = false;
            while (p2 < lcs.Length && p1 < txtString2.Text.Length)
            {
                if (lcs[p2] != txtString2.Text[p1])
                {
                    if (!started)
                        txtString2.SelectionStart = p1;
                    started = true;
                }
                else
                {
                    if (started)
                    {
                        started = false;
                        txtString2.SelectionLength = p1 - txtString2.SelectionStart;
                        txtString2.SelectionColor = Color.Green;
                    }
                    p2++;
                }
                p1++;
            }
            if (p1 != txtString2.Text.Length)
            {
                txtString2.SelectionStart = p1;
                txtString2.SelectionLength = txtString2.Text.Length - p1;
                txtString2.SelectionColor = Color.Green;
            }
        }

        private void RemovedValues(string lcs)
        {
            int p1 = 0, p2 = 0;
            bool started = false;
            while (p2 < lcs.Length && p1 < txtString1.Text.Length)
            {
                if (lcs[p2] != txtString1.Text[p1])
                {
                    if (!started)
                        txtString1.SelectionStart = p1;
                    started = true;
                }
                else
                {
                    if (started)
                    {
                        started = false;
                        txtString1.SelectionLength = p1 - txtString1.SelectionStart;
                        txtString1.SelectionColor = Color.Red;
                    }
                    p2++;
                }
                p1++;
            }
            if (p1 != txtString1.Text.Length)
            {
                txtString1.SelectionStart = p1;
                txtString1.SelectionLength = txtString1.Text.Length - p1;
                txtString1.SelectionColor = Color.Red;
            }
        }
    }
}
