using System.Drawing;
using System.Runtime.Serialization.Formatters;

namespace listPracticeTaskSheet
{
    internal class Program
    {
        public static void roomServiceMenu() {

            List<string> menuItems = new List<string> { "Pizza", "Pasta", "Lasagna", "Risotto" };
            int listLength = menuItems.Count;
            
            menuItems.Add("Tiramisu");
            menuItems.Add("Ravioli");
            menuItems.Remove("Pasta");
            if (listLength != menuItems.Count)
            {
                Console.WriteLine("Our updated Food menue: ");
                for (int i = 0; i < menuItems.Count; i++)
                {
                    Console.WriteLine($"Dish {i + 1}: {menuItems[i]}");
                }
            }
            else {
                //if the menue is not updated
                Console.WriteLine("Food menue: ");
                for (int i = 0; i < menuItems.Count; i++)
                {
                    Console.WriteLine($"Dish {i + 1}: {menuItems[i]}");
                }

            }

            Console.Write("Enter your fav dish: ");
            string userDish = Console.ReadLine();
            userDish = userDish.ToLower();
            //convert all the list items to lower case for comparison purpose
            //Select()(like hidden loop) does NOT return a List. It returns a special collection
            //.ToList() converts it back into a List<string>
            menuItems = menuItems.Select(item => item.ToLower()).ToList();
            if (menuItems.Contains(userDish))
            {
                Console.WriteLine("Your fav dish is available in our menue");
            }
            else Console.WriteLine("Sorry we can't find your fav dish in our menue");

            Console.WriteLine("We have "+ menuItems.Count + " dishs in our menue.");
        }
        public static void guestCheckInQueue() {
            List<string> checkInQueue = new List<string> {"Alice","Bob","Ahmed","Mohammed","Sara"};
            // list to check if the guest is done with check in process or not
            List<bool> state = new List<bool> { true,true, false, false, false};
            for (int i = 0; i < checkInQueue.Count; i++) {
                Console.WriteLine($"Guest {i + 1}: {checkInQueue[i]}");
            
            }

            Console.WriteLine();
            int guestCount = 0;
            for (int i = 0; i < state.Count; i++)
            {
                if (state[i] == true) {
                    
                    guestCount++;
                    checkInQueue.Remove(checkInQueue[i]);
                    state.Remove(state[i]);
                    // go one step back before the 2 lists get updated the index will be reduced by one in every removing process
                    i--;
                    Console.WriteLine("Updated Guests List: ");
                    // to print the guests list again after each removing process
                    for (int k = 0; k < checkInQueue.Count; k++) {
                        Console.WriteLine($"Guest {k + 1}: {checkInQueue[k]}");
                    }
                    Console.WriteLine();

                }
                

            }
            Console.WriteLine($"we are done with {guestCount} guests");

            Console.Write("Enter the guest name: ");
            string guestName = Console.ReadLine();
            guestName = guestName.ToLower();
            checkInQueue = checkInQueue.Select(item => item.ToLower()).ToList();
            if (checkInQueue.Contains(guestName)) {
                // to can know the place of the guest in the queue
                int guestPos = checkInQueue.IndexOf(guestName);
                Console.Write("The guest is still waiting in turn "+ (guestPos+1));
            }
            else Console.Write("The guest is done with check-in process");

            Console.WriteLine("\n");
            Console.Write(checkInQueue.Count + " guests are waiting in the queue");
            Console.WriteLine();
        }

        public static void housekeepingFloorAssignment() {
            List<int> assignedRooms = new List<int> {305, 101, 220, 410, 150, 275};
            Console.WriteLine("Assigned rooms list:");
            for (int i = 0; i < assignedRooms.Count; i++)
            {
                Console.WriteLine($"Room {i + 1}: {assignedRooms[i]}");
            }

            assignedRooms.Add(500);
            assignedRooms.Add(120);

            Console.WriteLine("\nUpdated rooms list:");
            for (int i = 0; i < assignedRooms.Count; i++)
            {
                Console.WriteLine($"Room {i + 1}: {assignedRooms[i]}");
            }

            Console.WriteLine("\nRoom number 305 is cleaned");
            assignedRooms.Remove(305);

            assignedRooms.Sort();
            Console.WriteLine("\nSorted assigned rooms list:");
            for (int i = 0; i < assignedRooms.Count; i++)
            {
                Console.WriteLine($"Room {i + 1}: {assignedRooms[i]}");
            }

            assignedRooms.Insert(2, 999); // dirty room number
            Console.WriteLine("\nThe final assigned rooms list:");
            for (int i = 0; i < assignedRooms.Count; i++)
            {
                Console.WriteLine($"Room {i + 1}: {assignedRooms[i]}");
            }

            Console.WriteLine("\nWe have "+ assignedRooms.Count +" rooms are assigned to housekeeping team");
        }

        public static void hotelBookingConflictResolver() {
            List<int> standardBookings = new List<int> { 101, 102, 103, 104, 105, 106 };
            List<int> suiteBookings = new List<int> { 103, 104, 105, 201, 202 };
            List<int> masterBookings = new List<int>();

            Console.WriteLine("standard Bookings:");
            for (int i = 0; i < standardBookings.Count; i++)
            {
                Console.WriteLine($"Reservation {i + 1}: {standardBookings[i]}");
            }

            Console.WriteLine();
            Console.WriteLine("Suite Bookings:");
            for (int i = 0; i < suiteBookings.Count; i++)
            {
                Console.WriteLine($"Reservation {i + 1}: {suiteBookings[i]}");
            }

            masterBookings.AddRange(standardBookings);
            masterBookings.AddRange(suiteBookings);
            int element;
            for (int i = 0; i < masterBookings.Count; i++) {
                element = masterBookings[i];
                for (int k = i+1; k< masterBookings.Count; k++) {
                    if (masterBookings[k] == element) {
                        masterBookings.Remove(masterBookings[k]);
                        i--;
                    }
            
                }
            }

            masterBookings.Sort();
            Console.WriteLine();
            Console.WriteLine("master Bookings:");
            for (int i = 0; i < masterBookings.Count; i++)
            {
                Console.WriteLine($"Reservation {i + 1}: {masterBookings[i]}");
            }

            int id1 = 104;
            int id2 = 300;
            Console.WriteLine();
            if (masterBookings.Contains(id1))
            {
                Console.WriteLine($"Booking ID {id1} exists in the master list.");
            }
            else
            {
                Console.WriteLine($"Booking ID {id1} does NOT exist.");
            }

            if (masterBookings.Contains(id2))
            {
                Console.WriteLine($"Booking ID {id2} exists in the master list.");
            }
            else
            {
                Console.WriteLine($"Booking ID {id2} does NOT exist.");
            }

            
            int targetId = 104;

            int index = masterBookings.IndexOf(targetId);

            if (index != -1)
            {
                Console.WriteLine($"Booking ID {targetId} found at index: {index}");
            }
            else
            {
                Console.WriteLine($"Booking ID {targetId} not found.");
            }

            masterBookings.RemoveRange(1, 3);
            Console.WriteLine();
            Console.WriteLine("Final master Bookings:");
            for (int i = 0; i < masterBookings.Count; i++)
            {
                Console.WriteLine($"Reservation {i + 1}: {masterBookings[i]}");
            }

            Console.WriteLine("We have "+ masterBookings.Count+ " bookings");

        }
        static void Main(string[] args)
        {
            //roomServiceMenu();
            //guestCheckInQueue();
            //housekeepingFloorAssignment();
            hotelBookingConflictResolver();


        }
    }
}
