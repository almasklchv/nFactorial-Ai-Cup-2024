namespace ExcelAI.Infrastructure.Files.Exceptions
{
    public class NoStorageRootFoundException : Exception
    {
        public NoStorageRootFoundException() :
            base(message: "There is no specified storage root in application configuration") { }
    }
}
