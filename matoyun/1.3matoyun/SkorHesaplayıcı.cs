namespace _1._3matoyun
{
    public class SkorHesaplayıcı
    {
        FormKontrolcu formkontrol;
        public int seviye; 
        int katsayi = 0;

        public SkorHesaplayıcı(FormKontrolcu formkontrol, int seviye)
        {
            this.formkontrol = formkontrol;
            this.seviye = seviye;
        }

        private void KatSayiHesapla()
        {
            if (seviye == 1)
            {
                katsayi = 2;
            }
            else if (seviye == 2)
            {
                katsayi = 3;
            }
            else if (seviye == 3)
            {
                katsayi = 4;
            }
            else if (seviye == 4)
            {
                katsayi = 5;
            }
            else
            {
                katsayi = 6;
            }
        }

        public int [] DYHesapla()
        {
            KatSayiHesapla();
            int dogru_sayisi = 0, yanlis_sayisi = 0;
            int[] esascevaplar = formkontrol.dogrucevaplar;

            for (int i = 0; i < formkontrol.cevaplar.Length; i++)
            {
                if (esascevaplar[i] == formkontrol.cevaplar[i])
                {
                    dogru_sayisi++;
                }
                else
                {
                    if (formkontrol.cevaplar[i] != -1)
                        yanlis_sayisi++;
                }
            }

            if (formkontrol.pascevaplar[0] != 0)
            {
                int[] pasesascevaplar = formkontrol.pasdogrucevaplar;

                for (int i = 0; i < formkontrol.pascevaplar.Length; i++)
                {
                    if (pasesascevaplar[i] == formkontrol.pascevaplar[i])
                    {
                        dogru_sayisi++;
                    }
                    else
                    {
                        yanlis_sayisi++;
                    }
                }
            }

            int[] sonuc = new int[2];
            sonuc[0] = dogru_sayisi;
            sonuc[1] = yanlis_sayisi;

            return sonuc;
        }

        public int PuanAl(int dogru_sayisi)
        {
            return dogru_sayisi * katsayi;
        }

        public int YildizDurum(int dogru_sayisi)
        {
            if (dogru_sayisi >= 11 && dogru_sayisi <= 15)
            {
                return 1;
            }
            else if (dogru_sayisi >= 16 && dogru_sayisi <= 18)
            {
                return 2;
            }
            else if (dogru_sayisi == 19 || dogru_sayisi == 20)
            {
                return 3;
            }

            return 0;
        }
    }
}
