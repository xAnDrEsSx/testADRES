namespace TestADRES.Application.Wrappers
{
    public class Response<T>
    {
        public Response(T data, string? message = null)
        {
            Succeeded = true;
            Message = message;
            Data = data;
        }

        public Response(string? message)
        {
            Succeeded = false;
            Message = message;
            Data = default!;
        }

        public bool Succeeded { get; set; } = false;
        public string? Message { get; set; } = string.Empty;
        public T Data { get; set; } 
    }


}
