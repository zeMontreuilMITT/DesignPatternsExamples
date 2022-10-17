Duck newMallard = new MallardDuck();
Duck streamerDuck = new FuegianSteamerDuck();

newMallard.PerformQuack();
streamerDuck.PerformQuack();
newMallard.PerformFly();
streamerDuck.PerformFly();
newMallard.Swim();
streamerDuck.Swim();

public abstract class Duck
{
    public IFlyBehaviour FlyBehaviour { get; set; }
    public IQuackBehaviour QuackBehaviour { get; set; }
    public void PerformFly()
    {
        FlyBehaviour.Fly();
    }

    public void PerformQuack()
    {
        QuackBehaviour.Quack();
    }

    public void Swim()
    {
        Console.WriteLine("All ducks can swim, including this one.");
    }

}

public class RoboDuck: Duck
{
    public RoboDuck()
    {
        FlyBehaviour = new PropellerFlyBehaviour();
        QuackBehaviour = new QuackLikeADuckBehaviour();
    }
}

public class MallardDuck: Duck
{
    public MallardDuck()
    {
        FlyBehaviour = new WingedFlyBehaviour();
        QuackBehaviour = new QuackLikeADuckBehaviour();
    }
    // a mallard can fly
    // a mallard quacks
}

public class FuegianSteamerDuck: Duck
{
    public FuegianSteamerDuck()
    {
        FlyBehaviour = new FlightlessFlyBehaviour();
        QuackBehaviour = new QuackLikeADuckBehaviour();
    }
    // cannot fly
    // probably quacks
}



public interface IFlyBehaviour
{
    public void Fly();
}

public class WingedFlyBehaviour : IFlyBehaviour
{
    public void Fly()
    {
        Console.WriteLine("The duck flies with its wings.");
    }
}

public class FlightlessFlyBehaviour: IFlyBehaviour
{
    public void Fly()
    {
        Console.WriteLine("This duck does not fly.");
    }
}

public class PropellerFlyBehaviour: IFlyBehaviour
{
    public void Fly()
    {
        Console.WriteLine("The duck flies away with propellers somehow.");
    }
}

public interface IQuackBehaviour
{
    public void Quack();
}

public class QuackLikeADuckBehaviour: IQuackBehaviour
{
    public void Quack()
    {
        Console.WriteLine("The duck makes a quacking sound.");
    }
}