namespace FA.JustBlog.Service
{
    public class ResponseResult<TData>
    {

        public ResponseResult()
        {
            State = true;
        }

        public ResponseResult(string message)
        {
            State = false;
            Message = message;
        }

        /// <summary>
        /// Trang thai
        /// </summary>
        public bool State { get; set; }

        /// <summary>
        /// Thong bao
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Du lieu
        /// </summary>
        public TData Data { get; set; }
    }
}
