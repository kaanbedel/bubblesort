using System;
using System.Diagnostics;

namespace BubbleShortKaanBedel
{
    class Program
    {
        static void Main(string[] args)
        {
            //Listeye random eleman ekleme
            int capacity = 100000;

            int[] arr = new int[capacity];
            Random rnd = new Random();
            for (int i = 0; i < capacity; i++)
            {
                arr[i] = rnd.Next(0, capacity);
            }

            //Bubble Sort
            var stopWatch1 = new Stopwatch();
            stopWatch1.Start();
            int temp;
            for (int i = 0; i <= arr.Length - 1; i++)
            {
                for (int j = 1; j <= arr.Length - 1; j++)
                {
                    //ilk eleman komşu elamandan büyük mü
                    if (arr[j - 1] > arr[j])
                    {
                        //büyük elemanı geçici bir değişkende tut
                        temp = arr[j - 1];
                        //büyük elemanlı index'e küçük elemanı ata (yer değiştirme)
                        arr[j - 1] = arr[j];
                        //küçük elemanlı index'e temp değişkeninde tutulan büyük değeri ata (yer değiştirme tamamlandı)
                        arr[j] = temp;
                    }
                }
            }
            Console.WriteLine("Bubble Sorted İle Sıralama İşlemi: {0} Milisaniye Sürdü.", stopWatch1.Elapsed.TotalMilliseconds);

            Console.WriteLine("Bubble Sorted ile Sıralanan Rakamlar:");
            foreach (int p in arr)
                Console.Write(p + " ");
            Console.WriteLine();


            //Binary Search
            Console.WriteLine("Aranacak bir değer giriniz: ");
            var value = Convert.ToInt32(Console.ReadLine());
            var stopWatch2 = new Stopwatch();
            stopWatch2.Start();
            int indis = BinarySearch(arr, value);
            stopWatch2.Stop();
            Console.WriteLine("Binary Search İle Arama İşlemi: {0} Milisaniye Sürdü.", stopWatch2.Elapsed.TotalMilliseconds);

            if (indis != -1)
                Console.WriteLine(indis + ". Konumda bulundu.");
            else
                Console.WriteLine("Bulunamadı.");

            Console.Read();
        }
        public static int BinarySearch(int[] sayilar, int arananSayi)
        {
            int baslangic = 0, bitis = sayilar.Length - 1, orta = 0;

            while (baslangic <= bitis) 
            {
                orta = (baslangic + bitis) / 2;

                if (arananSayi == sayilar[orta]) { return orta; }

                else if (arananSayi < sayilar[orta]) { bitis = orta - 1; }

                else{ baslangic = orta + 1; }
            }
            return -1;
        }
    }
}
