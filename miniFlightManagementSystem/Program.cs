namespace flightManagementSystem
{
    internal class Program
    {
        static List<String> passengerNames = new List<String> {"Ali","Sara","Omar","Laila","Hassan"};

        static List<string> ticketNumbers = new List<string>{"T001","T002","T003","T004","T005"};

        static List<string> cancelledTickets = new List<string>();
        public static void registerNewPassenger() {
            bool exist = false;
            Console.Write("Enter passenger's full name: ");
            string fullName = Console.ReadLine();
            fullName = fullName.Trim();
            // Validation
            if (string.IsNullOrWhiteSpace(fullName))
            {
                Console.WriteLine("Error: Name cannot be empty.");
                return; // go back to menu
            }

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
                        
                        break;

                    case 4:
                        
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
