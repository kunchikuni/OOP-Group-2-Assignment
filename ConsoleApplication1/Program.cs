using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Vehicle
    {
        public string reg_no;
        public string make;
        private double dailyRentalRate;
           

            

        public Vehicle(string reg_no, string make,double dailyRentalRate)
        {
            this.reg_no = reg_no;
            this.make = make;
            this.dailyRentalRate = dailyRentalRate;
        }

        public double GetDailyRate()
        {
            return dailyRentalRate;
        }

        public virtual double calculateRentalCost(int days)
        {
            return GetDailyRate() * days;
        }

    }

    class Truck : Vehicle {

        private const int insurance = 50;
        public Truck(string reg_no, string make, double dailyRentalRate): base( reg_no,  make, dailyRentalRate)
        {

        }

        public override double calculateRentalCost(int days)
        {
            return (days * GetDailyRate()) + insurance;
        }
    } 

    class Sedan: Vehicle
    {
        public Sedan(string reg_no, string make, double dailyRentalRate) : base(reg_no, make, dailyRentalRate)
        {

        }

        public override double calculateRentalCost(int days)
        {
            return GetDailyRate() * days;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Sunrise Car Hire");
            Console.WriteLine();
            Console.WriteLine("1.Sedan\n2.Truck");
            Console.WriteLine();
            Console.Write("Type vehicle type: ");
            int vehicle = Convert.ToInt32( Console.ReadLine());

            switch (vehicle)
            {
                case 1:
                    Console.WriteLine("Please enter the registration number: ");
                    string reg_no = Console.ReadLine();
                    Console.WriteLine("Please enter the vehicle make: ");
                    string make = Console.ReadLine();
                    Console.WriteLine("Please enter the daily rate: ");
                    double dailyRate = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Please enter the number of rental days: ");
                    int days = Convert.ToInt32( Console.ReadLine());
                    Sedan sed = new Sedan(reg_no, make, dailyRate);
                    double rate = sed.calculateRentalCost(days);
                    Console.WriteLine($"Sedan rate {rate}");
                    break;

                case 2:
                    Console.WriteLine("Please enter the registration number: ");
                    string reg_n = Console.ReadLine();
                    Console.WriteLine("Please enter the vehicle make: ");
                    string mak = Console.ReadLine();
                    Console.WriteLine("Please enter the daily rate: ");
                    double dailyRat = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Please enter the number of rental days: ");
                    int day = Convert.ToInt32(Console.ReadLine());


                    Truck truck = new Truck(reg_n, mak, dailyRat);
                    double trate = truck.calculateRentalCost(day);
                    Console.WriteLine($"Truck rate {trate}");
                    break;
                default:
                    Console.Write("Option out of range!");
                    break;
            }
            


            Console.ReadKey();
        }
    }
}
