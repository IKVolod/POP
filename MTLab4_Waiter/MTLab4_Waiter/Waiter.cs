namespace MTLab4_Waiter;

internal class Waiter
{
    private SemaphoreSlim permission;

    public Waiter()
    {
        permission = new SemaphoreSlim(4, 4);
    }

    public void RequestPermission()
    {
        permission.Wait();
    }

    public void ReleasePermission()
    {
        permission.Release();
    }
}