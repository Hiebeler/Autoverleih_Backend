namespace urlaubsplanungstool_backend.Services.Result
{
    public class ResultModel
    {
        public ResultModel(bool success)
        {
            this.Success = success;
        }

        public ResultModel(bool success, string error)
            : this(success)
        {
            this.Error = error;
        }

        public bool Success { get; private set; }
        public string? Message { get; set; }
        public string? Error { get; set; }

        public static implicit operator bool(ResultModel result)
        {
            return result.Success;
        }

        public static DataResult<T> WithData<T>(T data)
        {
            return new DataResult<T>(data);
        }
    }
}