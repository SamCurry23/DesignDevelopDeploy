Choices();
int userInput;
int ID;
string Password;
string FirstName;
string LastName;
string writeToText;
void Choices()
{
    Console.WriteLine("1. Log In");
    Console.WriteLine("2. Register New User");

    userInput = int.Parse(Console.ReadLine());

    if (userInput == 1)
    {
        LogIn();
    }
    else if (userInput == 2)
    {
        Register();
    }
    else
    {
        Console.WriteLine("ERROR User Input was incorrect.");
        Choices();
    }
}

void Register()
{
    Console.WriteLine("Enter your First Name: ");
    FirstName = Console.ReadLine();
    Console.WriteLine("Enter your Last Name: ");
    LastName = Console.ReadLine();
    Console.WriteLine("Enter your ID number: ");
    ID = int.Parse(Console.ReadLine());
    Console.WriteLine("Enter a Password: ");
    Password = Console.ReadLine();
    writeToText = (FirstName + "," + LastName + "," + ID + "," + Password);
    Console.WriteLine(writeToText);
    string projectRoot = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
    string filePath = Path.Combine(projectRoot, "Students.txt");
    using (StreamWriter writer = new StreamWriter(filePath, true))
    {
        writer.WriteLine(writeToText);
        writer.Flush();
    }    
}

void LogIn()
{
    Console.WriteLine("Enter your ID number:");
    ID = int.Parse(Console.ReadLine());
    Console.WriteLine("Enter your Password:");
    Password = Console.ReadLine();
}