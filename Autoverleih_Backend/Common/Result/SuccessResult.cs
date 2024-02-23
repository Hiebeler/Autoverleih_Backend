namespace urlaubsplanungstool_backend.Services.Result
{
    public class SuccessResult : ResultModel
    {
        public SuccessResult()
            : base(true)
        {
        }

        public static DataResult<T> WithData<T>(T data)
        {
            return new DataResult<T>(data);
        }
    }
}