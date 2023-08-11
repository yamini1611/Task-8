using System;
using System.Collections.Generic;

namespace CouponExample
{
    delegate double ApplyCoupon(double totalCost, bool hasValidCoupon);

    class Program
    {
        static bool IsValidCoupon(string couponCode)
        {
         
            return couponCode == "VALIDCOUPON";
        }

        static double ValidAmount(double totalCost, bool hasValidCoupon)
        {
            const double couponThreshold = 2000;
            const double couponAmount = 100; 

            if (hasValidCoupon && totalCost > couponThreshold)
            {
                return totalCost - couponAmount;
            }

            else
            {

                return totalCost;
            }
        }

        static void Main(string[] args)
        {
            ApplyCoupon couponDelegate;
            Console.WriteLine("Enter no of Customers:");
            int customers = int.Parse(Console.ReadLine());
            for(int  i = 0; i < customers; i++)
            {
                Console.WriteLine("Enter Customer Name:");
                string name = Console.ReadLine();

                Console.WriteLine("Enter total purchase cost:");
                double totalCost = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Enter coupon code:");
                string couponCode = Console.ReadLine();

                bool hasValidCoupon = IsValidCoupon(couponCode);

                if (totalCost > 2000 && hasValidCoupon)
                {
                    Console.WriteLine("Coupon Applied");
                    couponDelegate = ValidAmount;
                }
                else if (totalCost < 2000)
                {
                    Console.WriteLine("Amount is below the range for applying coupon");
                    couponDelegate = ValidAmount;
                }
                else if (!hasValidCoupon)
                {
                    Console.WriteLine("Invalid Code");
                    couponDelegate = ValidAmount;
                }
                else
                {
                      couponDelegate = ValidAmount;
                }
                double finalCost = couponDelegate(totalCost, hasValidCoupon);

                Console.WriteLine($"Final Cost after applying coupon: {finalCost}");
            }
      
            Console.ReadLine();
        }
    }
}

namespace TodoListExample
{
    class Program
    {
        class Task
        {
            public string Description { get; set; }
            public bool IsCompleted { get; set; }
        }

        static void Main(string[] args)
        {
            Dictionary<string, List<Task>> currentbatchTasks = new Dictionary<string, List<Task>>
            {
                { "2020", new List<Task>
                    {
                        new Task { Description = "Complete Assignment 1", IsCompleted = false },
                        new Task { Description = "Study for Quiz", IsCompleted = false }
                    }
                },
                { "2021", new List<Task>
                    {
                        new Task { Description = "Prepare Presentation", IsCompleted = false }
                    }
                },
                { "2022", new List<Task>
                    {
                        new Task { Description = "Attend Workshop", IsCompleted = false },
                        new Task { Description = "Review Notes", IsCompleted = false }
                    }
                }
            };

            Action<string> showTasks = currentbatch2 =>
            {
                if (currentbatchTasks.ContainsKey(currentbatch2))
                {
                    Console.WriteLine($"Tasks for currentbatch {currentbatch2}:");
                    foreach (var task in currentbatchTasks[currentbatch2])
                    {
                        string status = task.IsCompleted ? "Completed" : "Pending";
                        Console.WriteLine($"- {task.Description} (Status: {status})");
                    }
                }
                else
                {
                    Console.WriteLine($"No tasks found for currentbatch {currentbatch2}.");
                }
            };

            Action<string> updateTaskStatus = taskDescription =>
            {
                foreach (var currentbatch1 in currentbatchTasks.Keys)
                {
                    foreach (var task in currentbatchTasks[currentbatch1])
                    {
                        if (task.Description == taskDescription)
                        {
                            task.IsCompleted = true;
                            Console.WriteLine($"Task '{task.Description}' marked as completed.");
                            return;
                        }
                    }
                }
                Console.WriteLine($"Task '{taskDescription}' not found.");
            };

            Console.WriteLine("Enter your currentbatch (2020, 2021, or 2022) or 'q' to quit:");
            string currentbatch = Console.ReadLine();

            if (currentbatch == "2020" || currentbatch == "2021" || currentbatch == "2022")
            {
                showTasks(currentbatch);

                Console.WriteLine("Enter a task description to mark as completed (or 'q' to quit):");
                string taskDescription = Console.ReadLine();

                if (taskDescription.ToLower() != "q")
                {
                    updateTaskStatus(taskDescription);
                }
            }
            else if (currentbatch.ToLower() != "q")
            {
                Console.WriteLine("Invalid currentbatch.");
            }

         
            Console.ReadLine();
        }

    }
}


namespace MultiplicationTable
{
    class Table
    {
        static int MultiTable(int x , int y)
        {
            return x * y;
        }
        public void Multiply()
        {
            int result = 0;
            Console.WriteLine("Enter the number ");
            int x =int.Parse(Console.ReadLine());
            Console.WriteLine("-------------------------");
            Func<int, int, int> Table = MultiTable;
            for(int i = 1; i <= 10;i++)
            {
                result = Table(x,i);
                Console.WriteLine($"{x} * {i} = {result}");
            }
        }
        static void Main(string[] args)
        {
            Table func = new Table();
            func.Multiply();
            Console.WriteLine("---------------------------");
            Console.ReadLine();
        }
    }

    
}
