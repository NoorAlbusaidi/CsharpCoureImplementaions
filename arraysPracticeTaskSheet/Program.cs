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
        
        
        }
        static void Main(string[] args)
        {
            string service;

            Console.WriteLine("The cases: ");
            Console.WriteLine("1. Temperature Log");
            Console.WriteLine("2. Student Score Board ");
            Console.WriteLine("3. Product Price Finder ");
            Console.WriteLine("4. Race Finish Times ");
            Console.WriteLine("5. ");
            Console.WriteLine("6. ");
            Console.WriteLine("7. ");
            Console.WriteLine("8. ");
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

                        break;

                }//switch
                Console.WriteLine();
                Console.WriteLine("The cases: ");
                Console.WriteLine("1. Temperature Log");
                Console.WriteLine("2. Student Score Board ");
                Console.WriteLine("3. Product Price Finder ");
                Console.WriteLine("4. Race Finish Times");
                Console.WriteLine("5. ");
                Console.WriteLine("6. ");
                Console.WriteLine("7. ");
                Console.WriteLine("8. ");
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
