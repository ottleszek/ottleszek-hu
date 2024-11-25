namespace Shared.DomainLayer.Responses
{
    public abstract class ErrorStore
    {
        private string _error;
        public ErrorStore(string error="")
        {
            _error=error;
        }

        public string Error { get => _error; set => _error = value ?? string.Empty; }
        public bool HasError => !_error.Any();

        public void Clear()
        {
            _error = string.Empty;
        }

        public void ClearError()
        {
            _error=string.Empty;
        }

        public Response SetNewError(string error)
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
