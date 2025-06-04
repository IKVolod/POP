namespace MTLab4_ChangingOrder;

internal class Table
{
    private readonly SemaphoreSlim[] forks = new SemaphoreSlim[5];

    public Table()
    {
        for (int i = 0; i < forks.Length; i++)
        {
            forks[i] = new SemaphoreSlim(1, 1);
        }
    }

    public void TakeFork(int id)
    {
        forks[id].Wait();
    }

    public void ReleaseFork(int id)
    {
        forks[id].Release();
    }
}
