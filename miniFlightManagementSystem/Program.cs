using System.Net.Http.Headers;
using static System.Net.Mime.MediaTypeNames;

namespace flightManagementSystem
{
    internal class Program
    {
        static List<String> passengerNames = new List<String> { "Ali", "Sara", "Omar", "Laila", "Hassan" };

        static Queue<string> checkedInQueue = new Queue<string>();
        static Queue<string> tempQueue = new Queue<string>();
        static Queue<string> waitlistQueue = new Queue<string>();

        static Stack<string> boardingStack = new Stack<string>();
        static Stack<string> tempStack = new Stack<string>();

        static List<string> ticketNumbers = new List<string> { "T001", "T002", "T003", "T004", "T005" };
        static List<string> cancelledTickets = new List<string>();

        //dd-MMM-yyyy
        static List<DateTime> availableDates = new List<DateTime> {
        new DateTime(2026, 1, 1),
        new DateTime(2026, 1, 5),
        new DateTime(2026, 1, 10),
        new DateTime(2026, 1, 15)
        };

        static Dictionary<string, string> bookingRecord = new Dictionary<string, string>();
        static Dictionary<string, string> passengerSeatMap = new Dictionary<string, string>();

        static string[] flightNumbers = new string[] { "OA101", "OA102", "OA103", "OA104", "OA105", "OA106" };
        public static void registerNewPassenger()
        {


            bool exist = false;
            Console.Write("Enter passenger's full name: ");
            string fullName = Console.ReadLine();

            // Validation
            if (string.IsNullOrWhiteSpace(fullName))
            {
                Console.WriteLine("Error: Name cannot be empty.");
                return; // go back to menu
            }
            fullName = fullName.Trim();
            for (int i = 0; i < passengerNames.Count; i++)
            {

                if (fullName.ToLower() == passengerNames[i].ToLower())
                {
                    exist = true;
                    break;
                }
            }

            if (exist)
            {
                Console.WriteLine("Error: Passenger already exists.");
                return;
            }
            else
            {
                passengerNames.Add(fullName);
                Console.WriteLine("Passenger added successfully.");
                //"D3" → formats it to 3 digits with leading zeros
                int nextNumber = ticketNumbers.Count + 1;
                string ticketID = "TKT-" + nextNumber.ToString("D3");
                ticketNumbers.Add(ticketID);
                Console.WriteLine("Passenger added with Ticket ID: " + ticketID);
            }


        }

        public static void viewAllPassengers()
        {
            string name;
            string ticket;
            string status;
            if (passengerNames.Count == 0)
            {
                Console.WriteLine("No passengers registered yet.");
                return;
            }

            Console.WriteLine(
                                "No.".PadRight(5) +
                                "| " + "Passenger Name".PadRight(20) +
                                "| " + "Ticket ID".PadRight(12) +
                                "| " + "Status"
            );
            Console.WriteLine("-------------------------------------------------------------");

            for (int i = 0; i < passengerNames.Count; i++)
            {
                name = passengerNames[i];
                ticket = ticketNumbers[i];

                if (cancelledTickets.Contains(ticket))
                {
                    status = "CANCELLED";
                }
                else status = "Active";

                Console.WriteLine(
                                  (i + 1).ToString().PadRight(5) +
                                  "| " + name.PadRight(20) +
                                "| " + ticket.PadRight(12) +
                                 "| " + status
                );

            }

            Console.WriteLine("The Total passengers: " + passengerNames.Count);

        }

        public static void bookFlightTicket()
        {
            Console.Write("Enter Ticket ID: ");
            string ticketID = Console.ReadLine();
            string bookingValue;
            DateTime selectedDate;
            string selectedFlight;

            if (string.IsNullOrWhiteSpace(ticketID))
            {
                Console.WriteLine("Error: Ticket ID cannot be empty.");
                return;
            }

            ticketID = ticketID.Trim();

            // Check if ticket exists
            if (!ticketNumbers.Contains(ticketID))
            {
                Console.WriteLine("Error: Ticket ID does not exist.");
                return;
            }

            // Check if ticket is cancelled
            if (cancelledTickets.Contains(ticketID))
            {
                Console.WriteLine("Error: Ticket is already cancelled.");
                return;
            }

            // If valid
            Console.WriteLine("Ticket is valid.");

            // Check if ticket already has a booking
            if (bookingRecord.ContainsKey(ticketID))
            {
                Console.WriteLine("Error: This ticket already has a booking.");
                return;
            }
            if (flightNumbers.Length == 0)
            {
                Console.WriteLine("No flights available.");
                return;
            }
            Console.WriteLine("\nAvailable Flights:");

            for (int i = 0; i < flightNumbers.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {flightNumbers[i]}");
            }

            // Prompt user
            Console.Write("Select a flight (enter number 1-6): ");
            int flightChoice;
            flightChoice = int.Parse(Console.ReadLine());
            if (flightChoice < 1 || flightChoice > 6)
            {
                Console.WriteLine("Error: Selection out of range.");
                return;
            }

            // Display dates
            Console.WriteLine("Available Dates:");
            for (int i = 0; i < availableDates.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {availableDates[i].ToString("dd-MMM-yyyy")}");
            }
            Console.Write("Select a date by entering its number: ");
            int dateChoice;
            dateChoice = int.Parse(Console.ReadLine());

            if (dateChoice < 1 || dateChoice > 4)
            {
                Console.WriteLine("Error: Selection out of range.");
                return;
            }
            //Get selected flight
            selectedFlight = flightNumbers[flightChoice - 1];
            // Get selected date
            selectedDate = availableDates[dateChoice - 1];
            //a value of the dictionary
            bookingValue = selectedFlight + "|" + selectedDate;

            // Store in dictionary
            bookingRecord.Add(ticketID, bookingValue);

            string passName = passengerNames[ticketNumbers.IndexOf(ticketID)];
            //showing details
            Console.WriteLine("\nBooking successful!");
            Console.WriteLine("Details: " + ticketID + " of " + passName + ": " + bookingValue);
        }

        public static void viewBookingDetails()
        {
            Console.Write("Enter Ticket ID: ");
            string ticketID = Console.ReadLine();

            // Check empty input
            if (string.IsNullOrWhiteSpace(ticketID))
            {
                Console.WriteLine("Error: Ticket ID cannot be empty.");
                return;
            }
            ticketID = ticketID.Trim();

            if (!ticketNumbers.Contains(ticketID))
            {
                Console.WriteLine("Error: Ticket ID not found.");
                return;
            }
            Console.WriteLine("Ticket found.");
            if (ticketNumbers.Count == passengerNames.Count)
            {
                int ticketIndex = ticketNumbers.IndexOf(ticketID);
                string passName = passengerNames[ticketIndex];
                Console.WriteLine("Passenger name is: " + passName);
            }
            else
            {
                Console.WriteLine("System Error");
                return;
            }

            if (cancelledTickets.Contains(ticketID))
            {
                Console.WriteLine("This ticket has been cancelled");
                return;
            }
            if (bookingRecord.ContainsKey(ticketID))
            {
                string value = bookingRecord[ticketID];
                string[] valParts = value.Split('|');
                Console.WriteLine("The flight number is: " + valParts[0]);
                Console.WriteLine("The flight date is: " + valParts[1]);
            }
            else
            {
                Console.WriteLine("No booking found for this ticket.");
            }

        }

        public static void UpdateBooking()
        {
            string flight = "";
            int date = 0;
            string updatedDate = "";
            Console.Write("Enter Ticket ID: ");
            string ticketID = Console.ReadLine();

            // Check empty input
            if (string.IsNullOrWhiteSpace(ticketID))
            {
                Console.WriteLine("Error: Ticket ID cannot be empty.");
                return;
            }
            ticketID = ticketID.Trim();

            if (!ticketNumbers.Contains(ticketID))
            {
                Console.WriteLine("Error: Ticket ID not found.");
                return;
            }
            else if (cancelledTickets.Contains(ticketID))
            {
                Console.WriteLine("This ticket has been cancelled");
                return;
            }
            else if (!bookingRecord.ContainsKey(ticketID))
            {
                Console.WriteLine("No booking found for this ticket.");
                return;
            }
            string value = bookingRecord[ticketID];
            string[] valParts = value.Split('|');
            Console.WriteLine("The flight number is: " + valParts[0]);
            Console.WriteLine("The flight date is: " + valParts[1]);

            Console.WriteLine("\nThe updating menue: ");
            Console.WriteLine("1. Change flight only\n2. Change date only\n3. Change both\n0. Cancel update");
            Console.Write("Enter your choice number: ");
            int userChoice = int.Parse(Console.ReadLine());
            if (userChoice == 1)
            {
                Console.WriteLine("\nThe flights: ");
                foreach (string fl in flightNumbers)
                {
                    Console.WriteLine(fl);
                }
                Console.Write("\nenter your updated flight: ");
                flight = Console.ReadLine();
                flight = flight.ToUpper();
                bookingRecord[ticketID] = flight + "|" + valParts[1];
                Console.Write("\nYour updated flight is: " + bookingRecord[ticketID]);

            }
            else if (userChoice == 2)
            {
                Console.WriteLine("\nThe available dates: ");
                int i = 0;
                foreach (DateTime da in availableDates)
                {
                    i++;
                    Console.WriteLine(i + ": " + da);

                }
                Console.Write("\nEnter the number of your updated date: ");
                date = int.Parse(Console.ReadLine());
                updatedDate = availableDates[date - 1].ToString();
                bookingRecord[ticketID] = valParts[0] + "|" + updatedDate;
                Console.Write("\nYour updated date is: " + bookingRecord[ticketID]);
            }
            else if (userChoice == 3)
            {
                Console.WriteLine("\nThe flights: ");
                foreach (string fl in flightNumbers)
                {
                    Console.WriteLine(fl);
                }
                Console.Write("\nenter your updated flight: ");
                flight = Console.ReadLine();
                flight = flight.ToUpper();

                Console.WriteLine("\nThe available dates: ");
                int i = 0;
                foreach (DateTime da in availableDates)
                {
                    i++;
                    Console.WriteLine(i + ": " + da);

                }
                Console.Write("\nEnter the number of your updated date: ");
                date = int.Parse(Console.ReadLine());
                updatedDate = availableDates[date - 1].ToString();
                bookingRecord[ticketID] = flight + "|" + updatedDate;
                Console.Write("\nYour updated date and flight: " + bookingRecord[ticketID]);


            }
            else if (userChoice == 0)
            {
                Console.WriteLine("No updates");
                return;
            }
            else
            {
                Console.WriteLine("invalid choice. try again");
                Console.WriteLine("\nThe updating menue: ");
                Console.WriteLine(" 1. Change flight only\n2. Change date only\n3. Change both\n0. Cancel update");
                Console.Write("Enter your choice number: ");
                userChoice = int.Parse(Console.ReadLine());
            }

        }

        public static void cancelTicket()
        {
            bool foundQueue = false;
            bool foundStack = false;
            string currentName = "";
            string removedName = "";
            Console.Write("Enter Ticket ID: ");
            string ticketID = Console.ReadLine();

            // Check empty input
            if (string.IsNullOrWhiteSpace(ticketID))
            {
                Console.WriteLine("Error: Ticket ID cannot be empty.");
                return;
            }
            ticketID = ticketID.Trim();

            if (!ticketNumbers.Contains(ticketID))
            {
                Console.WriteLine("Error: Ticket ID not found.");
                return;
            }
            else if (cancelledTickets.Contains(ticketID))
            {
                Console.WriteLine("This ticket has been cancelled");
                return;
            }
            else if (!bookingRecord.ContainsKey(ticketID))
            {
                Console.WriteLine("No booking found for this ticket.");
                return;
            }
            string passName = passengerNames[ticketNumbers.IndexOf(ticketID)];


            if (bookingRecord.ContainsKey(ticketID))
            {
                string value = bookingRecord[ticketID];
                bookingRecord.Remove(ticketID);
                Console.WriteLine("The removed booking is: " + ticketID + " : " + value);
                cancelledTickets.Add(ticketID);
                if (checkedInQueue.Contains(passName))
                {
                    while (checkedInQueue.Count > 0)
                    {
                        currentName = checkedInQueue.Dequeue();
                        if (currentName == passName)
                        {
                            foundQueue = true;
                            removedName = currentName;
                            continue;
                        }
                        else tempQueue.Enqueue(currentName);

                    }
                    if (foundQueue)
                    {
                        Console.WriteLine($"{removedName} was removed from the check-in queue.");
                    }
                    else Console.WriteLine("Passenger not found in the check-in queue.");

                    while (tempQueue.Count > 0)
                    {
                        checkedInQueue.Enqueue(tempQueue.Dequeue());
                    }
                }//if (checkedInQueue.Contains(passName))


                if (boardingStack.Contains(passName))
                {

                    while (boardingStack.Count > 0)
                    {
                        currentName = boardingStack.Pop();
                        if (currentName == passName)
                        {
                            foundStack = true;
                            removedName = currentName;
                            continue;
                        }
                        else tempStack.Push(currentName);

                    }
                    if (foundStack)
                    {
                        Console.WriteLine($"{removedName} was removed from the boarding stack.");
                    }
                    else Console.WriteLine("Passenger not found in the boarding stack.");
                    
                    while (tempStack.Count > 0)
                    {
                        boardingStack.Push(tempStack.Pop());
                    }
                }//if (boardingStack.Contains(passName))
            }
        }

        public static void PassengerCheckIn() {
            string processedName = "";
            Console.WriteLine("Services: ");
            Console.WriteLine("1. Check in a passenger");
            Console.WriteLine("2. View check-in queue ");
            Console.WriteLine("3. Process next passenger");
            Console.WriteLine("0. Back");

            Console.Write("\nEnter your service number: ");
            int service = int.Parse(Console.ReadLine());


            if (service == 1)
            {
                Console.Write("Enter Ticket ID: ");
                string ticketID = Console.ReadLine();
                string passName = passengerNames[ticketNumbers.IndexOf(ticketID)];
                // Check empty input
                if (string.IsNullOrWhiteSpace(ticketID))
                {
                    Console.WriteLine("Error: Ticket ID cannot be empty.");
                    return;
                }
                ticketID = ticketID.Trim();

                if (!ticketNumbers.Contains(ticketID))
                {
                    Console.WriteLine("Error: Ticket ID not found.");
                    return;
                }
                else if (cancelledTickets.Contains(ticketID))
                {
                    Console.WriteLine("This ticket has been cancelled");
                    return;
                }
                else if (!bookingRecord.ContainsKey(ticketID))
                {
                    Console.WriteLine("No booking found for this ticket.");
                    return;
                }
                else if (bookingRecord.ContainsKey(ticketID))
                {
                    Console.WriteLine("booking found for this ticket.");
                    if (!checkedInQueue.Contains(passName) && checkedInQueue.Count < 10)
                    {
                        checkedInQueue.Enqueue(passName);
                        Console.WriteLine(passName + "Added into check-in queue");
                    }
                    else
                    {
                        if (checkedInQueue.Count >= 10)
                        {
                            waitlistQueue.Enqueue(passName);
                            Console.WriteLine($"User {passName} has been placed on the waiting list");
                        }
                        else Console.WriteLine("the user: " + passName + " is already in the check-in queue");
                    }
                }
            }//if (service == 1)

            else if (service == 2)
            {
                int i = 0;
                Console.WriteLine("\nUsers in the check-in queue: ");
                foreach (string name in checkedInQueue)
                {
                    i++;
                    Console.WriteLine($"{i}: {name}");
                }

                Console.WriteLine($"\n{waitlistQueue.Count} passengers are waiting in the waiting queue");
            }//else if (service == 2)

            else if (service == 3)
            {
                while (checkedInQueue.Count != 0)
                {
                    processedName = checkedInQueue.Dequeue();
                    Console.WriteLine("The processed passenger is: " + processedName);
                }
                if (waitlistQueue.Count == 0)
                {
                    Console.WriteLine("No passengers in the waiting queue");
                    return;
                }
                else
                {
                    while (waitlistQueue.Count != 0)
                    {
                        checkedInQueue.Enqueue(waitlistQueue.Dequeue());
                    }
                    while (checkedInQueue.Count != 0)
                    {
                        processedName = checkedInQueue.Dequeue();
                        Console.WriteLine("The processed passenger is: " + processedName);
                    }
                    if (checkedInQueue.Count == 0 && waitlistQueue.Count == 0)
                    {
                        Console.WriteLine("No passengers to process");
                    }
                }
            }//(service == 3)

            else if (service == 0) {
                return;
            }




        }

        public static void boardPassengers() {
            Console.WriteLine("Services: ");
            Console.WriteLine("1. Load boarding stack from check-in queue");
            Console.WriteLine("2. Board next passenger ");
            Console.WriteLine("3. View boarding stack");
            Console.WriteLine("4. View boarding log");
            Console.WriteLine("0. Back");

            Console.Write("\nEnter your service number: ");
            int service = int.Parse(Console.ReadLine());
            int count = 0;
            if (service == 1)
            {
                if (checkedInQueue.Count != 0)
                {
                    while (checkedInQueue.Count != 0)
                    {
                        count++;
                        boardingStack.Push(checkedInQueue.Dequeue());
                    }
                    Console.WriteLine("Number of loaded passengers: " + count);

                }
                if (boardingStack.Count != 0 && checkedInQueue.Count == 0)
                {
                    Console.WriteLine("check-in queue is empty");
                    return;
                }
            }//if (service==1)
            else if (service == 2)
            {
                int seatCounter = 0;
                if (boardingStack.Count > 0)
                {
                    string passName = boardingStack.Pop();
                    int row = (seatCounter / 4) + 1; // 4 seats per row
                    //(char)converts it back to a character.
                    //'A' + 0 → 'A'=56
                    //'A' + 1 → 'B'=66
                    //'A' + 2 → 'C'=67
                    //'A' + 3 -> 'D'=68
                    //(like 65 + 1 = 66)
                    char seatLetter = (char)('A' + (seatCounter % 4)); // A, B, C, D
                    string seat = Convert.ToString(row) + Convert.ToString(seatLetter);
                    // Store in dictionary
                    passengerSeatMap[passName] = seat;
                    seatCounter++;
                    Console.WriteLine($"{passName} assigned seat {seat}");
                }
            }//else if (service == 2)

            else if (service == 3)
            {
                Console.WriteLine("\npassengers into borading stack: ");
                foreach (string passenger in boardingStack)
                {
                    Console.WriteLine(passenger);
                }
            }

            else if (service == 4)
            {
                foreach (var item in passengerSeatMap)
                {
                    Console.WriteLine($"{item.Key} : {item.Value}");
                }
            }

            else if (service == 0) {
                return;
            }


        }
        static void Main(string[] args)
            {
                int choice;
            checkedInQueue.Enqueue("Ali");
            checkedInQueue.Enqueue("Sara");
            checkedInQueue.Enqueue("Omar");
            checkedInQueue.Enqueue("Laila");
            checkedInQueue.Enqueue("Hassan");

            boardingStack.Push("Ali");
            boardingStack.Push("Sara");
            boardingStack.Push("Omar");
            boardingStack.Push("Laila");
            boardingStack.Push("Hassan");

            Console.WriteLine("========================================\r\nSKY WINGS FLIGHT MANAGEMENT SYSTEM\r\n========================================");
                Console.WriteLine("1. Register New Passenger");
                Console.WriteLine("2. View All Passengers");
                Console.WriteLine("3. Book a Flight Ticket");
                Console.WriteLine("4. View Booking Details");
                Console.WriteLine("5. Update a Booking");
                Console.WriteLine("6. Cancel a Ticket");
                Console.WriteLine("7. Passenger Check-In");
                Console.WriteLine("8. Board Passengers (Boarding Stack)");
                Console.WriteLine("9. Generate Flight Manifest");
                Console.WriteLine("10.Manage Waitlist & Seat Assignment");
                Console.WriteLine("0. Quit ");
                Console.WriteLine("========================================");

                Console.Write("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());
                Console.WriteLine();
                while (choice != 0)
                {
                    switch (choice)
                    {
                        case 1:
                            registerNewPassenger();
                            break;

                        case 2:
                            viewAllPassengers();
                            break;

                        case 3:
                            bookFlightTicket();
                            break;

                        case 4:
                            viewBookingDetails();
                            break;

                        case 5:
                            UpdateBooking();
                            break;

                        case 6:
                            cancelTicket();
                            break;

                        case 7:
                            PassengerCheckIn();
                            break;

                        case 8:
                            boardPassengers();
                            break;

                        case 9:

                            break;

                        case 10:

                            break;

                        default:
                            Console.WriteLine("Invalid choice");
                            break;

                    }//switch

                    Console.WriteLine();
                    Console.WriteLine("========================================\r\nSKY WINGS FLIGHT MANAGEMENT SYSTEM\r\n========================================");
                    Console.WriteLine("1. Register New Passenger");
                    Console.WriteLine("2. View All Passengers");
                    Console.WriteLine("3. Book a Flight Ticke");
                    Console.WriteLine("4. View Booking Details");
                    Console.WriteLine("5. Update a Booking");
                    Console.WriteLine("6. Cancel a Ticket");
                    Console.WriteLine("7. Passenger Check-In");
                    Console.WriteLine("8. Board Passengers (Boarding Stack)");
                    Console.WriteLine("9. Generate Flight Manifest");
                    Console.WriteLine("10. Manage Waitlist & Seat Assignment");
                    Console.WriteLine("0. Quit ");
                    Console.WriteLine("========================================");

                    Console.Write("Enter your choice: ");
                    choice = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                }//while (service.ToLower() != "q")
            }
        }
    }

