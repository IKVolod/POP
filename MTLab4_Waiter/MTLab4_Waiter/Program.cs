namespace MTLab4_Waiter;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Waiter:");
        Table table = new();
        Waiter waiter = new();

        for (int i = 0; i < 5; i++)
        {
            new Philosopher(i, table, waiter);
        }

        Console.ReadLine();
    }
}