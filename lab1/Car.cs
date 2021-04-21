using System;
using System.Collections.Generic;
using System.Text;

namespace lab1
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int YearOfManufacture { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - {1} - {2}", Id, Name, YearOfManufacture);
        }

        public static IList<Car> Cars
        {
            get
            {
                return new List<Car>
                {
                    new Car { Id = 1, Name = "Honda", YearOfManufacture = 1990 },
                    new Car { Id = 2, Name = "Toyota", YearOfManufacture = 1880 },
                    new Car { Id = 3, Name = "Mazda", YearOfManufacture = 1925 },
                    new Car { Id = 4, Name = "VinFast", YearOfManufacture = 2017 },
                    new Car { Id = 5, Name = "KIA", YearOfManufacture = 1855 },
                    new Car { Id = 6, Name = "BMW", YearOfManufacture = 1920 },
                    new Car { Id = 7, Name = "Merc", YearOfManufacture = 1981 },
                    new Car { Id = 8, Name = "Abc", YearOfManufacture = 1920 },
                    new Car { Id = 9, Name = "Def", YearOfManufacture = 1940 },
                    new Car { Id = 10, Name = "Gij", YearOfManufacture = 1944 }
                };
            }
        }

        public static Car FindWithID(int id)
        {

            foreach (var car in Cars)
            {
                if (id == car.Id)
                {
                    return car;
                }
            }
            return null;
        }
        public static List<Car> WhereWithYearOfManufacture(int year)
        {
            List<Car> listCar = new List<Car>();
            foreach (var car in Cars)
            {
                if (year == car.YearOfManufacture)
                {
                    listCar.Add(car);
                }
            }
            return listCar;
        }
    }
}
