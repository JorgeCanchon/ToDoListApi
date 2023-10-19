﻿namespace Application.Wrappers
{
    public class Response<T>
    {
        public bool IsSucess { get; set; }
        public string Message { get; set; }
        public string Code { get; set; }
        public T Result { get; set; }
        public List<string> Errors { get; set; }

        public Response()
        {
            
        }

        public Response (T result, string message = null)
        {
            IsSucess = true;
            Message = message;
            Result = result;
        }

        public Response(string message = null)
        {
            IsSucess = false;
            Message = message;
        }
    }
}
