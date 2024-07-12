namespace YnabNet.Models.Exceptions;

public class YnabException(string? message, Exception? innerException) : Exception(message, innerException);
public class YnabNotFoundException(string? message, Exception? innerException) : YnabException(message, innerException);
