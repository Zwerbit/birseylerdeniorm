using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace vergiHesap
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Lütfen yapacaginiz islem sayisini giriniz: ");
            int islemSayisi = int.Parse(Console.ReadLine());
            string[] dizi = new string[islemSayisi];
            Console.Clear();
            Console.Write("Islemler:\nParayi artirma-azaltma (Orn: +15 ,-15 ,+15% ,-15%)\nVergiyi artirma-azaltma (Orn: V+15 ,V-15 ,V+15% ,V-15%)\nDilim (+1500/2500/15% ,-1500/2500/15%)\n\n");
            for (int i = 0; i < islemSayisi; i++)
            {
                Console.Write("Lütfen yapmak istediginiz islemi giriniz: ");
                dizi[i] = Console.ReadLine();
            }
            while (true)
            {
                Console.Clear();
                Console.Write("Vergisini hesaplamak istediginiz paranin miktarini giriniz: ");
                float vergi=0,para = float.Parse(Console.ReadLine());
                int islemTur = 0;// 1toplama 2cıkarma 3+yüzde 4-yüzde 5+dilim 6-dilim 7vToplama 8vÇıkarma 9v+yüzde 10v-yüzde
                for (int j = 0; j < islemSayisi; j++)
                {
                    islemTur = 0;
                    for (int k = 0; k < dizi[j].Length; k++)
                    {
                        if (dizi[j].Substring(k, 1) == "+") islemTur += 1;
                        if (dizi[j].Substring(k, 1) == "-") islemTur += 2;
                        if (dizi[j].Substring(k, 1) == "%") islemTur += 2;
                        if (dizi[j].Substring(k, 1) == "/") islemTur += 1;
                        if (dizi[j].Substring(k, 1) == "V"|| dizi[j].Substring(k, 1) == "v") islemTur += 6;
                    }
                    int slash1 = 0, slash2 = 0; float oran = 0, altS = 0, ustS = 0;
                    switch (islemTur)
                    {
                        case 1:
                            para += float.Parse(dizi[j].Substring(1));
                            break;
                        case 2:
                            para -= float.Parse(dizi[j].Substring(1));
                            break;
                        case 3:
                            para += para*float.Parse(dizi[j].Substring(1, dizi[j].Length - 2))/100;
                            break;
                        case 4:
                            para -= para*float.Parse(dizi[j].Substring(1, dizi[j].Length - 2))/100;
                            break;
                        case 5:
                            for(int i = 0; i < dizi[j].Length; i++)
                            {
                                if (dizi[j].Substring(i, 1) == "/")
                                {
                                    slash1 = i;
                                    for (; i < dizi[j].Length; i++) if (dizi[j].Substring(i, 1) == "/") slash2 = i;
                                }
                            }
                            altS = float.Parse(dizi[j].Substring(1, slash1-1));
                            ustS = float.Parse(dizi[j].Substring(slash1+1, slash2-slash1-1));
                            oran = float.Parse(dizi[j].Substring(slash2+1, dizi[j].Length - slash2 - 2));
                            if (para - altS <= ustS - altS) vergi += (para - altS) * oran / 100;
                            else vergi += (ustS - altS) * oran / 100;
                            break;
                        case 6:
                            for (int i = 0; i < dizi[j].Length; i++)
                            {
                                if (dizi[j].Substring(i, 1) == "/")
                                {
                                    slash1 = i;
                                    for (; i < dizi[j].Length; i++) if (dizi[j].Substring(i, 1) == "/") slash2 = i;
                                }
                            }
                            altS = float.Parse(dizi[j].Substring(1, slash1 - 1));
                            ustS = float.Parse(dizi[j].Substring(slash1 + 1, slash2 - slash1 - 1));
                            oran = float.Parse(dizi[j].Substring(slash2 + 1, dizi[j].Length - slash2 - 2));
                            if (para - altS <= ustS - altS) vergi -= (para - altS) * oran / 100;
                            else vergi -= (ustS - altS) * oran / 100;
                            break;
                        case 7:
                            vergi += float.Parse(dizi[j].Substring(1));
                            break;
                        case 8:
                            vergi -= float.Parse(dizi[j].Substring(1));
                            break;
                        case 9:
                            vergi += vergi * float.Parse(dizi[j].Substring(1, dizi[j].Length - 2)) / 100;
                            break;
                        case 10:
                            vergi -= vergi * float.Parse(dizi[j].Substring(1, dizi[j].Length - 2)) / 100;
                            break;
                        default:
                            break;
                    }
                }
                Console.Clear();
                Console.WriteLine("Yapilan islemler");
                for(int i = 0; i < islemSayisi; i++)
                {
                    Console.WriteLine(dizi[i]);
                }
                Console.Write("\nVergi tutari: {0}\nDevam etmek için tusa basininz.", vergi);
                Console.ReadKey();
            }
        }
    }
}
