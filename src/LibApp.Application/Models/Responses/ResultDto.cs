namespace LibApp.Application.Models.Responses
{
    public class ResultDto<T> where T:class
    {
        public ResultDto(bool status)
        {
            this.Success = status;
        }
        public bool Success { get; set; }
        public int ErrorCode { get; set; }
        public string? ErrorMessage { get; set; }
        public T Data { get; set; }
        public ResultDto<T> ReturnSuccess(T obj)
        {
            this.Success = true;
            this.Data = obj;
            return this;
        }
        public ResultDto<T> ReturnFail(string errorMessage)
        {
            this.Success = false;
            this.ErrorMessage = errorMessage;
            return this;
        }
    }
}
