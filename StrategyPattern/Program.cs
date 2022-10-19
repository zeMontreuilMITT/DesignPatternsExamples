// abstract beverage class
using System.ComponentModel;

Beverage CoffeeBeverage = new DripCoffee();
CoffeeBeverage = new Sugar(CoffeeBeverage);
CoffeeBeverage = new Sugar(CoffeeBeverage);

Beverage SecondCoffee = CoffeeBeverage;
Beverage ThirdCoffee = CoffeeBeverage;

Console.WriteLine(CoffeeBeverage.GetDescription());
Console.WriteLine(SecondCoffee.GetDescription());
Console.WriteLine(ThirdCoffee.GetDescription());

ThirdCoffee = new Sugar(ThirdCoffee);
Console.WriteLine("Add Sugar to new Coffee");

Console.WriteLine(CoffeeBeverage.GetDescription());
Console.WriteLine(SecondCoffee.GetDescription());
Console.WriteLine(ThirdCoffee.GetDescription());

CoffeeBeverage = new Sugar(CoffeeBeverage);
Console.WriteLine(CoffeeBeverage.GetDescription());
Console.WriteLine(SecondCoffee.GetDescription());
Console.WriteLine(ThirdCoffee.GetDescription());



Console.WriteLine(ThirdCoffee.Cost());

/* Coffee with Sugar Sugar (Sugar OR Sugar?)

 */
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
