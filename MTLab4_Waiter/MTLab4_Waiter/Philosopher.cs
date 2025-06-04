namespace MTLab4_Waiter;

internal class Philosopher
{
    private Table table;
    private Waiter waiter;
    private int philosopherId;
    private int leftFork, rightFork;
    private Thread thread;

    public Philosopher(int id, Table table, Waiter waiter)
    {
        this.philosopherId = id;
        this.table = table;
        this.waiter = waiter;
        rightFork = id;
        leftFork = (id + 1) % 5;
        thread = new Thread(Run);
        thread.Start();
    }

    private void Run()
    {
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine($"Philosopher {philosopherId} is thinking ({i + 1})");

            waiter.RequestPermission();

            table.TakeFork(rightFork);
            table.TakeFork(leftFork);

            Console.WriteLine($"Philosopher {philosopherId} is eating ({i + 1})");

            table.ReleaseFork(rightFork);
            table.ReleaseFork(leftFork);

            waiter.ReleasePermission();
        }
    }
}