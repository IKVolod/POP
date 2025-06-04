namespace MTLab4_ChangingOrder;

internal class Philosopher
{
    private readonly Table table;
    private readonly int leftFork, rightFork;
    private readonly int philosopherId;
    private readonly Thread thread;

    public Philosopher(int id, Table table)
    {
        this.philosopherId = id;
        this.table = table;

        if (id == 0)
        {
            leftFork = id;
            rightFork = (id + 1) % 5;
        }
        else
        {
            rightFork = id;
            leftFork = (id + 1) % 5;
        }

        thread = new Thread(Run);
        thread.Start();
    }

    private void Run()
    {
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine($"Philosopher {philosopherId} is thinking {i + 1} times");

            table.TakeFork(rightFork);
            table.TakeFork(leftFork);

            Console.WriteLine($"Philosopher {philosopherId} is eating {i + 1} times");

            table.ReleaseFork(leftFork);
            table.ReleaseFork(rightFork);
        }
    }
}
