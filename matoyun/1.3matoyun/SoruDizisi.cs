namespace _1._3matoyun
{
    public class SoruDizisi
    {
        string istek;

        public Soru[] seviye1 = new Soru[20];
        public Soru[] seviye2 = new Soru[20];
        public Soru[] seviye3 = new Soru[20];
        public Soru[] seviye4 = new Soru[20];
        public Soru[] seviye5 = new Soru[20];

        Sorular sorular;

        public SoruDizisi(string istek, Sorular sorular)
        {
            this.istek = istek;
            this.sorular = sorular;
        }

        public void Ekle()
        {
            if (istek == "random")
            {
                for (int i = 0; i < 5; i++)
                {
                    seviye1[i] = sorular.svy1[i];
                    seviye2[i] = sorular.svy2[i];
                    seviye3[i] = sorular.svy3[i];
                    seviye4[i] = sorular.svy4[i];
                    seviye5[i] = sorular.svy5[i];
                }

                for (int i = 5; i < 10; i++)
                {
                    seviye1[i] = sorular.svy1[i + 15];
                    seviye2[i] = sorular.svy2[i + 15];
                    seviye3[i] = sorular.svy3[i + 15];
                    seviye4[i] = sorular.svy4[i + 15];
                    seviye5[i] = sorular.svy5[i + 15];
                }

                for (int i = 10; i < 15; i++)
                {
                    seviye1[i] = sorular.svy1[i + 30];
                    seviye2[i] = sorular.svy2[i + 30];
                    seviye3[i] = sorular.svy3[i + 30];
                    seviye4[i] = sorular.svy4[i + 30];
                    seviye5[i] = sorular.svy5[i + 30];
                }

                for (int i = 15; i < 20; i++)
                {
                    seviye1[i] = sorular.svy1[i + 45];
                    seviye2[i] = sorular.svy2[i + 45];
                    seviye3[i] = sorular.svy3[i + 45];
                    seviye4[i] = sorular.svy4[i + 45];
                    seviye5[i] = sorular.svy5[i + 45];
                }
            }
            else if (istek == "toplama")
            {
                for (int i = 0; i < 20; i++)
                {
                    seviye1[i] = sorular.svy1[i];
                    seviye2[i] = sorular.svy2[i];
                    seviye3[i] = sorular.svy3[i];
                    seviye4[i] = sorular.svy4[i];
                    seviye5[i] = sorular.svy5[i];
                }
            }
            else if (istek == "carpma")
            {
                for (int i = 0; i < 20; i++)
                {
                    seviye1[i] = sorular.svy1[i + 20];
                    seviye2[i] = sorular.svy2[i + 20];
                    seviye3[i] = sorular.svy3[i + 20];
                    seviye4[i] = sorular.svy4[i + 20];
                    seviye5[i] = sorular.svy5[i + 20];
                }
            }
            else if (istek == "bolme")
            {
                for (int i = 0; i < 20; i++)
                {
                    seviye1[i] = sorular.svy1[i + 40];
                    seviye2[i] = sorular.svy2[i + 40];
                    seviye3[i] = sorular.svy3[i + 40];
                    seviye4[i] = sorular.svy4[i + 40];
                    seviye5[i] = sorular.svy5[i + 40];
                }
            }
            else
            {
                for (int i = 0; i < 20; i++)
                {
                    seviye1[i] = sorular.svy1[i + 60];
                    seviye2[i] = sorular.svy2[i + 60];
                    seviye3[i] = sorular.svy3[i + 60];
                    seviye4[i] = sorular.svy4[i + 60];
                    seviye5[i] = sorular.svy5[i + 60];
                }
            }
        }
    }
}
