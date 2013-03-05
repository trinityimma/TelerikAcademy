using System;

class InvalidRangeException<T> : Exception
{
    private const string Message = "Not in range!";

    public T Start { get; private set; }
    public T End { get; private set; }

    public InvalidRangeException(T start, T end, Exception innerException = null)
        : base(Message, innerException)
    {
        this.Start = start;
        this.End = end;
    }
}
