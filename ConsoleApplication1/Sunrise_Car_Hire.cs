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

       static string  rentalCost(int choice,string registration_no,string make,double rate,int days)
        {
            double cost;

            switch (choice)
            {
                case 1:
                    Sedan sed = new Sedan(registration_no, make, rate);
                    cost = sed.calculateRentalCost(days);
                    break;
                case 2:
                    Truck new_truck = new Truck(registration_no, make, rate);
                    cost = new_truck.calculateRentalCost(days);
                    break;
                default:
                    Vehicle new_vehicle = new Vehicle(registration_no, make, rate);
                    cost = new_vehicle.calculateRentalCost(days);
                    break;
            }
          
            return $"The total cost of this type of vehicle  ${cost}";
        }
        static void Main(string[] args)
        {
            
                try
                {
                    Console.WriteLine("Sunrise Car Hire");
                    Console.WriteLine();
                    Console.WriteLine("1.Sedan\n2.Truck\n3.Other");
                    Console.WriteLine();
                    Console.Write("Type vehicle type: ");
                    int vehicle = Convert.ToInt32(Console.ReadLine());
                    string reg_number;

                    Console.WriteLine();

                    while (true)
                    {
                        Console.Write("Enter the registration number: ");
                        reg_number = Console.ReadLine();

                        if (reg_number.Length == 7)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Registration length should be equal to 7 characters");
                        }
                    }


                    Console.Write("Enter the vehicle make: ");
                    string vehicle_make = Console.ReadLine();

                    Console.Write("Enter today's rate: ");
                    double rate = Convert.ToDouble(Console.ReadLine());

                    Console.Write("Vehicle rental days: ");
                    int days = Convert.ToInt32(Console.ReadLine());

                    string totalCost = rentalCost(vehicle, reg_number, vehicle_make, rate, days);
                    Console.WriteLine();

                    Console.WriteLine(totalCost);
                    
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Invalid input...Try again");
                
            }


            Console.ReadKey();
        }
    }
}
