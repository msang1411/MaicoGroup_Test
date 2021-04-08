using System;
using System.Collections.Generic;

//
//      Giải bài toán Fibonancci(Tối thiểu 3 cách).
//
namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Chỉ lấy 15 số trong chuỗi fibonancci
            int[] arrFibonancci = new int[15];

            //cach 1 dùng for
            Console.WriteLine("cach 1.");
            way1 w1 = new way1();
            arrFibonancci = w1.CreateArrayFibonancci(0,1);
            Console.Write("Fibonancci: ");
            w1.PrintFibonancci(arrFibonancci);
            Console.WriteLine("\n\n-------------------------------------\n");

            //cach 2 dùng de quy
            Console.WriteLine("cach 2.");
            way2 w2 = new way2();
            arrFibonancci = w2.CreateArrayFibonancci();
            Console.Write("Fibonancci: ");
            w2.PrintFibonancci(arrFibonancci);
            Console.WriteLine("\n\n-------------------------------------\n");

            //cach 3 dùng list
            Console.WriteLine("cach 3.");
            way3 w3 = new way3();
            List<int> listFibonancci = w3.CreateListFibonacci();
            Console.Write("Fibonancci: ");
            w3.PrintFibonancciWithList(listFibonancci);
            Console.WriteLine("\n\n-------------------------------------\n");

            Console.ReadKey();
        }
    }
}
