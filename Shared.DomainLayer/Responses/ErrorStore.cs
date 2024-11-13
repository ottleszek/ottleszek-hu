namespace Shared.DomainLayer.Responses
{
    public abstract class ErrorStore
    {
        private string _error;
        public ErrorStore()
        {
            _error=string.Empty;
        }

        public string Error { get => _error; set => _error = value; }
        public bool HasError => !_error.Any();

        public void Clear()
        {
            _error = string.Empty;
        }

        public Response ClearAndAddError(string error)
        {
            _error = error;
            return (Response)this;
        }

        public Response AppendError(string error)
        {
            _error = $"{Error}\n{error}";
            return (Response)this;
        }

        public void InsertToBegining(string error)
        {
            _error = $"{error}\n{Error}";
        }
    }
}
