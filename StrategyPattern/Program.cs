PizzaStore winnipegChain = new WinnipegPizzaStore();
PizzaStore nfldChain = new NewFoundLandPizzaStore();

winnipegChain.OrderPizza("special");
nfldChain.OrderPizza("special");

winnipegChain.OrderPizza("cod");
nfldChain.OrderPizza("cod");


public abstract class PizzaStore
{
    public Pizza OrderPizza(string type)
    {
        Pizza pizza;

        // creating pizza (deciding on the instance that we want to use) WILL change at different locations
        // this process will never change, regardless of what our store   
        try
        {
            pizza = CreatePizza(type);

        }
        catch (Exception ex)
        {
            Console.WriteLine("Sorry, we don't have that kind of pizza. Try our cheese pizza instead.");
            pizza = CreatePizza("cheese");
        }

        pizza.Prepare();
        pizza.Bake();
        pizza.Cut();

        return pizza;
    }

    // how we instantiate the Pizza depends upon the type of store
    // "factory" method
    protected abstract Pizza CreatePizza(string type);
}

public class NewFoundLandPizzaStore: PizzaStore
{
    protected override Pizza CreatePizza(string type)
    {
        Pizza pizza;

        switch (type)
        {
            case "special":
                pizza = new LobsterPizza();
                break;
            case "cheese":
                pizza = new CheddarPizza();
                break;
            case "cod":
                pizza = new CodPizza();
                break;
            default:
                throw new ArgumentException();
        }

        return pizza;
    }
}
public class WinnipegPizzaStore: PizzaStore
{
    protected override Pizza CreatePizza(string type)
    {
        Pizza pizza;

        switch (type)
        {
            case "special":
                pizza = new SlurpeePizza();
                break;
            case "cheese":
                pizza = new MozarellaPizza();
                break;
            default:
                throw new ArgumentException();
        }

        return pizza;
    }
}

public abstract class Pizza
{
    public void Bake()
    {
        Console.WriteLine("Baking the pizza");
    }

    public void Cut()
    {
        Console.WriteLine("Cutting the Pizza");
    }

    public abstract void Prepare();
}
public class LobsterPizza: Pizza
{
    public override void Prepare()
    {
        Console.WriteLine("Putting lobster on the pizza");
    }
}
public class MozarellaPizza : Pizza
{
    public override void Prepare()
    {
        Console.WriteLine("Putting mozarella on the pizza.");
    }
}
public class CheddarPizza: Pizza
{
    public override void Prepare() 
    {
        Console.WriteLine("Putting cheddar on the pizza");
    }
}
public class SlurpeePizza: Pizza
{
    public override void Prepare()
    {
        Console.WriteLine("Pouring out the slurpee all over the pizza.");
    }
}
public class CodPizza: Pizza
{
    public override void Prepare()
    {
        Console.WriteLine("Putting some cod on the pizza");
    }
}