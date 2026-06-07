using System.Net.Http.Headers;

namespace flightManagementSystem
{
    internal class Program
    {
        static List<String> passengerNames = new List<String> {"Ali","Sara","Omar","Laila","Hassan"};

        static List<string> ticketNumbers = new List<string>{"T001","T002","T003","T004","T005"};

        static List<string> cancelledTickets = new List<string>();

        //dd-MMM-yyyy
        static List<DateTime> availableDates = new List<DateTime> {
        new DateTime(2026, 1, 1),
        new DateTime(2026, 1, 5),
        new DateTime(2026, 1, 10),
        new DateTime(2026, 1, 15)
        };
        static Dictionary<string, string> bookingRecord = new Dictionary<string, string>();
        static string[] flightNumbers = new string[] { "OA101", "OA102", "OA103", "OA104", "OA105", "OA106" };
        public static void registerNewPassenger() {
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
            for (int i = 0; i < passengerNames.Count; i++) {
                
                if (fullName.ToLower() == passengerNames[i].ToLower()) {
                    exist = true;
                    break;
                }
            }
            
            if (exist)
            {
                Console.WriteLine("Error: Passenger already exists.");
                return;
            }
            else {
                passengerNames.Add(fullName);
                Console.WriteLine("Passenger added successfully.");
                //"D3" → formats it to 3 digits with leading zeros
                int nextNumber = ticketNumbers.Count + 1;
                string ticketID = "TKT-" + nextNumber.ToString("D3");
                ticketNumbers.Add(ticketID);
                Console.WriteLine("Passenger added with Ticket ID: " + ticketID);
            }


        }

        public static void viewAllPassengers() {
            string name;
            string ticket;
            string status;
            if (passengerNames.Count == 0) {
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

            for (int i = 0; i < passengerNames.Count; i++) {
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

            Console.WriteLine("The Total passengers: "+passengerNames.Count);

        }

        public static void bookFlightTicket() {
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
            if (flightChoice < 1 || flightChoice > 6) {
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
            Console.WriteLine("Details: "+ ticketID+ " of "+ passName+ ": "  + bookingValue);
        }

        public static void viewBookingDetails() {
            Console.Write("Enter Ticket ID: ");
            string ticketID = Console.ReadLine();

            // Check empty input
            if (string.IsNullOrWhiteSpace(ticketID))
            {
                Console.WriteLine("Error: Ticket ID cannot be empty.");
                return;
            }
            ticketID = ticketID.Trim();

            if (!ticketNumbers.Contains(ticketID)) {
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

            if (cancelledTickets.Contains(ticketID)) {
                Console.WriteLine("This ticket has been cancelled");
                return;
            }
            if (bookingRecord.ContainsKey(ticketID))
            {
                string value = bookingRecord[ticketID];
                string[] valParts = value.Split('|');
                Console.WriteLine("The flight number is: "+ valParts[0]);
                Console.WriteLine("The flight date is: " + valParts[1]);
            }
            else {
                Console.WriteLine("No booking found for this ticket.");
            }

        }

        static void Main(string[] args)
        {
            int choice;

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
                        
                        break;

                    case 6:
                        
                        break;

                    case 7:
                       
                        break;

                    case 8:
                       
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
