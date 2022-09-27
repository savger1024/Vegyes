using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GyakCsharpDesktop0926
{
    public partial class Form1 : Form
    {
        string muvelet = "";
        List<int> szam = new List<int>();
        int sorszam = 0;
        int eredmeny;
        public Form1()
        {
            InitializeComponent();
        }

        private void Szam(string szam)
        {
            textBox1.Text += szam;
        }

        private void Muvelet(string muveletTipus)
        {
            muvelet = muveletTipus;
            szam.Add(int.Parse(textBox1.Text));
            textBox1.Text = "";
            sorszam++;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Szam("1");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Szam("2");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Szam("3");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Szam("4");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Szam("5");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Szam("6");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Szam("7");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Szam("8");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Szam("9");
        }

        private void button0_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "") Szam("0");
        }

        private void plusButton_Click(object sender, EventArgs e)
        {
            Muvelet("osszeadas");

        }

        private void minusButton_Click(object sender, EventArgs e)
        {
            Muvelet("kivonas");
        }

        private void szorzasButton_Click(object sender, EventArgs e)
        {
            Muvelet("szorzas");
        }

        private void osztasButton_Click(object sender, EventArgs e)
        {
            Muvelet("osztas");
        }

        private void egyenloButton_Click(object sender, EventArgs e)
        {
            if (muvelet == "osszeadas")
            {
                szam.Add(int.Parse(textBox1.Text));
                sorszam = 0;
                eredmeny = 0;
                for (int i = 0; i < szam.Count; i++)
                {
                    eredmeny += szam[i];
                }

                textBox1.Text = eredmeny.ToString();
            }
            else if (muvelet == "kivonas")
            {
                szam.Add(int.Parse(textBox1.Text));
                sorszam = 0;
                eredmeny = szam[0];
                for (int i = 1; i < szam.Count; i++)
                {
                    eredmeny -= szam[i];
                }

                textBox1.Text = eredmeny.ToString();
            }
            else if (muvelet == "szorzas")
            {
                szam.Add(int.Parse(textBox1.Text));
                sorszam = 0;
                eredmeny = szam[0];
                for (int i = 1; i < szam.Count; i++)
                {
                    eredmeny *= szam[i];
                }

                textBox1.Text = eredmeny.ToString();
            }
            else if (muvelet == "osztas")
            {
                szam.Add(int.Parse(textBox1.Text));
                sorszam = 0;
                eredmeny = szam[0];
                for (int i = 1; i < szam.Count; i++)
                {
                    eredmeny /= szam[i];
                }

                textBox1.Text = eredmeny.ToString();
            }
        }

        private void torlesButton_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            szam.Clear();
            sorszam = 0;
            
        }
    }
}
