// See https://aka.ms/new-console-template for more information
namespace assignment1
{
    class Program2
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Number 1 :");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Number 2 :");
            int num2 = Convert.ToInt32(Console.ReadLine());

            int sum = num1 + num2;

            Console.WriteLine("Square Of Sum Of Number is : "+sum*sum);
        }
    }
}