using System.Collections;
using System.Xml.Linq;

namespace stackQueuePractice
{
    internal class Program
    {
        public static void browserHistoryTracker() {
            Stack<string> browserHistory = new Stack<string>();
            browserHistory.Push("https://example.com/home");
            browserHistory.Push("https://example.com/about");
            browserHistory.Push("https://example.com/services");
            browserHistory.Push("https://example.com/blog");
            browserHistory.Push("https://example.com/contact");

            Console.WriteLine("URLs:");
            foreach (string url in browserHistory) {
                Console.WriteLine(url);
            }

            string topStack = browserHistory.Peek();
            Console.WriteLine("\nThe page the user is currently on: "+ topStack);

            if (browserHistory.Count > 0) {
                string firstRemUrl = browserHistory.Pop();
                Console.WriteLine("\nThe first removed URL: " + firstRemUrl);
            }
            if (browserHistory.Count > 0)
            {
                string secRemUrl = browserHistory.Pop();
                Console.WriteLine("The second removed URL: " + secRemUrl);
            }

            Console.WriteLine("\nRemaining pages in stack:");
            foreach (string url in browserHistory)
            {
                Console.WriteLine(url);
            }

            string targetUrl = "https://example.com/home";
            if (browserHistory.Contains(targetUrl)) {
                Console.WriteLine("\nURL: "+ targetUrl+" is in the user history");

            }
            else Console.WriteLine("\nURL: " + targetUrl + " is not in the user history");

            Console.WriteLine("\nUser history contains "+ browserHistory.Count+" URLs");
        }

        public static void hotelCheckInQueue() {
            Queue<string> checkInQueue = new Queue<string>();
            checkInQueue.Enqueue("Ahmed");
            checkInQueue.Enqueue("Mohammed");
            checkInQueue.Enqueue("Sara");
            checkInQueue.Enqueue("Diana");
            checkInQueue.Enqueue("Charlie");

            Console.WriteLine("Waiting guests: ");
            foreach (string name in checkInQueue) { 
            Console.WriteLine(name);
            
            }

            Console.WriteLine("\nThe next guest is: "+ checkInQueue.Peek());

            if (checkInQueue.Count > 0)
            {
                string firstSerGuest = checkInQueue.Dequeue();
                Console.WriteLine("\nThe first served guest: " + firstSerGuest);
            }
            if (checkInQueue.Count > 0)
            {
                string secSerGuest = checkInQueue.Dequeue();
                Console.WriteLine("\nThe second served guest: " + secSerGuest);
                
            }

            Console.WriteLine("\nThe remaining guests: ");
            foreach (string name in checkInQueue)
            {
                Console.WriteLine(name);

            }

            string guestName = "Diana";
            if (checkInQueue.Contains(guestName)) {
                Console.WriteLine("\n"+ guestName+" is still waiting in the queue");

            }
            else Console.WriteLine("\n" + guestName + " is not in the queue");

            Console.WriteLine("\n"+ checkInQueue.Count+" guests are waiting");
        }

        //public static void 




        static void Main(string[] args)
        {
            //browserHistoryTracker();
            hotelCheckInQueue();
        }
    }
}
