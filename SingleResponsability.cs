// SRP: A class should have only one reason to change, meaning it should have only one job or responsibility.
// Wrong: UserService has multiple responsibilities - adding a user and sending emails.
public class UserService
{
    public void AddUser(string user) { /* Adds user to DB */ }
    public void SendEmail(string message) { /* Sends an email */ }
}

// SRP: Correct - UserService and EmailService have distinct responsibilities.
public class UserService
{
    public void AddUser(string user) { /* Adds user to DB */ }
}

public class EmailService
{
    public void SendEmail(string message) { /* Sends an email */ }
}
