namespace listsPracticeTaskSheet
{
    internal class Program
    {
        public static void temperatureLog()
        {
            List<double> temperatures = new List<double> { 30, 40.5, 44.1, 45, 41, 42.8, 43 };
            for (int i = 0; i < temperatures.Count; i++)
            {
                Console.WriteLine("Day " + (i + 1) + ": " + temperatures[i] + " C");
            }
            Console.WriteLine("We got " + temperatures.Count + " tempreture reads this weak.");
        }

        public static void studentScores()
        {
            List<int> scores = new List<int> { 15, 20, 13, 17, 18, 19 };
            Console.WriteLine("Scores:");
            foreach (int i in scores)
            {
                Console.Write(i + " ");

            }
            scores.Reverse();
            Console.WriteLine("\nScores in reverse order:");
            foreach (int i in scores)
            {

                Console.Write(i + " ");

            }
            Console.WriteLine();

        }

        public static void productPriceFinder()
        {
            List<double> prices = new List<double> { 10.5, 20, 11, 12.2, 5.3 };
           
            for (int i = 0; i < prices.Count; i++)
            {
                Console.WriteLine("Product " + (i + 1) + ": " + prices[i] + " OMR");
            }

            Console.Write("Enter the price of the product: ");
            double price = double.Parse(Console.ReadLine());
            int index = prices.IndexOf(price);
            if (index == -1)
            {
                Console.WriteLine("Sorry the product is not found");
            }
            else
            {
                Console.WriteLine("The product is found");
            }
        }

        public static void raceFinishTimes()
        {
            List <int> finishTimes = new List<int> { 4, 5, 8, 9, 15, 10, 11, 12 };
            
            Console.WriteLine("Finish times for " + finishTimes.Count + " runners: ");
            foreach (int i in finishTimes)
            {
                Console.Write(i + " sec, ");
            }
            Console.WriteLine();

            finishTimes.Sort();
            Console.WriteLine("sorted finish times: ");
            Console.WriteLine("Finish times for " + finishTimes.Count + " runners: ");
            foreach (int i in finishTimes)
            {
                Console.Write(i + " sec, ");
            }
            Console.WriteLine();
        }

        public static void classroomGradeReport()
        {
            List<int> grades = new List<int> { 69, 71, 55, 80, 90, 99, 50, 87, 98, 93 };

            grades.Sort();
            grades.Reverse();

            for (int i = 0; i < grades.Count; i++)
            {
                Console.WriteLine("Rank " + (i + 1) + ": " + grades[i]);
            }
        }

        public static void warehouseInventoryCheck()
        {
            List <int> quantities = new List<int> { 5, 20, 100, 40, 55, 88, 500, 78 };
            int total = quantities.Sum();
            Console.WriteLine("The total of quantities: " + total);
            Console.WriteLine("The Average: " + (total / quantities.Count));
            Console.WriteLine();
            Console.Write("Enter the quantity you want: ");
            int userQuantity = int.Parse(Console.ReadLine());
            int quantity = quantities.IndexOf(userQuantity);

            if (quantity == -1)
            {
                Console.WriteLine("Quantity not found");
            }
            else
            {
                Console.WriteLine("Quantity is found in slot number " + (quantity + 1));

            }
        }

        public static void libraryBookShelfScanner()
        {
            List<int> copies = new List<int> { 50, 0, 25, 0, 8, 10, 15, 22, 45 };
            Console.WriteLine("Number of copies for each book: ");
            foreach (int i in copies)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            Console.WriteLine("copies in ascending order: ");
            copies.Sort();
            foreach (int i in copies)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine("\nThe highest number of copies is: " + copies[copies.Count - 1] + " For the book number " + (copies.Count));

            for (int i = 0; i < copies.Count; i++)
            {
                if (copies[i] == 0)
                {
                    Console.WriteLine("Notification: Book number " + (i + 1) + " has zero copies");
                }
            }
        }

        public static void salesPerformanceAnalyzer()
        {
            List<double> revenue = new List<double>{ 1200.50, 1350.75, 1420.00, 1600.25, 1750.80, 1900.60,
                                                     2100.40, 2200.90, 2000.00, 1850.30, 1700.10, 1950.55 };
            List<double> sortedCopyRevenue = new List<double>(revenue);

            for (int i = 0; i < revenue.Count; i++)
            {
                Console.WriteLine("The revenue of month " + (i + 1) + " is: " + revenue[i]);

            }
            Console.WriteLine("Sorted revenues: ");
            sortedCopyRevenue.Sort();
            sortedCopyRevenue.ForEach(x => Console.Write(x + " | "));
            Console.WriteLine("\nThe best month's revenue is: " + sortedCopyRevenue[sortedCopyRevenue.Count - 1] + " in December");
            Console.WriteLine("The worst month's revenue is: " + sortedCopyRevenue[0] + " in January");

            double average = revenue.Sum() / revenue.Count;
            Console.WriteLine("The average monthly revenue is: " + Math.Round(average, 3));
        }

        public static void flightSeatAllocationDisplay()
        {
            int[] seats = { 45, 12, 78, 34, 23, 56, 89, 67, 11, 90, 32, 21, 54, 76, 88 };
            int[] reverse = new int[seats.Length];



            Console.WriteLine("Original Seat Assignments:");
            foreach (int seat in seats)
            {
                Console.Write(seat + " ");
            }
            Console.WriteLine("\n");
            Array.Sort(seats);
            Console.WriteLine("Sorted Boarding Order:");
            Array.ForEach(seats, x => Console.Write(x + " "));
            Console.WriteLine("\n");

            int targetSeat = 67;
            int targetIndex = Array.IndexOf(seats, targetSeat);

            if (targetIndex == -1)
            {
                Console.WriteLine("Seat is not found");
            }
            else
            {
                Console.WriteLine("Seat " + targetSeat + " found at sorted position: " + targetIndex);
            }
            Console.WriteLine();
            seats.CopyTo(reverse);
            Array.Reverse(reverse);
            for (int i = 0; i < seats.Length; i++)
            {
                Console.WriteLine($"Index {i}: Seats: {seats[i]} Reversed: {reverse[i]} ");
            }
            Console.WriteLine();
            Console.WriteLine("Total Seats: " + seats.Length);
        }

        public static void hospitalPatientPriorityQueue()
        {
            int patients = 0;
            int[] severity = { 3, 7, 1, 9, 5, 2, 8, 6, 4, 10,
                               7, 3, 6, 2, 9, 1, 5, 8, 4, 10 };
            int[] sortedSeverity = new int[severity.Length];

            for (int i = 0; i < severity.Length; i++)
            {
                sortedSeverity[i] = severity[i];
            }
            Array.Sort(sortedSeverity);
            Array.Reverse(sortedSeverity);

            for (int i = 0; i < sortedSeverity.Length; i++)
            {
                Console.WriteLine($"Patient {i + 1} : The severity level: {sortedSeverity[i]}");
            }

            Array.Reverse(sortedSeverity);
            int mid1 = sortedSeverity.Length / 2 - 1;
            int mid2 = sortedSeverity.Length / 2;

            double median = (sortedSeverity[mid1] + sortedSeverity[mid2]) / 2.0;
            Console.WriteLine();
            Console.WriteLine("Median: " + median);
            Console.WriteLine();

            for (int i = 0; i < sortedSeverity.Length; i++)
            {
                if (sortedSeverity[i] <= 3)
                {
                    patients++;
                }

            }
            Console.WriteLine(patients + " patients have a severity score of 3 or below (critical cases). ");

            Console.WriteLine();
            int severityScoreTarget = 5;
            int severityIndex = Array.IndexOf(sortedSeverity, severityScoreTarget);
            Console.WriteLine("The first patient with severity score = " + severityScoreTarget + " at position: " + severityIndex);

        }
        static void Main(string[] args)
        {
            string service;

            Console.WriteLine("The cases: ");
            Console.WriteLine("1. Temperature Log");
            Console.WriteLine("2. Student Score Board ");
            Console.WriteLine("3. Product Price Finder ");
            Console.WriteLine("4. Race Finish Times ");
            Console.WriteLine("5. Classroom Grade Report ");
            Console.WriteLine("6. Warehouse Inventory Check");
            Console.WriteLine("7. Library Book Shelf Scanner ");
            Console.WriteLine("8. Sales Performance Analyzer");
            Console.WriteLine("9. Flight Seat Allocation Display");
            Console.WriteLine("10.Hospital Patient Priority Queue");
            Console.WriteLine("q. Quit ");
            Console.WriteLine();

            Console.Write("Number of the case: ");
            service = Console.ReadLine();
            Console.WriteLine();
            while (service.ToLower() != "q")
            {
                switch (service)
                {
                    case "1":
                        temperatureLog();
                        break;

                    case "2":
                        studentScores();
                        break;

                    case "3":
                        productPriceFinder();
                        break;

                    case "4":
                        raceFinishTimes();
                        break;

                    case "5":
                        classroomGradeReport();
                        break;

                    case "6":
                        warehouseInventoryCheck();
                        break;

                    case "7":
                        libraryBookShelfScanner();
                        break;

                    case "8":
                        salesPerformanceAnalyzer();
                        break;

                    case "9":
                        flightSeatAllocationDisplay();
                        break;

                    case "10":
                        hospitalPatientPriorityQueue();
                        break;

                    default:
                        Console.WriteLine("Invalid choice");
                        break;

                }//switch
                Console.WriteLine();
                Console.WriteLine("The cases: ");
                Console.WriteLine("1. Temperature Log");
                Console.WriteLine("2. Student Score Board ");
                Console.WriteLine("3. Product Price Finder ");
                Console.WriteLine("4. Race Finish Times");
                Console.WriteLine("5. Classroom Grade Report  ");
                Console.WriteLine("6. Warehouse Inventory Check");
                Console.WriteLine("7. Library Book Shelf Scanner");
                Console.WriteLine("8. Sales Performance Analyzer");
                Console.WriteLine("9. Flight Seat Allocation Display");
                Console.WriteLine("10.Hospital Patient Priority Queue");
                Console.WriteLine("q. Quit ");
                Console.WriteLine();
                Console.Write("Number of the case: ");
                service = Console.ReadLine();
            }//while (service.ToLower() != "q")
        }
    }
}
