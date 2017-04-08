using System;

namespace _1._3matoyun
{
    public class FormKontrolcu
    {
        public int[] cevaplar = new int[20];
        public int[] pascevaplar = new int[20];
        public int[] dogrucevaplar = new int[20];
        public int[] pasdogrucevaplar;

        public void DogruCevapAl(int [] cevaplar)
        {
            dogrucevaplar = cevaplar;
        }

        public void PasDogruCevapAl(int [] cevaplar)
        {
            pasdogrucevaplar = new int[cevaplar.Length];
            pasdogrucevaplar = cevaplar;
        }
        public void CevapGonder(string c1, string c2, string c3, string c4, string c5, int baslangic)
        {
            cevaplar[baslangic] = Convert.ToInt32(c1);
            cevaplar[baslangic + 1] = Convert.ToInt32(c2);
            cevaplar[baslangic + 2] = Convert.ToInt32(c3);
            cevaplar[baslangic + 3] = Convert.ToInt32(c4);
            cevaplar[baslangic + 4] = Convert.ToInt32(c5);
        }

        public void PasCevapGonder(string c1, string c2, string c3, string c4, string c5, int baslangic)
        {
            pascevaplar[baslangic] = Convert.ToInt32(c1);

            if (c2 != "")
                pascevaplar[baslangic + 1] = Convert.ToInt32(c2);

            if (c3 != "")
                pascevaplar[baslangic + 2] = Convert.ToInt32(c3);

            if (c4 != "")
                pascevaplar[baslangic + 3] = Convert.ToInt32(c4);

            if (c5 != "")
                pascevaplar[baslangic + 4] = Convert.ToInt32(c5);
        }
    }
}
