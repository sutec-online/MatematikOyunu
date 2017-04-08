namespace _1._3matoyun
{
    class SoruEkle
    {
        Sorular sorular;

        public SoruEkle(Sorular sorular)
        {
            this.sorular = sorular;
        }

        public void EkleSeviye()
        {
            for (int i = 1; i < 6; i++)
            {
                Soru[] sorudizisi = new Soru[80];
                RandomSoruUretici randomuret = new RandomSoruUretici(i);
                for (int k = 0; k < sorudizisi.Length; k++)
                {
                    int sayi1 = randomuret.Uret();
                    int sayi2 = randomuret.Uret();
                    int islem = IslemDondur(k);

                    while (SonucHesapla(sayi1, sayi2, islem) == -1)
                    {
                        sayi1 = randomuret.Uret();
                        sayi2 = randomuret.Uret();
                    }

                    char krktr = KarakterAl(islem);
                    sorudizisi[k] = new Soru();
                    sorudizisi[k].soru = sayi1.ToString() + " " + krktr.ToString() + " " + sayi2.ToString();
                    sorudizisi[k].seviye = i;
                    sorudizisi[k].soru_cevap = SonucHesapla(sayi1, sayi2, islem);
                    sorudizisi[k].soru_tur = islem;
                }

                DiziyeAta(sorudizisi, i);
            }
        }

        public int IslemDondur(int deger)
        {
            int islem;
            int k = deger;

            if (k < 20)
            {
                islem = 1;
            }
            else if (k >= 20 && k < 40)
            {
                islem = 2;
            }
            else if (k >= 40 && k < 60)
            {
                islem = 3;
            }
            else
            {
                islem = 4;
            }

            return islem;
        }

        public int SonucHesapla(int sayi1, int sayi2, int islem)
        {
            switch (islem)
            {
                case 1:
                    return sayi1 + sayi2;
                    break;
                case 2:
                    return sayi1 * sayi2;
                    break;
                case 3:
                    if ((sayi1 % sayi2) == 0)
                        return sayi1 / sayi2;
                    else
                        return -1;
                    break;
                case 4:
                    if ((sayi1 - sayi2) >= 0)
                        return sayi1 - sayi2;
                    else
                        return -1;
                    break;
            }

            return -1;
        }

        public char KarakterAl(int islem)
        {
            switch (islem)
            {
                case 1:
                    return '+';
                    break;
                case 2:
                    return 'X';
                    break;
                case 3:
                    return '/';
                    break;
                case 4:
                    return '-';
                    break;
            }

            return 'H';
        }

        public void DiziyeAta(Soru[] dizi, int seviye)
        {
            if (seviye == 1)
            {
                sorular.svy1 = dizi;
            }
            else if (seviye == 2)
            {
                sorular.svy2 = dizi;
            }
            else if (seviye == 3)
            {
                sorular.svy3 = dizi;
            }
            else if (seviye == 4)
            {
                sorular.svy4 = dizi;
            }
            else
            {
                sorular.svy5 = dizi;
            }
        }
    }
}
