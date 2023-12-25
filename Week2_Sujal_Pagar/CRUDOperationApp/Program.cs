<<<<<<< HEAD
﻿namespace week2
{
    class TaskApp
    {
        static void tasks(List<String> myTasks)
        {
            if (myTasks.Count == 0)
            {
                Console.WriteLine("No Task Available \nAdd Task First");
            }
            else {
                int index = 1;
                foreach (var items in myTasks)
                {
                    Console.WriteLine(index + ". " + items);
                    index++;
                }
            }
            
        }
        static void options()
        {
            Console.WriteLine("Select Option below : ");
            Console.WriteLine(1 + ") Add Task");
            Console.WriteLine(2 + ") Display Task");
            Console.WriteLine(3 + ") Remove Task");
            Console.WriteLine(4 + ") Update Task");
            Console.WriteLine(5 + ") Exit");
        }
        static void startApp()
        {
            List<String> myTasks = new List<String>();

            Boolean start = true;

            while (start)
            {
                options();
                int userInput = Convert.ToInt32(Console.ReadLine());

                switch (userInput)
                {
                    case 1:
                        Console.Write("Enter Your Task Here : ");
                        String task = Console.ReadLine();
                        myTasks.Add(task);
                        Console.WriteLine();
                        break;
                    case 2:
                        Console.WriteLine("Tasks Is : ");
                        
                        tasks(myTasks);
                        Console.WriteLine();
                        break;
                    case 3:
                        tasks(myTasks);
                        Console.WriteLine("Enter Index Of Remove Task");
                        int removeInd = Convert.ToInt32(Console.ReadLine());
                        if(removeInd-1 < myTasks.Count)
                        {
                            myTasks.RemoveAt(removeInd - 1);
                            Console.WriteLine("Task Remove Successful....");
                        }
                        else
                        {
                            Console.WriteLine("Enter Valid Input");
                        }
                        Console.WriteLine();
                        break;
                    case 4:
                        tasks(myTasks);
                        Console.WriteLine("Enter Index Of Update Task :");
                        int updateInd = Convert.ToInt32(Console.ReadLine());
                        if(updateInd-1 < myTasks.Count)
                        {
                            Console.WriteLine("Enter New Task : ");
                            String newTask = Console.ReadLine();
                            myTasks[updateInd-1] = newTask;
                        }
                        else
                        {
                            Console.WriteLine("Enter Valid Input");
                        }
                        Console.WriteLine();
                        break;
                    case 5:
                        start = false;
                        Console.WriteLine("Thank You!!! visit again.....");
                        Console.WriteLine();
                        break;
                }
            }
        }
        public static void Main(string[] args)
        {
            startApp();
        }

    }
=======
﻿namespace week2
{
    class TaskApp
    {
        static void tasks(List<String> myTasks)
        {
            if (myTasks.Count == 0)
            {
                Console.WriteLine("No Task Available \nAdd Task First");
            }
            else {
                int index = 1;
                foreach (var items in myTasks)
                {
                    Console.WriteLine(index + ". " + items);
                    index++;
                }
            }
            
        }
        static void options()
        {
            Console.WriteLine("Select Option below : ");
            Console.WriteLine(1 + ") Add Task");
            Console.WriteLine(2 + ") Display Task");
            Console.WriteLine(3 + ") Remove Task");
            Console.WriteLine(4 + ") Update Task");
            Console.WriteLine(5 + ") Exit");
        }
        static void startApp()
        {
            List<String> myTasks = new List<String>();

            Boolean start = true;

            while (start)
            {
                options();
                int userInput = Convert.ToInt32(Console.ReadLine());

                switch (userInput)
                {
                    case 1:
                        Console.Write("Enter Your Task Here : ");
                        String task = Console.ReadLine();
                        myTasks.Add(task);
                        Console.WriteLine();
                        break;
                    case 2:
                        Console.WriteLine("Tasks Is : ");
                        
                        tasks(myTasks);
                        Console.WriteLine();
                        break;
                    case 3:
                        tasks(myTasks);
                        Console.WriteLine("Enter Index Of Remove Task");
                        int removeInd = Convert.ToInt32(Console.ReadLine());
                        if(removeInd-1 < myTasks.Count)
                        {
                            myTasks.RemoveAt(removeInd - 1);
                            Console.WriteLine("Task Remove Successful....");
                        }
                        else
                        {
                            Console.WriteLine("Enter Valid Input");
                        }
                        Console.WriteLine();
                        break;
                    case 4:
                        tasks(myTasks);
                        Console.WriteLine("Enter Index Of Update Task :");
                        int updateInd = Convert.ToInt32(Console.ReadLine());
                        if(updateInd-1 < myTasks.Count)
                        {
                            Console.WriteLine("Enter New Task : ");
                            String newTask = Console.ReadLine();
                            myTasks[updateInd-1] = newTask;
                        }
                        else
                        {
                            Console.WriteLine("Enter Valid Input");
                        }
                        Console.WriteLine();
                        break;
                    case 5:
                        start = false;
                        Console.WriteLine("Thank You!!! visit again.....");
                        Console.WriteLine();
                        break;
                }
            }
        }
        public static void Main(string[] args)
        {
            startApp();
        }

    }
>>>>>>> faccb85 (adding files)
}