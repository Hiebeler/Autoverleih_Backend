namespace urlaubsplanungstool_backend.Services.Result
{
    public class DataResult<T> : SuccessResult
    {
        public DataResult(T obj)
        {
            this.Data = obj;
        }

        public T Data { get; private set; }
    }
}