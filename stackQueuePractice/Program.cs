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

        public static void textEditorUndoSystem() {
            Stack<string> undoStack = new Stack<string>();
            Stack<string> tempStack = new Stack<string>();
            string removedAction;

            undoStack.Push("Typed: Hello");
            undoStack.Push("Typed: World");
            undoStack.Push("Deleted: World");
            undoStack.Push("Typed: welcome");
            undoStack.Push("Formatted: Bold");
            undoStack.Push("Inserted: Image");
            undoStack.Push("Typed: End");

            Console.WriteLine("Users actions:");
            foreach (string action in undoStack)
            {
                Console.WriteLine(action);
            }

            if (undoStack.Count > 0)
            {
                
                Console.WriteLine("Next action to undo: " + undoStack.Peek());
            }
            else Console.WriteLine("Undo stack is empty.");

            Console.WriteLine("\nUndoing last 2 actions:");

            if (undoStack.Count > 0)
            {
                Console.WriteLine("Removed action: " + undoStack.Pop());
            }

            if (undoStack.Count > 0)
            {
                Console.WriteLine("Removed action: " + undoStack.Pop());
            }

            
            Console.WriteLine("\nRemaining actions:");
            foreach (string action in undoStack)
            {
                Console.WriteLine(action);
            }

            string targetaction = "Typed: welcome";
            if (undoStack.Contains(targetaction))
            {
                while (undoStack.Count != 0)
            {
                    removedAction = undoStack.Pop();
                    if (removedAction == targetaction)
                    {
                        Console.WriteLine("\nRemoved action is: " + removedAction);
                        break;
                    }//if
                    else
                    {
                        
                        tempStack.Push(removedAction);
                    }//else
                }//while
            }//if

            Console.WriteLine("\nRemaining actions after removing the middle action:");
            foreach (string action in undoStack)
            {
                Console.WriteLine(action);
            }

            Console.WriteLine("\nThe whole actions except the removed one:");
           
            while (tempStack.Count > 0)
            {
                undoStack.Push(tempStack.Pop());
            }
            foreach (string k in undoStack)
            {
                Console.WriteLine(k);
            }

        }

        public static void hospitalEmergencyRoomTriage() {
            Queue<string> triageQueue = new Queue<string>();
            Queue<string> tempQueue = new Queue<string>();
            string removedName;

            triageQueue.Enqueue("Ali");
            triageQueue.Enqueue("Sara");
            triageQueue.Enqueue("Omar");
            triageQueue.Enqueue("Lina");
            triageQueue.Enqueue("Hassan");
            triageQueue.Enqueue("Mariam");
            triageQueue.Enqueue("Yousef");
            triageQueue.Enqueue("Noura");

            int i = 0;
            foreach (string patient in triageQueue) {
                i++;
                Console.WriteLine("Patient " + i + " : "+patient);
            }

            Console.WriteLine("\nThe next patient is : " + triageQueue.Peek());
            string patName;
            Console.WriteLine();
            for (int k = 1; k < 4; k++) {
                patName = triageQueue.Dequeue();
                Console.WriteLine(patName+" is done");

            }

            Console.WriteLine("\nThe remaining patients: ");
            foreach (string pat in triageQueue)
            {

                Console.WriteLine("Patient : " + pat);
            }

            string targetName = "Mariam";
            if (triageQueue.Contains(targetName))
            {
                while (triageQueue.Count != 0)
                {
                    removedName = triageQueue.Dequeue();
                    if (targetName == removedName)
                    {
                        Console.WriteLine("\nRemoved patient is: " + removedName);
                        break;
                    }//if
                    else
                    {

                        tempQueue.Enqueue(removedName);
                    }//else
                }//while
            }//if

            Console.WriteLine("\nRemaining patients after removing : "+ targetName);
            foreach (string name in triageQueue)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine("\nThe whole patients except the removed one:");

            while (triageQueue.Count > 0)
            {
                tempQueue.Enqueue(triageQueue.Dequeue());
            }

            //to keep the original queue order
            while (tempQueue.Count > 0)
            {
                triageQueue.Enqueue(tempQueue.Dequeue());
            }

            foreach (string k in triageQueue)
            {
                Console.WriteLine(k);
            }

        }



        static void Main(string[] args)
        {
            //browserHistoryTracker();
            //hotelCheckInQueue();
            //textEditorUndoSystem();
            hospitalEmergencyRoomTriage();
        }
    }
}
