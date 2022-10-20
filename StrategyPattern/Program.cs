// start by creating an instance of the base abstract class
using StrategyPattern;

/*
Beverage CoffeeOrder = new DripCoffee();

// redefine that instance as a decorator, which itself contains the original reference as a property
CoffeeOrder = new Sugar(CoffeeOrder);
CoffeeOrder = new MilkCondiment(CoffeeOrder);

// most recent new decorator refers down chain back to the initial instance
Console.WriteLine(CoffeeOrder.Cost());
*/

// CAR EXAMPLE

Car HondaAccord = new BaseVehicle(2020, "Accord", 30000, "Sedan", "Blue");
HondaAccord = new HeatedSeats(HondaAccord);
HondaAccord = new RemoteStart(HondaAccord);
HondaAccord = new AlloyRims(HondaAccord);

public abstract class Beverage
{
    protected string _description { get;  set; }
    public virtual string GetDescription()
    {
        return _description;
    }

    protected double _cost { get; set; }
    public virtual double Cost()
    {
        return _cost;
    }
}

public class DripCoffee: Beverage
{
    public DripCoffee()
    {
        _cost = 1.00;
        _description = "Columbian Coffee";
    }
}
public class Tea: Beverage
{
    public Tea()
    {
        _description = "English Tea";
        _cost = 0.50;
    }
}
public class MilkBeverage: Beverage
{
    public MilkBeverage()
    {
        _description = "Milk that you drink";
        _cost = 2.00;
    }
}
public abstract class CondimentDecorator : Beverage
{
    public Beverage Beverage { get; set; }
    public abstract override string GetDescription();
    public abstract override double Cost();
}

public class Sugar: CondimentDecorator
{
    public override double Cost()
    {
        return Beverage.Cost() + _cost;
    }

    public override string GetDescription()
    {
        return $"{Beverage.GetDescription()}, {_description}";
    }

    public Sugar(Beverage beverage)
    {
        Beverage = beverage;
        _cost = 0.2;
        _description = "Sugar";
    }
}

public class MilkCondiment: CondimentDecorator
{
    public override double Cost()
    {
        return Beverage.Cost() + _cost;
    }

    public override string GetDescription()
    {
        return $"{Beverage.GetDescription()}, {_description}";
    }

    public MilkCondiment(Beverage beverage)
    {
        Beverage = beverage;
        _cost = 0.15;
        _description = "Milk";
    }
}
