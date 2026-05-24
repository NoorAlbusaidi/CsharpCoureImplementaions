using System.Diagnostics.Metrics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace libraryManagementSystem
{
    internal class Program
    {
        //storage(variables)
        static int choice;
        static string memberName = "";
        static string memberNationalID = "";
        static string memberID = "";
        static string memberEmail = "";
        static DateTime membershipExpiryDate;
        static DateTime membershipStartDate;
        static string memberTierName = "";
        static int memberTierChoice = 0;
        static string bookTitle = "";
        static string bookAuthor = "";
        static string bookGenre = "";
        static int CopiesNum = 0; //constant
        static bool memberRegistered = false;
        static bool bookRegistered = false;
        static bool borrowActive = false;
        static bool returnActive = false;
        static int borrowedBooks = 0;
        static double totalFines = 0.0;
        bool searchedBook = false;
        static string keyword = "";
        static int registeredBookNum = 0;
        static DateTime borrowDate;
        static DateTime returnDate;
        static DateTime exactReturnDate;
        static int durationLateDays = 0;
        static int fineDays = 0;
        const double FINE = 0.500;
        static double payment = 0.0;

        public static bool IsMemberEligible(DateTime expiryDate)
        {

            // Compare with today's date
            if (expiryDate >= DateTime.Now)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static double MemberDiscount(string tier) {
            if (tier == "Basic")
            {
                return 10 / 100;
            }
            else if (tier == "Standard")
            {
                return 20 / 100;
            }
            else if (tier == "Premium")
            {
                return 30 / 100;
            }
            else if (tier == "Student")
            {
                return 40 / 100;
            }
            else if (tier == "VIP")
            {
                return 50 / 100;
            }
            else return -1;
        }
        public bool IsMemberEligible(string expiryDate)
        {
            // Convert string to DateTime
            DateTime expiry = DateTime.Parse(expiryDate);

            // Compare with today's date
            if (expiry >= DateTime.Now)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static int CalculateLateFine(DateTime returndate, DateTime borrowdate) {

                TimeSpan lateDays = returndate - borrowdate;
                int days = lateDays.Days;
                return days;
            

        }
        public static void returnBook(ref int copies) {
            // if borrowActive == true means someone is borrowed the book means the book is registered so no need to check if bookRegistered
            // so first you need to borrow a book 
            if (borrowActive)
            {
                copies++;
                borrowedBooks--;
                borrowActive = false;
                Console.WriteLine("Available copies after returning process: " + copies);
                exactReturnDate = DateTime.Now;
                Console.WriteLine("You return the book at: " + exactReturnDate);
            }
            else {
                Console.WriteLine("there is no borrowed book");
            }

         }
        public static void borrowBook(ref int copies) {
            // the book must be registered
            if (bookRegistered)
            {
                // to can borrow the copies must be > 0
                if (copies > 0)
                {
                    copies--;
                    borrowedBooks++;
                    // to use it later in returning process if the book is borrowed so there is returning process
                    borrowActive = true;
                    Console.WriteLine("Available copies after borrowing process: " + copies);
                    Console.WriteLine("number of borrowed books from library: "+ borrowedBooks);
                    // the borrowing duration = 3 days from now
                    borrowDate = DateTime.Now;
                     returnDate = borrowDate.AddDays(3);
                    borrowedBooks++;
                    Console.WriteLine("Borrow Date: " + borrowDate);
                    Console.WriteLine("Return Date: " + returnDate);

                    // pause to be able to see the result
                    Thread.Sleep(1000);


                }
                else {
                    Console.WriteLine("The book is out of stock \n");

                }
            }
            else Console.WriteLine("There is no registered book \n");
   
        }
        public static void registerBookSystem() {
            // only  library employee can register books
            Console.Write("Are you a library employee? ");
            string answer = Console.ReadLine();
            if (answer.ToLower() == "yes")
            {

                Console.Write("enter the book title: ");
                bookTitle = Console.ReadLine();

                Console.Write("enter the book author: ");
                bookAuthor = Console.ReadLine();

                Console.Write("enter the number of available copies: ");
                CopiesNum = int.Parse(Console.ReadLine());

                Console.Write("enter the book genre(Optional): ");
                bookGenre = Console.ReadLine();

                //if the user enter space or enter(key)
                if (string.IsNullOrWhiteSpace(bookGenre))
                {
                    // no need for genre will use the default one
                    registerBook(bookTitle, bookAuthor, CopiesNum);
                }
                else
                {
                    // if the employee entered a genre
                    registerBook(bookTitle, bookAuthor, CopiesNum, bookGenre);
                }
            }
            else Console.WriteLine("This service only for library staff \n ");

        }
        //Register Book
        public static void registerBook(string title, string author, int copies, string genre = "General") {
            Console.WriteLine("\nBook Registered:");
            Console.WriteLine($"Title: {title}");
            Console.WriteLine($"Author: {author}");
            Console.WriteLine($"Copies: {copies}");
            Console.WriteLine($"Genre: {genre}");
            //increase the number of registered books in the library
            bookRegistered = true;
            registeredBookNum++;
            Console.WriteLine();
        }
        // view book info 
        public static void viewBookInfo() {
            Console.WriteLine("the book title: " + bookTitle);
            Console.WriteLine("the book author: " + bookAuthor);
            Console.WriteLine("the book Genre: " + bookGenre);
            Console.WriteLine();
        }
        //Search Book by Title
        public static bool searchBook(string keyword) {

                // will allow you to search for a book if there is a registered book
                // true = there is the determined book 
                // false = book not found
                if (bookRegistered)
                {
                    //avoid sensitivity in letter cases(convert them to lower)
                    if (bookTitle.ToLower().Contains(keyword.ToLower()))
                    {
                        return true;
                    }
                    else return false;

                }
                else
                {
                    return false;

                }   
        }
        //view member info
        public static void viewMemberProfile() {
            // view member info if he is registered
            if (memberRegistered)
            {
                Console.WriteLine();
                Console.WriteLine(
                                        "Member Name".PadRight(20) +
                                        "National ID".PadRight(20) +
                                        "Email".PadRight(20)+
                                        "Tier".PadRight(20) +
                                        "Start Date".PadRight(20) +
                                        "Expiry Date".PadRight(20));

                Console.WriteLine(new string('-', 120));
                
                Console.WriteLine(memberName.ToUpper().PadRight(20) + 
                    memberNationalID.PadRight(20)+ 
                    memberEmail.ToLower().PadRight(20)+ 
                    memberTierName.ToUpper().PadRight(20)+ 
                    membershipStartDate.ToString("yyyy-MM-dd ").PadRight(20)+
                    membershipExpiryDate.ToString("yyyy-MM-dd").PadRight(20)
                    );     
            }
            else Console.WriteLine("No info to print. You need to register first");



        }
        public static void viewMainMenue() {
            Console.WriteLine("Library Services: \n 0. Register Member \n 1. Display Member Profile \n 2. Search Book by Title \n 3. Borrow a Book \n 4. Return a Book \n 5. Calculate Late Fine \n 6. Apply Member Discount    ");
            Console.WriteLine(" 7. Check Borrowing Eligibility \n 8. Register Book \n 9. Generate Member ID \n 10. Display Book Details \n 11. Calculate Renewal Fee \n 12. Update Member Email \n 13. Session Summary");

            Console.Write("Enter a number of a service: ");
            choice = int.Parse(Console.ReadLine());
        }
      
        public static void registerMember() {
            if (memberRegistered)
            {
                Console.WriteLine("You are already registered");
            }
            else {
                Console.Write("Enter your full name (first and last): ");
                memberName = Console.ReadLine();

                // Split by space and to remove extra spaces like if i enter (noor alhuda )
                string[] nameParts = memberName.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                //validate the member name
                while (memberName == "" || memberName.Length < 3 || nameParts.Length!=2) {
                    Console.WriteLine("Error: Invalid name");
                    Console.Write("Enter your full name (first and last): ");
                    memberName = Console.ReadLine();
                }

                Console.Write("Enter your national ID: ");
                memberNationalID = Console.ReadLine();

                //validate the member ID(must be 8 numbers)
                while (memberNationalID.Length > 8 || memberNationalID.Length < 8)
                {
                    Console.WriteLine("Error: Invalid ID");
                    Console.Write("Enter your national ID: ");
                    memberNationalID = Console.ReadLine();
                }

                Console.Write("Enter your Email: ");
                memberEmail = Console.ReadLine();

                //the email must incluse @gmail.com 
                while (!memberEmail.Contains("@gmail.com")) {
                    Console.WriteLine("Error: Invalid Email");
                    Console.Write("Enter your Email: ");
                    memberEmail = Console.ReadLine();
                }

                //the member should choose his tier
                Console.WriteLine("Menue of membership tiers: ");
                Console.WriteLine("1. Basic");
                Console.WriteLine("2. Standard");
                Console.WriteLine("3. Premium");
                Console.WriteLine("4. Student");
                Console.WriteLine("5. VIP");

                Console.Write("Enter your membership tier number: ");
                memberTierChoice = int.Parse(Console.ReadLine());

                //validate the memberTierChoice
                while (memberTierChoice != 1 && memberTierChoice != 2 && memberTierChoice != 3 && memberTierChoice != 4 && memberTierChoice != 5) {
                    Console.WriteLine("Invalid choice");
                    Console.Write("Enter your membership tier number: ");
                    memberTierChoice = int.Parse(Console.ReadLine());
                }
                //save the type
                if (memberTierChoice == 1) {
                    memberTierName = "Basic";
                    // the membership is valid for 1 month
                    membershipStartDate = DateTime.Now;
                    membershipExpiryDate = membershipStartDate.AddMonths(1); //add 1 month from the start date
                }
                else if(memberTierChoice ==2 ) {
                    memberTierName = "Standard";
                    // the membership is valid for 3 months
                    membershipStartDate = DateTime.Now;
                    membershipExpiryDate = membershipStartDate.AddMonths(3); //add 3 months from the start date
                }
                else if (memberTierChoice == 3) {
                    memberTierName = "Premium";
                    // the membership is valid for 6 months
                    membershipStartDate = DateTime.Now;
                    membershipExpiryDate = membershipStartDate.AddMonths(6); //add 6 months from the start date
                }
                else if (memberTierChoice == 4) {
                    memberTierName = "Student";
                    // the membership is valid for 10 months
                    membershipStartDate = DateTime.Now;
                    membershipExpiryDate = membershipStartDate.AddMonths(10); //add 10 months from the start date
                }
                else if (memberTierChoice == 5) {
                    memberTierName = "VIP";
                    // the membership is valid for 1 year
                    membershipStartDate = DateTime.Now;
                    membershipExpiryDate = membershipStartDate.AddYears(1); //add one year from the start date
                }
                memberRegistered = true;

                Console.WriteLine("YOUR REGISTERATION IS DONE");
                Console.WriteLine("=== WELCOME TO OUR LIBRARY ===");

            }//else
        }//registerMember
        static void Main(string[] args)
        {
            //view main library services
            viewMainMenue();

            while (choice != 13) {
                switch (choice) {
                    //register the member
                    case 0:
                        registerMember();
                        Thread.Sleep(3000);
                        Console.Clear();
                        break;

                    case 1:
                        viewMemberProfile();
                        //double space
                        Console.WriteLine("\n");
                        break;

                    case 2:
                        if (memberRegistered)
                        {
                            Console.Write("Enter the book name you want it: ");
                            keyword = Console.ReadLine();
                            keyword = keyword.Trim();

                            if (searchBook(keyword))
                            {
                                Console.WriteLine("the book is found: ");
                                //pause for 2 sec to can see the result then clear the console
                                Thread.Sleep(2000);
                                Console.Clear();
                                // to show the book info
                                viewBookInfo();

                            }
                            else
                            {
                                Console.WriteLine("the book is not found ");
                                //pause for 2 sec to can see the result then clear the console
                                Thread.Sleep(2000);
                                Console.Clear();
                               
                            }
                        }//if (memberRegistered)
                        else
                        {
                            Console.WriteLine("you need to registered first");
                            //pause for 2 sec to can see the result then clear the console
                            Thread.Sleep(2000);
                            Console.Clear();
                            
                        }

                        break;

                    case 3:
                        if (memberRegistered)
                        {
                            borrowBook(ref CopiesNum);
                            Thread.Sleep(3000);
                            Console.Clear();
                        }
                        else {
                            Console.WriteLine("you need to register first");
                            
                            //pause for 2 sec to can see the result then clear the console
                            Thread.Sleep(2000);
                            Console.Clear();
                        }
                        break;

                    case 4:
                        if (memberRegistered)
                        {
                            returnBook(ref CopiesNum);
                            Thread.Sleep(3000);
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("you need to register first");

                            //pause for 2 sec to can see the result then clear the console
                            Thread.Sleep(2000);
                            Console.Clear();
                        }
                        break;

                        //###need to be checked
                    case 5:
                        if (memberRegistered)
                        {
                            // means you returned the book
                            if (borrowActive == false)
                            {
                                durationLateDays = CalculateLateFine(exactReturnDate, borrowDate);
                                if (durationLateDays > 3)
                                {
                                    fineDays = durationLateDays - 3;
                                    Console.WriteLine("You are late for: " + fineDays + " Days.");

                                    //payment FINE PER DAY = 0.500
                                    payment = fineDays * FINE;
                                    Console.WriteLine("you need to pay: " + payment + " OMR");

                                }
                                else
                                {
                                    Console.WriteLine("No fine to pay");
                                }
                            }
                            else   
                                {
                                //if durationLateDays <= 3
                                Console.WriteLine("you need to return the book first");
                            }
                        }
                        else {
                            Console.WriteLine("you need to register first");
                        }
                        break;

                    case 6:

                        break;

                    case 7:
                        if (memberRegistered)
                        {
                            if (IsMemberEligible(membershipExpiryDate))
                            {
                                Console.WriteLine("You are Eligibile to borrow");
                                //pause for 2 sec to can see the result then clear the console
                                Thread.Sleep(2000);
                                Console.Clear();

                            }
                            else
                            {
                                Console.WriteLine("You need to renew your membership");
                                //pause for 2 sec to can see the result then clear the console
                                Thread.Sleep(2000);
                                Console.Clear();
                            }
                        }
                        else Console.WriteLine("You need to register first \n");
                        //pause for 2 sec to can see the result then clear the console
                        Thread.Sleep(2000);
                        Console.Clear();
                        break;

                    case 8:
                        registerBookSystem();
                        break;

                    case 9:
                        break;

                    case 10:
                        break;

                    case 11:
                        break;

                    case 12:
                        break;

                    case 13:
                        break;

                    default:
                        Console.WriteLine("Invalid choice");
                        break;





                }//switch (choice)

                //after each case will allow for user to choose another service
                viewMainMenue();
            }//while (choice != 0)
            
            //when choice == 13 show the summary of the session



        }
    }
}
