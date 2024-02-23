namespace urlaubsplanungstool_backend.Services.Result
{
    public class DataResultError<T> : FailResult
    {
        public DataResultError(T obj)
        {
            this.Data = obj;
        }

        public T Data { get; private set; }
    }
}