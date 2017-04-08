using System;

namespace _1._3matoyun
{
    class RandomSoruUretici
    {
        int seviye;
        Random rnd = new Random();

        public RandomSoruUretici(int seviye)
        {
            this.seviye = seviye;
        }

        public int Uret()
        {
            int sayi = 0;

            switch (seviye)
            {
                case 1:
                    sayi = rnd.Next(1, 10);         
                    break;
                case 2:
                    sayi = rnd.Next(10, 100);
                    break;
                case 3:
                    sayi = rnd.Next(100, 1000);
                    break;
                case 4:
                    sayi = rnd.Next(1000, 10000);
                    break;
                case 5:
                    sayi = rnd.Next(10000, 100000);
                    break;
            }

            return sayi;
        }
    }
}
