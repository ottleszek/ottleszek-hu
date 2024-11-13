namespace Shared.DomainLayer.Responses
{
    public class ErrorStorage
    {
        private bool _hasError = false;        
        public bool HasError => _hasError;
        public void NewError() { _hasError = true; }
        public void ClearError() { _hasError = false; }
    }
}
