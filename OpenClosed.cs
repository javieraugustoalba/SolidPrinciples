// OCP: Software entities should be open for extension but closed for modification.
// Wrong: PaymentService is modified to support new payment types.
public class PaymentService
{
    public void ProcessPayment(string paymentType)
    {
        if (paymentType == "CreditCard") { /* Process CreditCard */ }
        else if (paymentType == "PayPal") { /* Process PayPal */ }
    }
}

// OCP: Correct - New payment types can be added by extending IPayment without modifying PaymentService.
public interface IPayment
{
    void ProcessPayment();
}

public class CreditCardPayment : IPayment
{
    public void ProcessPayment() { /* Process CreditCard */ }
}

public class PayPalPayment : IPayment
{
    public void ProcessPayment() { /* Process PayPal */ }
}

public class PaymentService
{
    public void ProcessPayment(IPayment payment)
    {
        payment.ProcessPayment();
    }
}
