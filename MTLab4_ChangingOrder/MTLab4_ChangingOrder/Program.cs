namespace MTLab4_ChangingOrder;

internal class Program
{
    static void Main()
    {
        Console.WriteLine("ChangingOrder:");
        Table table = new();

        for (int i = 0; i < 5; i++)
        {
            new Philosopher(i, table);
        }
    }
}