using System;
using System.Collections.Generic;
using System.Text;

namespace lab1
{
    class way1
    {
        public int[] CreateArrayFibonancci(int num1,int num2) //num1,2 là 2 số đầu của chuỗi
        {
            int[] arrFibonancci = new int[15];
            // đưa 2 số đầu vào array
            arrFibonancci[0] = num1;
            arrFibonancci[1] = num2;
            for (int i=2;i<15;i++)
            {
                arrFibonancci[i] = arrFibonancci[i - 1] + arrFibonancci[i - 2];
            }
            return arrFibonancci;
        }
        public void PrintFibonancci(int [] arr)
        {
            for (int i=0; i<arr.Length;i++)
            {
                Console.Write("["+arr[i]+"]  ");
            }
        }
    }
}
