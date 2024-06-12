namespace WillBeThere.Shared.Responses
{
    public class Response : ErrorStore
    {
        public bool IsSuccess => !HasError;
        public Response() : base() { }
    }
}
