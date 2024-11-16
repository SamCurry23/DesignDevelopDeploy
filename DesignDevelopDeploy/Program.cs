int userInput;
string ID;
string Password;
string FirstName;
string LastName;
string writeToText;
int typeID;
string projectRoot = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
string studentsFilePath = Path.Combine(projectRoot, "Students.txt");
string notesFilePath = Path.Combine(projectRoot, "StudentNotes.txt");
string meetingFilePath = Path.Combine(projectRoot, "Meetings.txt");
bool correctPassword = false;
bool correctID = false;
string personType = "";
int logInCount = 0;
string userText;


Choices();


void Choices() // Method that gives the user the initial choices when using the program
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
    using (StreamWriter writer = new StreamWriter(studentsFilePath, true))
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
        Console.WriteLine("Incorrect ID your account might not exist, would you like to register an account?");
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
    using (StreamReader reader = new StreamReader(studentsFilePath, true))
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
    userInput = int.Parse(Console.ReadLine());
    if (userInput == 1)
    {
        ReportStatus(wordArray);
    }
    else if (userInput == 2)
    {
        string meetingType = "2";
        bookMeeting(wordArray, meetingType);
    }
    else if (userInput == 3)
    {
        
    }
}

void ReportStatus(string[] wordArray)
{
    Console.Clear();
    Console.WriteLine("1. Status Survey");
    Console.WriteLine("2. Write a note");
    int[] feelingsArray = new int[10];
    int userScore = 0;
    userInput = int.Parse(Console.ReadLine());
    if (userInput == 1)
    {
        Console.WriteLine("Welcome to the Status Survey, please answer each question out of ten");
        Console.WriteLine("How do you feel about your course?");
        feelingsArray[0] = int.Parse(Console.ReadLine());
        Console.WriteLine("How do you feel about the pace of the course?");
        feelingsArray[1] = int.Parse(Console.ReadLine());
        Console.WriteLine("How do you feel about the coursework you have to complete?");
        feelingsArray[2] = int.Parse(Console.ReadLine());
        Console.WriteLine("How do you feel about the amount of resources available to you?");
        feelingsArray[3] = int.Parse(Console.ReadLine());
        Console.WriteLine("How do you feel about the content covered in lectures?");
        feelingsArray[4] = int.Parse(Console.ReadLine());
        Console.WriteLine("How do you feel about your progress in labs?");
        feelingsArray[5] = int.Parse(Console.ReadLine());
        Console.WriteLine("How do you feel about your living standards?");
        feelingsArray[6] = int.Parse(Console.ReadLine());
        Console.WriteLine("How do you feel about your financial situation?");
        feelingsArray[7] = int.Parse(Console.ReadLine());
        Console.WriteLine("How do you feel about the support systems in place?");
        feelingsArray[8] = int.Parse(Console.ReadLine());
        Console.WriteLine("How do you feel about your accessibility onsite?");
        feelingsArray[9] = int.Parse(Console.ReadLine());
        for (int i = 0; i < 10; i++)
        {
            userScore += feelingsArray[i];
        }
        Console.WriteLine(userScore);
        string currentTime = DateTime.Now.ToString("MM/dd/yyyy h:mm tt");
        string note = "UserScore" + "," + wordArray[2] + "," + currentTime + "," + userScore;
        using (StreamWriter writer = new StreamWriter(notesFilePath, true))
        {
            writer.WriteLine(note);
            writer.Flush();
        }
        if (userScore < 50)
        {
            Console.WriteLine("Your total score was less than 50 please provide a more detailed reasoning for your answers:");
            makeNote(wordArray);
        }
        Console.WriteLine("Press any key to go back");
        Console.ReadKey();
        StudentPage(wordArray);
    }
    else if (userInput == 2)
    {
        makeNote(wordArray);
    }
}

void makeNote(string[] wordArray)
{
    Console.Clear();
    Console.WriteLine("Please type your note on the following line.");
    userText = Console.ReadLine();
    string currentTime = DateTime.Now.ToString("MM/dd/yyyy h:mm tt");
    userText = userText + "," + wordArray[2] + "," + currentTime;
    using (StreamWriter writer = new StreamWriter(notesFilePath, true))
    {
        writer.WriteLine(userText);
        writer.Flush();
    }
}

void bookMeeting(string[] wordArray, string meetingType)
{
    Console.Clear();
    Console.WriteLine("Who would you like to book a meeting with?");
    using (StreamReader reader = new StreamReader(studentsFilePath, true))
    {
        string line;
        string text = "";
        List<string> words = new List<string>();
        while ((line = reader.ReadLine()) != null)
        {
            string[] newArray = line.Split(',');
            if (newArray[4] == meetingType)
            {
                string toArray = newArray[0] + "," + newArray[1] + "," + newArray[2];
                words.Add(toArray);
            }        
        }
        string[] personalSupervisors = new string[words.Count];
        for (int i = 0; i < words.Count; i++)
        {
            personalSupervisors[i] = words[i];
        }
        Console.WriteLine(personalSupervisors[0]);
        Console.WriteLine(personalSupervisors[1]);
        for (int i = 0; i < personalSupervisors.Length; i++)
        {
            string[] tempArray = personalSupervisors[i].Split(',');
            Console.WriteLine($"{i+1}. {tempArray[0]} {tempArray[1]}");
        }
        userInput = int.Parse(Console.ReadLine());
        for (int i = 0; i < personalSupervisors.Length; i++)
        {
            string[] tempArray = personalSupervisors[userInput - 1].Split(',');
            text = $"{wordArray[2]},{tempArray[2]}";
        }
        Console.WriteLine("What time would you like the meeting to be? Choose an hour between 10 and 18");
        string meetingTime = Console.ReadLine();
        text = text + "," + meetingTime +":00";
        Console.WriteLine(text);
        using (StreamWriter writer = new StreamWriter(meetingFilePath, true))
        {
            writer.WriteLine(text);
            writer.Flush();
        }
    }
}

void SupervisorPage(string[] wordArray)
{
    string studentID = "";
    int userScore = 0;
    string FullName = "";
    List<string> notes = new List<string>();
    List<string> times = new List<string>();
    Console.WriteLine("Welcome to the Personal Supervisor Page");
    Console.WriteLine($"You have logged in as a {personType} called {wordArray[0]} {wordArray[1]} with ID:{wordArray[2]}");
    Console.WriteLine("1. Book a meeting");
    Console.WriteLine("2. Review student status");
    userInput = int.Parse(Console.ReadLine());
    Console.Clear();
    if (userInput == 1)
    {
        string meetingType = "1";
        bookMeeting(wordArray, meetingType);
    }
    if (userInput == 2)
    {
        using (StreamReader reader = new StreamReader(studentsFilePath, true))
        {
            string line;
            string text = "";
            List<string> words = new List<string>();
            while ((line = reader.ReadLine()) != null)
            {
                string[] newArray = line.Split(',');
                if (newArray[4] == "1")
                {
                    string toArray = newArray[0] + "," + newArray[1] + "," + newArray[2];
                    FullName = newArray[0] + " " + newArray[1];
                    words.Add(toArray);
                }
            }
            string[] personalSupervisors = new string[words.Count];
            for (int i = 0; i < words.Count; i++)
            {
                personalSupervisors[i] = words[i];
            }
            for (int i = 0; i < personalSupervisors.Length; i++)
            {
                string[] tempArray = personalSupervisors[i].Split(',');
                Console.WriteLine($"{i + 1}. {tempArray[0]} {tempArray[1]}");
            }
            userInput = int.Parse(Console.ReadLine());
            for (int i = 0; i < personalSupervisors.Length; i++)
            {
                string[] tempArray = personalSupervisors[userInput - 1].Split(',');
                text = $"{wordArray[2]},{tempArray[2]}";
                studentID = tempArray[2];
            }
            //Console.WriteLine(studentID);
        }
        using (StreamReader reader = new StreamReader(notesFilePath, true))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] newArray = line.Split(',');
                if (newArray[0] == "UserScore" && newArray[1] == studentID)
                {
                    userScore = int.Parse(newArray[3]);
                }
                else if (newArray[1] == studentID && !(newArray[0] == "UserScore"))
                {
                    notes.Add(newArray[0]);
                    times.Add(newArray[2]);
                }
            }
        }
        using (StreamReader reader = new StreamReader(studentsFilePath, true))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] newArray = line.Split(',');
                if (newArray[4] == "1" && newArray[2] == studentID)
                {
                    FullName = newArray[0] + " " + newArray[1];
                }
            }
        }
        //Console.WriteLine(userScore);
        //Console.WriteLine(FullName);
        Console.Clear();
        Console.WriteLine($"{FullName} has a total user score of {userScore}.");
        Console.WriteLine("1. Book a meeting");
        Console.WriteLine("2. View your meetings");
        Console.WriteLine("3. View notes");
        userInput = int.Parse(Console.ReadLine());
        if (userInput == 1)
        {
            string meetingType = "1";
            bookMeeting(wordArray, meetingType);
        }
        if (userInput == 2)
        {
            string supervisorID = wordArray[2];
            meetings(supervisorID, studentID);
        }
        if (userInput == 3)
        {
            using (StreamReader reader = new StreamReader(notesFilePath, true))
            {
                string line;
                List<string> words = new List<string>();
                while ((line = reader.ReadLine()) != null)
                {
                    string[] newArray = line.Split(',');
                    if (newArray[1] == studentID && !(newArray[0] == "UserScore"))
                    {
                        string text = $"Note created at {newArray[2]}, Full note: {newArray[0]}";
                        words.Add(text);
                    }
                }
                string[] finalArray = words.ToArray();
                for (int i = 0; i < finalArray.Length; i++)
                {
                    Console.WriteLine($"Note {i+1}: {finalArray[i]}");
                }
            }
        }
        
    }
}

void meetings(string supervisorID, string studentID)
{
    string studentName = "";
    string supervisorName = "";
    string meetingTime = "";
    List<string> words = new List<string>();
    using (StreamReader reader = new StreamReader(meetingFilePath, true))
    {
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            string[] newArray = line.Split(',');
            if (newArray[0] == supervisorID && newArray[1] == studentID || newArray[1] == supervisorID && newArray[0] == studentID)
            {
                words.Add(newArray[0] + "," + newArray[1] + "," + newArray[2]);
            }
        }
    }
    using (StreamReader reader = new StreamReader(studentsFilePath, true))
    {
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            string[] newArray = line.Split(',');
            if (newArray[2] == studentID)
            {
                studentName = newArray[0] + " " + newArray[1];
            }
            else if (newArray[2] == supervisorID)
            {
                supervisorName = newArray[0] + " " + newArray[1];
            }
        }
    }
    string[] finalArray = words.ToArray();
    for (int i = 0; i < finalArray.Length; i++)
    {
        string[] newArray = finalArray[i].Split(",");
        Console.WriteLine($"{supervisorName} has a meeting with {studentName} at {newArray[2]}");
    }
}

void SeniorPage(string[] wordArray)
{
    Console.WriteLine("Welcome to the Senior Tutor Page");
    Console.WriteLine($"You have logged in as a {personType} called {wordArray[0]} {wordArray[1]} with ID:{wordArray[2]}");
    Console.WriteLine("Which supervisor would you like to view?");
    using (StreamReader reader = new StreamReader(studentsFilePath, true))
    {
        string line;
        string text = "";
        List<string> words = new List<string>();
        List<string> students = new List<string>();
        while ((line = reader.ReadLine()) != null)
        {
            string[] newArray = line.Split(',');
            if (newArray[4] == "2")
            {
                string toArray = newArray[0] + "," + newArray[1] + "," + newArray[2];
                words.Add(toArray);
            }
            if (newArray[4] == "1")
            {
                students.Add(newArray[2]);
            }
        }
        string[] personalSupervisors = new string[words.Count];
        for (int i = 0; i < words.Count; i++)
        {
            personalSupervisors[i] = words[i];
        }
        for (int i = 0; i < personalSupervisors.Length; i++)
        {
            string[] tempArray = personalSupervisors[i].Split(',');
            Console.WriteLine($"{i + 1}. {tempArray[0]} {tempArray[1]}");
        }
        userInput = int.Parse(Console.ReadLine());
        for (int i = 0; i < personalSupervisors.Length; i++)
        {
            string[] tempArray = personalSupervisors[userInput - 1].Split(',');
            text = tempArray[2];
        }
        string[] idArray = students.ToArray();
        for (int i = 0; i < idArray.Length; i++)
        {
            meetings(text, idArray[i]);
        }
    }
}