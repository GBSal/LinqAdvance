using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqAdvance
{
    class Program
    {
        static void Main(string[] args)
        {

            var cars = GetCars("Cars.csv");


            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Name} , {car.Year} , {car.Engine} ");
            }



            Console.WriteLine("Press any key to Continue... ");
            Console.ReadKey();

        }



        private static List<Car> GetCars(string path)
        {

            var query = File.ReadAllLines(path)
                        .Where(l => l.Length > 1)
                        .Select(l =>
                        {
                            var columns = l.Split(',');

                            return new Car
                            {
                                Year = columns[0],
                                Name = columns[1],
                                Engine = columns[3]
                            };
                        });




            return query.ToList<Car>();


        }
    }
}
