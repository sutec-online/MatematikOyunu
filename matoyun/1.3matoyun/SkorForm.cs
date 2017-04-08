using System;
using System.Windows.Forms;

namespace _1._3matoyun
{
    public partial class SkorForm : Form
    {
        SkorHesaplayıcı skorhesap;
        SoruDizisi dizi;
        int[] dydurum;
        int puan, yildiz;
        public SkorForm(SkorHesaplayıcı skorhesap, SoruDizisi dizi)
        {
            InitializeComponent();
            this.skorhesap = skorhesap;
            this.dizi = dizi;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (skorhesap.seviye == 5)
            {
                MessageBox.Show("SON SEVİYEYİ TAMAMLADINIZ. BAŞKA SEVİYE YOKTUR.");
            }
            else
            {
                SoruBlok sorublok = new SoruBlok(dizi, skorhesap.seviye + 1);
                sorublok.Show();
                Close();
            }
        }

        private void SkorForm_Load(object sender, EventArgs e)
        {
            dydurum = skorhesap.DYHesapla();
            puan = skorhesap.PuanAl(dydurum[0]);
            yildiz = skorhesap.YildizDurum(dydurum[0]);

            if (yildiz == 3)
            {
                pictureBox1.Visible = true;
                pictureBox2.Visible = true;
                pictureBox3.Visible = true;
            }
            else if (yildiz == 2)
            {
                pictureBox1.Visible = true;
                pictureBox2.Visible = true;
            }
            else if (yildiz == 1)
            {
                pictureBox1.Visible = true;
            }

            label1.Text = "PUAN: " + puan;

            DosyaIsleyici dosyaisle = new DosyaIsleyici("C:/matoyun/skor.txt");
            dosyaisle.SkorYaz(puan.ToString());

            DosyaIsleyici dosyaisle2 = new DosyaIsleyici("C:/matoyun/kalanseviye.txt");
            dosyaisle2.BaglantiKapat();
            dosyaisle2.KalanSeviyeYaz((skorhesap.seviye + 1).ToString());
        }
    }
}
