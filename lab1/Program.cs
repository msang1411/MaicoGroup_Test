using System;
using System.Collections.Generic;
using System.Linq;

//
//      Giải bài toán Fibonancci(Tối thiểu 3 cách).
//
namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            var cars = Car.Cars;
            Console.WriteLine("====Test Find====");
            var car = Car.FindWithID(2);
            Console.WriteLine(car);
            Console.WriteLine("====Test Where====");
            var list = Car.WhereWithYearOfManufacture(1920);
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }
}
