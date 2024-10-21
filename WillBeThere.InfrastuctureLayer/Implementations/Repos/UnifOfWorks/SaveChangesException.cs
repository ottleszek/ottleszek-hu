using System.Runtime.Serialization;

namespace WillBeThere.InfrastuctureLayer.Implementations.Repos.UnifOfWorks
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