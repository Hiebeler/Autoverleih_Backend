namespace urlaubsplanungstool_backend.Services.Result
{
    public class FailResult : ResultModel
    {
        public FailResult()
            : base(false)
        {
        }

        public FailResult(string error)
            : base(false, error)
        {
        }
    
        public static DataResultError<T> WithData<T>(T data)
        {
            return new DataResultError<T>(data);
        }
    }
}