namespace DigiShop.Catalog.API.Models
{
    public class ApplicationResponse<T>
    {
        public ApplicationResponse()
        {
            State = false;
            Data = default;
            Message = default;
            ErrorCode = default;
            ErrorMessage = default;
        }

        public bool State { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}