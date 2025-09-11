namespace EventBoardBackend.CustomExceptions
{
    public class DuplicateException : Exception
    {
        public DuplicateException(string message, Exception exception) : base(message, exception){ }
    }
}
