// ISP: Clients should not be forced to depend on interfaces they do not use.
// Wrong: Robot is forced to implement the Eat method even though it doesn't eat.
public interface IWorker
{
    void Work();
    void Eat();
}

public class Robot : IWorker
{
    public void Work() { /* Work logic */ }
    public void Eat() { /* Robots don't eat! */ }
}

// ISP: Correct - Robot implements only the interface it needs.
public interface IWorkable
{
    void Work();
}

public interface IFeedable
{
    void Eat();
}

public class HumanWorker : IWorkable, IFeedable
{
    public void Work() { /* Work logic */ }
    public void Eat() { /* Eating logic */ }
}

public class Robot : IWorkable
{
    public void Work() { /* Work logic */ }
}
