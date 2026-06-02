using System.Diagnostics;

namespace arraysPracticeTaskSheet
{
    internal class Program
    {
        public static void temperatureLog() {
            double[] temperatures = { 30, 40.5, 44.1, 45, 41, 42.8, 43 };
            for (int i = 0; i < temperatures.Length; i++) {
                Console.WriteLine("Day "+ (i+1) +": "+ temperatures[i]+" C");
            }
            Console.WriteLine("We got "+ temperatures.Length+" tempreture reads this weak.");
        }

        public static void studentScores()
        {
            int[] scores = { 15,20,13,17,18,19};
            Console.WriteLine("Scores:");
            foreach (int i in scores) {
                Console.Write(i+" ");

            }
            Array.Reverse(scores);
            Console.WriteLine("\nScores in reverse order:");
            foreach (int i in scores)
            {
                
                Console.Write(i + " ");

            }
            Console.WriteLine();

        }

        public static void productPriceFinder()
        {
            double[] prices = { 10.5, 20, 11, 12.2, 5.3};
            for (int i = 0; i < prices.Length; i++)
            {
                Console.WriteLine("Product " + (i + 1) + ": " + prices[i] + " OMR");
            }

            Console.Write("Enter the price of the product: ");
            double price = double.Parse(Console.ReadLine());
            int index = Array.IndexOf(prices, price);
            if (index == -1)
            {
                Console.WriteLine("Sorry the product is not found");
            }
            else {
                Console.WriteLine("The product is found");
            }
        }

        public static void raceFinishTimes() {
            int[] finishTimes = { 4, 5, 8, 9, 15, 10, 11, 12 };
            Console.WriteLine("Finish times for "+ finishTimes.Length+" runners: ");
            foreach (int i in finishTimes) {
                Console.Write(i+" sec, ");
            }
            Console.WriteLine();

            Array.Sort(finishTimes);
            Console.WriteLine("sorted finish times: ");
            Console.WriteLine("Finish times for " + finishTimes.Length + " runners: ");
            foreach (int i in finishTimes)
            {
                Console.Write(i + " sec, ");
            }
            Console.WriteLine();
        }

        public static void classroomGradeReport()
        {
            int[] grades = {69, 71,55,80,90,99,50,87,98,93 };
            Array.Sort(grades);
            Array.Reverse(grades);

            for (int i = 0; i < grades.Length; i++) {
                Console.WriteLine("Rank " + (i + 1) + ": " + grades[i]);
            }
        }

        public static void warehouseInventoryCheck()
        {
            int[] quantities = { 5, 20, 100, 40, 55, 88, 500, 78 };
            int total = quantities.Sum();
            Console.WriteLine("The total of quantities: " + total);
            Console.WriteLine("The Average: " + (total/ quantities.Length));
            Console.WriteLine();
            Console.Write("Enter the quantity you want: ");
            int userQuantity = int.Parse(Console.ReadLine());
            int quantity = Array.IndexOf(quantities, userQuantity);

            if (quantity == -1)
            {
                Console.WriteLine("Quantity not found");
            }
            else {
                Console.WriteLine("Quantity is found in slot number "+ (quantity+1));

            }
        }

        public static void libraryBookShelfScanner(){
            int[] copies = {50,0,25,0,8,10,15,22,45 };
            Console.WriteLine("Number of copies for each book: ");
            foreach (int i in copies) {
                Console.Write(i+" ");
            }
            Console.WriteLine();
            Console.WriteLine("copies in descending order: ");
            Array.Sort(copies);
            foreach (int i in copies)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine("\nThe highest number of copies is: "+ copies[copies.Length-1] + " For the book number "+(copies.Length));

            for (int i =0; i< copies.Length; i++) {
                if (copies[i] == 0) {
                    Console.WriteLine("Notification: Book number "+(i+1)+" has zero copies");
                }
            }
        }

        public static void salesPerformanceAnalyzer() {
            double[] revenue = { 1200.50, 1350.75, 1420.00, 1600.25, 1750.80, 1900.60,
                                 2100.40, 2200.90, 2000.00, 1850.30, 1700.10, 1950.55 };
            double[] sortedCopyRevenue = new double[12];
            revenue.CopyTo(sortedCopyRevenue);

            for (int i = 0; i < revenue.Length; i++) {
                Console.WriteLine("The revenue of month "+(i+1) +" is: "+ revenue[i]);

            }
            Console.WriteLine("Sorted revenues: ");
            Array.Sort(sortedCopyRevenue);
            Array.ForEach(sortedCopyRevenue, x => Console.Write(x+" | "));
            Console.WriteLine("\nThe best month's revenue is: "+ sortedCopyRevenue[sortedCopyRevenue.Length-1]+" in December");
            Console.WriteLine("The worst month's revenue is: "+ sortedCopyRevenue[0]+" in January");

            double average = revenue.Sum() / revenue.Length;
            Console.WriteLine("The average monthly revenue is: " + Math.Round(average,3));
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
            Console.WriteLine("9. ");
            Console.WriteLine("10. ");
            Console.WriteLine("q. Quit ");
            Console.WriteLine();

            Console.Write("Number of the case: ");
            service = Console.ReadLine();
            Console.WriteLine();
            while (service.ToLower() != "q") {
                switch (service) {
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
                Console.WriteLine("9. ");
                Console.WriteLine("10. ");
                Console.WriteLine("q. Quit ");
                Console.WriteLine();
                Console.Write("Number of the case: ");
                service = Console.ReadLine();
            }//while (service.ToLower() != "q")
        }
    }
}
