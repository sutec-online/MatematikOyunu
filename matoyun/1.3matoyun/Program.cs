using System;
using System.Windows.Forms;

namespace _1._3matoyun
{
    static class Program
    {
        [STAThread]
        static void Main(string [] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args.Length > 0)
            {
                if (args[0] == "open")
                {
                    Sorular sorular = new Sorular();
                    SoruEkle soruekle = new SoruEkle(sorular);
                    soruekle.EkleSeviye();

                    SoruDizisi sorudizisi = new SoruDizisi("random", sorular);
                    sorudizisi.Ekle();
                    SoruBlok sorublok;

                    switch (args[1])
                    {
                        case "2":
                            Application.Run(new SoruBlok(sorudizisi, 2));
                            break;

                        case "3":
                            Application.Run(new SoruBlok(sorudizisi, 3));
                            break;

                        case "4":
                            Application.Run(new SoruBlok(sorudizisi, 4));
                            break;

                        case "5":
                            Application.Run(new SoruBlok(sorudizisi, 5));
                            break;

                        case "all":
                            Application.Run(new HileForm());
                            break;
                    }
                }
            }
            else
            {
                DosyaIsleyici dosyaisle = new DosyaIsleyici("C:/matoyun/kalanseviye.txt");
                int seviye = dosyaisle.KalanSeviyeAl();

                if (seviye == 0)
                {
                    dosyaisle.BaglantiKapat();
                    Application.Run(new Form1());
                }
                else if (seviye == 1)
                {
                    dosyaisle.BaglantiKapat();
                    Sorular sorular = new Sorular();
                    SoruEkle soruekle = new SoruEkle(sorular);
                    soruekle.EkleSeviye();

                    SoruDizisi sorudizisi = new SoruDizisi("random", sorular);
                    sorudizisi.Ekle();

                    SoruBlok sb = new SoruBlok(sorudizisi, 1);
                    sb.Show();

                    Application.Run();
                }
                else if (seviye == 2)
                {
                    dosyaisle.BaglantiKapat();
                    Sorular sorular = new Sorular();
                    SoruEkle soruekle = new SoruEkle(sorular);
                    soruekle.EkleSeviye();

                    SoruDizisi sorudizisi = new SoruDizisi("random", sorular);
                    sorudizisi.Ekle();

                    SoruBlok sb = new SoruBlok(sorudizisi, 2);
                    sb.Show();

                    Application.Run();
                }
                else if (seviye == 3)
                {
                    dosyaisle.BaglantiKapat();
                    Sorular sorular = new Sorular();
                    SoruEkle soruekle = new SoruEkle(sorular);
                    soruekle.EkleSeviye();

                    SoruDizisi sorudizisi = new SoruDizisi("random", sorular);
                    sorudizisi.Ekle();

                    SoruBlok sb = new SoruBlok(sorudizisi, 3);
                    sb.Show();

                    Application.Run();
                }
                else if (seviye == 4)
                {
                    dosyaisle.BaglantiKapat();
                    Sorular sorular = new Sorular();
                    SoruEkle soruekle = new SoruEkle(sorular);
                    soruekle.EkleSeviye();

                    SoruDizisi sorudizisi = new SoruDizisi("random", sorular);
                    sorudizisi.Ekle();

                    SoruBlok sb = new SoruBlok(sorudizisi, 4);
                    sb.Show();

                    Application.Run();
                }
                else if (seviye == 5)
                {
                    dosyaisle.BaglantiKapat();
                    Sorular sorular = new Sorular();
                    SoruEkle soruekle = new SoruEkle(sorular);
                    soruekle.EkleSeviye();

                    SoruDizisi sorudizisi = new SoruDizisi("random", sorular);
                    sorudizisi.Ekle();

                    SoruBlok sb = new SoruBlok(sorudizisi, 5);
                    sb.Show();

                    Application.Run();
                }
            }
        }
    }
}
