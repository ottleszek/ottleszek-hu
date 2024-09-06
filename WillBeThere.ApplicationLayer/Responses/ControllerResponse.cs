namespace WillBeThere.ApplicationLayer.Responses
{
    public class ControllerResponse : Response
    {
        public ControllerResponse()
        {
            Error=string.Empty;
        }
        public ControllerResponse(string error) 
        { 
            Error = error;
        }
    }
}
