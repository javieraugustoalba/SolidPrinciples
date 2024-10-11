using System;

namespace DIPExample
{
    // --------------------------
    // DIP Example 1: The Problematic Code
    // --------------------------
    
    // DIP: High-level modules should not depend on low-level modules. Both should depend on abstractions.
    // This code violates DIP because the Switch class directly depends on the LightBulb class.
    
    public class LightBulb
    {
        // The LightBulb class represents a light bulb that can be turned on.
        public void TurnOn() { Console.WriteLine("LightBulb is turned on."); }
    }

    public class Switch
    {
        // The Switch class has a direct dependency on the LightBulb class.
        private LightBulb _lightBulb;

        public Switch()
        {
            // Switch directly creates an instance of LightBulb.
            _lightBulb = new LightBulb();
        }

        public void Operate()
        {
            // Switch calls the TurnOn method of the specific LightBulb class.
            _lightBulb.TurnOn();
        }
    }

    // Explanation:
    // - The Switch class directly depends on the LightBulb class. 
    // - This means that if we want to use a different device (e.g., a Fan), 
    //   we would need to modify the Switch class itself.
    // - This creates a tight coupling between Switch and LightBulb, making the code less flexible 
    //   and harder to maintain or extend.
    // - It also makes the code harder to test since Switch cannot be easily tested with a mock device.

    public class ProblematicProgram
    {
        public static void Main()
        {
            Console.WriteLine("Problematic Code with Direct Dependency:");

            // Create a Switch that is tightly coupled to a LightBulb.
            Switch lightSwitch = new Switch();
            lightSwitch.Operate(); // Outputs: "LightBulb is turned on."
        }
    }

    // --------------------------
    // DIP Example 2: The Corrected Code
    // --------------------------

    // DIP: High-level modules should not depend on low-level modules. Both should depend on abstractions.
    // This code adheres to DIP because the Switch class depends on the IDevice interface (abstraction), 
    // not on a specific implementation like LightBulb.
    
    public interface IDevice
    {
        // The IDevice interface defines a method that any device should implement.
        void TurnOn();
    }

    public class LightBulb : IDevice
    {
        // The LightBulb class implements the IDevice interface, providing its own way of turning on.
        public void TurnOn() { Console.WriteLine("LightBulb is turned on."); }
    }

    public class Fan : IDevice
    {
        // The Fan class also implements the IDevice interface, providing its own way of turning on.
        public void TurnOn() { Console.WriteLine("Fan is turned on."); }
    }

    public class Switch
    {
        // The Switch class now depends on the IDevice interface, not a specific implementation.
        private readonly IDevice _device;

        public Switch(IDevice device)
        {
            // The specific device is passed as a dependency to the Switch constructor.
            _device = device;
        }

        public void Operate()
        {
            // The Switch class calls TurnOn on the IDevice, not caring if it's a LightBulb, Fan, or any other device.
            _device.TurnOn();
        }
    }

    // Explanation:
    // - The Switch class now depends on the IDevice interface, which is an abstraction.
    // - This means that the Switch doesn't need to know what specific type of device it is controlling.
    // - We can now easily extend the code with new devices (e.g., a Fan) without modifying the Switch class.
    // - This design follows the Open/Closed Principle (OCP) as well, since the Switch class is open for extension 
    //   (by adding new devices that implement IDevice) but closed for modification (no need to change Switch class).
    // - It makes the code more flexible, easier to maintain, and easier to test using mocks or stubs.

    public class CorrectedProgram
    {
        public static void Main()
        {
            Console.WriteLine("\nCorrected Code with Dependency Inversion:");

            // Create a Switch that controls a LightBulb.
            IDevice lightBulb = new LightBulb();
            Switch switchForLight = new Switch(lightBulb);
            switchForLight.Operate(); // Outputs: "LightBulb is turned on."

            // Create a Switch that controls a Fan.
            IDevice fan = new Fan();
            Switch switchForFan = new Switch(fan);
            switchForFan.Operate(); // Outputs: "Fan is turned on."
        }
    }
}
