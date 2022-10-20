using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{

    // DECORATOR PATTERN
    // Use Case: Base class can be OPTIONALLY modified at runtime, possibly multiple times
    // DESIGN
    // Need an abstract class that declares abstract methods that we expect to have on the base class and be modified by decorators
    // Need a concrete class that at least implements the abstract base class methods
    // Need an Abstract Decorator Class which has a property referring to an instance of the Base Abstract Class, and overrides of the Base Abstract Class Methods

    // When using this, we need to first instantiate the concrete class
    // We can then redefine the reference to that instance of the concrete class as an instance of the decorator, with reference back to the previously referred instance

    public abstract class Car
    {
        public abstract double GetTotal();
        public abstract string GetDescription();
    }

    public class BaseVehicle: Car
    {
        public DateTime Year { get; set; }
        public string Model { get; set; }
        public double BasePrice { get; set; }
        public string Colour { get; set; }
        public string BodyType { get; set; }

        public BaseVehicle(int year, string model, double basePrice, string bodyType, string colour)
        {
            Year = new DateTime(year, 1, 1);
            Model = model;
            BasePrice = basePrice;
            BodyType = bodyType;
            Colour = colour;
        }
        public override double GetTotal()
        {
            return BasePrice;
        }

        public override string GetDescription()
        {
            return $"{Colour} {Year.Year} Honda {Model} {BodyType}";
        }

    }

    public abstract class UpgradeDecorator : Car
    {
        public Car Car;
        public double Cost;
        public string Description;
        public override double GetTotal()
        {
            return Car.GetTotal() + Cost;
        }
        public override string GetDescription()
        {
            return $"{Car.GetDescription()}, {Description}";
        }
    }

    public class HeatedSeats : UpgradeDecorator
    {
        public HeatedSeats(Car car)
        {
            Car = car;
            Cost = 3000;
            Description = "Heated Seats";
        }
    }

    public class RemoteStart : UpgradeDecorator
    {
        public RemoteStart(Car car)
        {
            Car = car;
            Description = "Remote Start";
            Cost = 2000;
        }
    }

    public class AlloyRims : UpgradeDecorator
    {
        public AlloyRims(Car car)
        {
            Car = car;
            Description = "Alloy rims";
            Cost = 1000;
        }
    }
}
