using SortedList;
using System;
using System.Collections.Generic;

namespace lab1
{
    class Program
    {
        public static void ResizeEvent()
        {
            Console.WriteLine("Resize Happend");
        }

        public static void ClearEvent()
        {
            Console.WriteLine("Clear Happend");
        }
        public static void AddEvent()
        {
            Console.WriteLine("Add Happend");
        }
        public static void RemoveEvent()
        {
            Console.WriteLine("Remove Happend");
        }
        static void Main(string[] args)
        {
            CustomSortedList<string> Sorted = new CustomSortedList<string>();

            Sorted.addedElement += AddEvent;
            Sorted.resizedCollection += ResizeEvent;
            Sorted.clearedCollection += ClearEvent;
            Sorted.removedElement += RemoveEvent;

            Console.WriteLine("Welcome to Sorted List Interface.");

            string commandMessages = "Enter: \n" +
                                     "1 - to insert value into the list \n" +
                                     "2 - to get value by index \n" +
                                     "3 - to get list size \n" +
                                     "4 - to check if list is empty \n" +
                                     "5 - to check if list contains value \n" +                                     
                                     "6 - to delete value at index \n" +
                                     "7 - to delete value \n" +
                                     "8 - to clear list \n" +
                                     "9 - to show the whole list\n" +
                                     "10 - to shut down\n";

            bool isSuccess = false;
            bool isWorking = true;
            while (isWorking)
            {
                Console.WriteLine(commandMessages);
                string inputCommand = Console.ReadLine();
                switch (inputCommand)
                {
                    case "1":
                        Console.WriteLine("Enter the value you want to insert:\n");
                        string valueToInsert = Console.ReadLine();
                        Sorted.Add(valueToInsert);
                        break;
                    case "2":
                        Console.WriteLine("Enter the index you want to get value of:\n");
                        int getInsertIndex;
                        isSuccess = int.TryParse(Console.ReadLine(), out getInsertIndex);
                        if (!isSuccess)
                        {
                            Console.WriteLine("Your input was not a number. Please try again.");
                        }
                        else
                        {
                            Console.WriteLine(Sorted[getInsertIndex]);
                        }
                        break;
                    case "3":
                        Console.WriteLine("List size is "+Sorted.Size);
                        break;
                    case "4":
                        Console.WriteLine("Enter the value you want to insert:\n");
                        Console.WriteLine(Sorted.IsEmpty ? "List is empty" : "List is not empty");
                        break;
                    case "5":
                        Console.WriteLine("Enter the value you want to check is in the List:\n");
                        string valueToCheck = Console.ReadLine();
                        Console.WriteLine(Sorted.Contains(valueToCheck) ? "List doesn\'t contain the value "+ valueToCheck : "List contains the value " + valueToCheck);                        
                        break;
                    case "6":
                        Console.WriteLine("Enter the index you want to delete:\n");
                        int getDeleteIndex;
                        isSuccess = int.TryParse(Console.ReadLine(), out getDeleteIndex);
                        if (!isSuccess)
                        {
                            Console.WriteLine("Your input was not a number. Please try again.");
                        }
                        else
                        {
                            Sorted.DeleteAt(getDeleteIndex);
                        }
                        break;
                    case "7":
                        Console.WriteLine("Enter the value you want to delete:\n");
                        string valueToDelet = Console.ReadLine();
                        Sorted.Delete(valueToDelet);
                        break;
                    case "8":
                        Sorted.Clear();
                        Console.WriteLine("List is cleared.");                        
                        break;
                    case "9":
                        Console.WriteLine("List is:");
                        foreach(string val in Sorted)
                        {
                            Console.WriteLine(val);
                        }
                        break;
                    case "10":
                        isWorking = false;
                        break;
                    default:
                        Console.WriteLine("Command was not understood. Please try again.");
                        break;

                }
                Console.WriteLine("\nPress any button to proceed.");
                Console.ReadKey();
                Console.Clear();
            }



            

            /*var capitals = new Dictionary<string, string>()
            {
                {"Turkey", "Ankara"},
                {"UK", "London"},
                {"USA", "Washington"}
            };

            Console.WriteLine(capitals["UKS"]);*/

        }
    }
}
