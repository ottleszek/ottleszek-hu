namespace SharedDomainLayer.Responses
{
    public class ErrorStore
    {
        public ErrorStore()
        {
            Error = string.Empty;
        }

        public string Error { get; set; } = string.Empty;
        public bool HasError => !string.IsNullOrEmpty(Error);

        public void Clear()
        {
            Error = string.Empty;
        }

        public void ClearAndAdd(string error)
        {
            Error = error;
        }

        public void Append(string error)
        {
            Error = $"{Error}\n{error}";
        }

        public void InsertToBegining(string error)
        {
            Error = $"{error}\n{Error}";
        }
    }
}
