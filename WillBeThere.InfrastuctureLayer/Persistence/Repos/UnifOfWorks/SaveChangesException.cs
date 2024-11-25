using System.Runtime.Serialization;

namespace WillBeThere.InfrastuctureLayer.Persistence.UnifOfWorks
{
    [Serializable]
    public class SaveChangesException : Exception
    {
        public SaveChangesException()
        {
        }

        public SaveChangesException(string? message) : base(message)
        {
        }

        public SaveChangesException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}