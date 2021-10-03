using Newtonsoft.Json;

namespace MTBusinessLogic.Model.Common
{
    public class Response<T>
    {
        public Response(string message, T details = default)
        {
            Message = message;
            Data = details;
        }
        public Response()
        {
        
        }

        public bool Success { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }

        //Converts the object to Json incase of creating a response object as string
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
