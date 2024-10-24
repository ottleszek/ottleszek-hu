namespace Shared.DomainLayer.Responses
{
    public class ErrorStore
    {
        private string _error;
        public ErrorStore()
        {
            _error=string.Empty;
        }

        public string Error { get => _error; set => _error = value; }
        public bool HasError => !string.IsNullOrEmpty(Error);

        public void Clear()
        {
            _error = string.Empty;
        }

        public void ClearAndAdd(string error)
        {
            _error = error;
        }

        public void Append(string error)
        {
            _error = $"{Error}\n{error}";
        }

        public void InsertToBegining(string error)
        {
            _error = $"{error}\n{Error}";
        }
    }
}
