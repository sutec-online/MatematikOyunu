using System;
using System.Windows.Forms;

namespace _1._3matoyun
{
    public partial class SoruBlok : Form
    {
        SoruDizisi sorudizisi;
        FormKontrolcu formkontrol = new FormKontrolcu();
        int baslangic = 0, sayac = 1, k = 0, k_onceki = 0;
        bool pascevap = false, ilkpascalisma = false;
        Soru[] pasgecilenler;

        public SoruBlok(SoruDizisi sorudizisi)
        {
            InitializeComponent();
            this.sorudizisi = sorudizisi;
        }

        public SoruBlok(SoruDizisi sorudizisi, int seviye)
        {
            InitializeComponent();
            this.sorudizisi = sorudizisi;
            sayac = seviye;
        }

        private void SoruBlok_Load(object sender, EventArgs e)
        {
            SoruYaz(sayac);
            FormKontrolcuDogruCevapGonder();
            timer1.Interval = sayac * 20000;
            timer1.Start();
        }

        private void CheckBoxKontrol()
        {
            if (checkBox1.Checked)
                textBox1.Text = "-1";

            if (checkBox2.Checked)
                textBox2.Text = "-1";

            if (checkBox3.Checked)
                textBox3.Text = "-1";

            if (checkBox4.Checked)
                textBox4.Text = "-1";

            if (checkBox5.Checked)
                textBox5.Text = "-1";
        }

        private void FormTemizle()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";

            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
        }

        private void BaslangicKontrol()
        {
            if (baslangic == 20)
            {
                pascevap = true;
                ilkpascalisma = true;
                baslangic = 0;
            }
        }

        private bool TextBoxKontrol()
        {
            if (textBox1.Text == "" && textBox1.Visible || textBox2.Text == "" && textBox2.Visible || textBox3.Text == "" && textBox3.Visible || textBox4.Text == "" && textBox4.Visible || textBox5.Text == "" && textBox5.Visible)
            {
                MessageBox.Show("ALANLAR BOŞ BIRAKILAMAZ !");
                return false;
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CheckBoxKontrol();

            if (TextBoxKontrol())
            {
                if (pascevap == false)
                {
                    formkontrol.CevapGonder(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, baslangic);
                    baslangic += 5;
                }
                else
                {
                    if (k == 0)
                    {
                        SkorHesaplayıcı skorhesapla = new SkorHesaplayıcı(formkontrol, sayac);
                        SkorForm skorform = new SkorForm(skorhesapla, sorudizisi);
                        skorform.Show();
                        Close();
                    }

                    formkontrol.PasCevapGonder(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, baslangic);
                    baslangic += k_onceki - k;
                }

                FormTemizle();
                BaslangicKontrol();
                SoruYaz(sayac);
            }
        }

        public Soru[] DiziAl()
        {
            Soru[] dizi;

            if (sayac == 1)
            {
                dizi = sorudizisi.seviye1;
            }
            else if (sayac == 2)
            {
                dizi = sorudizisi.seviye2;
            }
            else if (sayac == 3)
            {
                dizi = sorudizisi.seviye3;
            }
            else if (sayac == 4)
            {
                dizi = sorudizisi.seviye4;
            }
            else
            {
                dizi = sorudizisi.seviye5;
            }

            return dizi;
        }

        public void SoruYaz(int seviye)
        {
            Soru[] dizi = DiziAl();

            if (pascevap == true)
            {
                PasSoruYaz(dizi);
            }
            else
            {
                label1.Text = "SEVİYE: " + dizi[baslangic].seviye;
                label2.Text = "#SORU - " + (baslangic + 1).ToString();
                label7.Text = "#SORU - " + (baslangic + 2).ToString();
                label10.Text = "#SORU - " + (baslangic + 3).ToString();
                label13.Text = "#SORU - " + (baslangic + 4).ToString();
                label16.Text = "#SORU - " + (baslangic + 5).ToString();

                label3.Text = dizi[baslangic].soru;
                label6.Text = dizi[baslangic + 1].soru;
                label9.Text = dizi[baslangic + 2].soru;
                label12.Text = dizi[baslangic + 3].soru;
                label15.Text = dizi[baslangic + 4].soru;
            }
        }

        private void KapatButon(object sender, FormClosingEventArgs e)
        {
            if (k != 0)
            {
                DosyaIsleyici dosyaisle = new DosyaIsleyici("C:/matoyun/kalanseviye.txt");
                dosyaisle.BaglantiKapat();
                dosyaisle.KalanSeviyeYaz(sayac.ToString());
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (MessageBox.Show("Süreniz Dolduğu için Puan Alamadınız. Lütfen Tekrar Deneyin.", "Süreniz Doldu" , MessageBoxButtons.OK) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private Soru [] PasIlkCalisma(Soru [] dizi)
        {
            int[] cevaplar = formkontrol.cevaplar;
            int[] indexleyici = new int[20];
            k = 0;

            for (int i = 0; i < cevaplar.Length; i++)
            {
                if (cevaplar[i] == -1)
                {
                    indexleyici[k] = i;
                    k++;
                }
            }

            if (k == 0)
            {
                SkorHesaplayıcı skorhesapla = new SkorHesaplayıcı(formkontrol, sayac);

                //Skor gösterecek forma sapış.
                SkorForm skorform = new SkorForm(skorhesapla, sorudizisi);
                skorform.Show();
                Close();
            }

            pasgecilenler = new Soru[k];

            for (int i = 0; i < k; i++)
            {
                pasgecilenler[i] = dizi[indexleyici[i]];
            }

            FormKontrolcuPasDogruCevapGonder(pasgecilenler);

            return pasgecilenler;
        }

        private void FormKontrolcuDogruCevapGonder()
        {
            Soru[] sorularial = DiziAl();
            int[] dogrucevaplar = new int[20];

            for (int i = 0; i < sorularial.Length; i++)
            {
                dogrucevaplar[i] = sorularial[i].soru_cevap;
            }

            formkontrol.DogruCevapAl(dogrucevaplar);
        }

        private void FormKontrolcuPasDogruCevapGonder(Soru [] passorulari)
        {
            int[] dogrucevaplar = new int[passorulari.Length];

            for (int i = 0; i < passorulari.Length; i++)
            {
                dogrucevaplar[i] = passorulari[i].soru_cevap;
            }

            formkontrol.PasDogruCevapAl(dogrucevaplar);
        }

        public void PasSoruYaz(Soru [] dizi)
        {
            if (ilkpascalisma == true)
            {
                dizi = PasIlkCalisma(dizi);
                ilkpascalisma = false;
            }

            k_onceki = k;

            if (k > 5)
            {
                label1.Text = "SEVİYE: " + dizi[baslangic].seviye;
                label2.Text = "#SORU - " + (baslangic + 1).ToString();
                label7.Text = "#SORU - " + (baslangic + 2).ToString();
                label10.Text = "#SORU - " + (baslangic + 3).ToString();
                label13.Text = "#SORU - " + (baslangic + 4).ToString();
                label16.Text = "#SORU - " + (baslangic + 5).ToString();

                label3.Text = dizi[baslangic].soru;
                label6.Text = dizi[baslangic + 1].soru;
                label9.Text = dizi[baslangic + 2].soru;
                label12.Text = dizi[baslangic + 3].soru;
                label15.Text = dizi[baslangic + 4].soru;

                k -= 5;
            }
            else if (k == 4)
            {
                label1.Text = "SEVİYE: " + dizi[baslangic].seviye;
                label2.Text = "#SORU - " + (baslangic + 1).ToString();
                label7.Text = "#SORU - " + (baslangic + 2).ToString();
                label10.Text = "#SORU - " + (baslangic + 3).ToString();
                label13.Text = "#SORU - " + (baslangic + 4).ToString();

                label3.Text = dizi[baslangic].soru;
                label6.Text = dizi[baslangic + 1].soru;
                label9.Text = dizi[baslangic + 2].soru;
                label12.Text = dizi[baslangic + 3].soru;
                panel5.Visible = false;

                k -= 4;
            }
            else if (k == 3)
            {
                label1.Text = "SEVİYE: " + dizi[baslangic].seviye;
                label2.Text = "#SORU - " + (baslangic + 1).ToString();
                label7.Text = "#SORU - " + (baslangic + 2).ToString();
                label10.Text = "#SORU - " + (baslangic + 3).ToString();

                label3.Text = dizi[baslangic].soru;
                label6.Text = dizi[baslangic + 1].soru;
                label9.Text = dizi[baslangic + 2].soru;
                panel5.Visible = false;
                panel4.Visible = false;

                k -= 3;
            }
            else if (k == 2)
            {
                label1.Text = "SEVİYE: " + dizi[baslangic].seviye;
                label2.Text = "#SORU - " + (baslangic + 1).ToString();
                label7.Text = "#SORU - " + (baslangic + 2).ToString();

                label3.Text = dizi[baslangic].soru;
                label6.Text = dizi[baslangic + 1].soru;
                panel5.Visible = false;
                panel4.Visible = false;
                panel3.Visible = false;

                k -= 2;
            }
            else if (k == 1)
            {
                label1.Text = "SEVİYE: " + dizi[baslangic].seviye;
                label2.Text = "#SORU - " + (baslangic + 1).ToString();

                label3.Text = dizi[baslangic].soru;
                panel5.Visible = false;
                panel4.Visible = false;
                panel3.Visible = false;
                panel2.Visible = false;
                k -= 1;
            }
        }
    }
}
