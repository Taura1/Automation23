namespace AutomationHackathon23.Helpers;

public static class Wait
{
    private const int DefaultTimeoutInSeconds = 30;

    private const int DefaultDelayInMilliseconds = 50;

    public static TValue WaitFor<TValue>(Func<TValue?> condition, int delayInMilliseconds, CancellationToken cancellationToken)
        where TValue : class
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            var result = condition();
            if (result != null)
            {
                return result;
            }

            Thread.Sleep(delayInMilliseconds);
        }

        cancellationToken.ThrowIfCancellationRequested();

        throw new Exception("No value");
    }
    
    public static void WaitFor(Func<bool> condition, CancellationToken cancellationToken)
    {
        WaitFor(condition, DefaultDelayInMilliseconds, cancellationToken);
    }
    
    public static void WaitFor(Func<bool> condition)
    {
        WaitFor(condition, DefaultDelayInMilliseconds, GetDefaultCancellationToken());
    }

    private static void WaitFor(Func<bool> condition, int delayInMilliseconds, CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            if (condition())
            {
                return;
            }

            Thread.Sleep(delayInMilliseconds);
        }

        cancellationToken.ThrowIfCancellationRequested();
    }

    private static CancellationToken GetDefaultCancellationToken()
    {
        return new CancellationTokenSource(DefaultTimeoutInSeconds).Token;
    }
    
    
}