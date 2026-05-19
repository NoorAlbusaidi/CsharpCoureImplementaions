using System.Numerics;
using System.Threading.Tasks.Dataflow;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace hotelManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            string serviceNote = "";
            string guestName = "";
            string guestPhone = "";
            int roomNumber;
            int roomTypeChoice = 0;
            string roomTypeName = "";
            double nightlyRate = 0.0;
            DateTime checkInDate;
            DateTime checkInDateToday;
            DateTime checkOutDate;
            int nights = 0;
            double totalPrice = 0;
            string roomNotes;
            //discoun = 20%
            double discountPercentage = 0.2;
            double discountAmount = 0;
            double loyalityPoints = 0;
            bool currentlyCheckedIn = false;
            bool registeredGuest = false;
            int userChoice;
            int updatedRoomTypeChoice;
            double updatedNightlyRate = 0.0;
            string searchName = "";

            // show services menue
            Console.WriteLine("The services menue: ");
            Console.WriteLine("0. Register New Guest");
            Console.WriteLine("1. View Guest Information");
            Console.WriteLine("2. Check-In Guest ");
            Console.WriteLine("3. Check-Out & Bill ");
            Console.WriteLine("4. Apply Discount ");
            Console.WriteLine("5. Upgrade Room ");
            Console.WriteLine("6. Add Room Service Note  ");
            Console.WriteLine("7. Search Guest by Name  ");
            Console.WriteLine("8. Calculate Loyalty Points  ");
            Console.WriteLine("9. Print Receipt  ");
            Console.WriteLine("10. Edit Guest Name  ");
            Console.WriteLine("11. Exit  ");
            Console.WriteLine();

            Console.Write("Enter number of service: ");
            userChoice = int.Parse(Console.ReadLine());

            while (userChoice != 11) {
                switch (userChoice)
                {
                    case 0:
                        Console.Write("Enter your name: ");
                        guestName = Console.ReadLine();
                        guestName = guestName.Trim();

                        //validate guest name
                        while (guestName == "") {
                            Console.WriteLine("Name should not be null");
                            Console.Write("Enter your name: ");
                            guestName = Console.ReadLine();
                        }

                        Console.Write("Please enter your phone number: +968 ");
                        guestPhone = Console.ReadLine();
                        guestPhone = guestPhone.Trim();

                        //validate guest name
                        while (guestPhone.Length<8)
                        {
                            Console.WriteLine("wrong phone number");
                            Console.Write("Please enter your phone number: +968 ");
                            guestPhone = Console.ReadLine();
                        }

                        Console.Write("Enter number of nights: ");
                        nights = int.Parse(Console.ReadLine());
                        //validate nights number
                        while (nights<=0) {
                            Console.WriteLine("Invalid nights number");
                            Console.Write("Enter number of nights: ");
                            nights = int.Parse(Console.ReadLine());
                        }
                        Console.WriteLine("menue of room types: \n 1. Standard Room \n 2. Deluxe Room \n 3. Suite \n 4. Family Room \n 5. Connecting Rooms");
                        Console.Write("Please enter the number of your room type: ");
                        roomTypeChoice = int.Parse(Console.ReadLine());
                        while (roomTypeChoice != 1 && roomTypeChoice != 2 && roomTypeChoice != 3 && roomTypeChoice != 4 && roomTypeChoice != 5) {
                            Console.WriteLine("Invalid room type number");
                            Console.Write("Please enter the number of your room type: ");
                            roomTypeChoice = int.Parse(Console.ReadLine());
                        }

                        
                        //Standard
                        if (roomTypeChoice == 1) {
                            roomTypeName = "Standard Room";
                            nightlyRate = 30.0;
                            Console.WriteLine("The nightly rate: "+ nightlyRate + " OMR");
                        }
                        //Deluxe
                        else if (roomTypeChoice == 2)
                        {
                            roomTypeName = "Deluxe Room";
                            nightlyRate = 50.0;
                            Console.WriteLine("The nightly rate: " + nightlyRate + " OMR");

                        }
                        //Suite
                        else if (roomTypeChoice == 3)
                        {
                            roomTypeName = "Suite";
                            nightlyRate = 80.0;
                            Console.WriteLine("The nightly rate: " + nightlyRate + " OMR");
                        }
                        //Family
                        else if (roomTypeChoice == 4)
                        {
                            roomTypeName = "Family room";
                            nightlyRate = 70.0;
                            Console.WriteLine("The nightly rate: " + nightlyRate + " OMR");
                        }
                        //Connecting
                        else if(roomTypeChoice == 5)
                        {
                            roomTypeName = "Connecting rooms";
                            nightlyRate = 90.0;
                            Console.WriteLine("The nightly rate: " + nightlyRate + " OMR");
                        }

                        roomNumber = rand.Next(100, 999); // generates number between 100–998
                        Console.WriteLine("Room Number: " + roomNumber);

                        Console.WriteLine("your reservation is done");
                        registeredGuest = true;
                        

                        break;

                    //View Guest Information
                    case 1:
                        if (registeredGuest)
                        {
                            Console.WriteLine("The guest name: " + guestName.ToUpper());
                            Console.WriteLine("The guest phone number: " + guestPhone);
                            Console.WriteLine("The room type: " + roomTypeName.ToUpper());
                            Console.WriteLine("The number of nights: " + nights +" night(s)");
                            Console.WriteLine("The nightly rate: " + nightlyRate.ToString() + " OMR");
                            Console.WriteLine("The total of nightly rate: " + nightlyRate * nights + " OMR");
                            //double space
                            Console.WriteLine("\n");
                        }
                        else
                        {
                            Console.WriteLine("No info to print");
                            Console.WriteLine("\n");
                        }
                        break;

                    case 2:
                        
                        // check in date from sys
                        checkInDate = DateTime.Now;
                        currentlyCheckedIn = true;
                        checkInDateToday = DateTime.Today;

                        //count check out date based on the nights#
                         checkOutDate = checkInDate.AddDays(nights);
                        Console.WriteLine("Today Date : " + checkInDateToday+" :");
                        Console.WriteLine();
                        Console.WriteLine("Check-in Date : " + checkInDate.ToString("yyyy-MM-dd HH:mm"));
                        Console.WriteLine("Check-out Date: " + checkOutDate.ToString("yyyy-MM-dd HH:mm"));
                        Console.WriteLine();
                        break;

                    case 3:
                        
                        // only calculate price if there are guests
                        if (registeredGuest)
                        {
                            totalPrice = nights * nightlyRate;
                            if (discountPercentage != 0)
                            {
                                // *100 to have it as a percentage bec it stored unpercented(/100)
                                Console.WriteLine("Discount percentage: "+ discountPercentage*100 + "% ");
                                discountAmount = totalPrice * discountPercentage;
                                totalPrice = totalPrice - discountAmount;
                            }

                            else totalPrice = Math.Round(totalPrice, 3);

                            Console.WriteLine("The Bill: ");
                            Console.WriteLine("Total price: " + totalPrice + " OMR");
                            //reset room number
                            roomNumber = 0;
                        }
                        else Console.WriteLine("No registered guest");
                        break;

                    case 4:
                        if (registeredGuest)
                        {
                            if (discountPercentage != 0)
                            {
                                Console.WriteLine("Discount percentage: " + discountPercentage * 100 + "% ");
                                totalPrice = nights * nightlyRate;
                                Console.WriteLine("total price before the discount: " + Math.Round(totalPrice, 3) + " OMR");
                                discountAmount = totalPrice * discountPercentage;
                                Console.WriteLine("The discounted amount: " + Math.Round(discountAmount,3) + " OMR");
                                totalPrice = totalPrice - discountAmount;
                                Console.WriteLine("total price after the discount: " + Math.Round(totalPrice, 3) + " OMR");
                                // we can add the idea of if the discounted amount > totalPrice
                            }
                            else Console.WriteLine("There is no discount: "+ Math.Round(totalPrice,3) + " OMR");
                        }
                        else Console.WriteLine("you need to register first");
                        Console.WriteLine();
                        break;

                    //Upgrade Room
                    case 5:
                        if (registeredGuest)
                        {
                            Console.WriteLine("menue of room types: \n 1. Standard Room \n 2. Deluxe Room \n 3. Suite \n 4. Family Room \n 5. Connecting Rooms");
                            Console.Write("Please enter the number of your room type: ");
                            updatedRoomTypeChoice = int.Parse(Console.ReadLine());
                            while (updatedRoomTypeChoice != 1 && updatedRoomTypeChoice != 2 && updatedRoomTypeChoice != 3 && updatedRoomTypeChoice != 4 && updatedRoomTypeChoice != 5)
                            {
                                Console.WriteLine("Invalid room type number");
                                Console.Write("Please enter the number of your room type: ");
                                updatedRoomTypeChoice = int.Parse(Console.ReadLine());
                            }
                            while (updatedRoomTypeChoice == roomTypeChoice) {
                                Console.WriteLine("your new room type same as the previous.");
                                Console.Write("Please enter the number of your room type: ");
                                updatedRoomTypeChoice = int.Parse(Console.ReadLine());
                            }

                            //Standard
                            if (updatedRoomTypeChoice == 1)
                            {
                                roomTypeName = "Standard Room";
                                updatedNightlyRate = 30.0;

                                Console.WriteLine("The nightly rate: " + nightlyRate + " OMR");
                            }
                            //Deluxe
                            else if (updatedRoomTypeChoice == 2)
                            {
                                roomTypeName = "Deluxe Room";
                                updatedNightlyRate = 50.0;
                                Console.WriteLine("The nightly rate: " + nightlyRate + " OMR");

                            }
                            //Suite
                            else if (updatedRoomTypeChoice == 3)
                            {
                                roomTypeName = "Suite";
                                updatedNightlyRate = 80.0;
                                Console.WriteLine("The nightly rate: " + nightlyRate + " OMR");
                            }
                            //Family
                            else if (updatedRoomTypeChoice == 4)
                            {
                                roomTypeName = "Family room";
                                updatedNightlyRate = 70.0;
                                Console.WriteLine("The nightly rate: " + nightlyRate + " OMR");
                            }
                            //Connecting
                            else if (updatedRoomTypeChoice == 5)
                            {
                                roomTypeName = "Connecting rooms";
                                updatedNightlyRate = 90.0;
                                Console.WriteLine("The nightly rate: " + nightlyRate + " OMR");
                            }

                            roomNumber = rand.Next(100, 999); // generates number between 100–998
                            

                            Console.WriteLine("Your new room type: " + roomTypeName);
                            Console.WriteLine("Your new room number: " + roomNumber);
                            Console.WriteLine("the nightly rate before: "+ nightlyRate + " OMR");
                            Console.WriteLine("the updated nightly rate:  " + updatedNightlyRate + " OMR");
                            double maxPrice = Math.Max(nightlyRate, updatedNightlyRate);
                            Console.WriteLine("the maximum price: "+ maxPrice+" OMR");
                            double minPrice = Math.Min(nightlyRate, updatedNightlyRate);
                            Console.WriteLine("the minimum price: " + minPrice + " OMR");
                        }
                        else Console.WriteLine("You need to be registered");
                        break;

                    case 6:
                        Console.WriteLine("your service note: ");
                        serviceNote = Console.ReadLine();
                        while (serviceNote == "") {
                            Console.WriteLine("You cannot leave the note empty");
                            Console.WriteLine("your service note: ");
                            serviceNote = Console.ReadLine();
                        }
                        serviceNote = serviceNote.Trim();
                        Console.WriteLine("The length of the note: " + serviceNote.Length);

                        string newNote = serviceNote.Replace("Hotel", "hotelName");
                        Console.WriteLine("before replacing: \n " + serviceNote);
                        Console.WriteLine("after replacing: \n " + newNote);
                        break;

                    case 7:
                        if (registeredGuest)
                        {
                            Console.Write("enter the guest name you want to find: ");
                            searchName = Console.ReadLine();
                            searchName = searchName.ToLower();
                            guestName = guestName.ToLower();
                            bool foundName = guestName.Contains(searchName);
                            if (foundName)
                            {
                                Console.WriteLine("The guest name contains the name you entered");
                            }
                            else Console.WriteLine("The guest name doesn't contain the name you entered");
                        }
                        else Console.WriteLine("You need to register first");
                        break;

                    case 8:
                        if (registeredGuest) {
                            // square the nights
                            loyalityPoints = Math.Pow(nights, 2);

                            // round to nearest whole number
                            loyalityPoints = (int)Math.Round(loyalityPoints);

                            Console.WriteLine("Earned points: " + loyalityPoints);
                        }
                        else Console.WriteLine("You need to register first");
                        break;

                    case 9:
                        if (registeredGuest)
                        {
                            // template
                            string receiptTemplate =
                                                    "----- HOTEL RECEIPT -----\n" +
                                                    "Date: {DATE}\n" +
                                                    "Guest: {NAME}\n" +
                                                    "Nights: {NIGHTS}\n" +
                                                    "Earned Points: {EARNED}\n" +
                                                    "Total price: {TOTAL}\n" +
                                                    "--------------------------";
                            // to show the new receipt after the replacements
                            string receipt = receiptTemplate;
                            receipt = receipt.Replace("{DATE}", DateTime.Now.ToString("yyyy-MM-dd"));
                            receipt = receipt.Replace("{NAME}", guestName);
                            receipt = receipt.Replace("{NIGHTS}", Convert.ToString(nights));
                            receipt = receipt.Replace("{EARNED}", Convert.ToString(loyalityPoints));
                            receipt = receipt.Replace("{TOTAL}", Convert.ToString(totalPrice));

                            Console.WriteLine("Your receipt: \n "+ receipt);

                        }
                        else Console.WriteLine("You need to register first");
                        break;

                    case 10:

                        break;

                    default:
                        Console.WriteLine("Invalid service choice...");
                        break;
                }//switch (userChoice)

                // to not clear the printed info
                if (userChoice != 1 && userChoice != 2 && userChoice != 3 && userChoice != 4 )
                {
                    // to can see the result before it clears it
                    Thread.Sleep(3000);
                    Console.Clear();
                }
                
                // show services menue after each case to activate services like print info
                Console.WriteLine("The services menue: ");
                Console.WriteLine("0. Register New Guest");
                Console.WriteLine("1. View Guest Information");
                Console.WriteLine("2. Check-In Guest ");
                Console.WriteLine("3. Check-Out & Bill ");
                Console.WriteLine("4. Apply Discount ");
                Console.WriteLine("5. Upgrade Room ");
                Console.WriteLine("6. Add Room Service Note  ");
                Console.WriteLine("7. Search Guest by Name  ");
                Console.WriteLine("8. Calculate Loyalty Points  ");
                Console.WriteLine("9. Print Receipt  ");
                Console.WriteLine("10. Edit Guest Name  ");
                Console.WriteLine("11. Exit  ");
                Console.WriteLine();

                Console.Write("Enter number of service: ");
                userChoice = int.Parse(Console.ReadLine());

            }//while userChoice != 0

        }
    }
}
