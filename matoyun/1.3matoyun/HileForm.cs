using System;
using System.Windows.Forms;

namespace _1._3matoyun
{
    public partial class HileForm : Form
    {
        public HileForm()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void HileForm_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("1");
            comboBox1.Items.Add("2");
            comboBox1.Items.Add("3");
            comboBox1.Items.Add("4");
            comboBox1.Items.Add("5");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sorular sorular = new Sorular();
            SoruEkle soruekle = new SoruEkle(sorular);
            soruekle.EkleSeviye();

            SoruDizisi sorudizisi = new SoruDizisi("random", sorular);
            sorudizisi.Ekle();

            if (comboBox1.SelectedItem.ToString() == "1")
            {
                SoruBlok sorublok = new SoruBlok(sorudizisi, 1);
                sorublok.Show();
            }else if (comboBox1.SelectedItem.ToString() == "2")
            {
                SoruBlok sorublok = new SoruBlok(sorudizisi, 2);
                sorublok.Show();
            }
            else if (comboBox1.SelectedItem.ToString() == "3")
            {
                SoruBlok sorublok = new SoruBlok(sorudizisi, 3);
                sorublok.Show();
            }
            else if (comboBox1.SelectedItem.ToString() == "4")
            {
                SoruBlok sorublok = new SoruBlok(sorudizisi, 4);
                sorublok.Show();
            }
            else
            {
                SoruBlok sorublok = new SoruBlok(sorudizisi, 5);
                sorublok.Show();
            }

            Close();
        }
    }
}
