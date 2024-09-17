namespace SharedDomainLayer.Responses
{
    public class ServerResponse : Response
    {
        public ServerResponse()
        {
            Error=string.Empty;
        }
        public ServerResponse(string error) 
        { 
            Error = error;
        }
    }
}
