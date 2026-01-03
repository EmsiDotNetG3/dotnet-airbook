namespace EMSi.Airbook.Exceptions;

public class FunctionalException : Exception
{
    public ExceptionTypeEnum Type { get; }
    public FunctionalException(string message, ExceptionTypeEnum type) : base(message)
    {
        Type = type;
    }
}