﻿namespace WillBeThere.Shared.Responses
{
    public class Response : ErrorStore
    {
        public Response(string error)
        {
            Error = error;
        }
        public Response() : base() { }

        public bool IsSuccess => !HasError;
    }
}
