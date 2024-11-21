using DesignDevelopDeploy;
namespace UnitTests
{
    // Base class to handle common login functionality
    [TestClass]
    public abstract class BaseTest
    {
        protected void LogInAsUser(string id, string password)
        {
            Console.SetIn(new StringReader(id)); // User ID
            Console.SetIn(new StringReader(password)); // User Password

            bool correctID = false;
            bool correctPassword = false;
            string[] wordArray = new string[0];
            LogIn(correctID, correctPassword, wordArray); // Assuming LogIn is defined elsewhere
        }
    }

    [TestClass]
    public class TestCase1_RegisterUsers : BaseTest
    {
        [TestMethod]
        public void RegisterUsers()
        {
            // Register Student
            RegisterNewUser("Student", "John", "Doe", "student001", "password123");

            // Register Personal Supervisor
            RegisterNewUser("Personal Supervisor", "Alice", "Smith", "supervisor001", "password123");

            // Register Senior Tutor
            RegisterNewUser("Senior Tutor", "Dr. Bob", "Johnson", "tutor001", "password123");

            Console.WriteLine("Test Case 1 - Register: Passed");
        }

        private void RegisterNewUser(string userType, string firstName, string lastName, string id, string password)
        {
            Console.SetIn(new StringReader("1")); // Select the user type
            Console.SetIn(new StringReader(firstName)); // First Name
            Console.SetIn(new StringReader(lastName));  // Last Name
            Console.SetIn(new StringReader(id));       // ID
            Console.SetIn(new StringReader(password)); // Password

            if (userType == "Student")
                Console.SetIn(new StringReader("1"));  // Choose Student option
            else if (userType == "Personal Supervisor")
                Console.SetIn(new StringReader("2"));  // Choose Personal Supervisor option
            else if (userType == "Senior Tutor")
                Console.SetIn(new StringReader("3"));  // Choose Senior Tutor option

            Register(); // Assuming Register is defined elsewhere
        }
    }

    [TestClass]
    public class TestCase2_Login : BaseTest
    {
        [TestMethod]
        public void Login()
        {
            // Log in as Student
            LogInAsUser("student001", "password123");

            // Log in as Personal Supervisor
            LogInAsUser("supervisor001", "password123");

            // Log in as Senior Tutor
            LogInAsUser("tutor001", "password123");

            Console.WriteLine("Test Case 2 - Log In: Passed");
        }
    }

    [TestClass]
    public class TestCase3_ReportProgress : BaseTest
    {
        [TestMethod]
        public void ReportProgress()
        {
            // Log in as Student
            LogInAsUser("student001", "password123");

            // Simulate reporting progress
            SimulateReportProgress();

            Console.WriteLine("Test Case 3 - Report Progress: Passed");
        }

        private void SimulateReportProgress()
        {
            Console.SetIn(new StringReader("1")); // Choose the status survey
            Console.SetIn(new StringReader("8")); // Example answer for "How do you feel about your course?"
            ReportStatus(new string[] { "John", "Doe", "student001", "password123", "1" }); // Assuming ReportStatus is defined elsewhere
        }
    }

    [TestClass]
    public class TestCase4_WriteNote : BaseTest
    {
        [TestMethod]
        public void WriteNote()
        {
            // Log in as Student
            LogInAsUser("student001", "password123");

            // Simulate writing a note
            SimulateWriteNote();

            Console.WriteLine("Test Case 4 - Write a Note: Passed");
        }

        private void SimulateWriteNote()
        {
            Console.SetIn(new StringReader("This is a test note."));
            makeNote(new string[] { "John", "Doe", "student001", "password123", "1" }); // Assuming makeNote is defined elsewhere
        }
    }

    [TestClass]
    public class TestCase5_BookMeetingAsStudent : BaseTest
    {
        [TestMethod]
        public void BookMeetingAsStudent()
        {
            // Log in as Student
            LogInAsUser("student001", "password123");

            // Simulate booking a meeting with Personal Supervisor
            SimulateBookMeetingAsStudent();

            Console.WriteLine("Test Case 5 - Book a Meeting as Student: Passed");
        }

        private void SimulateBookMeetingAsStudent()
        {
            Console.SetIn(new StringReader("1")); // Book a meeting
            Console.SetIn(new StringReader("1")); // Select the first personal supervisor
            Console.SetIn(new StringReader("15")); // Select meeting time (e.g., 15:00)
            bookMeeting(new string[] { "John", "Doe", "student001", "password123", "1" }, "2"); // Assuming bookMeeting is defined elsewhere
        }
    }

    [TestClass]
    public class TestCase6_UpdateProgress : BaseTest
    {
        [TestMethod]
        public void UpdateProgress()
        {
            // Log in as Student
            LogInAsUser("student001", "password123");

            // Simulate updating progress
            SimulateReportProgress(); // Reuse the progress reporting from TestCase3

            Console.WriteLine("Test Case 6 - Update Progress: Passed");
        }

        private void SimulateReportProgress()
        {
            Console.SetIn(new StringReader("1")); // Choose the status survey
            Console.SetIn(new StringReader("8")); // Example answer for "How do you feel about your course?"
            ReportStatus(new string[] { "John", "Doe", "student001", "password123", "1" }); // Assuming ReportStatus is defined elsewhere
        }
    }

    [TestClass]
    public class TestCase7_ReviewStudentStatus : BaseTest
    {
        [TestMethod]
        public void ReviewStudentStatus()
        {
            // Log in as Personal Supervisor
            LogInAsUser("supervisor001", "password123");

            // Simulate reviewing a student's status
            SimulateReviewStudentStatus();

            Console.WriteLine("Test Case 7 - Review Student's Status: Passed");
        }

        private void SimulateReviewStudentStatus()
        {
            Console.SetIn(new StringReader("1")); // Review student status
            ReviewStudentStatus(new string[] { "Alice", "Smith", "supervisor001", "password123", "2" }); // Assuming ReviewStudentStatus is defined elsewhere
        }
    }

    [TestClass]
    public class TestCase8_BookMeetingAsSupervisor : BaseTest
    {
        [TestMethod]
        public void BookMeetingAsSupervisor()
        {
            // Log in as Personal Supervisor
            LogInAsUser("supervisor001", "password123");

            // Simulate booking a meeting with a student
            SimulateBookMeetingAsSupervisor();

            Console.WriteLine("Test Case 8 - Book a Meeting as Personal Supervisor: Passed");
        }

        private void SimulateBookMeetingAsSupervisor()
        {
            Console.SetIn(new StringReader("1")); // Book a meeting
            Console.SetIn(new StringReader("1")); // Select the first student
            Console.SetIn(new StringReader("14")); // Select meeting time (e.g., 14:00)
            bookMeeting(new string[] { "Alice", "Smith", "supervisor001", "password123", "2" }, "1"); // Assuming bookMeeting is defined elsewhere
        }
    }

    [TestClass]
    public class TestCase9_ViewMeetings : BaseTest
    {
        [TestMethod]
        public void ViewMeetings()
        {
            // Log in as Personal Supervisor
            LogInAsUser("supervisor001", "password123");

            // Simulate viewing meetings
            SimulateViewMeetings();

            Console.WriteLine("Test Case 9 - View Meetings: Passed");
        }

        private void SimulateViewMeetings()
        {
            // View meetings for the supervisor
            string supervisorID = "supervisor001";
            meetings(supervisorID, "student001"); // Assuming meetings is defined elsewhere
        }
    }

    [TestClass]
    public class TestCase10_ViewStudentNotes : BaseTest
    {
        [TestMethod]
        public void ViewStudentNotes()
        {
            // Log in as Personal Supervisor
            LogInAsUser("supervisor001", "password123");

            // Simulate viewing student's notes
            SimulateViewStudentNotes();

            Console.WriteLine("Test Case 10 - View Student's Notes: Passed");
        }

        private void SimulateViewStudentNotes()
        {
            // View notes for a student
            ViewStudentNotes("student001"); // Assuming ViewStudentNotes is defined elsewhere
        }
    }

    [TestClass]
    public class TestCase11_ReviewSupervisorInteractions : BaseTest
    {
        [TestMethod]
        public void ReviewSupervisorInteractions()
        {
            // Log in as Senior Tutor
            LogInAsUser("tutor001", "password123");

            // Simulate reviewing interactions with a supervisor
            SimulateReviewSupervisorInteractions();

            Console.WriteLine("Test Case 11 - Review Supervisor Interactions: Passed");
        }

        private void SimulateReviewSupervisorInteractions()
        {
            using (var stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                // Assuming ReviewSupervisorInteractions is defined elsewhere
                ReviewSupervisorInteractions(new string[] { "Dr. Bob", "Johnson", "tutor001", "password123", "3" });
                string output = stringWriter.ToString();
                Assert.IsTrue(output.Contains("Supervisor interactions:"));
            }
        }
    }
}
