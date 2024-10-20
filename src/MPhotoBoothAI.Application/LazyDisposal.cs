﻿namespace MPhotoBoothAI.Application;
public class LazyDisposal<T> : Lazy<T>, IDisposable
{
    public LazyDisposal(Func<T> valueFactory) : base(valueFactory)
    {

    }

    public LazyDisposal() : base()
    {

    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            (Value as IDisposable)?.Dispose();
        }
    }
}
