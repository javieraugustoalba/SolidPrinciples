using System;

namespace LSPExample
{
    // --------------------------
    // LSP Example 1: Using Abstract Classes
    // --------------------------

    // The Problematic Code (Using Abstract Class)
    // LSP: Subtypes should be substitutable for their base types without altering the correctness of the program.
    // This code violates the LSP because substituting an Ostrich for a Bird changes the expected behavior.
    public abstract class BirdAbstract
    {
        // The BirdAbstract class has a method Fly that prints "Flying".
        public virtual void Fly()
        {
            Console.WriteLine("Flying");
        }
    }

    public class OstrichAbstract : BirdAbstract
    {
        // The OstrichAbstract class inherits from BirdAbstract but overrides the Fly method to throw an exception.
        public override void Fly()
        {
            throw new NotSupportedException("Ostriches can't fly");
        }
    }

    public class ProblematicAbstractProgram
    {
        public static void Main()
        {
            Console.WriteLine("Problematic Code with Abstract Classes:");

            // This will compile, but throws a runtime exception, violating LSP.
            try
            {
                BirdAbstract bird = new OstrichAbstract();
                bird.Fly(); // Throws NotSupportedException because Ostriches cannot fly.
            }
            catch (NotSupportedException ex)
            {
                Console.WriteLine(ex.Message); // Outputs: "Ostriches can't fly"
            }

            Console.WriteLine("\nCorrected Code with Abstract Classes:");

            // Corrected version using an abstract class and adhering to LSP.
            BirdAbstract correctedBird1 = new FlyingBirdAbstract();
            correctedBird1.Move(); // Outputs: "Flying"

            BirdAbstract correctedBird2 = new OstrichCorrectedAbstract();
            correctedBird2.Move(); // Outputs: "Running"
        }
    }

    // Adhering to LSP with Abstract Classes
    public abstract class BirdAbstract
    {
        // Define a common method that all birds must implement.
        public abstract void Move();
    }

    // FlyingBirdAbstract class inherits from BirdAbstract and represents birds that can fly.
    public class FlyingBirdAbstract : BirdAbstract
    {
        // The Move method represents the flying behavior.
        public override void Move()
        {
            Console.WriteLine("Flying");
        }
    }

    // OstrichCorrectedAbstract class inherits from BirdAbstract and represents birds that run instead of fly.
    public class OstrichCorrectedAbstract : BirdAbstract
    {
        // The Move method represents the running behavior.
        public override void Move()
        {
            Console.WriteLine("Running");
        }
    }

    // --------------------------
    // LSP Example 2: Using Interfaces
    // --------------------------

    // The Problematic Code (Using Interface)
    // LSP: Subtypes should be substitutable for their base types without altering the correctness of the program.
    // This code violates the LSP because substituting an Ostrich for a Bird changes the expected behavior.
    public interface IBird
    {
        void Fly();
    }

    public class OstrichInterface : IBird
    {
        // The OstrichInterface class implements IBird but throws an exception when Fly is called.
        public void Fly()
        {
            throw new NotSupportedException("Ostriches can't fly");
        }
    }

    public class ProblematicInterfaceProgram
    {
        public static void Main()
        {
            Console.WriteLine("\nProblematic Code with Interface:");

            // This will compile, but throws a runtime exception, violating LSP.
            try
            {
                IBird bird = new OstrichInterface();
                bird.Fly(); // Throws NotSupportedException because Ostriches cannot fly.
            }
            catch (NotSupportedException ex)
            {
                Console.WriteLine(ex.Message); // Outputs: "Ostriches can't fly"
            }

            Console.WriteLine("\nCorrected Code with Interface:");

            // Corrected version using interfaces and adhering to LSP.
            IBird correctedBird1 = new FlyingBirdInterface();
            correctedBird1.Move(); // Outputs: "Flying"

            IBird correctedBird2 = new OstrichCorrectedInterface();
            correctedBird2.Move(); // Outputs: "Running"
        }
    }

    // Adhering to LSP with Interfaces
    public interface IBird
    {
        void Move();
    }

    // FlyingBirdInterface class implements IBird and represents birds that can fly.
    public class FlyingBirdInterface : IBird
    {
        public void Move()
        {
            Console.WriteLine("Flying");
        }
    }

    // OstrichCorrectedInterface class implements IBird and represents birds that run instead of fly.
    public class OstrichCorrectedInterface : IBird
    {
        public void Move()
        {
            Console.WriteLine("Running");
        }
    }
}
