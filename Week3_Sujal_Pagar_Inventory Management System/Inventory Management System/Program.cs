using Inventory_Management_System;
using System.Numerics;

namespace week3
{
    public class MyClass
    {
        static Items getInstance(int id, string name, float price, int qnt)
        {
            Items item = new Items(id, name, price, qnt);
            return item;
        }

        static void setItem(List<Items> list)
        {
            int id = 0;
            Console.Write("Enter Name : ");
            string name = Console.ReadLine();
            Console.Write("Enter Price Of Product : ");
            float price = float.Parse(Console.ReadLine());
            Console.Write("Enter Quantity :");
            int qnt = Convert.ToInt32(Console.ReadLine());

            Items item = new Items(id,name,price,qnt);
            list.Add(item);
            Console.WriteLine("Item Add Successfully....");
            item.setId(id+1);
            Console.WriteLine();
        }

        static void displayItem(List<Items> list)
        {
            int i = 0;
            foreach (Items item in list)
            {
                Console.WriteLine("Id:"+i+item.ToString());
                i++;
            }
            Console.WriteLine() ;
        }

        static void findItem(int id, List<Items> list) {
            Items item = list[id];
            Console.WriteLine("Item Details : ");
            Console.WriteLine("Product Id : " + id);
            Console.WriteLine("Name : "+ item.getName());
            Console.WriteLine("Price : "+ item.getPrice());
            Console.WriteLine("Quantity : "+ item.getQnt());
            
            Console.WriteLine();
        }  

        static void removeAt(int ind,List<Items> list)
        {
            list.RemoveAt(ind);
            Console.WriteLine("Removed Successful....");
            Console.WriteLine();
        }
        
        static void updateInfo(int id, List<Items> list)
        {
            Console.Write("Enter Product Name : ");
            String name = Console.ReadLine();
            Console.Write("Enter Price : ");
            float price = float.Parse(Console.ReadLine());
            Console.Write("Enter Quantity :");
            int qnt = Convert.ToInt32(Console.ReadLine());

            list[id].setName(name);
            list[id].setPrice(price);
            list[id].setQnt(qnt);
            Console.WriteLine("Item Information changed Successfully....");
            Console.WriteLine();
        }

        public static void Main(string[] args)
        {
            List<Items> list = new List<Items>();

            int i = 0;
            while (i == 0)
            {
                Console.WriteLine("Choose the option : ");
                Console.WriteLine("1. Add new Item ");
                Console.WriteLine("2. Display all Items ");
                Console.WriteLine("3. Find Item by ID ");
                Console.WriteLine("4. Update Item information ");
                Console.WriteLine("5. Delete an Item ");

                int input = Convert.ToInt32(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        setItem(list);
                        break;
                    case 2:
                        displayItem(list);
                        break;
                    case 3:
                        Console.Write("Enter Id For Search : ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        findItem(id, list);
                        break;
                    case 4:
                        Console.Write("Enter Id For Update : ");
                        int uid = Convert.ToInt32(Console.ReadLine());
                        updateInfo(uid, list);
                        break;
                     case 5:
                        Console.Write("Enter Id For Delete : ");
                        int index = Convert.ToInt32(Console.ReadLine());
                        list.RemoveAt(index);
                        Console.WriteLine("Item Remove Successfully....");
                        break;
                }
            }

        }
    }
}
