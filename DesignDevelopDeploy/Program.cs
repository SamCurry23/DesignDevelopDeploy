int userInput;
string ID;
string Password;
string FirstName;
string LastName;
string writeToText;
int typeID;
string projectRoot = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
string filePath = Path.Combine(projectRoot, "Students.txt");
bool correctPassword = false;
bool correctID = false;
string personType = "";
int logInCount = 0;


Choices();
void Choices()
{
    Console.Clear();
    Console.WriteLine("1. Log In");
    Console.WriteLine("2. Register New User");
    Console.WriteLine("3. Cool testing option");

    userInput = int.Parse(Console.ReadLine());

    if (userInput == 1)
    {
        string[] wordArray = { };
        LogIn(correctID, correctPassword, wordArray);
    }
    else if (userInput == 2)
    {
        Register();
    }
    else if (userInput == 3)
    {
        string IDTest = "0";
        string passTest = "test";
        Search(IDTest, passTest);
    }
    else
    {
        Console.WriteLine("ERROR User Input was incorrect.");
        Choices();
    }
}

void Register()
{
    Console.Clear();
    typeID = 0;
    Console.WriteLine("1. Student");
    Console.WriteLine("2. Personal Supervisor");
    Console.WriteLine("3. Senior Tutor");
    userInput = int.Parse(Console.ReadLine());
    if (userInput == 1)
    {
        typeID = 1;
    }
    else if (userInput == 2)
    {
        typeID = 2;
    }
    else if (userInput == 3)
    {
        typeID = 3;
    }
    Console.WriteLine("Enter your First Name: ");
    FirstName = Console.ReadLine();
    Console.WriteLine("Enter your Last Name: ");
    LastName = Console.ReadLine();
    Console.WriteLine("Enter your ID number: ");
    ID = Console.ReadLine();
    Console.WriteLine("Enter a Password: ");
    Password = Console.ReadLine();
    writeToText = (FirstName + "," + LastName + "," + ID + "," + Password + "," + typeID);
    Console.WriteLine(writeToText);
    using (StreamWriter writer = new StreamWriter(filePath, true))
    {
        writer.WriteLine(writeToText);
        writer.Flush();
    }    
    Choices();
}

void LogIn(bool correctID, bool correctPassword, string[] wordArray)
{
    Console.Clear();
    if (!correctID && !correctPassword)
    {
        if (logInCount > 0)
        {
            Console.WriteLine("ID and Password was incorrect!");
        }
        Console.WriteLine("Enter your ID number:");
        ID = Console.ReadLine();
        Console.WriteLine("Enter your Password:");
        Password = Console.ReadLine();
        logInCount++;
        Search(ID, Password);
    }
    else if (!correctID && correctPassword) 
    {
        Console.WriteLine("Incorrect ID your account might not exist would you like to register an account?");
        Choices();
    }
    else if (correctID && !correctPassword)
    {
        Console.WriteLine("Your password was incorrect try again");
        Console.WriteLine("Enter your ID number:");
        ID = Console.ReadLine();
        Console.WriteLine("Enter your Password:");
        Password = Console.ReadLine();
        Search(ID, Password);
    }
    else if (correctID && correctPassword)
    {
        LoggedIn(wordArray);
    }
}


void Search(string ID, string password)
{
    using (StreamReader reader = new StreamReader(filePath, true))
    {
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            string[] wordArray = line.Split(',');
            for (int i = 0; i < wordArray.Length; i++) 
            {
                //Console.WriteLine(wordArray[i]);
                if (ID == wordArray[i] && password == wordArray[i + 1])
                {
                    Console.WriteLine($"You are {wordArray[i - 2]} {wordArray[i - 1]} with ID {ID} matching {wordArray[2]}");
                    Console.WriteLine($"Password is {wordArray[i + 1]} matching {password}");
                    correctID = true;
                    correctPassword = true;
                    LogIn(correctID, correctPassword, wordArray);
                }
                else if (ID == wordArray[i] && password != wordArray[i+1])
                {
                    correctID = true;
                    correctPassword = false;
                    LogIn(correctID, correctPassword, wordArray);
                }
            }
        }
        if (!correctID)
        {
            string[] wordArray = { };
            Console.WriteLine("Could not find ID");
            LogIn(correctID, correctPassword, wordArray);
        }
    }
}

void LoggedIn(string[] wordArray)
{
    Console.Clear();
    string typeID = wordArray[4];
    if (typeID == "1")
    {
        personType = "Student";
        StudentPage(wordArray);
    }
    else if (typeID == "2")
    {
        personType = "Personal Supervisor";
        SupervisorPage(wordArray);
    }
    else if (typeID == "3")
    {
        personType = "Senior Tutor";
        SeniorPage(wordArray);
    }
}

void StudentPage(string[] wordArray)
{
    Console.WriteLine("Welcome to the Student Page");
    Console.WriteLine($"You have logged in as a {personType} called {wordArray[0]} {wordArray[1]} with ID:{wordArray[2]}");
    Console.WriteLine("1. Report your feelings");
    Console.WriteLine("2. Book a meeting");
    Console.WriteLine("3. Exit");
}

void ReportStatus()
{
    Console.WriteLine("1. Status Survey");
    Console.WriteLine("2. Write a note");
    userInput = int.Parse(Console.ReadLine());
    if (userInput == 1)
    {
        Console.WriteLine("Welcome to the Status Survey, please answer each question out of ten");
        Console.WriteLine("How do you feel about your course?");
        Console.WriteLine("How do you feel about the pace of the course?");
        Console.WriteLine("How do you feel about the coursework you have to complete");
    }
    else if (userInput == 2)
    {

    }
}
void SupervisorPage(string[] wordArray)
{
    Console.WriteLine("Welcome to the Personal Supervisor Page");
    Console.WriteLine($"You have logged in as a {personType} called {wordArray[0]} {wordArray[1]} with ID:{wordArray[2]}");
}

void SeniorPage(string[] wordArray)
{
    Console.WriteLine("Welcome to the Senior Tutor Page");
    Console.WriteLine($"You have logged in as a {personType} called {wordArray[0]} {wordArray[1]} with ID:{wordArray[2]}");
}