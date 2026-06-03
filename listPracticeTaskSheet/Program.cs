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
        static void Main(string[] args)
        {
            roomServiceMenu();


        }
    }
}
