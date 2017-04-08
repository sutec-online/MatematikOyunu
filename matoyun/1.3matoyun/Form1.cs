using System;
using System.Windows.Forms;

namespace _1._3matoyun
{
    public partial class Form1 : Form
    {
        Sorular sorular;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sorular = new Sorular();
            SoruEkle soruekle = new SoruEkle(sorular);
            soruekle.EkleSeviye();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string istek = "random";

            if (radioButton1.Checked)
                istek = "random";

            if (radioButton2.Checked)
                istek = "toplama";

            if (radioButton3.Checked)
                istek = "carpma";

            if (radioButton4.Checked)
                istek = "bolme";

            if (radioButton5.Checked)
                istek = "cikarma";

            SoruDizisi sorudizisi = new SoruDizisi(istek, sorular);
            sorudizisi.Ekle();

            SoruBlok sorublok = new SoruBlok(sorudizisi);
            sorublok.Show();
            Hide();
        }
    }
}
