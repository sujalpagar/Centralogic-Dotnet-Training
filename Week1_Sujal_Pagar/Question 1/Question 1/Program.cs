namespace assignment1
{
    class Program1
    {
        static void greet(string name)
        {
            Console.WriteLine("Hello, " + name);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter Your Name : ");
            string name = Console.ReadLine();
            greet(name);
        }
    }
}