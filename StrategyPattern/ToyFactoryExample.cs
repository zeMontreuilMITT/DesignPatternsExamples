
using System.ComponentModel.DataAnnotations;

public abstract class ToyFactory
{
    public abstract Toy ManufactureToy(string type);

    public void Paint(Toy toy)
    {
        Console.WriteLine($"Painting the {toy.Name}");
    }
    public Toy CreateToy(string type)
    {
        Toy toy;
        toy = ManufactureToy(type);
        Paint(toy);
        Console.WriteLine("Toy's done");
        return toy;
    }
}


public class MattellFactory : ToyFactory
{
    public override Toy ManufactureToy(string type)
    {
        Toy toy;

        switch (type)
        {
            case "car":
                toy = new Car();
                break;
            default:
                throw new ArgumentException();
        } 

        return toy;
    }
}
public abstract class Toy
{
    public string Name { get; set; }
}

public class Car : Toy
{
    public Car()
    {
        Name = "Car";
    }
}