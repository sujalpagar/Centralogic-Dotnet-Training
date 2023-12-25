namespace assignment1
{
    class Program3
    {
        static void Main(string[] args)
        {
            int num1 = Convert.ToInt32(Console.ReadLine());
            int num2 = Convert.ToInt32(Console.ReadLine());         
             
            int add = num1 + num2;  
            int subtract = num1 - num2;
            int multiply = num1 * num2;
            int divide = num1 / num2;
            decimal modulos = (decimal) num1 % num2;

            Console.WriteLine("Addition Of two numbers is : " + add);
            Console.WriteLine("Substraction two numbers is : " + subtract);
            Console.WriteLine("Multiplication Of two numbers is : " + multiply);
            Console.WriteLine("Divide Of two numbers is : " + divide);
            Console.WriteLine("Modulo Of two numbers is : " + modulos);
        }
    }
}